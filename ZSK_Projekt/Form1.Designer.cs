namespace ZSK_Projekt
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
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.gbxNodeInfo = new System.Windows.Forms.GroupBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccess = new System.Windows.Forms.TextBox();
            this.txtSyntax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBerMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBerMin = new System.Windows.Forms.TextBox();
            this.txtBerStatus = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBerAccess = new System.Windows.Forms.TextBox();
            this.txtBerSyntax = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBerOID = new System.Windows.Forms.TextBox();
            this.txtBerName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBer = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEncode = new System.Windows.Forms.Button();
            this.gbxNodeInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(10, 10);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(250, 540);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // gbxNodeInfo
            // 
            this.gbxNodeInfo.Controls.Add(this.txtMax);
            this.gbxNodeInfo.Controls.Add(this.label5);
            this.gbxNodeInfo.Controls.Add(this.txtMin);
            this.gbxNodeInfo.Controls.Add(this.txtStatus);
            this.gbxNodeInfo.Controls.Add(this.label3);
            this.gbxNodeInfo.Controls.Add(this.label4);
            this.gbxNodeInfo.Controls.Add(this.txtAccess);
            this.gbxNodeInfo.Controls.Add(this.txtSyntax);
            this.gbxNodeInfo.Controls.Add(this.label6);
            this.gbxNodeInfo.Controls.Add(this.label7);
            this.gbxNodeInfo.Controls.Add(this.txtOID);
            this.gbxNodeInfo.Controls.Add(this.txtName);
            this.gbxNodeInfo.Controls.Add(this.label2);
            this.gbxNodeInfo.Controls.Add(this.label1);
            this.gbxNodeInfo.Location = new System.Drawing.Point(266, 10);
            this.gbxNodeInfo.Name = "gbxNodeInfo";
            this.gbxNodeInfo.Size = new System.Drawing.Size(368, 235);
            this.gbxNodeInfo.TabIndex = 1;
            this.gbxNodeInfo.TabStop = false;
            this.gbxNodeInfo.Text = "Selected Node Information";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(97, 183);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(236, 20);
            this.txtMax.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Max:";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(97, 157);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(236, 20);
            this.txtMin.TabIndex = 13;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(97, 130);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(236, 20);
            this.txtStatus.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Min:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status:";
            // 
            // txtAccess
            // 
            this.txtAccess.Location = new System.Drawing.Point(97, 104);
            this.txtAccess.Name = "txtAccess";
            this.txtAccess.ReadOnly = true;
            this.txtAccess.Size = new System.Drawing.Size(236, 20);
            this.txtAccess.TabIndex = 9;
            // 
            // txtSyntax
            // 
            this.txtSyntax.Location = new System.Drawing.Point(97, 77);
            this.txtSyntax.Name = "txtSyntax";
            this.txtSyntax.ReadOnly = true;
            this.txtSyntax.Size = new System.Drawing.Size(236, 20);
            this.txtSyntax.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Access:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Syntax:";
            // 
            // txtOID
            // 
            this.txtOID.Location = new System.Drawing.Point(97, 51);
            this.txtOID.Name = "txtOID";
            this.txtOID.ReadOnly = true;
            this.txtOID.Size = new System.Drawing.Size(236, 20);
            this.txtOID.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(97, 24);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(236, 20);
            this.txtName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "OID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBerMax);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBerMin);
            this.groupBox1.Controls.Add(this.txtBerStatus);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtBerAccess);
            this.groupBox1.Controls.Add(this.txtBerSyntax);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtBerOID);
            this.groupBox1.Controls.Add(this.txtBerName);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(628, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 235);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data to encode";
            // 
            // txtBerMax
            // 
            this.txtBerMax.Location = new System.Drawing.Point(97, 183);
            this.txtBerMax.Name = "txtBerMax";
            this.txtBerMax.Size = new System.Drawing.Size(236, 20);
            this.txtBerMax.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(66, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Max:";
            // 
            // txtBerMin
            // 
            this.txtBerMin.Location = new System.Drawing.Point(97, 157);
            this.txtBerMin.Name = "txtBerMin";
            this.txtBerMin.Size = new System.Drawing.Size(236, 20);
            this.txtBerMin.TabIndex = 13;
            // 
            // txtBerStatus
            // 
            this.txtBerStatus.Location = new System.Drawing.Point(97, 130);
            this.txtBerStatus.Name = "txtBerStatus";
            this.txtBerStatus.Size = new System.Drawing.Size(236, 20);
            this.txtBerStatus.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Min:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Status:";
            // 
            // txtBerAccess
            // 
            this.txtBerAccess.Location = new System.Drawing.Point(97, 104);
            this.txtBerAccess.Name = "txtBerAccess";
            this.txtBerAccess.Size = new System.Drawing.Size(236, 20);
            this.txtBerAccess.TabIndex = 9;
            // 
            // txtBerSyntax
            // 
            this.txtBerSyntax.Location = new System.Drawing.Point(97, 77);
            this.txtBerSyntax.Name = "txtBerSyntax";
            this.txtBerSyntax.Size = new System.Drawing.Size(236, 20);
            this.txtBerSyntax.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Access:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Syntax:";
            // 
            // txtBerOID
            // 
            this.txtBerOID.Location = new System.Drawing.Point(97, 51);
            this.txtBerOID.Name = "txtBerOID";
            this.txtBerOID.Size = new System.Drawing.Size(236, 20);
            this.txtBerOID.TabIndex = 5;
            // 
            // txtBerName
            // 
            this.txtBerName.Location = new System.Drawing.Point(97, 24);
            this.txtBerName.Name = "txtBerName";
            this.txtBerName.Size = new System.Drawing.Size(236, 20);
            this.txtBerName.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(65, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "OID:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(57, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Name:";
            // 
            // txtBer
            // 
            this.txtBer.Location = new System.Drawing.Point(628, 251);
            this.txtBer.Multiline = true;
            this.txtBer.Name = "txtBer";
            this.txtBer.Size = new System.Drawing.Size(368, 299);
            this.txtBer.TabIndex = 17;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AutoSize = false;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(267, 252);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 23);
            this.btnEncode.TabIndex = 19;
            this.btnEncode.Text = "button1";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.txtBer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxNodeInfo);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxNodeInfo.ResumeLayout(false);
            this.gbxNodeInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox gbxNodeInfo;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccess;
        private System.Windows.Forms.TextBox txtSyntax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBerMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBerMin;
        private System.Windows.Forms.TextBox txtBerStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBerAccess;
        private System.Windows.Forms.TextBox txtBerSyntax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBerOID;
        private System.Windows.Forms.TextBox txtBerName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnEncode;
    }
}

