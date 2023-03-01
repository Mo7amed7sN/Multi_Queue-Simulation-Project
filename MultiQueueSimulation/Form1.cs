using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;
using System.IO;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        SimulationSystem sys; int total_run = 0, tmpelete = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            sys = new SimulationSystem();
        }

        private void rd_data_Click(object sender, EventArgs e)
        {
            string w = "";
            FileStream fs = new FileStream("TestCase3.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while(( w = sr.ReadLine() )!= null)
            {
                if (w == "") continue;

                if( w == "NumberOfServers")
                {
                    sys.NumberOfServers = int.Parse(sr.ReadLine().ToString());
                }
                else if ( w == "StoppingNumber")
                {
                    sys.StoppingNumber = int.Parse(sr.ReadLine().ToString());
                }
                else if( w == "StoppingCriteria")
                {
                    if (sr.ReadLine().ToString() == "1")
                        sys.StoppingCriteria = Enums.StoppingCriteria.NumberOfCustomers;
                    else
                        sys.StoppingCriteria = Enums.StoppingCriteria.SimulationEndTime;
                }
                else if( w == "SelectionMethod")
                {
                    string tmp = sr.ReadLine().ToString();
                    if (tmp == "1")
                        sys.SelectionMethod = Enums.SelectionMethod.HighestPriority;
                    else if (tmp == "2")
                        sys.SelectionMethod = Enums.SelectionMethod.Random;
                    else
                        sys.SelectionMethod = Enums.SelectionMethod.LeastUtilization;
                }
                else
                {
                    string tmp = sr.ReadLine();                 
                    decimal acc = 0; int prev_min = 0;
                    string[] arr = new string[2];
                    while(tmp != ""){
                        TimeDistribution td = new TimeDistribution();
                        arr = tmp.Split(',');
                        td.Time = int.Parse(arr[0]);
                        td.Probability = decimal.Parse(arr[1]);
                        acc = acc + td.Probability;
                        td.CummProbability = acc;
                        td.MinRange = prev_min + 1;
                        td.MaxRange = (int)(100 * td.CummProbability);
                        prev_min = td.MaxRange;
                        tmp = sr.ReadLine();
                        sys.InterarrivalDistribution.Add(td);
                    }

                    int server_id = 1;
                    while ((w = sr.ReadLine()) != null)
                    {
                        List<TimeDistribution> ltd = new List<TimeDistribution>();
                        tmp = sr.ReadLine();
                        acc = 0; prev_min = 0;
                        while (tmp != ""&& tmp != null)
                        {
                            TimeDistribution td = new TimeDistribution();
                            arr = tmp.Split(',');
                            td.Time = int.Parse(arr[0]);
                            td.Probability = decimal.Parse(arr[1]);
                            acc = acc + td.Probability;
                            td.CummProbability = acc;
                            td.MinRange = prev_min + 1;
                            td.MaxRange = (int)(100 * td.CummProbability);
                            prev_min = td.MaxRange;
                            tmp = sr.ReadLine();
                            ltd.Add(td);
                        }

                        Server ser = new Server();
                        ser.ID = server_id;
                        server_id++;
                        ser.TimeDistribution = ltd;                     
                        sys.Servers.Add(ser);
                    }
                    break;
                }
            }
            sr.Close();
            fs.Close();
            MessageBox.Show("Done");
        }


        Random rd = new Random();
        int rInt, prev_arrive, rInd, wait_time, wait_num, max_len;

        int[] free_servers, servers_utilization, server_customers;
        Dictionary<int, List<int>> plotting;

        private void run_program_Click(object sender, EventArgs e)
        {
            plotting = new Dictionary<int, List<int>>();
            List<int> waiting = new List<int>();
            free_servers = new int[sys.NumberOfServers];
            servers_utilization = new int[sys.NumberOfServers];
            server_customers = new int[sys.NumberOfServers];
            wait_time = 0; wait_num = 0; max_len = 0;
            for (int i = 0; i < sys.NumberOfServers; i++) { free_servers[i] = 0; servers_utilization[i] = 0; server_customers[i] = 0; }

            for (int i = 1; true; i++) 
            {
                if(sys.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
                {
                    if (i > sys.StoppingNumber) break;
                }
                else
                {
                    if (total_run >= sys.StoppingNumber)
                    {
                        sys.StoppingNumber = i - 1;
                        break;
                    }
                }
                List<int> avail_servers = new List<int>();
                int mini = 10000000, ser = 0, wait = 0;

                SimulationCase sc = new SimulationCase();
                sc.CustomerNumber = i;
                if (i == 1)
                {
                    sc.RandomInterArrival = 100;
                    sc.InterArrival = 0;
                    sc.ArrivalTime = 0;

                    prev_arrive = 0;
                }
                else
                {
                    rInt = rd.Next(1, 101);
                    sc.RandomInterArrival = rInt;
                    for (int j = 0; j < sys.InterarrivalDistribution.Count; j++)
                    {
                        if (sys.InterarrivalDistribution[j].MinRange <= rInt && sys.InterarrivalDistribution[j].MaxRange >= rInt)
                        {
                            sc.InterArrival = sys.InterarrivalDistribution[j].Time;
                            break;
                        }
                    }
                    sc.ArrivalTime = prev_arrive + sc.InterArrival;
                    prev_arrive = sc.ArrivalTime;
                }

                rInt = rd.Next(1, 101);
                sc.RandomService = rInt;
                if (sys.SelectionMethod == Enums.SelectionMethod.HighestPriority)
                {
                    bool check = false;
                    for (int j = 0; j < sys.NumberOfServers; j++)
                    {
                        if (free_servers[j] <= sc.ArrivalTime)
                        {
                            check = true;
                            sc.AssignedServer = sys.Servers[j];
                            for (int k = 0; k < sc.AssignedServer.TimeDistribution.Count; k++)
                            {
                                if (sc.AssignedServer.TimeDistribution[k].MinRange <= rInt && sc.AssignedServer.TimeDistribution[k].MaxRange >= rInt)
                                {
                                    sc.ServiceTime = sc.AssignedServer.TimeDistribution[k].Time;
                                    break;
                                }
                            }
                            break;
                        }
                    }

                    if (!check)
                    {
                        for (int j = 0; j < sys.NumberOfServers; j++)
                        {
                            if (free_servers[j] - sc.ArrivalTime < mini)
                            {
                                ser = j;
                                mini = free_servers[j] - sc.ArrivalTime;
                                wait = mini;
                            }
                        }

                        tmpelete = 0;
                        for (int y = 0; y < waiting.Count; y++)
                        {
                            if (waiting[y] > sc.ArrivalTime) tmpelete++;
                        }
                        waiting.Add(sc.ArrivalTime + wait);
                        max_len = Math.Max(max_len, tmpelete + 1);

                        sc.AssignedServer = sys.Servers[ser];
                        for (int k = 0; k < sc.AssignedServer.TimeDistribution.Count; k++)
                        {
                            if (sc.AssignedServer.TimeDistribution[k].MinRange <= rInt && sc.AssignedServer.TimeDistribution[k].MaxRange >= rInt)
                            {
                                sc.ServiceTime = sc.AssignedServer.TimeDistribution[k].Time;
                                break;
                            }
                        }
                    }
                }
                else if (sys.SelectionMethod == Enums.SelectionMethod.Random)
                {
                    for (int j = 0; j < sys.NumberOfServers; j++)
                    {
                        if (free_servers[j] <= sc.ArrivalTime)
                        {
                            avail_servers.Add(j);
                        }
                    }

                    if (avail_servers.Count > 0)
                    {
                        rInd = rd.Next(0, avail_servers.Count);
                        sc.AssignedServer = sys.Servers[avail_servers[rInd]];
                        for (int k = 0; k < sc.AssignedServer.TimeDistribution.Count; k++)
                        {
                            if (sc.AssignedServer.TimeDistribution[k].MinRange <= rInt && sc.AssignedServer.TimeDistribution[k].MaxRange >= rInt)
                            {
                                sc.ServiceTime = sc.AssignedServer.TimeDistribution[k].Time;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < sys.NumberOfServers; j++)
                        {
                            if (free_servers[j] - sc.ArrivalTime < mini)
                            {
                                mini = free_servers[j] - sc.ArrivalTime;
                                wait = mini;
                            }
                        }
                        for (int j = 0; j < sys.NumberOfServers; j++)
                        {
                            if (free_servers[j] - sc.ArrivalTime == mini)
                            {
                                avail_servers.Add(j);
                            }
                        }

                        tmpelete = 0;
                        for (int y = 0; y < waiting.Count; y++)
                        {
                            if (waiting[y] > sc.ArrivalTime) tmpelete++;
                        }
                        waiting.Add(sc.ArrivalTime + wait);
                        max_len = Math.Max(max_len, tmpelete + 1);

                        rInd = rd.Next(0, avail_servers.Count);
                        sc.AssignedServer = sys.Servers[avail_servers[rInd]];
                        for (int k = 0; k < sc.AssignedServer.TimeDistribution.Count; k++)
                        {
                            if (sc.AssignedServer.TimeDistribution[k].MinRange <= rInt && sc.AssignedServer.TimeDistribution[k].MaxRange >= rInt)
                            {
                                sc.ServiceTime = sc.AssignedServer.TimeDistribution[k].Time;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < sys.NumberOfServers; j++)
                    {
                        if (free_servers[j] <= sc.ArrivalTime)
                        {
                            avail_servers.Add(j);
                        }
                    }

                    if (avail_servers.Count > 0)
                    {
                        for (int j = 0; j < avail_servers.Count; j++)
                        {
                            if (servers_utilization[avail_servers[j]] < mini)
                            {
                                ser = avail_servers[j];
                                mini = servers_utilization[avail_servers[j]];
                            }
                        }

                        sc.AssignedServer = sys.Servers[ser];
                        for (int k = 0; k < sc.AssignedServer.TimeDistribution.Count; k++)
                        {
                            if (sc.AssignedServer.TimeDistribution[k].MinRange <= rInt && sc.AssignedServer.TimeDistribution[k].MaxRange >= rInt)
                            {
                                sc.ServiceTime = sc.AssignedServer.TimeDistribution[k].Time;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < sys.NumberOfServers; j++)
                        {
                            if (free_servers[j] - sc.ArrivalTime < mini)
                            {
                                mini = free_servers[j] - sc.ArrivalTime;
                                wait = mini;
                            }
                        }
                        for (int j = 0; j < sys.NumberOfServers; j++)
                        {
                            if (free_servers[j] - sc.ArrivalTime == mini)
                            {
                                avail_servers.Add(j);
                            }
                        }

                        tmpelete = 0;
                        for (int y = 0; y < waiting.Count; y++)
                        {
                            if (waiting[y] > sc.ArrivalTime) tmpelete++;
                        }
                        waiting.Add(sc.ArrivalTime + wait);
                        max_len = Math.Max(max_len, tmpelete + 1);

                        mini = 10000000;
                        for (int j = 0; j < avail_servers.Count; j++)
                        {
                            if (servers_utilization[avail_servers[j]] < mini)
                            {
                                ser = avail_servers[j];
                                mini = servers_utilization[avail_servers[j]];
                            }
                        }

                        sc.AssignedServer = sys.Servers[ser];
                        for (int k = 0; k < sc.AssignedServer.TimeDistribution.Count; k++)
                        {
                            if (sc.AssignedServer.TimeDistribution[k].MinRange <= rInt && sc.AssignedServer.TimeDistribution[k].MaxRange >= rInt)
                            {
                                sc.ServiceTime = sc.AssignedServer.TimeDistribution[k].Time;
                                break;
                            }
                        }
                    }
                }
                sc.StartTime = sc.ArrivalTime + wait;
                sc.EndTime = sc.ArrivalTime + wait + sc.ServiceTime;
                sc.TimeInQueue = wait;

                free_servers[sc.AssignedServer.ID - 1] = sc.EndTime;
                total_run = Math.Max(total_run, sc.EndTime);
                servers_utilization[sc.AssignedServer.ID - 1] += sc.ServiceTime;
                server_customers[sc.AssignedServer.ID - 1]++;
                wait_time += wait;
                if (wait > 0)
                    wait_num++;

                int ind = (sc.AssignedServer.ID - 1);
                for (int y = sc.ArrivalTime + wait; y <= sc.EndTime; y++)
                {
                    try
                    {
                        plotting[ind].Add(y);
                    }
                    catch (Exception w)
                    {
                        plotting[ind] = new List<int>();
                        plotting[ind].Add(y);
                    }
                }
                sys.SimulationTable.Add(sc);
            }
            MessageBox.Show("Done");
        }

        private void show_outputs_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Customer #"); dt.Columns.Add("RandomInterArrival"); dt.Columns.Add("InterArrival"); dt.Columns.Add("ArrivalTime");
            dt.Columns.Add("RandomService"); dt.Columns.Add("ServiceTime"); dt.Columns.Add("AssignedServer"); dt.Columns.Add("StartTime");
            dt.Columns.Add("EndTime"); dt.Columns.Add("TimeInQueue");

            for(int i = 0; i < sys.SimulationTable.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Customer #"] = sys.SimulationTable[i].CustomerNumber.ToString();
                dr["RandomInterArrival"] = sys.SimulationTable[i].RandomInterArrival.ToString();
                dr["InterArrival"] = sys.SimulationTable[i].InterArrival.ToString();
                dr["ArrivalTime"] = sys.SimulationTable[i].ArrivalTime.ToString();
                dr["RandomService"] = sys.SimulationTable[i].RandomService.ToString();
                dr["ServiceTime"] = sys.SimulationTable[i].ServiceTime.ToString();
                dr["AssignedServer"] = sys.SimulationTable[i].AssignedServer.ID.ToString();
                dr["StartTime"] = sys.SimulationTable[i].StartTime.ToString();
                dr["EndTime"] = sys.SimulationTable[i].EndTime.ToString();
                dr["TimeInQueue"] = sys.SimulationTable[i].TimeInQueue.ToString();
                dt.Rows.Add(dr);
            }
            cus_datagridview.DataSource = dt;
            ///////////////////////////////////////////////////////////////////////////////

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ServerId");
            dt1.Columns.Add("Idle Probability");
            dt1.Columns.Add("AverageServiceTime");
            dt1.Columns.Add("Utilization");
            for (int i = 0; i < sys.Servers.Count; i++)
            {
                decimal x = total_run - servers_utilization[i]; x =(decimal) x / total_run;
                sys.Servers[i].IdleProbability = (decimal)x;

                if (servers_utilization[i] == 0 || server_customers[i] == 0)
                    x = 0;
                else
                {
                    x = (decimal)servers_utilization[i] / server_customers[i];
                    sys.Servers[i].AverageServiceTime = (decimal)x;
                }

                x = (decimal)servers_utilization[i] / total_run;
                sys.Servers[i].Utilization = (decimal)x;

                DataRow dr1 = dt1.NewRow();
                dr1["ServerId"] = (i + 1).ToString();
                dr1["Idle Probability"] = sys.Servers[i].IdleProbability.ToString();
                dr1["AverageServiceTime"] = sys.Servers[i].AverageServiceTime.ToString();
                dr1["Utilization"] = sys.Servers[i].Utilization.ToString();
                
                dt1.Rows.Add(dr1);
            }
            server_datagridview.DataSource = dt1;

            sys.PerformanceMeasures.AverageWaitingTime = (decimal)wait_time / sys.StoppingNumber;
            sys.PerformanceMeasures.WaitingProbability = (decimal)wait_num / sys.StoppingNumber;
            sys.PerformanceMeasures.MaxQueueLength = max_len;

            avg_wait.Text = sys.PerformanceMeasures.AverageWaitingTime.ToString();
            max_length.Text = sys.PerformanceMeasures.MaxQueueLength.ToString();
            wait_prop.Text = sys.PerformanceMeasures.WaitingProbability.ToString();

            string test = TestingManager.Test(sys, Constants.FileNames.TestCase3);
            MessageBox.Show(test);
        }

        private void sh_Click(object sender, EventArgs e)
        {
            Graphs g = new Graphs(plotting, sys.NumberOfServers);
            g.Show();
            this.Hide();
        }
    }
}
