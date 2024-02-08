namespace Hospital_Managment_System
{
    partial class Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.combobox_fullname = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btn_sent_msg = new Guna.UI2.WinForms.Guna2Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.btn_show_msg = new Guna.UI2.WinForms.Guna2Button();
            this.combobox_incoming_msg = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbl_sendername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // combobox_fullname
            // 
            this.combobox_fullname.AutoRoundedCorners = true;
            this.combobox_fullname.BackColor = System.Drawing.Color.Transparent;
            this.combobox_fullname.BorderRadius = 17;
            this.combobox_fullname.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_fullname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_fullname.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_fullname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_fullname.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.combobox_fullname.ForeColor = System.Drawing.Color.Black;
            this.combobox_fullname.ItemHeight = 30;
            this.combobox_fullname.Location = new System.Drawing.Point(12, 86);
            this.combobox_fullname.Name = "combobox_fullname";
            this.combobox_fullname.Size = new System.Drawing.Size(180, 36);
            this.combobox_fullname.TabIndex = 0;
            this.combobox_fullname.SelectedIndexChanged += new System.EventHandler(this.combobox_fullname_SelectedIndexChanged);
            // 
            // btn_sent_msg
            // 
            this.btn_sent_msg.AutoRoundedCorners = true;
            this.btn_sent_msg.BorderRadius = 21;
            this.btn_sent_msg.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_sent_msg.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_sent_msg.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_sent_msg.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_sent_msg.FillColor = System.Drawing.Color.White;
            this.btn_sent_msg.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_sent_msg.ForeColor = System.Drawing.Color.Black;
            this.btn_sent_msg.Location = new System.Drawing.Point(12, 150);
            this.btn_sent_msg.Name = "btn_sent_msg";
            this.btn_sent_msg.Size = new System.Drawing.Size(180, 45);
            this.btn_sent_msg.TabIndex = 1;
            this.btn_sent_msg.Text = "Sent Message";
            this.btn_sent_msg.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 248);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(500, 422);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // guna2Button2
            // 
            this.guna2Button2.AutoRoundedCorners = true;
            this.guna2Button2.BorderRadius = 21;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.Location = new System.Drawing.Point(12, 12);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(180, 45);
            this.guna2Button2.TabIndex = 3;
            this.guna2Button2.Text = "Sent Message";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // btn_show_msg
            // 
            this.btn_show_msg.AutoRoundedCorners = true;
            this.btn_show_msg.BorderRadius = 21;
            this.btn_show_msg.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_show_msg.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_show_msg.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_show_msg.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_show_msg.FillColor = System.Drawing.Color.White;
            this.btn_show_msg.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_show_msg.ForeColor = System.Drawing.Color.Black;
            this.btn_show_msg.Location = new System.Drawing.Point(332, 12);
            this.btn_show_msg.Name = "btn_show_msg";
            this.btn_show_msg.Size = new System.Drawing.Size(180, 45);
            this.btn_show_msg.TabIndex = 4;
            this.btn_show_msg.Text = "Show Messages";
            this.btn_show_msg.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // combobox_incoming_msg
            // 
            this.combobox_incoming_msg.AutoRoundedCorners = true;
            this.combobox_incoming_msg.BackColor = System.Drawing.Color.Transparent;
            this.combobox_incoming_msg.BorderRadius = 17;
            this.combobox_incoming_msg.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_incoming_msg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_incoming_msg.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_incoming_msg.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.combobox_incoming_msg.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.combobox_incoming_msg.ForeColor = System.Drawing.Color.Black;
            this.combobox_incoming_msg.ItemHeight = 30;
            this.combobox_incoming_msg.Location = new System.Drawing.Point(332, 86);
            this.combobox_incoming_msg.Name = "combobox_incoming_msg";
            this.combobox_incoming_msg.Size = new System.Drawing.Size(180, 36);
            this.combobox_incoming_msg.TabIndex = 5;
            this.combobox_incoming_msg.SelectedIndexChanged += new System.EventHandler(this.combobox_incoming_msg_SelectedIndexChanged);
            // 
            // lbl_sendername
            // 
            this.lbl_sendername.BackColor = System.Drawing.Color.Transparent;
            this.lbl_sendername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_sendername.ForeColor = System.Drawing.Color.White;
            this.lbl_sendername.Location = new System.Drawing.Point(12, 225);
            this.lbl_sendername.Name = "lbl_sendername";
            this.lbl_sendername.Size = new System.Drawing.Size(65, 18);
            this.lbl_sendername.TabIndex = 6;
            this.lbl_sendername.Text = "Sender = ";
            // 
            // guna2Button1
            // 
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BorderRadius = 21;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(385, 150);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(77, 45);
            this.guna2Button1.TabIndex = 7;
            this.guna2Button1.Text = "Delete";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 225);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(78, 18);
            this.guna2HtmlLabel1.TabIndex = 8;
            this.guna2HtmlLabel1.Text = "Receiver =";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(524, 682);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.lbl_sendername);
            this.Controls.Add(this.combobox_incoming_msg);
            this.Controls.Add(this.btn_show_msg);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_sent_msg);
            this.Controls.Add(this.combobox_fullname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox combobox_fullname;
        private Guna.UI2.WinForms.Guna2Button btn_sent_msg;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button btn_show_msg;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_sendername;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        public Guna.UI2.WinForms.Guna2ComboBox combobox_incoming_msg;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}