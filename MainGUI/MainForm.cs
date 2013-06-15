//Dino Tinitigan
//Smart Modular platform GUI
//2012

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Diagnostics;

using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder;

namespace MainGUI
{
    
    public partial class MAIN_GUI : Form
    {
        //Global Variables
        string debugText;
        StringBuilder debugLog = new StringBuilder();
        const byte HEADER = 170;
        byte[] writeBuffer = new byte[256];
        byte[] dataRXBuffer = new byte[256];
        Queue<byte> dataQueue = new Queue<byte>(); 
        byte[] tempRXBuffer = new byte[256];
        String[] serialports;
        string serialportName = "";
        Boolean dataIsSaved = false;
        Boolean isPlotting = false;
        Boolean newModuleGraph = true;
        Boolean controlEnabled = false;
        Boolean rawDataEnabled = false;
        int currentModToPlot = 0;
        int lastPacketSent = 0;
        int lastGPSPacket = 0;
        string currentFileName = "default.smp";
        

        //Module Objects
        List<SMP_Module> moduleList = new List<SMP_Module>();
        string compassHeading = "";

        //webcam object
        private LiveJob _job;
        private LiveDeviceSource _deviceSource;
        int horizontalRes = 640;
        int verticalRes = 480;
        int framRate = 24;
        private bool _bStartedRecording = false;
        
        public MAIN_GUI()
        {
            InitializeComponent();
        }

