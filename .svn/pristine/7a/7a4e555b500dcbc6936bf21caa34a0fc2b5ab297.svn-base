using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CommLib
{
    public class Modbus
    {

        #region 常量
        public const byte MB_READ_COILS = 0x01;     // 读取线圈寄存器
        public const byte MB_READ_DISCRETE = 0x02;     //读取离散输入寄存器
        public const byte MB_READ_HOLD_REG = 0x03;     //读保持寄存器
        public const byte MB_READ_INPUT_REG = 0x04;     //读输入寄存器
        public const byte MB_WRITE_SINGLE_COIL = 0x05;     //写单个线圈
        public const byte MB_WRITE_SINGLE_REG = 0x06;     //写单个寄存器
        public const byte MB_WRITE_MULTIPLE_COILS = 0x0f;     //写多个线圈
        public const byte MB_WRITE_MULTIPLE_REGS = 0x10;     //写多个寄存器
        public const byte MB_WRITE_SETRELAYBOARD = 0x43;

        //private const int MB_MAX_LENGTH = 120;          //最大数据长度
        //private const int MB_SCI_MAX_COUNT = 150;       //指令管道最大存储的指令个数
        //private const int MB_MAX_REPEAT_COUNT = 3;      //指令最多发送次数
        #endregion

     
        #region 校验
        private static readonly byte[] aucCRCHi = {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40
        };
        private static readonly byte[] aucCRCLo = {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7,
            0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E,
            0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9,
            0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC,
            0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32,
            0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D,
            0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38,
            0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF,
            0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1,
            0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4,
            0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB,
            0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA,
            0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0,
            0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97,
            0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E,
            0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89,
            0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83,
            0x41, 0x81, 0x80, 0x40
        };
        /// <summary>
        /// CRC效验
        /// </summary>
        /// <param name="pucFrame">效验数据</param>
        /// <param name="usLen">数据长度</param>
        /// <returns>效验结果</returns>
        public static int Crc16(byte[] pucFrame, int usLen)
        {
            int i = 0;
            byte ucCRCHi = 0xFF;
            byte ucCRCLo = 0xFF;
            UInt16 iIndex = 0x0000;

            while (usLen-- > 0)
            {
                iIndex = (UInt16)(ucCRCLo ^ pucFrame[i++]);
                ucCRCLo = (byte)(ucCRCHi ^ aucCRCHi[iIndex]);
                ucCRCHi = aucCRCLo[iIndex];
            }
            return (ucCRCHi << 8 | ucCRCLo);
        }

        #endregion
        #region  发送操作
        //数据帧首部
        //node  节点地址
        //addr 寄存器地址
        //len 数据长度
        // stat 功能码
        private static byte[] SendTrainHead(int node, int addr, int len, byte stat)
        {
            byte[] head = null;
            switch (stat)
            {
                case MB_READ_COILS:
                case MB_READ_DISCRETE:
                case MB_READ_HOLD_REG:
                case MB_READ_INPUT_REG:
                case MB_WRITE_MULTIPLE_COILS:
                case MB_WRITE_MULTIPLE_REGS:
                case MB_WRITE_SETRELAYBOARD:
                    head = new byte[6];
                    head[0] = Convert.ToByte(node);
                    head[1] = stat;
                    head[2] = (byte)(addr >> 8);
                    head[3] = (byte)(addr & 0x0ff);
                    head[4] = (byte)(len >> 8);
                    head[5] = (byte)(len & 0x0ff);
                    break;
                case MB_WRITE_SINGLE_COIL:
                case MB_WRITE_SINGLE_REG:
                    head = new byte[4];
                    head[0] = Convert.ToByte(node);
                    head[1] = stat;
                    head[2] = (byte)(addr >> 8);
                    head[3] = (byte)(addr & 0x0ff);
                    break;
                default:
                    break;

            }


            return head;
        }

        //加载数据
        private static byte[] SendTrainBytes(byte[] arr, ref int len, byte stat)
        {
            byte[] res;
            switch (stat)
            {
                default: len = 0; break;
                case MB_READ_COILS:
                case MB_READ_DISCRETE:
                case MB_READ_HOLD_REG:
                case MB_READ_INPUT_REG:

                    len = 0;
                    break;
                case MB_WRITE_SINGLE_COIL:
                case MB_WRITE_SINGLE_REG:
                    len = 2;
                    break;

                case MB_WRITE_MULTIPLE_COILS:
                    len = (len % 8 == 0) ? (len / 8) : (len / 8 + 1);
                    res = new byte[arr.Length + 1];
                    arr.CopyTo(res, 0);
                    res[arr.Length] = (byte)(len);//把字节写入数据最后位置
                    arr = res;
                    break;
                case MB_WRITE_MULTIPLE_REGS:
                    len *= 2;
                    res = new byte[arr.Length + 1];
                    arr.CopyTo(res, 0);
                    res[arr.Length] = (byte)len;    //把字节写入数据最后位置
                    arr = res;
                    break;
                case MB_WRITE_SETRELAYBOARD:
                    len *= 2;
                    res = new byte[arr.Length];
                    arr.CopyTo(res, 0);
                    arr = res;
                    break;

            }

            return arr;
        }

        //Master发送，发送指令模板
        //  node    节点ID
        //  data    数据
        //  addr    地址
        //  con     各数
        //  stat    功能码
        /// <summary>
        /// node:节点ID  data:数据  addr:地址  con:各数  stat:功能码
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <param name="addr"></param>
        /// <param name="con"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        public static byte[] SendTrainCyclostyle(int node, byte[] data, int addr, int con, byte stat)
        {
            int crcVal = 0;
            byte[] headData = SendTrainHead(node, addr, con, stat);//头部数据
            if (headData == null)
                return null;
            byte[] headDataLen = SendTrainBytes(headData, ref con, stat);//数据长度，写入数据
            byte[] res = new byte[headDataLen.Length + con + 2];
            headDataLen.CopyTo(res, 0);//写入头部
            if ((stat == MB_WRITE_SINGLE_COIL) || (stat == MB_WRITE_SINGLE_REG))
            {
                Array.Copy(data, 0, res, headDataLen.Length, 2);
            }
            else if ((stat == MB_WRITE_MULTIPLE_REGS) || (stat == MB_WRITE_MULTIPLE_COILS) || (stat == MB_WRITE_SETRELAYBOARD))
            {
                Array.Copy(data, 0, res, headDataLen.Length, con);
            }
            else
            {
                if (con > 0)
                    Array.Copy(data, 0, res, headDataLen.Length, con);
            }
            crcVal = Crc16(res, res.Length - 2);
            res[res.Length - 2] = (byte)(crcVal & 0xff);
            res[res.Length - 1] = (byte)(crcVal >> 8);
            return res;
        }
       
        #endregion
        #region 回传数据

        //读线圈
        private static bool ReadDiscrete(byte[] data, int addr)
        {
            bool res = true;
            int len = data[2];
            if (len != (data.Length - 5))       //数据长度错误
                return false;
            for (int i = 0; i < len; i++)
            {
                //
            }
            return res;
        }
        //读取寄存器
        private static bool ReadReg(byte[] data, int addr)
        {
            bool res = true;
            int len = data[2];
            if (len != (data.Length - 5))
                return false;
            for (int i = 0; i < len; i += 2)
            {

            }
            return res;
        }

        //回传数据处理
        //buff 数据
        //addr 当前操作的地址
        private static bool ReceiveDataProcess(byte[] buff, int addr)
        {
            if (buff == null)
                return false;
            if (buff.Length < 5)
                return false;
            //检查CRC
            int crcVal = Crc16(buff, buff.Length - 2);

            if ((((byte)(crcVal >> 8) & 0xff) != (buff[buff.Length - 1])) ||
               (((byte)(crcVal & 0xff)) != (buff[buff.Length - 2])))
                return false;
            bool res = true;
            byte stat = buff[1];
            switch (stat)
            {
                case MB_READ_COILS:
                    ReadDiscrete(buff, addr);
                    break;
                case MB_READ_DISCRETE:
                    ReadDiscrete(buff, addr);
                    break;
                case MB_READ_HOLD_REG:
                    ReadReg(buff, addr);
                    break;
                case MB_READ_INPUT_REG:
                    ReadReg(buff, addr);
                    break;
                case MB_WRITE_SINGLE_COIL:
                case MB_WRITE_SINGLE_REG:
                case MB_WRITE_MULTIPLE_COILS:
                case MB_WRITE_MULTIPLE_REGS:
                    break;
                default: res = false; break;
            }
            return res;
        }

        #endregion

        //
        public static bool CheckCrc(byte[] data)
        {
            bool res = false;
            int len = data.Length;
            int crcVal = Crc16(data, data.Length - 2);
            if ((((byte)(crcVal >> 8) & 0xff) == (data[len - 1])) &&
               (((byte)(crcVal & 0xff)) == (data[len - 2])))
            {
                res = true;
            }
            return res;
        }

    }
}
