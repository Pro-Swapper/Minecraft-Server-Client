
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.server = new System.ComponentModel.BackgroundWorker();
            this.rconbox = new System.Windows.Forms.TextBox();
            this.rconsend = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.startstopbutton = new System.Windows.Forms.Button();
            this.LogChannelText = new System.Windows.Forms.Label();
            this.chatlbl = new System.Windows.Forms.Label();
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
            this.server.WorkerSupportsCancellation = true;
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
            this.button5.Size = new System.Drawing.Size(176, 34);
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
            // startstopbutton
            // 
            this.startstopbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startstopbutton.ForeColor = System.Drawing.Color.White;
            this.startstopbutton.Location = new System.Drawing.Point(202, 389);
            this.startstopbutton.Name = "startstopbutton";
            this.startstopbutton.Size = new System.Drawing.Size(176, 34);
            this.startstopbutton.TabIndex = 14;
            this.startstopbutton.Text = "Start Server";
            this.startstopbutton.UseVisualStyleBackColor = true;
            this.startstopbutton.Click += new System.EventHandler(this.startstopbutton_Click);
            // 
            // LogChannelText
            // 
            this.LogChannelText.AutoSize = true;
            this.LogChannelText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogChannelText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LogChannelText.ForeColor = System.Drawing.Color.White;
            this.LogChannelText.Location = new System.Drawing.Point(18, 444);
            this.LogChannelText.Name = "LogChannelText";
            this.LogChannelText.Size = new System.Drawing.Size(115, 15);
            this.LogChannelText.TabIndex = 15;
            this.LogChannelText.Text = "Log/RCON Channel:";
            // 
            // chatlbl
            // 
            this.chatlbl.AutoSize = true;
            this.chatlbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chatlbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chatlbl.ForeColor = System.Drawing.Color.White;
            this.chatlbl.Location = new System.Drawing.Point(19, 471);
            this.chatlbl.Name = "chatlbl";
            this.chatlbl.Size = new System.Drawing.Size(82, 15);
            this.chatlbl.TabIndex = 16;
            this.chatlbl.Text = "Chat Channel:";
            // 
            // ServerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(45)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(600, 544);
            this.Controls.Add(this.chatlbl);
            this.Controls.Add(this.LogChannelText);
            this.Controls.Add(this.startstopbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.rconsend);
            this.Controls.Add(this.rconbox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServerUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Run_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker server;
        private System.Windows.Forms.TextBox rconbox;
        private System.Windows.Forms.Button rconsend;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startstopbutton;
        private System.Windows.Forms.Label LogChannelText;
        private System.Windows.Forms.Label chatlbl;
    }
}

