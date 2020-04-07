using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace CommLib
{
    public class SerialClass
    {

        SerialPort _serialPort = null;
        Int32 maxinterval = 1;
        public bool isOpened { get; set; }
        public delegate bool SerialPortDataCallBack(byte[] data);
        //接收事件函数
        public event SerialPortDataCallBack DataReceived = null;

        public struct portConfig
        {
            public string comPortName;
            public int baudRate;
            public Parity parity;
            public int dataBits;
            public StopBits stopBits;
        };

        portConfig portCon = new portConfig();


        //串口名称的get set
        public string GetPortName
        {
            get { return portCon.comPortName; }
            set
            {
                _serialPort.PortName = value;
                portCon.comPortName = value;
            }
        }
        //波特率
        private int baudRate;
        public int BaudRate
        {
            get { return _serialPort.BaudRate; }
            set
            {
                _serialPort.BaudRate = value;
                baudRate = value;
            }
        }

        //默认构造函数，无输入参数；默认设置
        public SerialClass()
        {
            _serialPort = new SerialPort();
        }

        //构造函数1
        public SerialClass(string comPortName)
        {
            try
            {
                _serialPort = new SerialPort(comPortName);
            }
            catch (Exception ex)
            {
                return;
            }

            portCon.comPortName = comPortName;
            portCon.baudRate = 115200;
            portCon.parity = Parity.None;
            portCon.dataBits = 8;
            portCon.stopBits = StopBits.One;
            setSerialPort();
        }

        public SerialClass(portConfig conf)
        {

            try
            {
                _serialPort = new SerialPort(conf.comPortName);
                portCon.comPortName = conf.comPortName;
                portCon.baudRate = conf.baudRate;
                portCon.parity = conf.parity;
                portCon.dataBits = conf.dataBits;
                portCon.stopBits = conf.stopBits;
                setSerialPort();

            }
            catch (Exception)
            {
                return;
            }

        }

        //构造函数2
        public SerialClass(string comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            try
            {
                _serialPort = new SerialPort(comPortName);
            }
            catch (Exception ex)
            {
                return;
            }
            portCon.comPortName = comPortName;
            portCon.baudRate = baudRate;
            portCon.parity = parity;
            portCon.dataBits = dataBits;
            portCon.stopBits = stopBits;
            setSerialPort();
        }


        //串口参数设置函数
        public void setSerailPort(string comPortName, int baudRate, int dataBits, int parity, int stopBits)
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
            portCon.comPortName = comPortName;
            portCon.baudRate = baudRate;
            portCon.parity = (Parity)parity;
            portCon.dataBits = dataBits;
            portCon.stopBits = (StopBits)stopBits;
            setSerialPort();
        }

        //设定串口触发回到函数
        /// <summary>
        /// 
        /// </summary>
        void setSerialPort()
        {
            if (_serialPort != null)
            {
                _serialPort.BaudRate = portCon.baudRate;
                _serialPort.Parity = portCon.parity;
                _serialPort.DataBits = portCon.dataBits;
                _serialPort.StopBits = portCon.stopBits;
                _serialPort.Handshake = Handshake.None;
                _serialPort.RtsEnable = false;


                //触发接收字节数量
                _serialPort.ReceivedBytesThreshold = 3;
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                _serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(_serialPort_ErrorReceived);
                _serialPort.PinChanged += new SerialPinChangedEventHandler(_serialPort_PinReceived);
                _serialPort.ReadTimeout = 2000;
                _serialPort.WriteTimeout = 2000;
                _serialPort.ReadBufferSize = 256;
                _serialPort.WriteBufferSize = 256;


                if (portCon.baudRate <= 19200)
                {
                    maxinterval = 25;
                }
                else
                {
                    maxinterval = 2;
                }
            }
        }

        //串口接收事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            //System.Threading.Thread.Sleep(2);
            int DataLen = _serialPort.BytesToRead;
            System.Threading.Thread.Sleep(maxinterval);
            for (int t = 0; t < 10; t++)
            {
                if (_serialPort.BytesToRead == DataLen)
                {
                    break;
                }
                else
                {
                    DataLen = _serialPort.BytesToRead;
                    System.Threading.Thread.Sleep(maxinterval);
                }
            }


            byte[] _data = new byte[_serialPort.BytesToRead];
            _serialPort.Read(_data, 0, _data.Length);

            if (DataReceived != null && _data.Length > 0)
            {
                DataReceived(_data);
            }
        }

        //接收错误事件
        void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

        }

        void _serialPort_PinReceived(object sender, SerialPinChangedEventArgs e)
        {
            SerialPinChange pin = e.EventType;
        }
        //发送数据 string类型
        public void SendData(string data)
        {

            if (_serialPort.IsOpen)
            {
                _serialPort.Write(data);
            }
        }

        //发送数据 byte类型
        /// <summary>
        /// data:数据  offset:参数中从零开始的字节偏移量  count:数据长度
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public void SendData(byte[] data, int offset, int count)
        {

            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Write(data, offset, count);
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        //打开串口
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool openPort()
        {
            bool ok = false;
            if (_serialPort.IsOpen)
                _serialPort.Close();
            try
            {
                _serialPort.Open();
                ok = true;
            }
            catch (Exception)
            {
                ok = false;
            }
            isOpened = ok;
            return ok;
        }

        //关闭串口
        /// <summary>
        /// 
        /// </summary>
        public void closePort()
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
            isOpened = false;
        }



    }//class SerialClass
}
