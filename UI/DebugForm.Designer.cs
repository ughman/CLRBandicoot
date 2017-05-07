namespace CLRBandicoot.UI
{
    partial class DebugForm
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
            this.uxTabs = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.lblProfile = new System.Windows.Forms.Label();
            this.tmUpdate = new System.Windows.Forms.Timer(this.components);
            this.fraRegisters = new System.Windows.Forms.GroupBox();
            this.fraBreakpoints = new System.Windows.Forms.GroupBox();
            this.chkReadBreakpoint = new System.Windows.Forms.CheckBox();
            this.chkWriteBreakpoint = new System.Windows.Forms.CheckBox();
            this.chkExecuteBreakpoint = new System.Windows.Forms.CheckBox();
            this.txtReadBreakpoint = new System.Windows.Forms.TextBox();
            this.txtWriteBreakpoint = new System.Windows.Forms.TextBox();
            this.txtExecuteBreakpoint = new System.Windows.Forms.TextBox();
            this.lblMemoryBase = new System.Windows.Forms.Label();
            this.lblPCTitle = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.lblAT = new System.Windows.Forms.Label();
            this.lblATTitle = new System.Windows.Forms.Label();
            this.lblV0 = new System.Windows.Forms.Label();
            this.lblV0Title = new System.Windows.Forms.Label();
            this.lblV1 = new System.Windows.Forms.Label();
            this.lblV1Title = new System.Windows.Forms.Label();
            this.lblA0 = new System.Windows.Forms.Label();
            this.lblA0Title = new System.Windows.Forms.Label();
            this.lblA1 = new System.Windows.Forms.Label();
            this.lblA1Title = new System.Windows.Forms.Label();
            this.lblA2 = new System.Windows.Forms.Label();
            this.lblA2Title = new System.Windows.Forms.Label();
            this.lblA3 = new System.Windows.Forms.Label();
            this.lblA3Title = new System.Windows.Forms.Label();
            this.uxTabs.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.fraRegisters.SuspendLayout();
            this.fraBreakpoints.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxTabs
            // 
            this.uxTabs.Controls.Add(this.tabMain);
            this.uxTabs.Controls.Add(this.tabProfile);
            this.uxTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxTabs.Location = new System.Drawing.Point(0,0);
            this.uxTabs.Name = "uxTabs";
            this.uxTabs.SelectedIndex = 0;
            this.uxTabs.Size = new System.Drawing.Size(406,321);
            this.uxTabs.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.lblMemoryBase);
            this.tabMain.Controls.Add(this.fraBreakpoints);
            this.tabMain.Controls.Add(this.fraRegisters);
            this.tabMain.Location = new System.Drawing.Point(4,22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(398,295);
            this.tabMain.TabIndex = 1;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.lblProfile);
            this.tabProfile.Location = new System.Drawing.Point(4,22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Size = new System.Drawing.Size(398,315);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // lblProfile
            // 
            this.lblProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProfile.Location = new System.Drawing.Point(0,0);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(398,315);
            this.lblProfile.TabIndex = 1;
            this.lblProfile.Text = "<PROFILE>";
            // 
            // tmUpdate
            // 
            this.tmUpdate.Enabled = true;
            this.tmUpdate.Interval = 1000;
            this.tmUpdate.Tick += new System.EventHandler(this.tmUpdate_Tick);
            // 
            // fraRegisters
            // 
            this.fraRegisters.Controls.Add(this.lblA3);
            this.fraRegisters.Controls.Add(this.lblA3Title);
            this.fraRegisters.Controls.Add(this.lblA2);
            this.fraRegisters.Controls.Add(this.lblA2Title);
            this.fraRegisters.Controls.Add(this.lblA1);
            this.fraRegisters.Controls.Add(this.lblA1Title);
            this.fraRegisters.Controls.Add(this.lblA0);
            this.fraRegisters.Controls.Add(this.lblA0Title);
            this.fraRegisters.Controls.Add(this.lblV1);
            this.fraRegisters.Controls.Add(this.lblV1Title);
            this.fraRegisters.Controls.Add(this.lblV0);
            this.fraRegisters.Controls.Add(this.lblV0Title);
            this.fraRegisters.Controls.Add(this.lblAT);
            this.fraRegisters.Controls.Add(this.lblATTitle);
            this.fraRegisters.Controls.Add(this.lblPC);
            this.fraRegisters.Controls.Add(this.lblPCTitle);
            this.fraRegisters.Location = new System.Drawing.Point(8,6);
            this.fraRegisters.Name = "fraRegisters";
            this.fraRegisters.Size = new System.Drawing.Size(382,175);
            this.fraRegisters.TabIndex = 0;
            this.fraRegisters.TabStop = false;
            this.fraRegisters.Text = "Registers";
            // 
            // fraBreakpoints
            // 
            this.fraBreakpoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fraBreakpoints.Controls.Add(this.txtExecuteBreakpoint);
            this.fraBreakpoints.Controls.Add(this.txtWriteBreakpoint);
            this.fraBreakpoints.Controls.Add(this.txtReadBreakpoint);
            this.fraBreakpoints.Controls.Add(this.chkExecuteBreakpoint);
            this.fraBreakpoints.Controls.Add(this.chkWriteBreakpoint);
            this.fraBreakpoints.Controls.Add(this.chkReadBreakpoint);
            this.fraBreakpoints.Location = new System.Drawing.Point(8,187);
            this.fraBreakpoints.Name = "fraBreakpoints";
            this.fraBreakpoints.Size = new System.Drawing.Size(158,100);
            this.fraBreakpoints.TabIndex = 0;
            this.fraBreakpoints.TabStop = false;
            this.fraBreakpoints.Text = "Breakpoints";
            // 
            // chkReadBreakpoint
            // 
            this.chkReadBreakpoint.Location = new System.Drawing.Point(6,19);
            this.chkReadBreakpoint.Name = "chkReadBreakpoint";
            this.chkReadBreakpoint.Size = new System.Drawing.Size(77,20);
            this.chkReadBreakpoint.TabIndex = 0;
            this.chkReadBreakpoint.Text = "Read";
            this.chkReadBreakpoint.UseVisualStyleBackColor = true;
            this.chkReadBreakpoint.CheckedChanged += new System.EventHandler(this.chkReadBreakpoint_CheckedChanged);
            // 
            // chkWriteBreakpoint
            // 
            this.chkWriteBreakpoint.Location = new System.Drawing.Point(6,45);
            this.chkWriteBreakpoint.Name = "chkWriteBreakpoint";
            this.chkWriteBreakpoint.Size = new System.Drawing.Size(77,20);
            this.chkWriteBreakpoint.TabIndex = 1;
            this.chkWriteBreakpoint.Text = "Write";
            this.chkWriteBreakpoint.UseVisualStyleBackColor = true;
            this.chkWriteBreakpoint.CheckedChanged += new System.EventHandler(this.chkWriteBreakpoint_CheckedChanged);
            // 
            // chkExecuteBreakpoint
            // 
            this.chkExecuteBreakpoint.Location = new System.Drawing.Point(6,71);
            this.chkExecuteBreakpoint.Name = "chkExecuteBreakpoint";
            this.chkExecuteBreakpoint.Size = new System.Drawing.Size(77,20);
            this.chkExecuteBreakpoint.TabIndex = 2;
            this.chkExecuteBreakpoint.Text = "Execute";
            this.chkExecuteBreakpoint.UseVisualStyleBackColor = true;
            this.chkExecuteBreakpoint.CheckedChanged += new System.EventHandler(this.chkExecuteBreakpoint_CheckedChanged);
            // 
            // txtReadBreakpoint
            // 
            this.txtReadBreakpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReadBreakpoint.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.txtReadBreakpoint.Location = new System.Drawing.Point(89,19);
            this.txtReadBreakpoint.Name = "txtReadBreakpoint";
            this.txtReadBreakpoint.Size = new System.Drawing.Size(63,20);
            this.txtReadBreakpoint.TabIndex = 1;
            this.txtReadBreakpoint.Text = "XXXXXXXX";
            // 
            // txtWriteBreakpoint
            // 
            this.txtWriteBreakpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWriteBreakpoint.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.txtWriteBreakpoint.Location = new System.Drawing.Point(89,45);
            this.txtWriteBreakpoint.Name = "txtWriteBreakpoint";
            this.txtWriteBreakpoint.Size = new System.Drawing.Size(63,20);
            this.txtWriteBreakpoint.TabIndex = 3;
            this.txtWriteBreakpoint.Text = "XXXXXXXX";
            // 
            // txtExecuteBreakpoint
            // 
            this.txtExecuteBreakpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExecuteBreakpoint.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.txtExecuteBreakpoint.Location = new System.Drawing.Point(89,71);
            this.txtExecuteBreakpoint.Name = "txtExecuteBreakpoint";
            this.txtExecuteBreakpoint.Size = new System.Drawing.Size(63,20);
            this.txtExecuteBreakpoint.TabIndex = 4;
            this.txtExecuteBreakpoint.Text = "XXXXXXXX";
            // 
            // lblMemoryBase
            // 
            this.lblMemoryBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemoryBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemoryBase.Font = new System.Drawing.Font("Courier New",27.75F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.lblMemoryBase.Location = new System.Drawing.Point(172,187);
            this.lblMemoryBase.Name = "lblMemoryBase";
            this.lblMemoryBase.Size = new System.Drawing.Size(218,100);
            this.lblMemoryBase.TabIndex = 1;
            this.lblMemoryBase.Text = "XXXXXXXX";
            this.lblMemoryBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPCTitle
            // 
            this.lblPCTitle.Location = new System.Drawing.Point(253,16);
            this.lblPCTitle.Name = "lblPCTitle";
            this.lblPCTitle.Size = new System.Drawing.Size(42,19);
            this.lblPCTitle.TabIndex = 1;
            this.lblPCTitle.Text = "PC:";
            this.lblPCTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPC
            // 
            this.lblPC.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.lblPC.Location = new System.Drawing.Point(301,16);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(75,19);
            this.lblPC.TabIndex = 2;
            this.lblPC.Text = "XXXXXXXX";
            this.lblPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAT
            // 
            this.lblAT.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.lblAT.Location = new System.Drawing.Point(54,16);
            this.lblAT.Name = "lblAT";
            this.lblAT.Size = new System.Drawing.Size(75,19);
            this.lblAT.TabIndex = 4;
            this.lblAT.Text = "XXXXXXXX";
            this.lblAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblATTitle
            // 
            this.lblATTitle.Location = new System.Drawing.Point(6,16);
            this.lblATTitle.Name = "lblATTitle";
            this.lblATTitle.Size = new System.Drawing.Size(42,19);
            this.lblATTitle.TabIndex = 3;
            this.lblATTitle.Text = "AT:";
            this.lblATTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblV0
            // 
            this.lblV0.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.lblV0.Location = new System.Drawing.Point(54,35);
            this.lblV0.Name = "lblV0";
            this.lblV0.Size = new System.Drawing.Size(75,19);
            this.lblV0.TabIndex = 6;
            this.lblV0.Text = "XXXXXXXX";
            this.lblV0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblV0Title
            // 
            this.lblV0Title.Location = new System.Drawing.Point(6,35);
            this.lblV0Title.Name = "lblV0Title";
            this.lblV0Title.Size = new System.Drawing.Size(42,19);
            this.lblV0Title.TabIndex = 5;
            this.lblV0Title.Text = "V0:";
            this.lblV0Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblV1
            // 
            this.lblV1.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.lblV1.Location = new System.Drawing.Point(54,54);
            this.lblV1.Name = "lblV1";
            this.lblV1.Size = new System.Drawing.Size(75,19);
            this.lblV1.TabIndex = 8;
            this.lblV1.Text = "XXXXXXXX";
            this.lblV1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblV1Title
            // 
            this.lblV1Title.Location = new System.Drawing.Point(6,54);
            this.lblV1Title.Name = "lblV1Title";
            this.lblV1Title.Size = new System.Drawing.Size(42,19);
            this.lblV1Title.TabIndex = 7;
            this.lblV1Title.Text = "V1:";
            this.lblV1Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblA0
            // 
            this.lblA0.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.lblA0.Location = new System.Drawing.Point(54,73);
            this.lblA0.Name = "lblA0";
            this.lblA0.Size = new System.Drawing.Size(75,19);
            this.lblA0.TabIndex = 10;
            this.lblA0.Text = "XXXXXXXX";
            this.lblA0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblA0Title
            // 
            this.lblA0Title.Location = new System.Drawing.Point(6,73);
            this.lblA0Title.Name = "lblA0Title";
            this.lblA0Title.Size = new System.Drawing.Size(42,19);
            this.lblA0Title.TabIndex = 9;
            this.lblA0Title.Text = "A0:";
            this.lblA0Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblA1
            // 
            this.lblA1.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.lblA1.Location = new System.Drawing.Point(54,92);
            this.lblA1.Name = "lblA1";
            this.lblA1.Size = new System.Drawing.Size(75,19);
            this.lblA1.TabIndex = 12;
            this.lblA1.Text = "XXXXXXXX";
            this.lblA1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblA1Title
            // 
            this.lblA1Title.Location = new System.Drawing.Point(6,92);
            this.lblA1Title.Name = "lblA1Title";
            this.lblA1Title.Size = new System.Drawing.Size(42,19);
            this.lblA1Title.TabIndex = 11;
            this.lblA1Title.Text = "A1:";
            this.lblA1Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblA2
            // 
            this.lblA2.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.lblA2.Location = new System.Drawing.Point(54,111);
            this.lblA2.Name = "lblA2";
            this.lblA2.Size = new System.Drawing.Size(75,19);
            this.lblA2.TabIndex = 14;
            this.lblA2.Text = "XXXXXXXX";
            this.lblA2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblA2Title
            // 
            this.lblA2Title.Location = new System.Drawing.Point(6,111);
            this.lblA2Title.Name = "lblA2Title";
            this.lblA2Title.Size = new System.Drawing.Size(42,19);
            this.lblA2Title.TabIndex = 13;
            this.lblA2Title.Text = "A2:";
            this.lblA2Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblA3
            // 
            this.lblA3.Font = new System.Drawing.Font("Courier New",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.lblA3.Location = new System.Drawing.Point(54,130);
            this.lblA3.Name = "lblA3";
            this.lblA3.Size = new System.Drawing.Size(75,19);
            this.lblA3.TabIndex = 16;
            this.lblA3.Text = "XXXXXXXX";
            this.lblA3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblA3Title
            // 
            this.lblA3Title.Location = new System.Drawing.Point(6,130);
            this.lblA3Title.Name = "lblA3Title";
            this.lblA3Title.Size = new System.Drawing.Size(42,19);
            this.lblA3Title.TabIndex = 15;
            this.lblA3Title.Text = "A3:";
            this.lblA3Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406,321);
            this.Controls.Add(this.uxTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugForm";
            this.Text = "Debugger";
            this.uxTabs.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.fraRegisters.ResumeLayout(false);
            this.fraBreakpoints.ResumeLayout(false);
            this.fraBreakpoints.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl uxTabs;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.Timer tmUpdate;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.GroupBox fraBreakpoints;
        private System.Windows.Forms.TextBox txtExecuteBreakpoint;
        private System.Windows.Forms.TextBox txtWriteBreakpoint;
        private System.Windows.Forms.TextBox txtReadBreakpoint;
        private System.Windows.Forms.CheckBox chkExecuteBreakpoint;
        private System.Windows.Forms.CheckBox chkWriteBreakpoint;
        private System.Windows.Forms.CheckBox chkReadBreakpoint;
        private System.Windows.Forms.GroupBox fraRegisters;
        private System.Windows.Forms.Label lblMemoryBase;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lblPCTitle;
        private System.Windows.Forms.Label lblV1;
        private System.Windows.Forms.Label lblV1Title;
        private System.Windows.Forms.Label lblV0;
        private System.Windows.Forms.Label lblV0Title;
        private System.Windows.Forms.Label lblAT;
        private System.Windows.Forms.Label lblATTitle;
        private System.Windows.Forms.Label lblA3;
        private System.Windows.Forms.Label lblA3Title;
        private System.Windows.Forms.Label lblA2;
        private System.Windows.Forms.Label lblA2Title;
        private System.Windows.Forms.Label lblA1;
        private System.Windows.Forms.Label lblA1Title;
        private System.Windows.Forms.Label lblA0;
        private System.Windows.Forms.Label lblA0Title;
    }
}