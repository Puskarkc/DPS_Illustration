namespace Manage_Data
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dPSScemesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dPSGOLDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dPSSILVERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dPSBRONZEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dPSScemesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dPSGOLDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsFormList = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsFormClose = new System.Windows.Forms.ToolStripButton();
            this.tsMain = new Manage_Data.MyFormBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(92, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManageData,
            this.mnuTest});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "&Action";
            // 
            // mnuManageData
            // 
            this.mnuManageData.Name = "mnuManageData";
            this.mnuManageData.Size = new System.Drawing.Size(144, 22);
            this.mnuManageData.Text = "&Manage Data";
            this.mnuManageData.Click += new System.EventHandler(this.mnuManageData_Click);
            // 
            // mnuTest
            // 
            this.mnuTest.Name = "mnuTest";
            this.mnuTest.Size = new System.Drawing.Size(144, 22);
            this.mnuTest.Text = "&Test";
            this.mnuTest.Click += new System.EventHandler(this.mnuTest_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(450, 17);
            // 
            // tssDate
            // 
            this.tssDate.Name = "tssDate";
            this.tssDate.Size = new System.Drawing.Size(118, 17);
            this.tssDate.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(300, 17);
            // 
            // tssTime
            // 
            this.tssTime.Name = "tssTime";
            this.tssTime.Size = new System.Drawing.Size(118, 15);
            this.tssTime.Text = "toolStripStatusLabel2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dPSScemesToolStripMenuItem
            // 
            this.dPSScemesToolStripMenuItem.Name = "dPSScemesToolStripMenuItem";
            this.dPSScemesToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.dPSScemesToolStripMenuItem.Text = "&DPS Scemes";
            // 
            // dPSGOLDToolStripMenuItem
            // 
            this.dPSGOLDToolStripMenuItem.Name = "dPSGOLDToolStripMenuItem";
            this.dPSGOLDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dPSGOLDToolStripMenuItem.Text = "DPS GOLD";
            // 
            // dPSSILVERToolStripMenuItem
            // 
            this.dPSSILVERToolStripMenuItem.Name = "dPSSILVERToolStripMenuItem";
            this.dPSSILVERToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dPSSILVERToolStripMenuItem.Text = "DPS SILVER";
            // 
            // dPSBRONZEToolStripMenuItem
            // 
            this.dPSBRONZEToolStripMenuItem.Name = "dPSBRONZEToolStripMenuItem";
            this.dPSBRONZEToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dPSBRONZEToolStripMenuItem.Text = "DPS BRONZE";
            // 
            // dPSScemesToolStripMenuItem1
            // 
            this.dPSScemesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dPSGOLDToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.dPSScemesToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dPSScemesToolStripMenuItem1.Name = "dPSScemesToolStripMenuItem1";
            this.dPSScemesToolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.dPSScemesToolStripMenuItem1.Text = "&Menu";
            // 
            // dPSGOLDToolStripMenuItem1
            // 
            this.dPSGOLDToolStripMenuItem1.Name = "dPSGOLDToolStripMenuItem1";
            this.dPSGOLDToolStripMenuItem1.Size = new System.Drawing.Size(97, 22);
            this.dPSGOLDToolStripMenuItem1.Text = "DPS";
            this.dPSGOLDToolStripMenuItem1.Click += new System.EventHandler(this.dPSGOLDToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.analysisToolStripMenuItem.Text = "&_Analysis";
            this.analysisToolStripMenuItem.Visible = false;
            this.analysisToolStripMenuItem.Click += new System.EventHandler(this.analysisToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Linen;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dPSScemesToolStripMenuItem1,
            this.analysisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsFormList
            // 
            this.tsFormList.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsFormList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFormList.Image = ((System.Drawing.Image)(resources.GetObject("tsFormList.Image")));
            this.tsFormList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFormList.Name = "tsFormList";
            this.tsFormList.ShowDropDownArrow = false;
            this.tsFormList.Size = new System.Drawing.Size(20, 22);
            this.tsFormList.ToolTipText = "Open Forms";
            this.tsFormList.Click += new System.EventHandler(this.tsFormList_Click_1);
            // 
            // tsFormClose
            // 
            this.tsFormClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsFormClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFormClose.Image = ((System.Drawing.Image)(resources.GetObject("tsFormClose.Image")));
            this.tsFormClose.Name = "tsFormClose";
            this.tsFormClose.Size = new System.Drawing.Size(23, 22);
            this.tsFormClose.ToolTipText = "Close Form";
            this.tsFormClose.Click += new System.EventHandler(this.tsFormClose_Click_1);
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.Azure;
            this.tsMain.CanOverflow = false;
            this.tsMain.CurrentActive = "";
            this.tsMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFormList,
            this.tsFormClose});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(912, 25);
            this.tsMain.TabIndex = 5;
            this.tsMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsMain_ItemClicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 567);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(912, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(124, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(970, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gisha", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(970, 56);
            this.label2.TabIndex = 1;
            this.label2.Text = ".:: MetLife Nepal. DPS ILLUSTRATION SYSTEM ::.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 543);
            this.panel1.TabIndex = 3;
            this.panel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel1_ControlAdded);
            this.panel1.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panel1_ControlRemoved);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(912, 589);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "MetLife  Nepal . Future Care DPS Illustration System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuManageData;
        private System.Windows.Forms.ToolStripMenuItem mnuTest;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel tssDate;
        private System.Windows.Forms.ToolStripStatusLabel tssTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem dPSScemesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dPSGOLDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dPSSILVERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dPSBRONZEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dPSScemesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dPSGOLDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsFormList;
        private System.Windows.Forms.ToolStripButton tsFormClose;
        private MyFormBar tsMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}