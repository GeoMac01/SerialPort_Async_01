namespace SerialPort_Async_01
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
            this.bt_Scan_Com = new System.Windows.Forms.Button();
            this.bt_Connect_Com = new System.Windows.Forms.Button();
            this.cb_COM_Sel = new System.Windows.Forms.ComboBox();
            this.Lbl_Ls_Nb = new System.Windows.Forms.Label();
            this.Bt_Send = new System.Windows.Forms.Button();
            this.Rtb_UartIn = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Bt_TestRun = new System.Windows.Forms.Button();
            this.Lbl_99Cmd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_Scan_Com
            // 
            this.bt_Scan_Com.Location = new System.Drawing.Point(121, 22);
            this.bt_Scan_Com.Name = "bt_Scan_Com";
            this.bt_Scan_Com.Size = new System.Drawing.Size(78, 28);
            this.bt_Scan_Com.TabIndex = 0;
            this.bt_Scan_Com.Text = "Scan COMs";
            this.bt_Scan_Com.UseVisualStyleBackColor = true;
            this.bt_Scan_Com.Click += new System.EventHandler(this.Bt_Scan_Com_Click);
            // 
            // bt_Connect_Com
            // 
            this.bt_Connect_Com.BackColor = System.Drawing.Color.Orange;
            this.bt_Connect_Com.Location = new System.Drawing.Point(205, 22);
            this.bt_Connect_Com.Name = "bt_Connect_Com";
            this.bt_Connect_Com.Size = new System.Drawing.Size(78, 28);
            this.bt_Connect_Com.TabIndex = 1;
            this.bt_Connect_Com.Text = "Connect";
            this.bt_Connect_Com.UseVisualStyleBackColor = false;
            this.bt_Connect_Com.CausesValidationChanged += new System.EventHandler(this.Bt_Connect_Com_Click);
            this.bt_Connect_Com.Click += new System.EventHandler(this.Bt_Connect_Com_Click);
            // 
            // cb_COM_Sel
            // 
            this.cb_COM_Sel.FormattingEnabled = true;
            this.cb_COM_Sel.Location = new System.Drawing.Point(36, 22);
            this.cb_COM_Sel.Name = "cb_COM_Sel";
            this.cb_COM_Sel.Size = new System.Drawing.Size(68, 21);
            this.cb_COM_Sel.TabIndex = 2;
            // 
            // Lbl_Ls_Nb
            // 
            this.Lbl_Ls_Nb.AutoSize = true;
            this.Lbl_Ls_Nb.Location = new System.Drawing.Point(301, 30);
            this.Lbl_Ls_Nb.Name = "Lbl_Ls_Nb";
            this.Lbl_Ls_Nb.Size = new System.Drawing.Size(16, 13);
            this.Lbl_Ls_Nb.TabIndex = 3;
            this.Lbl_Ls_Nb.Text = "---";
            // 
            // Bt_Send
            // 
            this.Bt_Send.Location = new System.Drawing.Point(36, 94);
            this.Bt_Send.Name = "Bt_Send";
            this.Bt_Send.Size = new System.Drawing.Size(95, 24);
            this.Bt_Send.TabIndex = 4;
            this.Bt_Send.Text = "Send";
            this.Bt_Send.UseVisualStyleBackColor = true;
            this.Bt_Send.Click += new System.EventHandler(this.Bt_Send_Click);
            // 
            // Rtb_UartIn
            // 
            this.Rtb_UartIn.Location = new System.Drawing.Point(36, 124);
            this.Rtb_UartIn.Name = "Rtb_UartIn";
            this.Rtb_UartIn.Size = new System.Drawing.Size(95, 261);
            this.Rtb_UartIn.TabIndex = 5;
            this.Rtb_UartIn.Text = "";
            this.Rtb_UartIn.DoubleClick += new System.EventHandler(this.Rtb_UartIn_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name ---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ser. Numb. ---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Part Nb. ---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cust Part ---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date ---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Firm ---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Current ---";
            // 
            // Bt_TestRun
            // 
            this.Bt_TestRun.BackColor = System.Drawing.Color.Orange;
            this.Bt_TestRun.Location = new System.Drawing.Point(36, 391);
            this.Bt_TestRun.Name = "Bt_TestRun";
            this.Bt_TestRun.Size = new System.Drawing.Size(95, 24);
            this.Bt_TestRun.TabIndex = 13;
            this.Bt_TestRun.Text = "Test Run";
            this.Bt_TestRun.UseVisualStyleBackColor = false;
            this.Bt_TestRun.Click += new System.EventHandler(this.Bt_TestRun_Click);
            // 
            // Lbl_99Cmd
            // 
            this.Lbl_99Cmd.AutoSize = true;
            this.Lbl_99Cmd.Location = new System.Drawing.Point(334, 30);
            this.Lbl_99Cmd.Name = "Lbl_99Cmd";
            this.Lbl_99Cmd.Size = new System.Drawing.Size(16, 13);
            this.Lbl_99Cmd.TabIndex = 14;
            this.Lbl_99Cmd.Text = "---";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 452);
            this.Controls.Add(this.Lbl_99Cmd);
            this.Controls.Add(this.Bt_TestRun);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rtb_UartIn);
            this.Controls.Add(this.Bt_Send);
            this.Controls.Add(this.Lbl_Ls_Nb);
            this.Controls.Add(this.cb_COM_Sel);
            this.Controls.Add(this.bt_Connect_Com);
            this.Controls.Add(this.bt_Scan_Com);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Scan_Com;
        private System.Windows.Forms.Button bt_Connect_Com;
        private System.Windows.Forms.ComboBox cb_COM_Sel;
        private System.Windows.Forms.Label Lbl_Ls_Nb;
        private System.Windows.Forms.Button Bt_Send;
        private System.Windows.Forms.RichTextBox Rtb_UartIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Bt_TestRun;
        private System.Windows.Forms.Label Lbl_99Cmd;
    }
}

