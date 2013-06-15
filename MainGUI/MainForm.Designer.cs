namespace MainGUI
{
    partial class MAIN_GUI
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
            if(disposing && (components != null))
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataLoggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataLogging_New = new System.Windows.Forms.ToolStripMenuItem();
            this.DataLogging_SaveData = new System.Windows.Forms.ToolStripMenuItem();
            this.DataLogging_SaveDataAs = new System.Windows.Forms.ToolStripMenuItem();
            this.Data_Logging_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com2 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com3 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com4 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com5 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com6 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com7 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com8 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com9 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com10 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com11 = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPort_Com12 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_BaudRate = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_BaudRate_2400 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_BaudRate_4800 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_BaudRate_9600 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_BaudRate_19200 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_BaudRate_38400 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_BaudRate_57600 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_BaudRate_115200 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_GraphRefreshRate = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_GrapRefreshRate100 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_GrapRefreshRate250 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_GrapRefreshRate500 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_GrapRefreshRate1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_GrapRefreshRate2000 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_GrapRefreshRate5000 = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.dashboardTab = new System.Windows.Forms.TabPage();
            this.googleStreetViewBrowser = new System.Windows.Forms.WebBrowser();
            this.saveImageButton = new System.Windows.Forms.Button();
            this.recordVideoButton = new System.Windows.Forms.Button();
            this.googleMapsBrowser = new System.Windows.Forms.WebBrowser();
            this.enableKeyboardControl = new System.Windows.Forms.Button();
            this.audSrcLbl = new System.Windows.Forms.Label();
            this.vidSrcLabel = new System.Windows.Forms.Label();
            this.audioSrcComboBox = new System.Windows.Forms.ComboBox();
            this.videoSrcComboBox = new System.Windows.Forms.ComboBox();
            this.viewVideoBtn = new System.Windows.Forms.Button();
            this.panelVideoPreview = new System.Windows.Forms.Panel();
            this.headingLabel = new System.Windows.Forms.Label();
            this.dataTab = new System.Windows.Forms.TabPage();
            this.moduleIDTextBox = new System.Windows.Forms.TextBox();
            this.dataPlotButton = new System.Windows.Forms.Button();
            this.dataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.googleMapsTab = new System.Windows.Forms.TabPage();
            this.loadGmapsBtn = new System.Windows.Forms.Button();
            this.bigGoogleMapsBrowser = new System.Windows.Forms.WebBrowser();
            this.environmentTab = new System.Windows.Forms.TabPage();
            this.imuDataDisplay = new System.Windows.Forms.GroupBox();
            this.yawLbl = new System.Windows.Forms.Label();
            this.pitchLbl = new System.Windows.Forms.Label();
            this.rollLbl = new System.Windows.Forms.Label();
            this.envDataDisplay = new System.Windows.Forms.GroupBox();
            this.temperatureLbl = new System.Windows.Forms.Label();
            this.humidityLbl = new System.Windows.Forms.Label();
            this.accDataDisplay = new System.Windows.Forms.GroupBox();
            this.accZLbl = new System.Windows.Forms.Label();
            this.accYLbl = new System.Windows.Forms.Label();
            this.accXLbl = new System.Windows.Forms.Label();
            this.biometricsTab = new System.Windows.Forms.TabPage();
            this.heartRateDisplay = new System.Windows.Forms.GroupBox();
            this.HRLbl = new System.Windows.Forms.Label();
            this.minitankTab = new System.Windows.Forms.TabPage();
            this.debugtestButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.clrDebugButton = new System.Windows.Forms.Button();
            this.comLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.GUIbackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.guiRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.watchRawDataButton = new System.Windows.Forms.Button();
            this.plotBackgoundWorker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CAS_DataDisplay = new System.Windows.Forms.GroupBox();
            this.CAS_FrontLbl = new System.Windows.Forms.Label();
            this.CAS_RearLbl = new System.Windows.Forms.Label();
            this.CAS_LeftLbl = new System.Windows.Forms.Label();
            this.CAS_RightLbl = new System.Windows.Forms.Label();
            this.frontcasLbl = new System.Windows.Forms.Label();
            this.leftcasLbl = new System.Windows.Forms.Label();
            this.rightcasLbl = new System.Windows.Forms.Label();
            this.rearcasLbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.dashboardTab.SuspendLayout();
            this.panelVideoPreview.SuspendLayout();
            this.dataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).BeginInit();
            this.googleMapsTab.SuspendLayout();
            this.environmentTab.SuspendLayout();
            this.imuDataDisplay.SuspendLayout();
            this.envDataDisplay.SuspendLayout();
            this.accDataDisplay.SuspendLayout();
            this.biometricsTab.SuspendLayout();
            this.heartRateDisplay.SuspendLayout();
            this.CAS_DataDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 38400;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataLoggingToolStripMenuItem,
            this.serialPortToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataLoggingToolStripMenuItem
            // 
            this.dataLoggingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataLogging_New,
            this.DataLogging_SaveData,
            this.DataLogging_SaveDataAs,
            this.Data_Logging_Open});
            this.dataLoggingToolStripMenuItem.Name = "dataLoggingToolStripMenuItem";
            this.dataLoggingToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.dataLoggingToolStripMenuItem.Text = "Data Logging";
            // 
            // DataLogging_New
            // 
            this.DataLogging_New.Name = "DataLogging_New";
            this.DataLogging_New.Size = new System.Drawing.Size(141, 22);
            this.DataLogging_New.Text = "New";
            this.DataLogging_New.Click += new System.EventHandler(this.DataLogging_New_Click);
            // 
            // DataLogging_SaveData
            // 
            this.DataLogging_SaveData.Name = "DataLogging_SaveData";
            this.DataLogging_SaveData.Size = new System.Drawing.Size(141, 22);
            this.DataLogging_SaveData.Text = "Save Data";
            this.DataLogging_SaveData.Click += new System.EventHandler(this.DataLogging_SaveData_Click);
            // 
            // DataLogging_SaveDataAs
            // 
            this.DataLogging_SaveDataAs.Name = "DataLogging_SaveDataAs";
            this.DataLogging_SaveDataAs.Size = new System.Drawing.Size(141, 22);
            this.DataLogging_SaveDataAs.Text = "Save Data As";
            this.DataLogging_SaveDataAs.Click += new System.EventHandler(this.DataLogging_SaveDataAs_Click);
            // 
            // Data_Logging_Open
            // 
            this.Data_Logging_Open.Name = "Data_Logging_Open";
            this.Data_Logging_Open.Size = new System.Drawing.Size(141, 22);
            this.Data_Logging_Open.Text = "Open";
            this.Data_Logging_Open.Click += new System.EventHandler(this.Data_Logging_Open_Click);
            // 
            // serialPortToolStripMenuItem
            // 
            this.serialPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SerialPort_Com1,
            this.SerialPort_Com2,
            this.SerialPort_Com3,
            this.SerialPort_Com4,
            this.SerialPort_Com5,
            this.SerialPort_Com6,
            this.SerialPort_Com7,
            this.SerialPort_Com8,
            this.SerialPort_Com9,
            this.SerialPort_Com10,
            this.SerialPort_Com11,
            this.SerialPort_Com12});
            this.serialPortToolStripMenuItem.Name = "serialPortToolStripMenuItem";
            this.serialPortToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.serialPortToolStripMenuItem.Text = "Serial Port";
            this.serialPortToolStripMenuItem.Click += new System.EventHandler(this.serialPortToolStripMenuItem_Click);
            // 
            // SerialPort_Com1
            // 
            this.SerialPort_Com1.CheckOnClick = true;
            this.SerialPort_Com1.Name = "SerialPort_Com1";
            this.SerialPort_Com1.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com1.Text = "COM1";
            this.SerialPort_Com1.Visible = false;
            this.SerialPort_Com1.Click += new System.EventHandler(this.SerialPort_Com1_Click);
            // 
            // SerialPort_Com2
            // 
            this.SerialPort_Com2.CheckOnClick = true;
            this.SerialPort_Com2.Name = "SerialPort_Com2";
            this.SerialPort_Com2.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com2.Text = "COM2";
            this.SerialPort_Com2.Visible = false;
            this.SerialPort_Com2.Click += new System.EventHandler(this.SerialPort_Com2_Click);
            // 
            // SerialPort_Com3
            // 
            this.SerialPort_Com3.CheckOnClick = true;
            this.SerialPort_Com3.Name = "SerialPort_Com3";
            this.SerialPort_Com3.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com3.Text = "COM3";
            this.SerialPort_Com3.Visible = false;
            this.SerialPort_Com3.Click += new System.EventHandler(this.SerialPort_Com3_Click);
            // 
            // SerialPort_Com4
            // 
            this.SerialPort_Com4.CheckOnClick = true;
            this.SerialPort_Com4.Name = "SerialPort_Com4";
            this.SerialPort_Com4.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com4.Text = "COM4";
            this.SerialPort_Com4.Visible = false;
            this.SerialPort_Com4.Click += new System.EventHandler(this.SerialPort_Com4_Click);
            // 
            // SerialPort_Com5
            // 
            this.SerialPort_Com5.CheckOnClick = true;
            this.SerialPort_Com5.Name = "SerialPort_Com5";
            this.SerialPort_Com5.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com5.Text = "COM5";
            this.SerialPort_Com5.Visible = false;
            this.SerialPort_Com5.Click += new System.EventHandler(this.SerialPort_Com5_Click);
            // 
            // SerialPort_Com6
            // 
            this.SerialPort_Com6.CheckOnClick = true;
            this.SerialPort_Com6.Name = "SerialPort_Com6";
            this.SerialPort_Com6.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com6.Text = "COM6";
            this.SerialPort_Com6.Visible = false;
            this.SerialPort_Com6.Click += new System.EventHandler(this.SerialPort_Com6_Click);
            // 
            // SerialPort_Com7
            // 
            this.SerialPort_Com7.CheckOnClick = true;
            this.SerialPort_Com7.Name = "SerialPort_Com7";
            this.SerialPort_Com7.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com7.Text = "COM7";
            this.SerialPort_Com7.Visible = false;
            this.SerialPort_Com7.Click += new System.EventHandler(this.SerialPort_Com7_Click);
            // 
            // SerialPort_Com8
            // 
            this.SerialPort_Com8.CheckOnClick = true;
            this.SerialPort_Com8.Name = "SerialPort_Com8";
            this.SerialPort_Com8.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com8.Text = "COM8";
            this.SerialPort_Com8.Visible = false;
            this.SerialPort_Com8.Click += new System.EventHandler(this.SerialPort_Com8_Click);
            // 
            // SerialPort_Com9
            // 
            this.SerialPort_Com9.CheckOnClick = true;
            this.SerialPort_Com9.Name = "SerialPort_Com9";
            this.SerialPort_Com9.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com9.Text = "COM9";
            this.SerialPort_Com9.Visible = false;
            this.SerialPort_Com9.Click += new System.EventHandler(this.SerialPort_Com9_Click);
            // 
            // SerialPort_Com10
            // 
            this.SerialPort_Com10.CheckOnClick = true;
            this.SerialPort_Com10.Name = "SerialPort_Com10";
            this.SerialPort_Com10.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com10.Text = "COM10";
            this.SerialPort_Com10.Visible = false;
            this.SerialPort_Com10.Click += new System.EventHandler(this.SerialPort_Com10_Click);
            // 
            // SerialPort_Com11
            // 
            this.SerialPort_Com11.CheckOnClick = true;
            this.SerialPort_Com11.Name = "SerialPort_Com11";
            this.SerialPort_Com11.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com11.Text = "COM11";
            this.SerialPort_Com11.Visible = false;
            this.SerialPort_Com11.Click += new System.EventHandler(this.SerialPort_Com11_Click);
            // 
            // SerialPort_Com12
            // 
            this.SerialPort_Com12.CheckOnClick = true;
            this.SerialPort_Com12.Name = "SerialPort_Com12";
            this.SerialPort_Com12.Size = new System.Drawing.Size(114, 22);
            this.SerialPort_Com12.Text = "COM12";
            this.SerialPort_Com12.Visible = false;
            this.SerialPort_Com12.Click += new System.EventHandler(this.SerialPort_Com12_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings_BaudRate,
            this.Settings_GraphRefreshRate,
            this.cameraResolutionToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // Settings_BaudRate
            // 
            this.Settings_BaudRate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings_BaudRate_2400,
            this.Settings_BaudRate_4800,
            this.Settings_BaudRate_9600,
            this.Settings_BaudRate_19200,
            this.Settings_BaudRate_38400,
            this.Settings_BaudRate_57600,
            this.Settings_BaudRate_115200});
            this.Settings_BaudRate.Name = "Settings_BaudRate";
            this.Settings_BaudRate.Size = new System.Drawing.Size(174, 22);
            this.Settings_BaudRate.Text = "Baud Rate";
            // 
            // Settings_BaudRate_2400
            // 
            this.Settings_BaudRate_2400.CheckOnClick = true;
            this.Settings_BaudRate_2400.Name = "Settings_BaudRate_2400";
            this.Settings_BaudRate_2400.Size = new System.Drawing.Size(110, 22);
            this.Settings_BaudRate_2400.Text = "2400";
            this.Settings_BaudRate_2400.Click += new System.EventHandler(this.Settings_BaudRate_2400_Click);
            // 
            // Settings_BaudRate_4800
            // 
            this.Settings_BaudRate_4800.CheckOnClick = true;
            this.Settings_BaudRate_4800.Name = "Settings_BaudRate_4800";
            this.Settings_BaudRate_4800.Size = new System.Drawing.Size(110, 22);
            this.Settings_BaudRate_4800.Text = "4800";
            this.Settings_BaudRate_4800.Click += new System.EventHandler(this.Settings_BaudRate_4800_Click);
            // 
            // Settings_BaudRate_9600
            // 
            this.Settings_BaudRate_9600.CheckOnClick = true;
            this.Settings_BaudRate_9600.Name = "Settings_BaudRate_9600";
            this.Settings_BaudRate_9600.Size = new System.Drawing.Size(110, 22);
            this.Settings_BaudRate_9600.Text = "9600";
            this.Settings_BaudRate_9600.Click += new System.EventHandler(this.Settings_BaudRate_9600_Click);
            // 
            // Settings_BaudRate_19200
            // 
            this.Settings_BaudRate_19200.CheckOnClick = true;
            this.Settings_BaudRate_19200.Name = "Settings_BaudRate_19200";
            this.Settings_BaudRate_19200.Size = new System.Drawing.Size(110, 22);
            this.Settings_BaudRate_19200.Text = "19200";
            this.Settings_BaudRate_19200.Click += new System.EventHandler(this.Settings_BaudRate_19200_Click);
            // 
            // Settings_BaudRate_38400
            // 
            this.Settings_BaudRate_38400.CheckOnClick = true;
            this.Settings_BaudRate_38400.Name = "Settings_BaudRate_38400";
            this.Settings_BaudRate_38400.Size = new System.Drawing.Size(110, 22);
            this.Settings_BaudRate_38400.Text = "38400";
            this.Settings_BaudRate_38400.Click += new System.EventHandler(this.Settings_BaudRate_38400_Click);
            // 
            // Settings_BaudRate_57600
            // 
            this.Settings_BaudRate_57600.CheckOnClick = true;
            this.Settings_BaudRate_57600.Name = "Settings_BaudRate_57600";
            this.Settings_BaudRate_57600.Size = new System.Drawing.Size(110, 22);
            this.Settings_BaudRate_57600.Text = "57600";
            this.Settings_BaudRate_57600.Click += new System.EventHandler(this.Settings_BaudRate_57600_Click);
            // 
            // Settings_BaudRate_115200
            // 
            this.Settings_BaudRate_115200.CheckOnClick = true;
            this.Settings_BaudRate_115200.Name = "Settings_BaudRate_115200";
            this.Settings_BaudRate_115200.Size = new System.Drawing.Size(110, 22);
            this.Settings_BaudRate_115200.Text = "115200";
            this.Settings_BaudRate_115200.Click += new System.EventHandler(this.Settings_BaudRate_115200_Click);
            // 
            // Settings_GraphRefreshRate
            // 
            this.Settings_GraphRefreshRate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings_GrapRefreshRate100,
            this.Settings_GrapRefreshRate250,
            this.Settings_GrapRefreshRate500,
            this.Settings_GrapRefreshRate1000,
            this.Settings_GrapRefreshRate2000,
            this.Settings_GrapRefreshRate5000});
            this.Settings_GraphRefreshRate.Name = "Settings_GraphRefreshRate";
            this.Settings_GraphRefreshRate.Size = new System.Drawing.Size(174, 22);
            this.Settings_GraphRefreshRate.Text = "Graph Refresh Rate";
            // 
            // Settings_GrapRefreshRate100
            // 
            this.Settings_GrapRefreshRate100.CheckOnClick = true;
            this.Settings_GrapRefreshRate100.Name = "Settings_GrapRefreshRate100";
            this.Settings_GrapRefreshRate100.Size = new System.Drawing.Size(98, 22);
            this.Settings_GrapRefreshRate100.Text = "100";
            this.Settings_GrapRefreshRate100.Click += new System.EventHandler(this.Settings_GrapRefreshRate100_Click);
            // 
            // Settings_GrapRefreshRate250
            // 
            this.Settings_GrapRefreshRate250.CheckOnClick = true;
            this.Settings_GrapRefreshRate250.Name = "Settings_GrapRefreshRate250";
            this.Settings_GrapRefreshRate250.Size = new System.Drawing.Size(98, 22);
            this.Settings_GrapRefreshRate250.Text = "250";
            this.Settings_GrapRefreshRate250.Click += new System.EventHandler(this.Settings_GrapRefreshRate250_Click);
            // 
            // Settings_GrapRefreshRate500
            // 
            this.Settings_GrapRefreshRate500.CheckOnClick = true;
            this.Settings_GrapRefreshRate500.Name = "Settings_GrapRefreshRate500";
            this.Settings_GrapRefreshRate500.Size = new System.Drawing.Size(98, 22);
            this.Settings_GrapRefreshRate500.Text = "500";
            this.Settings_GrapRefreshRate500.Click += new System.EventHandler(this.Settings_GrapRefreshRate500_Click);
            // 
            // Settings_GrapRefreshRate1000
            // 
            this.Settings_GrapRefreshRate1000.CheckOnClick = true;
            this.Settings_GrapRefreshRate1000.Name = "Settings_GrapRefreshRate1000";
            this.Settings_GrapRefreshRate1000.Size = new System.Drawing.Size(98, 22);
            this.Settings_GrapRefreshRate1000.Text = "1000";
            this.Settings_GrapRefreshRate1000.Click += new System.EventHandler(this.Settings_GrapRefreshRate1000_Click);
            // 
            // Settings_GrapRefreshRate2000
            // 
            this.Settings_GrapRefreshRate2000.CheckOnClick = true;
            this.Settings_GrapRefreshRate2000.Name = "Settings_GrapRefreshRate2000";
            this.Settings_GrapRefreshRate2000.Size = new System.Drawing.Size(98, 22);
            this.Settings_GrapRefreshRate2000.Text = "2000";
            this.Settings_GrapRefreshRate2000.Click += new System.EventHandler(this.Settings_GrapRefreshRate2000_Click);
            // 
            // Settings_GrapRefreshRate5000
            // 
            this.Settings_GrapRefreshRate5000.CheckOnClick = true;
            this.Settings_GrapRefreshRate5000.Name = "Settings_GrapRefreshRate5000";
            this.Settings_GrapRefreshRate5000.Size = new System.Drawing.Size(98, 22);
            this.Settings_GrapRefreshRate5000.Text = "5000";
            this.Settings_GrapRefreshRate5000.Click += new System.EventHandler(this.Settings_GrapRefreshRate5000_Click);
            // 
            // cameraResolutionToolStripMenuItem
            // 
            this.cameraResolutionToolStripMenuItem.Name = "cameraResolutionToolStripMenuItem";
            this.cameraResolutionToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.cameraResolutionToolStripMenuItem.Text = "Camera Resolution";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "smp";
            this.saveFileDialog1.Title = "Save Module Data";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.dashboardTab);
            this.tabControl.Controls.Add(this.dataTab);
            this.tabControl.Controls.Add(this.googleMapsTab);
            this.tabControl.Controls.Add(this.environmentTab);
            this.tabControl.Controls.Add(this.biometricsTab);
            this.tabControl.Controls.Add(this.minitankTab);
            this.tabControl.Location = new System.Drawing.Point(12, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1240, 579);
            this.tabControl.TabIndex = 14;
            // 
            // dashboardTab
            // 
            this.dashboardTab.BackColor = System.Drawing.SystemColors.Control;
            this.dashboardTab.Controls.Add(this.googleStreetViewBrowser);
            this.dashboardTab.Controls.Add(this.saveImageButton);
            this.dashboardTab.Controls.Add(this.recordVideoButton);
            this.dashboardTab.Controls.Add(this.googleMapsBrowser);
            this.dashboardTab.Controls.Add(this.enableKeyboardControl);
            this.dashboardTab.Controls.Add(this.audSrcLbl);
            this.dashboardTab.Controls.Add(this.vidSrcLabel);
            this.dashboardTab.Controls.Add(this.audioSrcComboBox);
            this.dashboardTab.Controls.Add(this.videoSrcComboBox);
            this.dashboardTab.Controls.Add(this.viewVideoBtn);
            this.dashboardTab.Controls.Add(this.panelVideoPreview);
            this.dashboardTab.Location = new System.Drawing.Point(4, 22);
            this.dashboardTab.Name = "dashboardTab";
            this.dashboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.dashboardTab.Size = new System.Drawing.Size(1232, 553);
            this.dashboardTab.TabIndex = 0;
            this.dashboardTab.Text = "Main Dashboard";
            // 
            // googleStreetViewBrowser
            // 
            this.googleStreetViewBrowser.AllowWebBrowserDrop = false;
            this.googleStreetViewBrowser.Location = new System.Drawing.Point(6, 215);
            this.googleStreetViewBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.googleStreetViewBrowser.Name = "googleStreetViewBrowser";
            this.googleStreetViewBrowser.ScrollBarsEnabled = false;
            this.googleStreetViewBrowser.Size = new System.Drawing.Size(200, 200);
            this.googleStreetViewBrowser.TabIndex = 43;
            this.googleStreetViewBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.googleStreetViewBrowser.Visible = false;
            // 
            // saveImageButton
            // 
            this.saveImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveImageButton.Location = new System.Drawing.Point(619, 517);
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(75, 23);
            this.saveImageButton.TabIndex = 42;
            this.saveImageButton.Text = "Save Img";
            this.saveImageButton.UseVisualStyleBackColor = true;
            this.saveImageButton.Click += new System.EventHandler(this.saveImageButton_Click);
            // 
            // recordVideoButton
            // 
            this.recordVideoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordVideoButton.Location = new System.Drawing.Point(538, 517);
            this.recordVideoButton.Name = "recordVideoButton";
            this.recordVideoButton.Size = new System.Drawing.Size(75, 23);
            this.recordVideoButton.TabIndex = 41;
            this.recordVideoButton.Text = "Record";
            this.recordVideoButton.UseVisualStyleBackColor = true;
            this.recordVideoButton.Click += new System.EventHandler(this.recordVideoButton_Click);
            // 
            // googleMapsBrowser
            // 
            this.googleMapsBrowser.AllowWebBrowserDrop = false;
            this.googleMapsBrowser.Location = new System.Drawing.Point(6, 9);
            this.googleMapsBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.googleMapsBrowser.Name = "googleMapsBrowser";
            this.googleMapsBrowser.ScrollBarsEnabled = false;
            this.googleMapsBrowser.Size = new System.Drawing.Size(200, 200);
            this.googleMapsBrowser.TabIndex = 39;
            this.googleMapsBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.googleMapsBrowser.Visible = false;
            // 
            // enableKeyboardControl
            // 
            this.enableKeyboardControl.Location = new System.Drawing.Point(1018, 495);
            this.enableKeyboardControl.Name = "enableKeyboardControl";
            this.enableKeyboardControl.Size = new System.Drawing.Size(105, 23);
            this.enableKeyboardControl.TabIndex = 35;
            this.enableKeyboardControl.Text = "Enable Control";
            this.enableKeyboardControl.UseVisualStyleBackColor = true;
            this.enableKeyboardControl.Click += new System.EventHandler(this.enableKeyboardControl_Click);
            // 
            // audSrcLbl
            // 
            this.audSrcLbl.AutoSize = true;
            this.audSrcLbl.Location = new System.Drawing.Point(224, 522);
            this.audSrcLbl.Name = "audSrcLbl";
            this.audSrcLbl.Size = new System.Drawing.Size(71, 13);
            this.audSrcLbl.TabIndex = 33;
            this.audSrcLbl.Text = "Audio Source";
            // 
            // vidSrcLabel
            // 
            this.vidSrcLabel.AutoSize = true;
            this.vidSrcLabel.Location = new System.Drawing.Point(224, 495);
            this.vidSrcLabel.Name = "vidSrcLabel";
            this.vidSrcLabel.Size = new System.Drawing.Size(71, 13);
            this.vidSrcLabel.TabIndex = 32;
            this.vidSrcLabel.Text = "Video Source";
            // 
            // audioSrcComboBox
            // 
            this.audioSrcComboBox.FormattingEnabled = true;
            this.audioSrcComboBox.Location = new System.Drawing.Point(301, 519);
            this.audioSrcComboBox.Name = "audioSrcComboBox";
            this.audioSrcComboBox.Size = new System.Drawing.Size(231, 21);
            this.audioSrcComboBox.TabIndex = 31;
            // 
            // videoSrcComboBox
            // 
            this.videoSrcComboBox.FormattingEnabled = true;
            this.videoSrcComboBox.Location = new System.Drawing.Point(301, 492);
            this.videoSrcComboBox.Name = "videoSrcComboBox";
            this.videoSrcComboBox.Size = new System.Drawing.Size(231, 21);
            this.videoSrcComboBox.TabIndex = 30;
            // 
            // viewVideoBtn
            // 
            this.viewVideoBtn.Location = new System.Drawing.Point(538, 490);
            this.viewVideoBtn.Name = "viewVideoBtn";
            this.viewVideoBtn.Size = new System.Drawing.Size(75, 23);
            this.viewVideoBtn.TabIndex = 25;
            this.viewVideoBtn.Text = "View Video";
            this.viewVideoBtn.UseVisualStyleBackColor = true;
            this.viewVideoBtn.Click += new System.EventHandler(this.viewVideoBtn_Click);
            // 
            // panelVideoPreview
            // 
            this.panelVideoPreview.Controls.Add(this.rearcasLbl);
            this.panelVideoPreview.Controls.Add(this.rightcasLbl);
            this.panelVideoPreview.Controls.Add(this.leftcasLbl);
            this.panelVideoPreview.Controls.Add(this.frontcasLbl);
            this.panelVideoPreview.Controls.Add(this.headingLabel);
            this.panelVideoPreview.Location = new System.Drawing.Point(227, 9);
            this.panelVideoPreview.MaximumSize = new System.Drawing.Size(1280, 720);
            this.panelVideoPreview.Name = "panelVideoPreview";
            this.panelVideoPreview.Size = new System.Drawing.Size(896, 480);
            this.panelVideoPreview.TabIndex = 24;
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.BackColor = System.Drawing.Color.Transparent;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.Location = new System.Drawing.Point(829, 0);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(43, 39);
            this.headingLabel.TabIndex = 0;
            this.headingLabel.Text = "N";
            this.headingLabel.Visible = false;
            // 
            // dataTab
            // 
            this.dataTab.BackColor = System.Drawing.SystemColors.Control;
            this.dataTab.Controls.Add(this.moduleIDTextBox);
            this.dataTab.Controls.Add(this.dataPlotButton);
            this.dataTab.Controls.Add(this.dataGraph);
            this.dataTab.Location = new System.Drawing.Point(4, 22);
            this.dataTab.Name = "dataTab";
            this.dataTab.Padding = new System.Windows.Forms.Padding(3);
            this.dataTab.Size = new System.Drawing.Size(1232, 553);
            this.dataTab.TabIndex = 1;
            this.dataTab.Text = "Data";
            // 
            // moduleIDTextBox
            // 
            this.moduleIDTextBox.Location = new System.Drawing.Point(871, 82);
            this.moduleIDTextBox.Name = "moduleIDTextBox";
            this.moduleIDTextBox.Size = new System.Drawing.Size(43, 20);
            this.moduleIDTextBox.TabIndex = 0;
            this.moduleIDTextBox.TextChanged += new System.EventHandler(this.moduleIDTextBox_TextChanged);
            // 
            // dataPlotButton
            // 
            this.dataPlotButton.Location = new System.Drawing.Point(920, 79);
            this.dataPlotButton.Name = "dataPlotButton";
            this.dataPlotButton.Size = new System.Drawing.Size(107, 23);
            this.dataPlotButton.TabIndex = 1;
            this.dataPlotButton.Text = "Plot";
            this.dataPlotButton.UseVisualStyleBackColor = true;
            this.dataPlotButton.Click += new System.EventHandler(this.dataPlotButton_Click);
            // 
            // dataGraph
            // 
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LabelStyle.Angle = 90;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            chartArea2.AxisX.LabelStyle.Interval = 0D;
            chartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorGrid.LineWidth = 2;
            chartArea2.AxisX.MaximumAutoSize = 100F;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisX.Title = "Time Recieved";
            chartArea2.Name = "ChartArea1";
            this.dataGraph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.dataGraph.Legends.Add(legend2);
            this.dataGraph.Location = new System.Drawing.Point(63, 107);
            this.dataGraph.Name = "dataGraph";
            this.dataGraph.Size = new System.Drawing.Size(964, 440);
            this.dataGraph.TabIndex = 0;
            this.dataGraph.Text = "Module Data";
            // 
            // googleMapsTab
            // 
            this.googleMapsTab.BackColor = System.Drawing.SystemColors.Control;
            this.googleMapsTab.Controls.Add(this.loadGmapsBtn);
            this.googleMapsTab.Controls.Add(this.bigGoogleMapsBrowser);
            this.googleMapsTab.Location = new System.Drawing.Point(4, 22);
            this.googleMapsTab.Name = "googleMapsTab";
            this.googleMapsTab.Padding = new System.Windows.Forms.Padding(3);
            this.googleMapsTab.Size = new System.Drawing.Size(1232, 553);
            this.googleMapsTab.TabIndex = 2;
            this.googleMapsTab.Text = "Maps";
            // 
            // loadGmapsBtn
            // 
            this.loadGmapsBtn.Location = new System.Drawing.Point(688, 505);
            this.loadGmapsBtn.Name = "loadGmapsBtn";
            this.loadGmapsBtn.Size = new System.Drawing.Size(72, 27);
            this.loadGmapsBtn.TabIndex = 41;
            this.loadGmapsBtn.Text = "Load";
            this.loadGmapsBtn.UseVisualStyleBackColor = true;
            this.loadGmapsBtn.Click += new System.EventHandler(this.loadGmapsBtn_Click);
            // 
            // bigGoogleMapsBrowser
            // 
            this.bigGoogleMapsBrowser.AllowWebBrowserDrop = false;
            this.bigGoogleMapsBrowser.Location = new System.Drawing.Point(160, 19);
            this.bigGoogleMapsBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.bigGoogleMapsBrowser.Name = "bigGoogleMapsBrowser";
            this.bigGoogleMapsBrowser.ScrollBarsEnabled = false;
            this.bigGoogleMapsBrowser.Size = new System.Drawing.Size(600, 480);
            this.bigGoogleMapsBrowser.TabIndex = 40;
            this.bigGoogleMapsBrowser.Url = new System.Uri("http://maps.googleapis.com/maps/api/staticmap?&size=600x480&key=AIzaSyBAjzQzZl73y" +
        "lfFexJu3nbexI6pj4AK_l8&sensor=true", System.UriKind.Absolute);
            // 
            // environmentTab
            // 
            this.environmentTab.BackColor = System.Drawing.SystemColors.Control;
            this.environmentTab.Controls.Add(this.CAS_DataDisplay);
            this.environmentTab.Controls.Add(this.imuDataDisplay);
            this.environmentTab.Controls.Add(this.envDataDisplay);
            this.environmentTab.Controls.Add(this.accDataDisplay);
            this.environmentTab.Location = new System.Drawing.Point(4, 22);
            this.environmentTab.Name = "environmentTab";
            this.environmentTab.Size = new System.Drawing.Size(1232, 553);
            this.environmentTab.TabIndex = 3;
            this.environmentTab.Text = "Environment";
            // 
            // imuDataDisplay
            // 
            this.imuDataDisplay.Controls.Add(this.yawLbl);
            this.imuDataDisplay.Controls.Add(this.pitchLbl);
            this.imuDataDisplay.Controls.Add(this.rollLbl);
            this.imuDataDisplay.Location = new System.Drawing.Point(1118, 80);
            this.imuDataDisplay.Name = "imuDataDisplay";
            this.imuDataDisplay.Size = new System.Drawing.Size(97, 60);
            this.imuDataDisplay.TabIndex = 47;
            this.imuDataDisplay.TabStop = false;
            this.imuDataDisplay.Text = "IMU";
            this.imuDataDisplay.Visible = false;
            // 
            // yawLbl
            // 
            this.yawLbl.AutoSize = true;
            this.yawLbl.Location = new System.Drawing.Point(6, 42);
            this.yawLbl.Name = "yawLbl";
            this.yawLbl.Size = new System.Drawing.Size(31, 13);
            this.yawLbl.TabIndex = 2;
            this.yawLbl.Text = "Yaw:";
            // 
            // pitchLbl
            // 
            this.pitchLbl.AutoSize = true;
            this.pitchLbl.Location = new System.Drawing.Point(6, 29);
            this.pitchLbl.Name = "pitchLbl";
            this.pitchLbl.Size = new System.Drawing.Size(34, 13);
            this.pitchLbl.TabIndex = 1;
            this.pitchLbl.Text = "Pitch:";
            // 
            // rollLbl
            // 
            this.rollLbl.AutoSize = true;
            this.rollLbl.Location = new System.Drawing.Point(6, 16);
            this.rollLbl.Name = "rollLbl";
            this.rollLbl.Size = new System.Drawing.Size(28, 13);
            this.rollLbl.TabIndex = 0;
            this.rollLbl.Text = "Roll:";
            // 
            // envDataDisplay
            // 
            this.envDataDisplay.Controls.Add(this.temperatureLbl);
            this.envDataDisplay.Controls.Add(this.humidityLbl);
            this.envDataDisplay.Location = new System.Drawing.Point(1118, 146);
            this.envDataDisplay.Name = "envDataDisplay";
            this.envDataDisplay.Size = new System.Drawing.Size(97, 47);
            this.envDataDisplay.TabIndex = 46;
            this.envDataDisplay.TabStop = false;
            this.envDataDisplay.Text = "Environment Data";
            this.envDataDisplay.Visible = false;
            // 
            // temperatureLbl
            // 
            this.temperatureLbl.AutoSize = true;
            this.temperatureLbl.Location = new System.Drawing.Point(6, 29);
            this.temperatureLbl.Name = "temperatureLbl";
            this.temperatureLbl.Size = new System.Drawing.Size(63, 13);
            this.temperatureLbl.TabIndex = 3;
            this.temperatureLbl.Text = "temperature";
            // 
            // humidityLbl
            // 
            this.humidityLbl.AutoSize = true;
            this.humidityLbl.Location = new System.Drawing.Point(6, 16);
            this.humidityLbl.Name = "humidityLbl";
            this.humidityLbl.Size = new System.Drawing.Size(45, 13);
            this.humidityLbl.TabIndex = 1;
            this.humidityLbl.Text = "humidity";
            // 
            // accDataDisplay
            // 
            this.accDataDisplay.Controls.Add(this.accZLbl);
            this.accDataDisplay.Controls.Add(this.accYLbl);
            this.accDataDisplay.Controls.Add(this.accXLbl);
            this.accDataDisplay.Location = new System.Drawing.Point(1118, 14);
            this.accDataDisplay.Name = "accDataDisplay";
            this.accDataDisplay.Size = new System.Drawing.Size(97, 60);
            this.accDataDisplay.TabIndex = 45;
            this.accDataDisplay.TabStop = false;
            this.accDataDisplay.Text = "Accelerometer Data";
            this.accDataDisplay.Visible = false;
            // 
            // accZLbl
            // 
            this.accZLbl.AutoSize = true;
            this.accZLbl.Location = new System.Drawing.Point(6, 42);
            this.accZLbl.Name = "accZLbl";
            this.accZLbl.Size = new System.Drawing.Size(31, 13);
            this.accZLbl.TabIndex = 2;
            this.accZLbl.Text = "zAxis";
            // 
            // accYLbl
            // 
            this.accYLbl.AutoSize = true;
            this.accYLbl.Location = new System.Drawing.Point(6, 29);
            this.accYLbl.Name = "accYLbl";
            this.accYLbl.Size = new System.Drawing.Size(31, 13);
            this.accYLbl.TabIndex = 1;
            this.accYLbl.Text = "yAxis";
            // 
            // accXLbl
            // 
            this.accXLbl.AutoSize = true;
            this.accXLbl.Location = new System.Drawing.Point(6, 16);
            this.accXLbl.Name = "accXLbl";
            this.accXLbl.Size = new System.Drawing.Size(31, 13);
            this.accXLbl.TabIndex = 0;
            this.accXLbl.Text = "xAxis";
            // 
            // biometricsTab
            // 
            this.biometricsTab.BackColor = System.Drawing.SystemColors.Control;
            this.biometricsTab.Controls.Add(this.heartRateDisplay);
            this.biometricsTab.Location = new System.Drawing.Point(4, 22);
            this.biometricsTab.Name = "biometricsTab";
            this.biometricsTab.Size = new System.Drawing.Size(1232, 553);
            this.biometricsTab.TabIndex = 4;
            this.biometricsTab.Text = "Biometrics";
            // 
            // heartRateDisplay
            // 
            this.heartRateDisplay.Controls.Add(this.HRLbl);
            this.heartRateDisplay.Location = new System.Drawing.Point(1104, 22);
            this.heartRateDisplay.Name = "heartRateDisplay";
            this.heartRateDisplay.Size = new System.Drawing.Size(97, 60);
            this.heartRateDisplay.TabIndex = 46;
            this.heartRateDisplay.TabStop = false;
            this.heartRateDisplay.Text = "Heart Rate";
            // 
            // HRLbl
            // 
            this.HRLbl.AutoSize = true;
            this.HRLbl.Location = new System.Drawing.Point(6, 16);
            this.HRLbl.Name = "HRLbl";
            this.HRLbl.Size = new System.Drawing.Size(26, 13);
            this.HRLbl.TabIndex = 0;
            this.HRLbl.Text = "HR:";
            // 
            // minitankTab
            // 
            this.minitankTab.BackColor = System.Drawing.SystemColors.Control;
            this.minitankTab.Location = new System.Drawing.Point(4, 22);
            this.minitankTab.Name = "minitankTab";
            this.minitankTab.Size = new System.Drawing.Size(1232, 553);
            this.minitankTab.TabIndex = 5;
            this.minitankTab.Text = "Mini Tank";
            // 
            // debugtestButton
            // 
            this.debugtestButton.Location = new System.Drawing.Point(920, 687);
            this.debugtestButton.Name = "debugtestButton";
            this.debugtestButton.Size = new System.Drawing.Size(66, 31);
            this.debugtestButton.TabIndex = 40;
            this.debugtestButton.Text = "Test";
            this.debugtestButton.UseVisualStyleBackColor = true;
            this.debugtestButton.Visible = false;
            this.debugtestButton.Click += new System.EventHandler(this.debugtestButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(271, 629);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(50, 25);
            this.startButton.TabIndex = 25;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // clrDebugButton
            // 
            this.clrDebugButton.Location = new System.Drawing.Point(215, 629);
            this.clrDebugButton.Name = "clrDebugButton";
            this.clrDebugButton.Size = new System.Drawing.Size(50, 25);
            this.clrDebugButton.TabIndex = 24;
            this.clrDebugButton.Text = "Clear";
            this.clrDebugButton.UseVisualStyleBackColor = true;
            this.clrDebugButton.Click += new System.EventHandler(this.clrDebugButton_Click_1);
            // 
            // comLabel
            // 
            this.comLabel.AutoSize = true;
            this.comLabel.BackColor = System.Drawing.Color.Red;
            this.comLabel.Location = new System.Drawing.Point(13, 635);
            this.comLabel.Name = "comLabel";
            this.comLabel.Size = new System.Drawing.Size(31, 13);
            this.comLabel.TabIndex = 18;
            this.comLabel.Text = "COM";
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(327, 629);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(50, 25);
            this.pauseButton.TabIndex = 17;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click_1);
            // 
            // debugTextBox
            // 
            this.debugTextBox.AcceptsReturn = true;
            this.debugTextBox.AcceptsTab = true;
            this.debugTextBox.Location = new System.Drawing.Point(16, 658);
            this.debugTextBox.Multiline = true;
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.ReadOnly = true;
            this.debugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugTextBox.Size = new System.Drawing.Size(364, 60);
            this.debugTextBox.TabIndex = 14;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 500;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // GUIbackgroundWorker
            // 
            this.GUIbackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GUIbackgroundWorker_DoWork);
            // 
            // guiRefreshTimer
            // 
            this.guiRefreshTimer.Enabled = true;
            this.guiRefreshTimer.Interval = 500;
            this.guiRefreshTimer.Tick += new System.EventHandler(this.guiRefreshTimer_Tick);
            // 
            // watchRawDataButton
            // 
            this.watchRawDataButton.Location = new System.Drawing.Point(159, 629);
            this.watchRawDataButton.Name = "watchRawDataButton";
            this.watchRawDataButton.Size = new System.Drawing.Size(50, 25);
            this.watchRawDataButton.TabIndex = 26;
            this.watchRawDataButton.Text = "Raw";
            this.watchRawDataButton.UseVisualStyleBackColor = true;
            this.watchRawDataButton.Click += new System.EventHandler(this.watchRawDataButton_Click);
            // 
            // plotBackgoundWorker
            // 
            this.plotBackgoundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.plotBackgoundWorker_DoWork);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CAS_DataDisplay
            // 
            this.CAS_DataDisplay.Controls.Add(this.CAS_RightLbl);
            this.CAS_DataDisplay.Controls.Add(this.CAS_LeftLbl);
            this.CAS_DataDisplay.Controls.Add(this.CAS_RearLbl);
            this.CAS_DataDisplay.Controls.Add(this.CAS_FrontLbl);
            this.CAS_DataDisplay.Location = new System.Drawing.Point(1118, 199);
            this.CAS_DataDisplay.Name = "CAS_DataDisplay";
            this.CAS_DataDisplay.Size = new System.Drawing.Size(97, 74);
            this.CAS_DataDisplay.TabIndex = 48;
            this.CAS_DataDisplay.TabStop = false;
            this.CAS_DataDisplay.Text = "CAS";
            // 
            // CAS_FrontLbl
            // 
            this.CAS_FrontLbl.AutoSize = true;
            this.CAS_FrontLbl.Location = new System.Drawing.Point(6, 16);
            this.CAS_FrontLbl.Name = "CAS_FrontLbl";
            this.CAS_FrontLbl.Size = new System.Drawing.Size(34, 13);
            this.CAS_FrontLbl.TabIndex = 49;
            this.CAS_FrontLbl.Text = "Front:";
            // 
            // CAS_RearLbl
            // 
            this.CAS_RearLbl.AutoSize = true;
            this.CAS_RearLbl.Location = new System.Drawing.Point(6, 29);
            this.CAS_RearLbl.Name = "CAS_RearLbl";
            this.CAS_RearLbl.Size = new System.Drawing.Size(33, 13);
            this.CAS_RearLbl.TabIndex = 50;
            this.CAS_RearLbl.Text = "Rear:";
            // 
            // CAS_LeftLbl
            // 
            this.CAS_LeftLbl.AutoSize = true;
            this.CAS_LeftLbl.Location = new System.Drawing.Point(6, 42);
            this.CAS_LeftLbl.Name = "CAS_LeftLbl";
            this.CAS_LeftLbl.Size = new System.Drawing.Size(28, 13);
            this.CAS_LeftLbl.TabIndex = 50;
            this.CAS_LeftLbl.Text = "Left:";
            // 
            // CAS_RightLbl
            // 
            this.CAS_RightLbl.AutoSize = true;
            this.CAS_RightLbl.Location = new System.Drawing.Point(6, 55);
            this.CAS_RightLbl.Name = "CAS_RightLbl";
            this.CAS_RightLbl.Size = new System.Drawing.Size(35, 13);
            this.CAS_RightLbl.TabIndex = 50;
            this.CAS_RightLbl.Text = "Right:";
            // 
            // frontcasLbl
            // 
            this.frontcasLbl.AutoSize = true;
            this.frontcasLbl.BackColor = System.Drawing.Color.Transparent;
            this.frontcasLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frontcasLbl.ForeColor = System.Drawing.Color.Lime;
            this.frontcasLbl.Location = new System.Drawing.Point(424, 0);
            this.frontcasLbl.Name = "frontcasLbl";
            this.frontcasLbl.Size = new System.Drawing.Size(28, 25);
            this.frontcasLbl.TabIndex = 44;
            this.frontcasLbl.Text = "N";
            this.frontcasLbl.Visible = false;
            // 
            // leftcasLbl
            // 
            this.leftcasLbl.AutoSize = true;
            this.leftcasLbl.BackColor = System.Drawing.Color.Transparent;
            this.leftcasLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftcasLbl.ForeColor = System.Drawing.Color.Lime;
            this.leftcasLbl.Location = new System.Drawing.Point(3, 206);
            this.leftcasLbl.Name = "leftcasLbl";
            this.leftcasLbl.Size = new System.Drawing.Size(28, 25);
            this.leftcasLbl.TabIndex = 45;
            this.leftcasLbl.Text = "N";
            this.leftcasLbl.Visible = false;
            // 
            // rightcasLbl
            // 
            this.rightcasLbl.AutoSize = true;
            this.rightcasLbl.BackColor = System.Drawing.Color.Transparent;
            this.rightcasLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightcasLbl.ForeColor = System.Drawing.Color.Lime;
            this.rightcasLbl.Location = new System.Drawing.Point(829, 206);
            this.rightcasLbl.Name = "rightcasLbl";
            this.rightcasLbl.Size = new System.Drawing.Size(28, 25);
            this.rightcasLbl.TabIndex = 46;
            this.rightcasLbl.Text = "N";
            this.rightcasLbl.Visible = false;
            // 
            // rearcasLbl
            // 
            this.rearcasLbl.AutoSize = true;
            this.rearcasLbl.BackColor = System.Drawing.Color.Transparent;
            this.rearcasLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rearcasLbl.ForeColor = System.Drawing.Color.Lime;
            this.rearcasLbl.Location = new System.Drawing.Point(424, 441);
            this.rearcasLbl.Name = "rearcasLbl";
            this.rearcasLbl.Size = new System.Drawing.Size(28, 25);
            this.rearcasLbl.TabIndex = 47;
            this.rearcasLbl.Text = "N";
            this.rearcasLbl.Visible = false;
            // 
            // MAIN_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.watchRawDataButton);
            this.Controls.Add(this.clrDebugButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.debugtestButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.comLabel);
            this.Controls.Add(this.debugTextBox);
            this.Controls.Add(this.pauseButton);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MAIN_GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Modular Platform Main GUI";
            this.Deactivate += new System.EventHandler(this.MAIN_GUI_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAIN_GUI_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MAIN_GUI_FormClosed);
            this.Load += new System.EventHandler(this.MAIN_GUI_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MAIN_GUI_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.dashboardTab.ResumeLayout(false);
            this.dashboardTab.PerformLayout();
            this.panelVideoPreview.ResumeLayout(false);
            this.panelVideoPreview.PerformLayout();
            this.dataTab.ResumeLayout(false);
            this.dataTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).EndInit();
            this.googleMapsTab.ResumeLayout(false);
            this.environmentTab.ResumeLayout(false);
            this.imuDataDisplay.ResumeLayout(false);
            this.imuDataDisplay.PerformLayout();
            this.envDataDisplay.ResumeLayout(false);
            this.envDataDisplay.PerformLayout();
            this.accDataDisplay.ResumeLayout(false);
            this.accDataDisplay.PerformLayout();
            this.biometricsTab.ResumeLayout(false);
            this.heartRateDisplay.ResumeLayout(false);
            this.heartRateDisplay.PerformLayout();
            this.CAS_DataDisplay.ResumeLayout(false);
            this.CAS_DataDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataLoggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataLogging_SaveData;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage dashboardTab;
        private System.Windows.Forms.TabPage dataTab;
        private System.Windows.Forms.Button clrDebugButton;
        private System.Windows.Forms.Label comLabel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.TextBox debugTextBox;
        private System.Windows.Forms.Timer refreshTimer;
        private System.ComponentModel.BackgroundWorker GUIbackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com6;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com1;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com2;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com3;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com4;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com5;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com7;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com8;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com9;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com10;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com11;
        private System.Windows.Forms.ToolStripMenuItem SerialPort_Com12;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Settings_BaudRate;
        private System.Windows.Forms.ToolStripMenuItem Settings_BaudRate_2400;
        private System.Windows.Forms.ToolStripMenuItem Settings_BaudRate_4800;
        private System.Windows.Forms.ToolStripMenuItem Settings_BaudRate_9600;
        private System.Windows.Forms.ToolStripMenuItem Settings_BaudRate_19200;
        private System.Windows.Forms.ToolStripMenuItem Settings_BaudRate_38400;
        private System.Windows.Forms.ToolStripMenuItem Settings_BaudRate_57600;
        private System.Windows.Forms.ToolStripMenuItem Settings_BaudRate_115200;
        private System.Windows.Forms.Button startButton;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button dataPlotButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataGraph;
        private System.Windows.Forms.TextBox moduleIDTextBox;
        private System.Windows.Forms.ToolStripMenuItem Settings_GraphRefreshRate;
        private System.Windows.Forms.ToolStripMenuItem Settings_GrapRefreshRate100;
        private System.Windows.Forms.ToolStripMenuItem Settings_GrapRefreshRate250;
        private System.Windows.Forms.ToolStripMenuItem Settings_GrapRefreshRate500;
        private System.Windows.Forms.ToolStripMenuItem Settings_GrapRefreshRate1000;
        private System.Windows.Forms.ToolStripMenuItem Settings_GrapRefreshRate2000;
        private System.Windows.Forms.ToolStripMenuItem Settings_GrapRefreshRate5000;
        private System.Windows.Forms.Button viewVideoBtn;
        private System.Windows.Forms.Panel panelVideoPreview;
        private System.Windows.Forms.Label audSrcLbl;
        private System.Windows.Forms.Label vidSrcLabel;
        private System.Windows.Forms.ComboBox audioSrcComboBox;
        private System.Windows.Forms.ComboBox videoSrcComboBox;
        private System.Windows.Forms.ToolStripMenuItem cameraResolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataLogging_SaveDataAs;
        private System.Windows.Forms.ToolStripMenuItem DataLogging_New;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Timer guiRefreshTimer;
        private System.Windows.Forms.Button enableKeyboardControl;
        private System.Windows.Forms.Button watchRawDataButton;
        private System.ComponentModel.BackgroundWorker plotBackgoundWorker;
        private System.Windows.Forms.ToolStripMenuItem Data_Logging_Open;
        private System.Windows.Forms.TabPage googleMapsTab;
        private System.Windows.Forms.WebBrowser googleMapsBrowser;
        private System.Windows.Forms.Button debugtestButton;
        private System.Windows.Forms.Button loadGmapsBtn;
        private System.Windows.Forms.WebBrowser bigGoogleMapsBrowser;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button recordVideoButton;
        private System.Windows.Forms.Button saveImageButton;
        private System.Windows.Forms.WebBrowser googleStreetViewBrowser;
        private System.Windows.Forms.TabPage environmentTab;
        private System.Windows.Forms.GroupBox imuDataDisplay;
        private System.Windows.Forms.Label yawLbl;
        private System.Windows.Forms.Label pitchLbl;
        private System.Windows.Forms.Label rollLbl;
        private System.Windows.Forms.GroupBox envDataDisplay;
        private System.Windows.Forms.Label temperatureLbl;
        private System.Windows.Forms.Label humidityLbl;
        private System.Windows.Forms.GroupBox accDataDisplay;
        private System.Windows.Forms.Label accZLbl;
        private System.Windows.Forms.Label accYLbl;
        private System.Windows.Forms.Label accXLbl;
        private System.Windows.Forms.TabPage biometricsTab;
        private System.Windows.Forms.TabPage minitankTab;
        private System.Windows.Forms.GroupBox heartRateDisplay;
        private System.Windows.Forms.Label HRLbl;
        private System.Windows.Forms.GroupBox CAS_DataDisplay;
        private System.Windows.Forms.Label CAS_RightLbl;
        private System.Windows.Forms.Label CAS_LeftLbl;
        private System.Windows.Forms.Label CAS_RearLbl;
        private System.Windows.Forms.Label CAS_FrontLbl;
        private System.Windows.Forms.Label rearcasLbl;
        private System.Windows.Forms.Label rightcasLbl;
        private System.Windows.Forms.Label leftcasLbl;
        private System.Windows.Forms.Label frontcasLbl;
    }
}

