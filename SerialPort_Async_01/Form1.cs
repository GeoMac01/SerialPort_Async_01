using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace SerialPort_Async_01
{
    public partial class Form1 : Form
    {

        #region Commands Definition
        // Command Constants
        const string CmdLaserEnable = "02";
        const string CmdSetLsPw = "03";
        const string CmdRdSerialNo = "04";
        const string CmdRdFirmware = "06";
        const string CmdRdBplateTemp = "07";
        const string CmdRdWavelen = "08";
        const string CmdSetUnitNo = "12";
        const string CmdLaserStatus = "14";
        const string CmdRdTecTemprt = "15";
        const string CmdHELP = "16";
        const string CmdsetTTL = "17";
        const string CmdEnablLogicvIn = "18";
        const string CmdAnalgInpt = "19";
        const string CmdRdLsrStatus = "20";
        const string CmsSetPwMonOut = "21";
        const string CmdRdCalDate = "22";
        const string CmdSetPwCtrlOut = "23";
        const string CmdSetOffstVolt = "24";
        const string CmdSetVgaGain = "25";
        const string CmdOperatingHr = "26";
        const string CmdRdSummary = "27";
        const string CmdSetInOutPwCtrl = "28";
        const string CmdSet0mA = "29";
        const string CmdSetStramind = "30";
        const string CmdRdCmdStautus2 = "34";
        const string CmdManufDate = "40";
        const string CmdRdPwSetPcon = "41";
        const string CmdRdInitCurrent = "42";
        const string CmdRdModelName = "43";
        const string CmdRdLaserPow = "44";
        const string CmdRdPnNb = "45";
        const string CmdRdCustomerPm = "46";
        const string CmdRatedPower = "47";
        const string CmdCurrentRead = "56";
        const string CmdSetCalAPw = "60";
        const string CmdSetCalBPw = "61";
        const string CmdSetCalAPwtoVin = "62";
        const string CmdSetCalBPwtoVin = "63";
        const string CmdRstTime = "66";
        const string CmdRstPtr = "67";
        const string CmdRstTon = "68";
        const string CmdRstCntr1000 = "69";
        const string CmdSetFirmware = "70";
        const string CmdSetSerNumber = "71";
        const string CmdSetWavelenght = "72";
        const string CmdSetLsMominalPw = "73";
        const string CmdSetCustomerPm = "74";
        const string CmdSetMaxIop = "76";
        const string CmdSetCalDate = "77";
        const string CmdSeManuDate = "78";
        const string CmdSetPartNumber = "79";
        const string CmdSetModel = "80";
        const string CmdSetCalAPwtoI = "81";
        const string CmdSetCalBPwtoI = "82";
        const string CmdTestMode = "83";
        const string CmdSetPSU = "84";
        const string CmdRdPSUvolt = "85";//check cmd 86 / 85
        const string CmdReadPSU = "86";
        const string CmdSetBaseTempCal = "87";
        const string CmdSetTECTemp = "90";
        const string CmdSetTECkp = "91";
        const string CmdSetTECki = "92";
        const string CmdSetTECsmpTime = "93";
        const string CmdRdTECsetTemp = "94";
        const string CmdRdTECsetkp = "95";
        const string CmdRdTECsetki = "96";
        const string CmdRdTECsmpTime = "97";
        const string CmdSetTECena_dis = "98";
        const string CmdRdUnitNo = "99";
        const string Footer = "\r\n";
        const string Header = "#";
        const string StrEnable = "0001";
        const string StrDisable = "0000";
        #endregion

        string[] initial_Call = new string[7]
        {
            (CmdRdModelName),
            (CmdRdSerialNo),
            (CmdRdPnNb),
            (CmdRdCustomerPm),
            (CmdManufDate),
            (CmdRdFirmware),
            (CmdRdInitCurrent),
        };

        string[] portNames = new string[10];

        string Outdata = string.Empty;
        string Indata = string.Empty;
        string laserAddress = string.Empty;
        string cmdSubStr = string.Empty;
        string rtnValue = string.Empty;
        
        int[] byteArrayToTest1 = new int[16];
        int[] byteArrayToTest2 = new int[16];
        int[] byteArrayToTest3 = new int[16];

        bool dataReceived = false;
        int pointerTestCycle = 0;
        int arrLght = 0;
        
        SerialPort Serial_CDC = new SerialPort();
        System.Timers.Timer Tmr_Send_Cmd = new System.Timers.Timer();

        public Form1()
        {
            InitializeComponent();
            InitTimer();
            
            Tmr_Send_Cmd.Elapsed += new ElapsedEventHandler(Tmr_Send_Cmd_Elapsed); 
            Serial_CDC.DataReceived += new SerialDataReceivedEventHandler(RS_DataReceivedHandler);
        }

        //================================================================================================
        #region Timer_Init
        private void InitTimer()
        {
            Tmr_Send_Cmd.Stop();
            Tmr_Send_Cmd.Interval = 100;
            Tmr_Send_Cmd.AutoReset = true;
            Tmr_Send_Cmd.Enabled = false;
        }
        #endregion
        //================================================================================================
        #region GetPortName
        private void GetPortNames()
        {
            Cursor.Current = Cursors.WaitCursor;
            
            portNames = SerialPort.GetPortNames();

            cb_COM_Sel.Items.Clear();
            foreach (string s in portNames)
            {
                cb_COM_Sel.Items.Add(s);
            }

            if (cb_COM_Sel.Items.Count > 0)
            {
                cb_COM_Sel.SelectedIndex = 0;
                Init_Coms(cb_COM_Sel.ToString());
                bt_Connect_Com.Enabled = true;
                bt_Connect_Com.BackColor = Color.Orange;
            }
            else
            {
                cb_COM_Sel.Text = "NO-COMs";
                bt_Connect_Com.Enabled = false;
                bt_Connect_Com.BackColor = Color.Red;
            }

            Task<bool> detect = DetectComs();//higher level

            Cursor.Current = Cursors.Default;
        }
        #endregion
        //================================================================================================
        #region ASYNC Detect COMs Auto
        private async Task<bool>  DetectComs()
        {
            bool goodComFlag = false;

            foreach (string strCom in cb_COM_Sel.Items)
            {
                Serial_CDC.Close();
                Serial_CDC.PortName = strCom;
                Serial_CDC.Open();
   
                    RS_DataTransmit("00990000");
                    bool firstGo = await WastingTime(500);//second level
                    
                    if ((Lbl_99Cmd.Text == CmdRdUnitNo) && goodComFlag == false)
                    {
                        goodComFlag = true;
                        cb_COM_Sel.Text = strCom;
                    }
            }
            Serial_CDC.Close();

            if (goodComFlag == false) { MessageBox.Show("No Laser Connected"); }
            else if (goodComFlag == true) { PressComConnect(); }

            return true;
        }
        #endregion
        //================================================================================================
        #region Init_Coms
        private void Init_Coms(string comPort)
        {
            try
            {
                Serial_CDC.Close();
                Serial_CDC.PortName = comPort;
                Serial_CDC.Parity = Parity.None;
                Serial_CDC.StopBits = StopBits.One;
                Serial_CDC.DataBits = 8;
                Serial_CDC.BaudRate = 115200;
                //Serial_CDC.BaudRate = 19200;
                Serial_CDC.ReadTimeout = 500;
                Serial_CDC.WriteTimeout = 500;
                Serial_CDC.ReceivedBytesThreshold = 10;
            }
            catch (Exception)
            {
                Serial_CDC.Close();
                Serial_CDC.Dispose();
                MessageBox.Show("USB_Port_Init COM Error");
            }
        }
        #endregion
        //================================================================================================
        #region ScanCOM
        private void Bt_Scan_Com_Click(object sender, EventArgs e)
        {
            GetPortNames();
        }
        #endregion
        //================================================================================================
        #region bt_Button_Com_Click
        private void Bt_Connect_Com_Click(object sender, EventArgs e)
        {
            PressComConnect();
        }
        #endregion
        //================================================================================================
        #region Button COM connect Method decouple from event
        private void PressComConnect()
        {
            if (Serial_CDC.IsOpen)//COM oppened
            {
                Tmr_Send_Cmd.Stop();
                Thread.Sleep(100);
                Serial_CDC.Close();
                bt_Connect_Com.BackColor = Color.Orange;
                bt_Connect_Com.Text = "Connect";
                bt_Scan_Com.Enabled = true;
                cb_COM_Sel.Enabled = true;
            }
            else
            {
                try
                {
                    bt_Scan_Com.Enabled = false;
                    cb_COM_Sel.Enabled = false;
                    Serial_CDC.Close();//close port
                    Serial_CDC.PortName = cb_COM_Sel.Text;
                    Serial_CDC.Open();
                    bt_Connect_Com.BackColor = Color.LawnGreen;
                    bt_Connect_Com.Text = "Connected";
                    Thread.Sleep(200);
                }
                catch
                {
                    Tmr_Send_Cmd.Stop();
                    Serial_CDC.Close();//close port
                    Serial_CDC.Dispose();
                    bt_Connect_Com.BackColor = Color.Orange;
                    bt_Connect_Com.Text = "Connect";
                    bt_Scan_Com.Enabled = true;
                    cb_COM_Sel.Enabled = true;
                    MessageBox.Show("COM Connect error");
                }
            }
        }
        #endregion
        //================================================================================================
        private void RS_DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Indata = Serial_CDC.ReadExisting();
            this.Invoke(new Action(() => DisplayText(Indata)));
        }
        //================================================================================================
        private void Tmr_Send_Cmd_Elapsed(object sender, ElapsedEventArgs e)
        {
            dataReceived = false;

            if(pointerTestCycle > (arrLght - 1)) { pointerTestCycle = 0;}
            RunTestArray(pointerTestCycle, StrDisable);
            pointerTestCycle++;
        }
        //================================================================================================
        private void RunTestArray(int posit, string argu)
        {
            string tempString = string.Empty;

            tempString = (Lbl_Ls_Nb.Text + initial_Call[posit] + argu);
            RS_DataTransmit(tempString);
            //Task<bool> nextArr = WastingTime(50);
        }
        //================================================================================================
        #region Display Select returned data
        private void DisplayText(string rxData)
        {
                int strLength = 0;
                dataReceived = true;

                try
                {
                    strLength = rxData.Length;
                    laserAddress = rxData.Substring(1, 2);
                    cmdSubStr = rxData.Substring(3, 2);
                    rtnValue = rxData.Substring(5, (strLength - 7));
                    Debug.WriteLine("rtncmd:" + cmdSubStr + " " + "strLgth:" + strLength + " " + "rtnVal:" + rtnValue);

                    switch (cmdSubStr)
                    {
                        case CmdRdUnitNo://will hapen if something valid is present
                        Lbl_Ls_Nb.Text = laserAddress;
                        Lbl_99Cmd.Text = cmdSubStr;
                            break;

                    case CmdRdModelName:
                        label1.Text = rtnValue;
                        break;

                    case CmdRdSerialNo:
                        label2.Text = rtnValue;
                        break;

                        case CmdRdPnNb:
                        label3.Text = rtnValue;
                        break;

                    case CmdRdCustomerPm:
                        label4.Text = rtnValue;
                        break;

                    case CmdManufDate:
                        label5.Text = rtnValue;
                        break;

                    case CmdRdFirmware:
                        label6.Text = rtnValue;
                        break;

                    case CmdRdInitCurrent:
                        label7.Text = rtnValue;
                        break;

                        default:
                            //MessageBox.Show("Invalid RX command");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No message");
                    Trace.WriteLine("Error{0}", ex.ToString());
                }
        }
        #endregion
        //================================================================================================
        private void Bt_Send_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            RS_DataTransmit("00990000");
            Task<bool> rtn = WastingTime(1000);
            pointerTestCycle = 0;
            arrLght = initial_Call.Length;
            Cursor.Current = Cursors.Default;
        }
        //================================================================================================
        private void RS_DataTransmit(string thinksToTransmit)
        {
            try
            {
                Serial_CDC.Write(Header + thinksToTransmit + Footer);
            }
            catch (Exception)
            {/*
                Tmr_Send_Cmd.Stop();
                Tmr_Send_Cmd.Dispose();
                Serial_CDC.Close();
                Serial_CDC.Dispose();
                MessageBox.Show("Re-Scan for Laser", "COM error TX");
                */
            }
            Debug.WriteLine("TX:" + thinksToTransmit);
        }
        //================================================================================================
        private void Rtb_UartIn_DoubleClick(object sender, EventArgs e)
        {
            Tmr_Send_Cmd.Stop();
            Rtb_UartIn.Clear();
        }
        //================================================================================================
        private void Bt_TestRun_Click(object sender, EventArgs e)
        {
            if (Bt_TestRun.BackColor == Color.Orange)
            {
                pointerTestCycle = 0;
                arrLght = initial_Call.Length;
                Bt_TestRun.BackColor = Color.Green;
                Tmr_Send_Cmd.Start();
            }
            else if (Bt_TestRun.BackColor == Color.Green)
            {
                Bt_TestRun.BackColor = Color.Orange;
                Tmr_Send_Cmd.Stop();
            }
        }
        //================================================================================================
        private async Task<bool> WastingTime(int timeWt)//not required if timer sloww for example
        {
            await Task.Delay(timeWt);//last level here
            Debug.WriteLine("TaskEnd");
            return true;
        }
        //================================================================================================
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tmr_Send_Cmd.Stop();
            Tmr_Send_Cmd.Dispose();
            Serial_CDC.Close();
            Serial_CDC.Dispose();
            Thread.Sleep(200);
        }
        //================================================================================================

        //===================================== END FORM ==================================================
    }
}
