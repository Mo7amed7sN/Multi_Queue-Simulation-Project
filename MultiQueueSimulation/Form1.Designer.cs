namespace MultiQueueSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label10 = new System.Windows.Forms.Label();
            this.wait_prop = new System.Windows.Forms.TextBox();
            this.max_length = new System.Windows.Forms.TextBox();
            this.avg_wait = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.server_datagridview = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cus_datagridview = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.run_program = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rd_data = new System.Windows.Forms.Button();
            this.show_outputs = new System.Windows.Forms.Button();
            this.sh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.server_datagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cus_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(768, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 27);
            this.label10.TabIndex = 41;
            this.label10.Text = "Performance Measures";
            // 
            // wait_prop
            // 
            this.wait_prop.Location = new System.Drawing.Point(804, 399);
            this.wait_prop.Name = "wait_prop";
            this.wait_prop.ReadOnly = true;
            this.wait_prop.Size = new System.Drawing.Size(202, 20);
            this.wait_prop.TabIndex = 40;
            // 
            // max_length
            // 
            this.max_length.Location = new System.Drawing.Point(804, 352);
            this.max_length.Name = "max_length";
            this.max_length.ReadOnly = true;
            this.max_length.Size = new System.Drawing.Size(202, 20);
            this.max_length.TabIndex = 39;
            // 
            // avg_wait
            // 
            this.avg_wait.Location = new System.Drawing.Point(804, 306);
            this.avg_wait.Name = "avg_wait";
            this.avg_wait.ReadOnly = true;
            this.avg_wait.Size = new System.Drawing.Size(202, 20);
            this.avg_wait.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(673, 355);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 17);
            this.label9.TabIndex = 37;
            this.label9.Text = "Max Queue Length";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(673, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 17);
            this.label8.TabIndex = 36;
            this.label8.Text = "Wait Propability";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(673, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Average Wait Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(340, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Servers Output";
            // 
            // server_datagridview
            // 
            this.server_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.server_datagridview.Location = new System.Drawing.Point(343, 272);
            this.server_datagridview.Name = "server_datagridview";
            this.server_datagridview.Size = new System.Drawing.Size(323, 142);
            this.server_datagridview.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(340, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Customer Output";
            // 
            // cus_datagridview
            // 
            this.cus_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cus_datagridview.Location = new System.Drawing.Point(343, 84);
            this.cus_datagridview.Name = "cus_datagridview";
            this.cus_datagridview.Size = new System.Drawing.Size(753, 150);
            this.cus_datagridview.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Menu;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(645, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 30);
            this.label4.TabIndex = 29;
            this.label4.Text = "Output Data";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Location = new System.Drawing.Point(370, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(726, 32);
            this.panel4.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(10, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Click to Run the Simulation";
            // 
            // run_program
            // 
            this.run_program.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.run_program.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.run_program.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.run_program.ForeColor = System.Drawing.Color.Navy;
            this.run_program.Location = new System.Drawing.Point(59, 340);
            this.run_program.Name = "run_program";
            this.run_program.Size = new System.Drawing.Size(213, 48);
            this.run_program.TabIndex = 27;
            this.run_program.Text = "Run";
            this.run_program.UseVisualStyleBackColor = false;
            this.run_program.Click += new System.EventHandler(this.run_program_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(16, 368);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 46);
            this.panel3.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(13, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Click to Read Data from file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 30);
            this.label1.TabIndex = 22;
            this.label1.Text = "Input Data";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 32);
            this.panel2.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(294, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 402);
            this.panel1.TabIndex = 21;
            // 
            // rd_data
            // 
            this.rd_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rd_data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rd_data.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_data.ForeColor = System.Drawing.Color.Navy;
            this.rd_data.Location = new System.Drawing.Point(59, 145);
            this.rd_data.Name = "rd_data";
            this.rd_data.Size = new System.Drawing.Size(213, 48);
            this.rd_data.TabIndex = 42;
            this.rd_data.Text = "Read Data";
            this.rd_data.UseVisualStyleBackColor = false;
            this.rd_data.Click += new System.EventHandler(this.rd_data_Click);
            // 
            // show_outputs
            // 
            this.show_outputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.show_outputs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_outputs.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_outputs.ForeColor = System.Drawing.Color.Navy;
            this.show_outputs.Location = new System.Drawing.Point(1024, 266);
            this.show_outputs.Name = "show_outputs";
            this.show_outputs.Size = new System.Drawing.Size(70, 153);
            this.show_outputs.TabIndex = 43;
            this.show_outputs.Text = "Show Outputs";
            this.show_outputs.UseVisualStyleBackColor = false;
            this.show_outputs.Click += new System.EventHandler(this.show_outputs_Click);
            // 
            // sh
            // 
            this.sh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sh.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sh.ForeColor = System.Drawing.Color.Navy;
            this.sh.Location = new System.Drawing.Point(876, 53);
            this.sh.Name = "sh";
            this.sh.Size = new System.Drawing.Size(213, 27);
            this.sh.TabIndex = 44;
            this.sh.Text = "Show Graphs";
            this.sh.UseVisualStyleBackColor = false;
            this.sh.Click += new System.EventHandler(this.sh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 426);
            this.Controls.Add(this.sh);
            this.Controls.Add(this.show_outputs);
            this.Controls.Add(this.rd_data);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.wait_prop);
            this.Controls.Add(this.max_length);
            this.Controls.Add(this.avg_wait);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.server_datagridview);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cus_datagridview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.run_program);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "MultiQueue Problem";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.server_datagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cus_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox wait_prop;
        private System.Windows.Forms.TextBox max_length;
        private System.Windows.Forms.TextBox avg_wait;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView server_datagridview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView cus_datagridview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button run_program;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button rd_data;
        private System.Windows.Forms.Button show_outputs;
        private System.Windows.Forms.Button sh;
    }
}

