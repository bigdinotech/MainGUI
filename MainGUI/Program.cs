using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MainGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MAIN_GUI());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SMP_Packet
    {
        private DateTime receiveTime;
        private byte moduleID;
        private byte dataLength;
        public List<byte> dataBytes = new List<byte>();
        //byte data array

        //default constructor
        public SMP_Packet()
        {
            //initialize
        }

        //getters and setters
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte getID()
        {
            return this.moduleID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modID"></param>
        public void setID(byte modID)
        {
            this.moduleID = modID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte getLength()
        {
            if (dataBytes.Count > 4)
            {

                dataLength = dataBytes[2];
            }
            else
            {
                dataLength = 0;
            }
            return this.dataLength;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dLength"></param>
        public void setLength(byte dLength)
        {
            this.dataLength = dLength;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime getReceiveTime()
        {
            return this.receiveTime;
        }

        /// <summary>
        /// 
        /// </summary>
        public void setReceiveTime()
        {
            this.receiveTime = System.DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataByte"></param>
        public void pushDataByte(byte dataByte)
        {
            this.dataBytes.Add(dataByte);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SMP_Module
    {
        public int moduleID;
        public string moduleName;
        public Boolean hasData;
        public List<SMP_Packet> packetsReceived= new List<SMP_Packet>();
        //default constructor
        public SMP_Module()
        {
            this.hasData = false;
        }

        /// <summary>
        /// Adds a SMP_Packet to the list packetsReceived
        /// </summary>
        /// <param name="packet"></param>
        public void add_SMP_Packet(SMP_Packet packet)
        {
            this.hasData = true;
            this.packetsReceived.Add(packet);
        }

        /// <summary>
        /// returns the number of SMP_Packets received
        /// </summary>
        /// <returns></returns>
        public int getPacketsReceivedCount()
        {
            return packetsReceived.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean getHasData()
        {
            return hasData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        public void setHasData(Boolean b)
        {
            hasData = b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getSMP_PacketCount()
        {
            return this.packetsReceived.Count;
        }

        /// <summary>
        /// returns the last packet received by this module
        /// </summary>
        /// <returns></returns>
        public SMP_Packet getLastPacket()
        {
            return packetsReceived[packetsReceived.Count - 1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public SMP_Packet getPacket(int i)
        {
            if (packetsReceived.Count > i)
            {
                return packetsReceived[i];
            }
            else
            {
                return null;
            }
        }

    }

    class settingsFile
    {
    }
}