        //************************************************************************************************************//
        //Event DisplayInfo Functions
        //************************************************************************************************************//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DisplayText(object s, EventArgs e)
        {
            try
            {
                debugTextBox.Text = debugText;
            }
            catch(Exception error)
            {
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void updateGUI(object s, EventArgs e)
        {
            try
            {
                if(serialPort1.IsOpen)
                {
                    this.Invoke(new EventHandler(DisplaySerialPortInfo));
                }
                else
                {
                    comLabel.BackColor = Color.Red;
                }
                this.Invoke(new EventHandler(DisplayCasInfo));
                this.Invoke(new EventHandler(DisplayHeadingInfo));
                this.Invoke(new EventHandler(DisplayAccelerometerInfo));
                this.Invoke(new EventHandler(DisplayEnvironmentInfo));
                this.Invoke(new EventHandler(DisplayGPSInfo));
                this.Invoke(new EventHandler(DisplayIMUInfo));
                this.Invoke(new EventHandler(DisplayHeartRateInfo));
            }
            catch(Exception error)
            {
                debugText = error.Message;
                //this.Invoke(new EventHandler(DisplayText));
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DisplayCasInfo(object s, EventArgs e)
        {
            if(moduleList[3].hasData)
            {
                if(moduleList[3].hasData)
                {
                    CAS_DataDisplay.Visible = true;
                    CASModule();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DisplayGPSInfo(object s, EventArgs e)
        {
            if(moduleList[35].hasData)
            {
                if((moduleList[35].packetsReceived.Count) > lastGPSPacket)
                {
                    GPSModule();
                }
                lastGPSPacket = moduleList[35].packetsReceived.Count;
            }

        }

        private void DisplayIMUInfo(object s, EventArgs e)
        {
            if (moduleList[38].hasData)
            {
                imuDataDisplay.Visible = true;
                headingLabel.Visible = true;
                IMUModule();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DisplayHeadingInfo(object s, EventArgs e)
        {
            if (moduleList[38].hasData)
            {
                imuDataDisplay.Visible = true;
                IMUModule();
            }
            else if(moduleList[39].hasData)
            {
                headingLabel.Visible = true;
                compassModule();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DisplayAccelerometerInfo(object s, EventArgs e)
        {
            if(moduleList[40].hasData)
            {
                accDataDisplay.Visible = true;
                accelerometerModule();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DisplayHeartRateInfo(object s, EventArgs e)
        {
            if (moduleList[175].hasData)
            {
                heartRateModule();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DisplayMinitankInfo(object s, EventArgs e)
        {
            if (moduleList[200].hasData)
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DisplayEnvironmentInfo(object s, EventArgs e)
        {
            if(moduleList[41].hasData)
            {
                envDataDisplay.Visible = true;
                environmentModule();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DisplaySerialPortInfo(object s, EventArgs e)
        {
            try
            {
                comLabel.Text = serialPort1.PortName.ToString() + "    " + serialPort1.BaudRate.ToString();
                if(serialPort1.IsOpen)
                {
                    comLabel.BackColor = Color.Green;
                }
                else
                {
                    comLabel.BackColor = Color.Red;
                }
            }
            catch(Exception error)
            {
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        //************************************************************************************************************//
        //Serial Port Stuff
        //************************************************************************************************************//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //read Serial Stream
            try
            {
                //byte[] tempRXBuffer = new byte[256];
                int bufferLength = serialPort1.BytesToRead;
                serialPort1.Read(tempRXBuffer, 0, bufferLength);
                

                if(rawDataEnabled)
                {
                    for (int i = 0; i < bufferLength; i++)
                    {
                        debugText += ((char)tempRXBuffer[i]).ToString();

                    }
                    this.Invoke(new EventHandler(DisplayText));
                }
                else
                {
                    processSerialData(tempRXBuffer, bufferLength);
                }
                
            }
            catch(Exception error)
            {
                debugText = error.Message;
                if(serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    //debugText = "Serial Port Closed!";
                    //MessageBox.Show(debugText);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void updateSerialPorts()
        {
            serialports = SerialPort.GetPortNames();
            Array.Sort(serialports);
            if(serialports.Contains("COM1"))
            {
                SerialPort_Com1.Visible = true;
            }
            if(serialports.Contains("COM2"))
            {
                SerialPort_Com2.Visible = true;
            }
            if(serialports.Contains("COM3"))
            {
                SerialPort_Com3.Visible = true;
            }
            if(serialports.Contains("COM4"))
            {
                SerialPort_Com4.Visible = true;
            }
            if(serialports.Contains("COM5"))
            {
                SerialPort_Com5.Visible = true;
            }
            if(serialports.Contains("COM6"))
            {
                SerialPort_Com6.Visible = true;
            }
            if(serialports.Contains("COM7"))
            {
                SerialPort_Com7.Visible = true;
            }
            if(serialports.Contains("COM8"))
            {
                SerialPort_Com8.Visible = true;
            }
            if(serialports.Contains("COM9"))
            {
                SerialPort_Com9.Visible = true;
            }
            if(serialports.Contains("COM10"))
            {
                SerialPort_Com10.Visible = true;
            }
            if(serialports.Contains("COM11"))
            {
                SerialPort_Com11.Visible = true;
            }
            if(serialports.Contains("COM12"))
            {
                SerialPort_Com12.Visible = true;
            }
        }

        //************************************************************************************************************//
        //Other Functions
        //************************************************************************************************************//
        /// <summary>
        /// 
        /// </summary>
        private void resetAndClear()
        {
            debugText = "";
            newModuleData();
            dataGraph.Series.Clear();
            debugLog = new StringBuilder();
            writeBuffer = new byte[256];
            dataRXBuffer = new byte[256];
            dataQueue = new Queue<byte>();
            tempRXBuffer = new byte[256];
            serialportName = "";
            dataIsSaved = false;
            isPlotting = false;
            newModuleGraph = true;
            controlEnabled = false;
            rawDataEnabled = false;
            currentModToPlot = 0;
            lastPacketSent = 0;
            lastGPSPacket = 0;
            currentFileName = "default.smp";

            //update serial port
            if(serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
            ResetGUI();
            System.GC.Collect(); //force garbage collection
        }

        void ResetGUI()
        {
            //reset GUI
            bigGoogleMapsBrowser.Url = new Uri("http://maps.googleapis.com/maps/api/staticmap?&size=600x480&key=AIzaSyBAjzQzZl73ylfFexJu3nbexI6pj4AK_l8&sensor=true");
            googleMapsBrowser.Visible = false;
            googleStreetViewBrowser.Visible = false;

            accDataDisplay.Visible = false;
            envDataDisplay.Visible = false;
            headingLabel.Visible = false;
        }
        /// <summary>
        /// 
        /// </summary>
        void newModuleData()
        {
            moduleList.Clear();
            moduleList = new List<SMP_Module>();
            for (int x = 0; x < 256; x++)
            {
                SMP_Module m = new SMP_Module();
                m.moduleID = (byte)x;
                moduleList.Add(m);
            }
            dataIsSaved = false;
            refreshTimer.Enabled = false;
        }

        /// <summary>
        /// Process if data in serial buffer is valid
        /// </summary>
        /// <param name="rxBuff"></param>
        /// <param name="buffLength"></param>
        private void processSerialData(byte[] rxBuff, int buffLength)
        {
            byte dataChecksum = 0;
            int packetLength = 0;
            for (int i = 0; i < buffLength; i++)
            {
                dataQueue.Enqueue(rxBuff[i]);
            }
            if(dataQueue.Count >= 4)
            {
                //First Byte is Header
                if(dataQueue.ElementAt(0) == 170)
                {
                    //Make sure there is enough bytes in the queue
                    packetLength = dataQueue.ElementAt(2) + 4;
                    if(dataQueue.Count >= packetLength)
                    {
                        dataRXBuffer[0] = dataQueue.Dequeue();  //Header Byte
                        //Caculate checksum value
                        for (int j = 1; j < packetLength - 1; j++)
                        {
                            dataRXBuffer[j] = dataQueue.Dequeue();
                            dataChecksum += dataRXBuffer[j];
                        }
                        dataRXBuffer[packetLength - 1] = dataQueue.Dequeue();
                        //Check checksum value
                        if(dataChecksum == dataRXBuffer[packetLength - 1])
                        {
                            try
                            {
                                validPacket(packetLength);
                            }
                            catch(Exception error)
                            {
                                debugText += "\n" + error.Message;
                                this.Invoke(new EventHandler(DisplayText));
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        //debugText = "Not enough Bytes!";
                    }
                }
                else
                {
                    byte temp = 0;
                    while ((temp != 170) && dataQueue.Count > 0)
                    {
                        temp = dataQueue.Peek();
                        if(temp != 170)
                        {
                            temp = dataQueue.Dequeue();
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetLength"></param>
        void validPacket(int packetLength)
        {
            try
            {
                SMP_Packet tempPacket = new SMP_Packet();
                tempPacket.setID(dataRXBuffer[1]);  //ID byte
                tempPacket.setLength(dataRXBuffer[2]);  //Length byte
                for (int i = 3; i < 3 + dataRXBuffer[2]; i++)
                {
                    tempPacket.pushDataByte(dataRXBuffer[i]);   //Data bytes
                }
                tempPacket.setReceiveTime();
                addPacketToModuleList(tempPacket);
            }
            catch(Exception error)
            {
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modPacket"></param>
        void addPacketToModuleList(SMP_Packet modPacket)
        {
            try
            {
                moduleList[modPacket.getID()].hasData = true;
                moduleList[modPacket.getID()].add_SMP_Packet(modPacket);
                dataIsSaved = false;
            }
            catch(Exception error)
            {
                debugText = error.Message;
            }
            this.Invoke(new EventHandler(DisplayText));
            
        }

        void loadBigMap()
        {
            try
            {
                string url = "http://maps.googleapis.com/maps/api/staticmap?&size=580x460&key=AIzaSyBAjzQzZl73ylfFexJu3nbexI6pj4AK_l8";
                string markers = "";
                int packetCount = moduleList[35].packetsReceived.Count;

                if (packetCount <= 20)
                {
                    foreach (SMP_Packet p in moduleList[35].packetsReceived)
                    {
                        markers += "&markers=color:blue%7Clabel:S%7C" + getGPSLocationString(p);
                    }
                }
                else
                {
                    double indexWeight = packetCount / 20;
                    for (int i = 0; i < packetCount; )
                    {
                        markers += "&markers=color:blue%7Clabel:S%7C" + getGPSLocationString(moduleList[35].packetsReceived[i]);
                        i += (int)indexWeight;
                    }
                }

                url += markers;
                url += "&sensor=false";
                bigGoogleMapsBrowser.Url = new Uri(url);
                //debugText = url;
                //this.Invoke(new EventHandler(DisplayText));
            }
            catch (Exception error)
            {
                debugText = error.Message;
            }
        }
        //************************************************************************************************************//
        //File Operations
        //************************************************************************************************************//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fname"></param>
        void saveModuleData(string fname)
        {
            try
            {
                using (Stream fStream = new FileStream(fname, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<SMP_Module>));
                    xmlFormat.Serialize(fStream, moduleList);
                }
            }
            catch(Exception error)
            {
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fname"></param>
        void openModuleData(string fname)
        {
            try
            {
                using (Stream fStream = File.OpenRead(fname))
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<SMP_Module>));
                    moduleList = (List<SMP_Module>)xmlFormat.Deserialize(fStream);
                }
                dataIsSaved = true;
                currentFileName = fname;
            }
            catch(Exception error)
            {
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        
        //************************************************************************************************************//
        //Plotting
        //************************************************************************************************************//

        /// <summary>
        /// 
        /// </summary>
        void clearGraph()
        {
            dataGraph.Invalidate();
            dataGraph.Series.Clear();
        }

        void newGraph()
        {
            if (!isPlotting)
            {
                
                dataPlotButton.Text = "Pause Plotting";
                int modID;
                try
                {
                    modID = int.Parse(moduleIDTextBox.Text);
                    currentModToPlot = modID;
                    newModuleGraph = true;
                    lastPacketSent = 0;
                    clearGraph();
                    refreshTimer.Enabled = true;
                    isPlotting = true;
                    graphModuleData(currentModToPlot);    
                    //plotBackgoundWorker.RunWorkerAsync();
                }
                catch
                {
                    debugText = "Invalid Module ID Entered!";
                    this.Invoke(new EventHandler(DisplayText));
                    refreshTimer.Enabled = false;
                    dataPlotButton.Text = "Plot";
                    isPlotting = false;
                    //badModID = true;
                }
            }
            else
            {
                refreshTimer.Enabled = false;
                isPlotting = false;
                dataPlotButton.Text = "Plot";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modID"></param>
        void graphModuleData(int modID)
        {
            try
            {
                if(moduleList[modID].hasData)
                {
                    int cnt = moduleList[modID].packetsReceived.Count;
                    if(lastPacketSent < cnt)
                    {
                        int i = lastPacketSent;
                        for (; i < cnt; i++)
                        {
                            int dataBytesCnt = moduleList[modID].packetsReceived[i].dataBytes.Count;
                            for (int j = 0; j < dataBytesCnt; j++)
                            {
                                string sName = "Series" + j.ToString();
                                if(i == 0)
                                {
                                    if(newModuleGraph)
                                    {
                                        dataGraph.Series.Add(sName);
                                        dataGraph.Series[sName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                    }
                                }
                                string dateLabel = moduleList[modID].packetsReceived[i].getReceiveTime().ToLocalTime().Hour.ToString() + ":" + moduleList[modID].packetsReceived[i].getReceiveTime().ToLocalTime().Minute.ToString() + ":" + moduleList[modID].packetsReceived[i].getReceiveTime().ToLocalTime().Second.ToString() + ":" + moduleList[modID].packetsReceived[i].getReceiveTime().ToLocalTime().Millisecond.ToString();
                                dataGraph.Series[sName].Points.AddXY(dateLabel, moduleList[modID].packetsReceived[i].dataBytes[j]);
                            }
                            
                        }
                        lastPacketSent = i;
                        newModuleGraph = false;
                    }
                }

                refreshTimer.Enabled = true;
            }
            catch(Exception error)
            {
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        //************************************************************************************************************//
        //Video Capture
        //************************************************************************************************************//
        /// <summary>
        /// 
        /// </summary>
        public void updateVideoAudioDevices()
        { 
            foreach (EncoderDevice edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            {
                try
                {
                    videoSrcComboBox.Items.Add(edv.Name);
                }
                catch(Exception error)
                {
                    debugText = error.Message;
                    this.Invoke(new EventHandler(DisplayText));
                }
            }
            foreach (EncoderDevice eda in EncoderDevices.FindDevices(EncoderDeviceType.Audio))
            {
                try
                {
                    audioSrcComboBox.Items.Add(eda.Name);
                }
                catch(Exception error)
                {
                    debugText = error.Message;
                    this.Invoke(new EventHandler(DisplayText));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="video"></param>
        /// <param name="audio"></param>
        private void GetSelectedVideoAndAudioDevices(out EncoderDevice video, out EncoderDevice audio)
        {
            video = null;
            audio = null;



            if(videoSrcComboBox.SelectedIndex < 0 || audioSrcComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("No Video and Audio capture devices have been selected.\nSelect an audio and video devices from the listboxes and try again.", "Warning");
                return;
            }

            // Get the selected video device            
            foreach (EncoderDevice edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            {
                if(String.Compare(edv.Name, videoSrcComboBox.SelectedItem.ToString()) == 0)
                {
                    video = edv;
                    break;
                }
            }

            // Get the selected audio device            
            foreach (EncoderDevice eda in EncoderDevices.FindDevices(EncoderDeviceType.Audio))
            {
                if(String.Compare(eda.Name, audioSrcComboBox.SelectedItem.ToString()) == 0)
                {
                    audio = eda;
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void StopJob()
        {
            // Has the Job already been created ?
            if(_job != null)
            {
                // Yes
                // Is it capturing ?
                if(_job.IsCapturing)
                
                if(_bStartedRecording)
                {
                    // Yes
                    // Stop Capturing
                    //btnStartStopRecording.PerformClick();
                }
                
                _job.StopEncoding();

                // Remove the Device Source and destroy the job
                _job.RemoveDeviceSource(_deviceSource);

                // Destroy the device source
                _deviceSource.PreviewWindow = null;
                _deviceSource = null;
            }
        }

        /// <summary>
        /// Starts/Stops recording of the video from chosen device
        /// </summary>
        void recordVideo()
        {
            try
            {
                // Is it Recoring ?
                if (_bStartedRecording)
                {
                    // Yes
                    // Stops encoding
                    _job.StopEncoding();

                    _bStartedRecording = false;
                    this.Invoke(new EventHandler(DisplayRecordStatus));
                }
                else
                {
                    // Sets up publishing format for file archival type
                    FileArchivePublishFormat fileOut = new FileArchivePublishFormat();

                    // Sets file path and name
                    fileOut.OutputFileName = String.Format("C:\\WebCam{0:yyyyMMdd_hhmmss}.wmv", DateTime.Now);

                    // Adds the format to the job. You can add additional formats as well such as
                    // Publishing streams or broadcasting from a port
                    _job.PublishFormats.Add(fileOut);

                    // Start encoding
                    _job.StartEncoding();

                    _bStartedRecording = true;
                    this.Invoke(new EventHandler(DisplayRecordStatus));
                }
            }
            catch (Exception error)
            {
                debugText = error.Message;
            }
        }

        //Saves a snapshot of the video from chosen device
        void captureImage()
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(panelVideoPreview.Width, panelVideoPreview.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        // Get the paramters to call g.CopyFromScreen and get the image
                        Rectangle rectanglePanelVideoPreview = panelVideoPreview.Bounds;
                        Point sourcePoints = panelVideoPreview.PointToScreen(new Point(panelVideoPreview.ClientRectangle.X, panelVideoPreview.ClientRectangle.Y));
                        g.CopyFromScreen(sourcePoints, Point.Empty, rectanglePanelVideoPreview.Size);
                    }

                    string strGrabFileName = String.Format("Snapshot_{0:yyyyMMdd_hhmmss}.jpg", DateTime.Now);
                    bitmap.Save(strGrabFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception error)
            {
                debugText = error.Message;
            }
        }
        //************************************************************************************************************//
        //Module Data Conversion
        //************************************************************************************************************//
        /// <summary>
        /// 
        /// </summary>
        void ControlModule()
        {
        }

        /// <summary>
        ///
        /// </summary>
        void CASModule()
        {
            try
            {
                int dist = moduleList[3].packetsReceived[moduleList[3].packetsReceived.Count - 1].dataBytes[0];
                byte dir = moduleList[3].packetsReceived[moduleList[3].packetsReceived.Count - 1].dataBytes[1];

                if((char)dir == 'F')
                {
                    CAS_FrontLbl.Text = "Front: " + dist.ToString() + "\"";
                    frontcasLbl.Text = dist.ToString();
                    frontcasLbl.Visible = true;
                }
                else if ((char)dir == 'B')
                {
                    CAS_RearLbl.Text = "Back: " + dist.ToString() + "\"";
                    rearcasLbl.Text = dist.ToString();
                    rearcasLbl.Visible = true;
                }
                else if ((char)dir == 'L')
                {
                    CAS_LeftLbl.Text = "Left: " + dist.ToString() + "\"";
                    leftcasLbl.Text = dist.ToString();
                    leftcasLbl.Visible = true;
                }
                else if ((char)dir == 'R')
                {
                    CAS_RightLbl.Text = "Right: " + dist.ToString() + "\"";
                    rightcasLbl.Text = dist.ToString();
                    rightcasLbl.Visible = true;
                }
            }
            catch (Exception error)
            {
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void SmartPowerModule()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        void GPSModule()
        {
            try
            {
                string gMapsURL = "http://maps.googleapis.com/maps/api/staticmap?&size=180x180&key=AIzaSyBAjzQzZl73ylfFexJu3nbexI6pj4AK_l8";
                string streetViewURL = "http://maps.googleapis.com/maps/api/streetview?size=180x180&key=AIzaSyBAjzQzZl73ylfFexJu3nbexI6pj4AK_l8&fov=120&pitch=10&location=";
                string location = getGPSLocationString(moduleList[35].packetsReceived[moduleList[35].packetsReceived.Count - 1]);
                string marker = "&markers=color:blue%7Clabel:S%7C";
                gMapsURL += marker + location + "&sensor=false";
                
                //heading for streetview
                int headingDegrees = 0;
                if (moduleList[38].hasData)
                {

                    int degMSB = moduleList[38].packetsReceived[moduleList[38].packetsReceived.Count - 1].dataBytes[4];
                    int degLSB = moduleList[38].packetsReceived[moduleList[38].packetsReceived.Count - 1].dataBytes[5];
                    if (degMSB == 1)
                    {
                        headingDegrees += 256;
                    }
                    else if (degMSB == 0)
                    {
                    }
                    headingDegrees += degLSB;
                }
                else if (moduleList[39].hasData)
                {
                    
                    int degMSB = moduleList[39].packetsReceived[moduleList[39].packetsReceived.Count - 1].dataBytes[0];
                    int degLSB = moduleList[39].packetsReceived[moduleList[39].packetsReceived.Count - 1].dataBytes[1];
                    if (degMSB == 1)
                    {
                        headingDegrees += 256;
                    }
                    else if (degMSB == 0)
                    {
                    }
                    headingDegrees += degLSB;
                }
                streetViewURL += location + "&heading=" + headingDegrees.ToString() + "&sensor=false";
                googleMapsBrowser.Url = new Uri(gMapsURL);
                googleMapsBrowser.Visible = true;
                googleStreetViewBrowser.Url = new Uri(streetViewURL);
                googleStreetViewBrowser.Visible = true;
            }
            catch(Exception error)
            {
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        string getGPSLocationString(SMP_Packet packet)
        {
            int longitude = 0;
            int latitude = 0;
            byte longDir;
            byte latDir;
            double longDeg;
            double longMin;
            double longSec;
            double latDeg;
            double latMin;
            double latSec;
            double dtemp;
            string longSign;
            string latSign;
            string longString;
            string latString;
            string location;
            string stemp;
            
            latDir = packet.dataBytes[5];
            longDir = packet.dataBytes[0];

            int long0 = packet.dataBytes[1];
            int long1 = packet.dataBytes[2];
            int long2 = packet.dataBytes[3];
            int long3 = packet.dataBytes[4];
            longitude = long0 * 16777216 + long1 * 65536 + long2 * 256 + long3;

            int lat0 = packet.dataBytes[6];
            int lat1 = packet.dataBytes[7];
            int lat2 = packet.dataBytes[8];
            int lat3 = packet.dataBytes[9];
            latitude = lat0 * 16777216 + lat1 * 65536 + lat2 * 256 + lat3;

            longDeg = longitude / 1000000;
            longMin = (longitude / 10000) % 100;
            stemp = ((longitude % 10000) * 6 / 1000).ToString() + "." + (((longitude % 10000) * 6 / 10) % 100).ToString();
            longSec = double.Parse(stemp);
            latDeg = latitude / 1000000;
            latMin = (latitude / 10000) % 100;
            stemp = ((latitude % 10000) * 6 / 1000).ToString() + "." + (((latitude % 10000) * 6 / 10) % 100).ToString();
            latSec = double.Parse(stemp);


            if((char)latDir == 'N')
            {
                latSign = "+";
            }
            else
            {
                latSign = "-";
            }
            if((char)longDir == 'E')
            {
                longSign = "+";
            }
            else
            {
                longSign = "-";
            }

            dtemp = (longDeg + longMin / 60 + longSec / 3600);
            dtemp = Math.Round(dtemp, 6);
            longString = longSign + dtemp.ToString();
            dtemp = (latDeg + latMin / 60 + latSec / 3600);
            dtemp = Math.Round(dtemp, 6);
            latString = latSign + dtemp.ToString();
            location = latString + "," + longString;
            return location;           
        }

        /// <summary>
        /// 
        /// </summary>
        void IMUModule()
        {
            try
            {
                int temp;
                double rollValue;
                double pitchValue;
                double yawValue;
                int rollMSB = moduleList[38].packetsReceived[moduleList[38].packetsReceived.Count - 1].dataBytes[0];
                int rollLSB = moduleList[38].packetsReceived[moduleList[38].packetsReceived.Count - 1].dataBytes[1];
                int pitchMSB = moduleList[38].packetsReceived[moduleList[38].packetsReceived.Count - 1].dataBytes[2];
                int pitchLSB = moduleList[38].packetsReceived[moduleList[38].packetsReceived.Count - 1].dataBytes[3];
                int yawMSB = moduleList[38].packetsReceived[moduleList[38].packetsReceived.Count - 1].dataBytes[4];
                int yawLSB = moduleList[38].packetsReceived[moduleList[38].packetsReceived.Count - 1].dataBytes[5];
                temp = rollMSB * 256 + rollLSB;
                rollValue = Math.Round(double.Parse(temp.ToString()) * (360.0 / 65536.0), 3);
                temp = pitchMSB * 256 + pitchLSB;
                pitchValue = Math.Round(double.Parse(temp.ToString()) * (360.0 / 65536.0), 3);
                temp = yawMSB * 256 + yawLSB;
                yawValue = Math.Round(double.Parse(temp.ToString()) * (360.0 / 65536.0), 3);

                rollLbl.Text = "Roll: " + rollValue.ToString();
                pitchLbl.Text = "Pitch: " + pitchValue.ToString();
                yawLbl.Text = "Yaw: " + yawValue.ToString();

                double headingDegrees = yawValue;
                this.Invoke(new EventHandler(DisplayText));
                if (((headingDegrees >= 0) && (headingDegrees <= 22)) || ((headingDegrees >= 338) && (headingDegrees <= 360)))
                {
                    compassHeading = "N";
                }
                else if ((headingDegrees >= 22) && (headingDegrees <= 67))
                {
                    compassHeading = "NE";
                }
                else if ((headingDegrees >= 68) && (headingDegrees <= 112))
                {
                    compassHeading = "E";
                }
                else if ((headingDegrees >= 113) && (headingDegrees <= 157))
                {
                    compassHeading = "SE";
                }
                else if ((headingDegrees >= 158) && (headingDegrees <= 202))
                {
                    compassHeading = "S";
                }
                else if ((headingDegrees >= 203) && (headingDegrees <= 247))
                {
                    compassHeading = "SW";
                }
                else if ((headingDegrees >= 248) && (headingDegrees <= 292))
                {
                    compassHeading = "W";
                }
                else if ((headingDegrees >= 293) && (headingDegrees <= 337))
                {
                    compassHeading = "NW";
                }
                headingLabel.Text = compassHeading;
            }
            catch (Exception error)
            {
                //console.beep();
                //console.beep();
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        void compassModule()
        {
            try
            {
                double headingDegrees = 0;
                int temp;
                int degMSB = moduleList[39].packetsReceived[moduleList[39].packetsReceived.Count-1].dataBytes[0];
                int degLSB = moduleList[39].packetsReceived[moduleList[39].packetsReceived.Count - 1].dataBytes[1];
                /**
                if(degMSB == 1)
                {
                    headingDegrees += 256;
                }
                else if(degMSB == 0)
                {
                }
                headingDegrees += degLSB;
                **/
                temp = degMSB * 256 + degLSB;
                //debugText = temp.ToString();
                headingDegrees = double.Parse(temp.ToString()) * (360.0/65536.0);
                //debugText = headingDegrees.ToString();
                this.Invoke(new EventHandler(DisplayText));
                if(((headingDegrees >= 0) && (headingDegrees <= 22)) || ((headingDegrees >= 338) && (headingDegrees <= 360)))
                {
                    compassHeading = "N";
                }
                else if((headingDegrees >= 22) && (headingDegrees <= 67))
                {
                    compassHeading = "NE";
                }
                else if((headingDegrees >= 68) && (headingDegrees <= 112))
                {
                    compassHeading = "E";
                }
                else if((headingDegrees >= 113) && (headingDegrees <= 157))
                {
                    compassHeading = "SE";
                }
                else if((headingDegrees >= 158) && (headingDegrees <= 202))
                {
                    compassHeading = "S";
                }
                else if((headingDegrees >= 203) && (headingDegrees <= 247))
                {
                    compassHeading = "SW";
                }
                else if((headingDegrees >= 248) && (headingDegrees <= 292))
                {
                    compassHeading = "W";
                }
                else if((headingDegrees >= 293) && (headingDegrees <= 337))
                {
                    compassHeading = "NW";
                }
                headingLabel.Text = compassHeading;
            }
            catch(Exception error)
            {
                //console.beep();
                //console.beep();
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void accelerometerModule()
        {
            try
            {
                int xVal = moduleList[40].packetsReceived[moduleList[40].packetsReceived.Count - 1].dataBytes[0];
                int yVal = moduleList[40].packetsReceived[moduleList[40].packetsReceived.Count - 1].dataBytes[1];
                int zVal = moduleList[40].packetsReceived[moduleList[40].packetsReceived.Count - 1].dataBytes[2];
                double tempxVal = double.Parse(xVal.ToString()) / 25.0;
                double tempyVal = double.Parse(yVal.ToString()) / 25.0;
                double tempzVal = double.Parse(zVal.ToString()) / 25.0;
                tempxVal -= 5.0;
                tempyVal -= 5.0;
                tempzVal -= 5.0;
                tempxVal = Math.Round(tempxVal, 3);
                tempyVal = Math.Round(tempyVal, 3);
                tempzVal = Math.Round(tempzVal, 3);
                
                accXLbl.Text = "X Axis: " + tempxVal.ToString();
                accYLbl.Text = "Y Axis: " + tempyVal.ToString();
                accZLbl.Text = "Z Axis: " + tempzVal.ToString();
            }
            catch(Exception error)
            {
                //console.beep();
                //console.beep();
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void environmentModule()
        {
            int humidity = moduleList[41].packetsReceived[moduleList[41].packetsReceived.Count - 1].dataBytes[0];
            int temperature = moduleList[41].packetsReceived[moduleList[41].packetsReceived.Count - 1].dataBytes[1];

            humidityLbl.Text = "Humidity: " + humidity.ToString() + "%";
            temperatureLbl.Text = "Temperature: " + temperature.ToString() + "C";
        }

        /// <summary>
        /// 
        /// </summary>
        void heartRateModule()
        {
            int HR = moduleList[175].packetsReceived[moduleList[175].packetsReceived.Count - 1].dataBytes[0];
            HRLbl.Text = "HR: " + HR.ToString() + " bpm";
        }

        /// <summary>
        /// 
        /// </summary>
        void miniTankModule()
        {
        }
        //************************************************************************************************************//
        //GUI Events
        //************************************************************************************************************//

        private void MAIN_GUI_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////console.beep();
            byte cmdByte = (byte)e.KeyChar;
            if(serialPort1.IsOpen)
            {
                writeBuffer[0] = cmdByte;
                serialPort1.Write(writeBuffer, 0, 1);
            }
        }

        private void MAIN_GUI_Deactivate(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void MAIN_GUI_Load(object sender, EventArgs e)
        {
            updateSerialPorts();
            updateVideoAudioDevices();
            newModuleData();  
        }

        private void MAIN_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check if file is saved first
            try
            {
                if (!dataIsSaved)
                {
                    DialogResult dres1 = MessageBox.Show("Data has not been saved. Do you want to save?", "Save Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (dres1 == DialogResult.Yes)
                    {
                        if (currentFileName == "default.smp")
                        {
                            saveFileDialog1.ShowDialog();
                            currentFileName = saveFileDialog1.FileName;
                            if (currentFileName != "")
                            {
                                saveModuleData(currentFileName);
                                dataIsSaved = true;
                            }
                            else
                            {
                                currentFileName = "default.smp";
                                dataIsSaved = false;
                            }
                        }
                        //resetAndClear();
                    }
                    else if (dres1 == DialogResult.No)
                    {
                        //resetAndClear();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    //resetAndClear();
                }
            }
            catch(Exception error)
            {
                string test = error.Message;
            }

        }

        private void MAIN_GUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if(serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch(Exception error)
            {
                debugText = error.Message;
            }
        }

        private void clrDebugButton_Click_1(object sender, EventArgs e)
        {
            debugLog.AppendLine(debugTextBox.Text);
            debugTextBox.Text = "";
            debugText = "";
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void watchRawDataButton_Click(object sender, EventArgs e)
        {
            if(!rawDataEnabled)
            {
                rawDataEnabled = true;
            }
            else
            {
                rawDataEnabled = false;
            }
        }

        private void pauseButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    pauseButton.Enabled = false;
                    startButton.Enabled = true;
                }
                this.Invoke(new EventHandler(DisplaySerialPortInfo));
            }
            catch(Exception error)
            {
                //console.beep();
                //console.beep();
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                if(!serialPort1.IsOpen)
                {
                    serialPort1.PortName = serialportName;
                    serialPort1.Open();
                    pauseButton.Enabled = true;
                    startButton.Enabled = false;
                }
                this.Invoke(new EventHandler(DisplaySerialPortInfo));
            }
            catch(Exception error)
            {
                //console.beep();
                //console.beep();
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        private void enableKeyboardControl_Click(object sender, EventArgs e)
        {
            if(!controlEnabled)
            {
                this.KeyPreview = true;
                enableKeyboardControl.Text = "Disable Control";
                controlEnabled = true;
            }
            else
            {
                this.KeyPreview = false;
                enableKeyboardControl.Text = "Enable Control";
                controlEnabled = false;
            }
        }

        private void serialPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void SerialPort_Com1_Click(object sender, EventArgs e)
        {
            serialportName = "COM1";
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com2_Click(object sender, EventArgs e)
        {
            serialportName = "COM2";
            SerialPort_Com1.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com3_Click(object sender, EventArgs e)
        {
            serialportName = "COM3";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com4_Click(object sender, EventArgs e)
        {
            serialportName = "COM4";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com5_Click(object sender, EventArgs e)
        {
            serialportName = "COM5";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com6_Click(object sender, EventArgs e)
        {
            serialportName = "COM6";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com7_Click(object sender, EventArgs e)
        {
            serialportName = "COM7";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com8_Click(object sender, EventArgs e)
        {
            serialportName = "COM8";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com9_Click(object sender, EventArgs e)
        {
            serialportName = "COM9";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com10_Click(object sender, EventArgs e)
        {
            serialportName = "COM10";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com11.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com11_Click(object sender, EventArgs e)
        {
            serialportName = "COM11";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com12.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void SerialPort_Com12_Click(object sender, EventArgs e)
        {
            serialportName = "COM12";
            SerialPort_Com1.Checked = false;
            SerialPort_Com2.Checked = false;
            SerialPort_Com3.Checked = false;
            SerialPort_Com4.Checked = false;
            SerialPort_Com5.Checked = false;
            SerialPort_Com6.Checked = false;
            SerialPort_Com7.Checked = false;
            SerialPort_Com8.Checked = false;
            SerialPort_Com9.Checked = false;
            SerialPort_Com10.Checked = false;
            SerialPort_Com11.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void Settings_BaudRate_2400_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 2400;
            Settings_BaudRate_4800.Checked = false;
            Settings_BaudRate_9600.Checked = false;
            Settings_BaudRate_19200.Checked = false;
            Settings_BaudRate_38400.Checked = false;
            Settings_BaudRate_57600.Checked = false;
            Settings_BaudRate_115200.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void Settings_BaudRate_4800_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 4800;
            Settings_BaudRate_2400.Checked = false;
            Settings_BaudRate_9600.Checked = false;
            Settings_BaudRate_19200.Checked = false;
            Settings_BaudRate_38400.Checked = false;
            Settings_BaudRate_57600.Checked = false;
            Settings_BaudRate_115200.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void Settings_BaudRate_9600_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            Settings_BaudRate_2400.Checked = false;
            Settings_BaudRate_4800.Checked = false;
            Settings_BaudRate_19200.Checked = false;
            Settings_BaudRate_38400.Checked = false;
            Settings_BaudRate_57600.Checked = false;
            Settings_BaudRate_115200.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void Settings_BaudRate_19200_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 19200;
            Settings_BaudRate_2400.Checked = false;
            Settings_BaudRate_4800.Checked = false;
            Settings_BaudRate_9600.Checked = false;
            Settings_BaudRate_38400.Checked = false;
            Settings_BaudRate_57600.Checked = false;
            Settings_BaudRate_115200.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void Settings_BaudRate_38400_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 38400;
            Settings_BaudRate_2400.Checked = false;
            Settings_BaudRate_4800.Checked = false;
            Settings_BaudRate_9600.Checked = false;
            Settings_BaudRate_19200.Checked = false;
            Settings_BaudRate_57600.Checked = false;
            Settings_BaudRate_115200.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void Settings_BaudRate_57600_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 57600;
            Settings_BaudRate_2400.Checked = false;
            Settings_BaudRate_4800.Checked = false;
            Settings_BaudRate_9600.Checked = false;
            Settings_BaudRate_19200.Checked = false;
            Settings_BaudRate_38400.Checked = false;
            Settings_BaudRate_115200.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void Settings_BaudRate_115200_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 115200;
            Settings_BaudRate_2400.Checked = false;
            Settings_BaudRate_4800.Checked = false;
            Settings_BaudRate_9600.Checked = false;
            Settings_BaudRate_19200.Checked = false;
            Settings_BaudRate_38400.Checked = false;
            Settings_BaudRate_57600.Checked = false;
            this.Invoke(new EventHandler(DisplaySerialPortInfo));
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                graphModuleData(currentModToPlot);
                //plotBackgoundWorker.RunWorkerAsync();
            }
            catch(Exception error)
            {
                //console.beep();
                //console.beep();
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        private void guiRefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                GUIbackgroundWorker.RunWorkerAsync();
            }
            catch(Exception error)
            {
                //console.beep();
                //console.beep();
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }

        }

        private void moduleIDTextBox_TextChanged(object sender, EventArgs e)
        {
            refreshTimer.Enabled = false;
            isPlotting = false;
            dataPlotButton.Text = "Plot";
            //dataGraph.Series.Clear();
            lastPacketSent = 0;
        }

        private void Settings_GrapRefreshRate100_Click(object sender, EventArgs e)
        {
            refreshTimer.Interval = 100;
            Settings_GrapRefreshRate100.Checked = true;
            Settings_GrapRefreshRate250.Checked = false;
            Settings_GrapRefreshRate500.Checked = false;
            Settings_GrapRefreshRate1000.Checked = false;
            Settings_GrapRefreshRate2000.Checked = false;
            Settings_GrapRefreshRate5000.Checked = false;
        }

        private void Settings_GrapRefreshRate250_Click(object sender, EventArgs e)
        {
            refreshTimer.Interval = 250;
            Settings_GrapRefreshRate100.Checked = false;
            Settings_GrapRefreshRate500.Checked = false;
            Settings_GrapRefreshRate1000.Checked = false;
            Settings_GrapRefreshRate2000.Checked = false;
            Settings_GrapRefreshRate5000.Checked = false;
        }

        private void Settings_GrapRefreshRate500_Click(object sender, EventArgs e)
        {
            refreshTimer.Interval = 500;
            Settings_GrapRefreshRate100.Checked = false;
            Settings_GrapRefreshRate250.Checked = false;
            Settings_GrapRefreshRate1000.Checked = false;
            Settings_GrapRefreshRate2000.Checked = false;
            Settings_GrapRefreshRate5000.Checked = false;
        }

        private void Settings_GrapRefreshRate1000_Click(object sender, EventArgs e)
        {
            refreshTimer.Interval = 1000;
            Settings_GrapRefreshRate100.Checked = false;
            Settings_GrapRefreshRate250.Checked = false;
            Settings_GrapRefreshRate500.Checked = false;
            Settings_GrapRefreshRate2000.Checked = false;
            Settings_GrapRefreshRate5000.Checked = false;
        }

        private void Settings_GrapRefreshRate2000_Click(object sender, EventArgs e)
        {
            refreshTimer.Interval = 2000;
            Settings_GrapRefreshRate100.Checked = false;
            Settings_GrapRefreshRate250.Checked = false;
            Settings_GrapRefreshRate500.Checked = false;
            Settings_GrapRefreshRate1000.Checked = false;
            Settings_GrapRefreshRate5000.Checked = false;
        }

        private void Settings_GrapRefreshRate5000_Click(object sender, EventArgs e)
        {
            refreshTimer.Interval = 5000;
            Settings_GrapRefreshRate100.Checked = false;
            Settings_GrapRefreshRate250.Checked = false;
            Settings_GrapRefreshRate500.Checked = false;
            Settings_GrapRefreshRate1000.Checked = false;
            Settings_GrapRefreshRate2000.Checked = false;
        }

        private void viewVideoBtn_Click(object sender, EventArgs e)
        {
            EncoderDevice video = null;
            EncoderDevice audio = null;
            try
            {
                GetSelectedVideoAndAudioDevices(out video, out audio);
                StopJob();

                if(video == null)
                {
                    return;
                }

                // Starts new job for preview window
                _job = new LiveJob();

                // Checks for a/v devices
                if(video != null && audio != null)
                {
                    // Create a new device source. We use the first audio and video devices on the system
                    _deviceSource = _job.AddDeviceSource(video, audio);
                    _deviceSource.PickBestVideoFormat(new Size(verticalRes, horizontalRes), framRate);


                    // Get the properties of the device video
                    SourceProperties sp = _deviceSource.SourcePropertiesSnapshot();

                    // Resize the preview panel to match the video device resolution set
                    panelVideoPreview.Size = new Size(sp.Size.Width, sp.Size.Height);

                    // Setup the output video resolution file as the preview
                    _job.OutputFormat.VideoProfile.Size = new Size(sp.Size.Width, sp.Size.Height);

                    // Display the video device properties set
                    //toolStripStatusLabel1.Text = sp.Size.Width.ToString() + "x" + sp.Size.Height.ToString() + "  " + sp.FrameRate.ToString() + " fps";

                    // Sets preview window to winform panel hosted by xaml window
                    _deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(panelVideoPreview, panelVideoPreview.Handle));

                    // Make this source the active one
                    _job.ActivateSource(_deviceSource);

                    //btnStartStopRecording.Enabled = true;
                    //btnGrabImage.Enabled = true;

                    debugText = "Preview activated";
                }
                else
                {
                    // Gives error message as no audio and/or video devices found
                    MessageBox.Show("No Video/Audio capture devices have been found.", "Warning");
                    debugText = "No Video/Audio capture devices have been found.";
                }
            }
            catch(Exception error)
            {
                debugText = error.Message;
                this.Invoke(new EventHandler(DisplayText));
            }
  
        }

        private void dataPlotButton_Click(object sender, EventArgs e)
        {
            newGraph();
            System.GC.Collect();
        }

        private void DataLogging_SaveDataAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            currentFileName = saveFileDialog1.FileName;
            if(currentFileName != "")
            {
                saveModuleData(currentFileName);
                dataIsSaved = true;
            }
            else
            {
                currentFileName = "default.smp";
                dataIsSaved = false;
            }
        }

        private void DataLogging_SaveData_Click(object sender, EventArgs e)
        {
            if(currentFileName == "default.smp")
            {
                saveFileDialog1.ShowDialog();
                currentFileName = saveFileDialog1.FileName;
                if(currentFileName != "")
                {
                    saveModuleData(currentFileName);
                    dataIsSaved = true;
                }
                else
                {
                    currentFileName = "default.smp";
                    dataIsSaved = false;
                }
            }
            else
            {
                saveModuleData(currentFileName);
            }
        }

        private void DataLogging_New_Click(object sender, EventArgs e)
        {
            if (!dataIsSaved)
            {
                DialogResult dres1 = MessageBox.Show("Data has not been saved. Do you want to save?", "Save Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dres1 == DialogResult.Yes)
                {
                    if (currentFileName == "default.smp")
                    {
                        saveFileDialog1.ShowDialog();
                        currentFileName = saveFileDialog1.FileName;
                        if (currentFileName != "")
                        {
                            saveModuleData(currentFileName);
                            dataIsSaved = true;
                        }
                        else
                        {
                            currentFileName = "default.smp";
                            dataIsSaved = false;
                        }
                    }
                    resetAndClear();
                }
                else if (dres1 == DialogResult.No)
                {
                    resetAndClear();
                }
                else
                {
                    //do nothing
                }
            }
            else
            {
                resetAndClear();
            }
            
        }

        private void Data_Logging_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string openFileName = openFileDialog1.FileName;
            openModuleData(openFileName);
        }

        private void GUIbackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new EventHandler(updateGUI));
        }

        private void plotBackgoundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            graphModuleData(currentModToPlot);
        }

        

        private void loadGmapsBtn_Click(object sender, EventArgs e)
        {
            loadBigMap();
        }

        private void recordVideoButton_Click(object sender, EventArgs e)
        {
            recordVideo();
        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            captureImage(); 
        }

        private void debugtestButton_Click(object sender, EventArgs e)
        {

        }

        private void DisplayRecordStatus(object s, EventArgs e)
        {
            if (_bStartedRecording)
            {
                recordVideoButton.Text = "End Recording";
            }
            else
            {
                recordVideoButton.Text = "Record";
            }
        }

    }
}
