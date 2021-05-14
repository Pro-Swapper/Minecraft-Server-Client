
namespace MinecraftServerClient
{
    partial class DiscordUI
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
            this.chatchannellabel = new System.Windows.Forms.Label();
            this.chatchannel = new System.Windows.Forms.TextBox();
            this.loglabel = new System.Windows.Forms.Label();
            this.logchannel = new System.Windows.Forms.TextBox();
            this.BotTokenlabel = new System.Windows.Forms.Label();
            this.discordcheckbox = new System.Windows.Forms.CheckBox();
            this.bottoken = new System.Windows.Forms.TextBox();
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
            // chatchannellabel
            // 
            this.chatchannellabel.AutoSize = true;
            this.chatchannellabel.ForeColor = System.Drawing.Color.White;
            this.chatchannellabel.Location = new System.Drawing.Point(89, 190);
            this.chatchannellabel.Name = "chatchannellabel";
            this.chatchannellabel.Size = new System.Drawing.Size(94, 13);
            this.chatchannellabel.TabIndex = 25;
            this.chatchannellabel.Text = "Chat Channel ID:";
            // 
            // chatchannel
            // 
            this.chatchannel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatchannel.Font = new System.Drawing.Font("Consolas", 9F);
            this.chatchannel.Location = new System.Drawing.Point(184, 190);
            this.chatchannel.Name = "chatchannel";
            this.chatchannel.Size = new System.Drawing.Size(239, 15);
            this.chatchannel.TabIndex = 24;
            this.chatchannel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.logchannel_KeyPress);
            // 
            // loglabel
            // 
            this.loglabel.AutoSize = true;
            this.loglabel.ForeColor = System.Drawing.Color.White;
            this.loglabel.Location = new System.Drawing.Point(89, 169);
            this.loglabel.Name = "loglabel";
            this.loglabel.Size = new System.Drawing.Size(89, 13);
            this.loglabel.TabIndex = 23;
            this.loglabel.Text = "Log Channel ID:";
            // 
            // logchannel
            // 
            this.logchannel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logchannel.Font = new System.Drawing.Font("Consolas", 9F);
            this.logchannel.Location = new System.Drawing.Point(184, 169);
            this.logchannel.Name = "logchannel";
            this.logchannel.Size = new System.Drawing.Size(239, 15);
            this.logchannel.TabIndex = 22;
            this.logchannel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.logchannel_KeyPress);
            // 
            // BotTokenlabel
            // 
            this.BotTokenlabel.AutoSize = true;
            this.BotTokenlabel.ForeColor = System.Drawing.Color.White;
            this.BotTokenlabel.Location = new System.Drawing.Point(90, 106);
            this.BotTokenlabel.Name = "BotTokenlabel";
            this.BotTokenlabel.Size = new System.Drawing.Size(61, 13);
            this.BotTokenlabel.TabIndex = 21;
            this.BotTokenlabel.Text = "Bot Token:";
            // 
            // discordcheckbox
            // 
            this.discordcheckbox.AutoSize = true;
            this.discordcheckbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.discordcheckbox.ForeColor = System.Drawing.Color.White;
            this.discordcheckbox.Location = new System.Drawing.Point(93, 58);
            this.discordcheckbox.Name = "discordcheckbox";
            this.discordcheckbox.Size = new System.Drawing.Size(231, 23);
            this.discordcheckbox.TabIndex = 19;
            this.discordcheckbox.Text = "Integrate Server with Discord Bot";
            this.discordcheckbox.UseVisualStyleBackColor = true;
            // 
            // bottoken
            // 
            this.bottoken.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bottoken.Font = new System.Drawing.Font("Consolas", 9F);
            this.bottoken.Location = new System.Drawing.Point(184, 103);
            this.bottoken.Multiline = true;
            this.bottoken.Name = "bottoken";
            this.bottoken.Size = new System.Drawing.Size(239, 60);
            this.bottoken.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(89, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Leave fields blank if you don\'t want to use the feature";
            // 
            // DiscordUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(45)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(600, 544);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chatchannellabel);
            this.Controls.Add(this.chatchannel);
            this.Controls.Add(this.loglabel);
            this.Controls.Add(this.logchannel);
            this.Controls.Add(this.BotTokenlabel);
            this.Controls.Add(this.discordcheckbox);
            this.Controls.Add(this.bottoken);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiscordUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Control Panel";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label chatchannellabel;
        private System.Windows.Forms.TextBox chatchannel;
        private System.Windows.Forms.Label loglabel;
        private System.Windows.Forms.TextBox logchannel;
        private System.Windows.Forms.Label BotTokenlabel;
        private System.Windows.Forms.CheckBox discordcheckbox;
        private System.Windows.Forms.TextBox bottoken;
        private System.Windows.Forms.Label label1;
    }
}

