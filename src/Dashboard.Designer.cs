
namespace MinecraftServerClient
{
    partial class Dashboard
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
            this.serverproperties = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.launchargs = new System.Windows.Forms.TextBox();
            this.discordcheckbox = new System.Windows.Forms.CheckBox();
            this.bottoken = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BotTokenlabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverproperties
            // 
            this.serverproperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverproperties.FormattingEnabled = true;
            this.serverproperties.Location = new System.Drawing.Point(54, 62);
            this.serverproperties.Name = "serverproperties";
            this.serverproperties.Size = new System.Drawing.Size(214, 221);
            this.serverproperties.TabIndex = 0;
            this.serverproperties.SelectedIndexChanged += new System.EventHandler(this.serverproperties_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(51, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Settings";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(758, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(54, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(284, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "Server Control Panel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(391, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Launch Args:";
            // 
            // launchargs
            // 
            this.launchargs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.launchargs.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchargs.Location = new System.Drawing.Point(394, 62);
            this.launchargs.Multiline = true;
            this.launchargs.Name = "launchargs";
            this.launchargs.Size = new System.Drawing.Size(234, 127);
            this.launchargs.TabIndex = 10;
            this.launchargs.TextChanged += new System.EventHandler(this.launchargs_TextChanged);
            // 
            // discordcheckbox
            // 
            this.discordcheckbox.AutoSize = true;
            this.discordcheckbox.ForeColor = System.Drawing.Color.White;
            this.discordcheckbox.Location = new System.Drawing.Point(6, 21);
            this.discordcheckbox.Name = "discordcheckbox";
            this.discordcheckbox.Size = new System.Drawing.Size(195, 17);
            this.discordcheckbox.TabIndex = 11;
            this.discordcheckbox.Text = "Integrate Server with Discord Bot";
            this.discordcheckbox.UseVisualStyleBackColor = true;
            this.discordcheckbox.CheckedChanged += new System.EventHandler(this.discordcheckbox_CheckedChanged);
            // 
            // bottoken
            // 
            this.bottoken.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bottoken.Font = new System.Drawing.Font("Consolas", 9F);
            this.bottoken.Location = new System.Drawing.Point(73, 44);
            this.bottoken.Multiline = true;
            this.bottoken.Name = "bottoken";
            this.bottoken.Size = new System.Drawing.Size(239, 60);
            this.bottoken.TabIndex = 12;
            this.bottoken.Visible = false;
            this.bottoken.TextChanged += new System.EventHandler(this.bottoken_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BotTokenlabel);
            this.groupBox1.Controls.Add(this.discordcheckbox);
            this.groupBox1.Controls.Add(this.bottoken);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(401, 282);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 168);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Discord Bot Integration";
            // 
            // BotTokenlabel
            // 
            this.BotTokenlabel.AutoSize = true;
            this.BotTokenlabel.ForeColor = System.Drawing.Color.White;
            this.BotTokenlabel.Location = new System.Drawing.Point(4, 47);
            this.BotTokenlabel.Name = "BotTokenlabel";
            this.BotTokenlabel.Size = new System.Drawing.Size(61, 13);
            this.BotTokenlabel.TabIndex = 14;
            this.BotTokenlabel.Text = "Bot Token:";
            this.BotTokenlabel.Visible = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(45)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.launchargs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverproperties);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Server Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox serverproperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox launchargs;
        private System.Windows.Forms.CheckBox discordcheckbox;
        private System.Windows.Forms.TextBox bottoken;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label BotTokenlabel;
    }
}

