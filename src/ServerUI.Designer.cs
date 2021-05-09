
namespace MinecraftServerClient
{
    partial class ServerUI
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.server = new System.ComponentModel.BackgroundWorker();
            this.rconbox = new System.Windows.Forms.TextBox();
            this.rconsend = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(546, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(22, 423);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 34);
            this.button2.TabIndex = 7;
            this.button2.Text = "Start Server";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(386, 423);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 34);
            this.button3.TabIndex = 8;
            this.button3.Text = "Stop Server";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(22, 48);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(528, 252);
            this.textBox1.TabIndex = 9;
            // 
            // server
            // 
            this.server.DoWork += new System.ComponentModel.DoWorkEventHandler(this.server_DoWork);
            // 
            // rconbox
            // 
            this.rconbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rconbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rconbox.Location = new System.Drawing.Point(22, 315);
            this.rconbox.Name = "rconbox";
            this.rconbox.Size = new System.Drawing.Size(528, 16);
            this.rconbox.TabIndex = 10;
            this.rconbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rcon_KeyDown);
            // 
            // rconsend
            // 
            this.rconsend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rconsend.ForeColor = System.Drawing.Color.White;
            this.rconsend.Location = new System.Drawing.Point(22, 337);
            this.rconsend.Name = "rconsend";
            this.rconsend.Size = new System.Drawing.Size(528, 34);
            this.rconsend.TabIndex = 11;
            this.rconsend.Text = "Send Command";
            this.rconsend.UseVisualStyleBackColor = true;
            this.rconsend.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(202, 471);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(164, 34);
            this.button5.TabIndex = 12;
            this.button5.Text = "Ping Server";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Server IP:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ServerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(45)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(600, 544);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.rconsend);
            this.Controls.Add(this.rconbox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServerUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Run_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerUI_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker server;
        private System.Windows.Forms.TextBox rconbox;
        private System.Windows.Forms.Button rconsend;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
    }
}

