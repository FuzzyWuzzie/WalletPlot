namespace WalletPlot
{
    partial class Donate
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btcAddress = new System.Windows.Forms.TextBox();
            this.copyBTC = new System.Windows.Forms.Button();
            this.ltcAddress = new System.Windows.Forms.TextBox();
            this.vtcAddress = new System.Windows.Forms.TextBox();
            this.dogeAddress = new System.Windows.Forms.TextBox();
            this.copyLTC = new System.Windows.Forms.Button();
            this.copyVTC = new System.Windows.Forms.Button();
            this.copyDOGE = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.82178F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.17822F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Controls.Add(this.copyDOGE, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.copyVTC, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.copyLTC, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dogeAddress, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.vtcAddress, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ltcAddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btcAddress, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.copyBTC, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(302, 158);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Although I created this program for my own use in my spare time, donations are ve" +
    "ry much appreciated and help me stay afloat!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "BTC:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "LTC:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "VTC:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 29);
            this.label8.TabIndex = 7;
            this.label8.Text = "DOGE:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btcAddress
            // 
            this.btcAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btcAddress.BackColor = System.Drawing.SystemColors.Control;
            this.btcAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.btcAddress.Location = new System.Drawing.Point(51, 48);
            this.btcAddress.Name = "btcAddress";
            this.btcAddress.ReadOnly = true;
            this.btcAddress.Size = new System.Drawing.Size(218, 13);
            this.btcAddress.TabIndex = 8;
            this.btcAddress.TabStop = false;
            this.btcAddress.Text = "1GXeAqgcyioS5EXcXrD58P2Z57e6vfDMEH";
            // 
            // copyBTC
            // 
            this.copyBTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyBTC.Image = global::WalletPlot.Properties.Resources.copy;
            this.copyBTC.Location = new System.Drawing.Point(275, 43);
            this.copyBTC.Name = "copyBTC";
            this.copyBTC.Size = new System.Drawing.Size(24, 23);
            this.copyBTC.TabIndex = 9;
            this.copyBTC.TabStop = false;
            this.copyBTC.UseVisualStyleBackColor = true;
            this.copyBTC.Click += new System.EventHandler(this.copyBTC_Click);
            // 
            // ltcAddress
            // 
            this.ltcAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ltcAddress.BackColor = System.Drawing.SystemColors.Control;
            this.ltcAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ltcAddress.Location = new System.Drawing.Point(51, 77);
            this.ltcAddress.Name = "ltcAddress";
            this.ltcAddress.ReadOnly = true;
            this.ltcAddress.Size = new System.Drawing.Size(218, 13);
            this.ltcAddress.TabIndex = 10;
            this.ltcAddress.TabStop = false;
            this.ltcAddress.Text = "LNqQPGKmcVkHETT6emQXhyb7iBXVQrZMJN";
            // 
            // vtcAddress
            // 
            this.vtcAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vtcAddress.BackColor = System.Drawing.SystemColors.Control;
            this.vtcAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vtcAddress.Location = new System.Drawing.Point(51, 106);
            this.vtcAddress.Name = "vtcAddress";
            this.vtcAddress.ReadOnly = true;
            this.vtcAddress.Size = new System.Drawing.Size(218, 13);
            this.vtcAddress.TabIndex = 12;
            this.vtcAddress.TabStop = false;
            this.vtcAddress.Text = "VtsF99GWnjXw2tm2fDC9WL5HweQVkEYfbz";
            // 
            // dogeAddress
            // 
            this.dogeAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dogeAddress.BackColor = System.Drawing.SystemColors.Control;
            this.dogeAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dogeAddress.Location = new System.Drawing.Point(51, 135);
            this.dogeAddress.Name = "dogeAddress";
            this.dogeAddress.ReadOnly = true;
            this.dogeAddress.Size = new System.Drawing.Size(218, 13);
            this.dogeAddress.TabIndex = 14;
            this.dogeAddress.TabStop = false;
            this.dogeAddress.Text = "DKSLFVZ6XidDAyuiDhffsScGk8ZUPD6epB";
            // 
            // copyLTC
            // 
            this.copyLTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyLTC.Image = global::WalletPlot.Properties.Resources.copy;
            this.copyLTC.Location = new System.Drawing.Point(275, 72);
            this.copyLTC.Name = "copyLTC";
            this.copyLTC.Size = new System.Drawing.Size(24, 23);
            this.copyLTC.TabIndex = 15;
            this.copyLTC.TabStop = false;
            this.copyLTC.UseVisualStyleBackColor = true;
            this.copyLTC.Click += new System.EventHandler(this.copyLTC_Click);
            // 
            // copyVTC
            // 
            this.copyVTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyVTC.Image = global::WalletPlot.Properties.Resources.copy;
            this.copyVTC.Location = new System.Drawing.Point(275, 101);
            this.copyVTC.Name = "copyVTC";
            this.copyVTC.Size = new System.Drawing.Size(24, 23);
            this.copyVTC.TabIndex = 16;
            this.copyVTC.TabStop = false;
            this.copyVTC.UseVisualStyleBackColor = true;
            this.copyVTC.Click += new System.EventHandler(this.copyVTC_Click);
            // 
            // copyDOGE
            // 
            this.copyDOGE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyDOGE.Image = global::WalletPlot.Properties.Resources.copy;
            this.copyDOGE.Location = new System.Drawing.Point(275, 130);
            this.copyDOGE.Name = "copyDOGE";
            this.copyDOGE.Size = new System.Drawing.Size(24, 23);
            this.copyDOGE.TabIndex = 17;
            this.copyDOGE.TabStop = false;
            this.copyDOGE.UseVisualStyleBackColor = true;
            this.copyDOGE.Click += new System.EventHandler(this.copyDOGE_Click);
            // 
            // Donate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 158);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Donate";
            this.Text = "Donate";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox btcAddress;
        private System.Windows.Forms.Button copyBTC;
        private System.Windows.Forms.Button copyDOGE;
        private System.Windows.Forms.Button copyVTC;
        private System.Windows.Forms.Button copyLTC;
        private System.Windows.Forms.TextBox dogeAddress;
        private System.Windows.Forms.TextBox vtcAddress;
        private System.Windows.Forms.TextBox ltcAddress;
    }
}