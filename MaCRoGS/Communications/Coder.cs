using System;
using System.Text;
using System.Globalization;

namespace MaCRoGS.Communications
{
    public class Coder
    {
        SerialTransport transport;
        SerialTransportAddress t;
        MainWindow display;

        public void Start(MainWindow display)
        {
            this.display = display;
            t = new SerialTransportAddress("COM3", false);
            transport = new SerialTransport(t, 9600);
            transport.Start(this);
        }
        public void Send(Message message,object value)
        {
            //1 byte: movement/telemtry
            //1 byte: right/left - forward/backward
            //2 bytes: (short) distance in centimeters or angle in degrees
            byte[] buffer;
            switch (message)
            {
                case Message.Forward:
                    buffer = new byte[3];
                    buffer[0] = (byte)'f';

                    this.FromShort((short)value, buffer, 1);
                    break;
                case Message.Backward:
                    buffer = new byte[3];
                    buffer[0] = (byte)'b';

                    this.FromShort((short)value, buffer, 1);
                    break;
                case Message.TurnLeft:
                    buffer = new byte[1];
                    buffer[0] = (byte)'l';
                    break;
                case Message.TurnRight:
                    buffer = new byte[1];
                    buffer[0] = (byte)'r';
                    break;
                case Message.Stop:
                    buffer = new byte[1];
                    buffer[0] = (byte)'s';
                    break;
                case Message.ToManual:
                    buffer = new byte[1];
                    buffer[0] = (byte)'m';
                    break;
                case Message.StopManual:
                    buffer = new byte[1];
                    buffer[0] = (byte)'M';
                    break;
                default:
                    buffer = new byte[0];
                    break;
            }

            transport.Send(t, buffer);
        }

        public void DataReceived(byte[] buffer, int offset, int length, TransportAddress t)
        {
            byte[] tmpBuff = new byte[length];
            for (int i = 0; i < length; i++)
            {
                tmpBuff[i] = buffer[offset + i];
            }

            object value;
            switch ((char)tmpBuff[0])
            {
                case 'm':
                    switch ((char)tmpBuff[1])
                    {
                        case 'm':
                            value = ToShort(tmpBuff, 2);
                            display.UpdateMode((short)value);
                            break;
                        default:
                            break;
                    }
                    break;
                case 't':
                    switch ((char)tmpBuff[1])
                    {
                        case 'S':
                            value = ToShort(tmpBuff, 2);
                            display.UpdateS1((short)value);
                            break;
                        case 's':
                            value = ToShort(tmpBuff, 2);
                            display.UpdateS2((short)value);
                            break;
                        case 'L':
                            value = ToShort(tmpBuff, 2);
                            display.UpdateL1((short)value);
                            break;
                        case 'l':
                            value = ToShort(tmpBuff, 2);
                            display.UpdateL2((short)value);
                            break;
                        default:
                            break;
                    }
                    break;
                case 'p':
                    switch ((char)tmpBuff[1])
                    {
                        case 'x':
                            value = ToDouble(tmpBuff, 2);
                            display.SetPositionX((double)value);
                            break;
                        case 'y':
                            value = ToDouble(tmpBuff, 2);
                            display.SetPositionY((double)value);
                            break;
                        case 'a':
                            value = ToDouble(tmpBuff, 2);
                            display.SetPositionAngle((double)value);
                            break;
                    }
                    break;
                case 'a':
                    switch ((char)tmpBuff[1])
                    {
                        case 'p':
                            value = ToDouble(tmpBuff, 2);
                            display.SetPitch((double)value);
                            break;
                        case 'y':
                            value = ToDouble(tmpBuff, 2);
                            display.SetYaw((double)value);
                            break;
                        case 'r':
                            value = ToDouble(tmpBuff, 2);
                            display.SetRoll((double)value);
                            break;
                        case 'm':
                            value = ToDouble(tmpBuff, 2);
                            display.SetMHead((double)value);
                            break;
                    }
                    break;
                case 'v':
                    switch ((char)tmpBuff[1])
                    {
                        case 'x':
                            value = ToDouble(tmpBuff, 2);
                            display.SetVelocityX((double)value);
                            break;
                        case 'y':
                            value = ToDouble(tmpBuff, 2);
                            display.SetVelocityY((double)value);
                            break;
                        case 't':
                            value = ToDouble(tmpBuff, 2);
                            display.SetTime((double)value);
                            break;
                    }
                    break;
                case 'A':
                    switch ((char)tmpBuff[1])
                    {
                        case 'X':
                            value = ToDouble(tmpBuff, 2);
                            display.SetAccX((double)value);
                            break;
                        case 'Y':
                            value = ToDouble(tmpBuff, 2);
                            display.SetAccY((double)value);
                            break;
                        case 'Z':
                            value = ToDouble(tmpBuff, 2);
                            display.SetAccZ((double)value);
                            break;
                    }
                    break;
                case 'G':
                    switch ((char)tmpBuff[1])
                    {
                        case 'X':
                            value = ToDouble(tmpBuff, 2);
                            display.SetGyroX((double)value);
                            break;
                        case 'Y':
                            value = ToDouble(tmpBuff, 2);
                            display.SetGyroY((double)value);
                            break;
                        case 'Z':
                            value = ToDouble(tmpBuff, 2);
                            display.SetGyroZ((double)value);
                            break;
                    }
                    break;
                case 'M':
                    switch ((char)tmpBuff[1])
                    {
                        case 'X':
                            value = ToDouble(tmpBuff, 2);
                            display.SetMagX((double)value);
                            break;
                        case 'Y':
                            value = ToDouble(tmpBuff, 2);
                            display.SetMagY((double)value);
                            break;
                        case 'Z':
                            value = ToDouble(tmpBuff, 2);
                            display.SetMagZ((double)value);
                            break;
                    }
                    break;
                case 'T':
                    switch ((char)tmpBuff[1])
                    {
                        case 'X':
                            value = ToDouble(tmpBuff, 2);
                            display.SetTempX((double)value);
                            break;
                        case 'Y':
                            value = ToDouble(tmpBuff, 2);
                            display.SetTempY((double)value);
                            break;
                        case 'Z':
                            value = ToDouble(tmpBuff, 2);
                            display.SetTempZ((double)value);
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void FromShort(short theUShort, byte[] buffer, int offset)
        {
            unchecked
            {
                buffer[offset] = (byte)theUShort;
                buffer[offset + 1] = (byte)(theUShort >> 8);
            }
        }

        private short ToShort(byte[] buffer, int offset)
        {
            return (short)(
               (buffer[offset] & 0x000000FF) |
               (buffer[offset + 1] << 8 & 0x0000FF00)
               );
        }

        private int ToString(byte[] buffer, int offset, out string theString)
        {
            // Strings are prefixed with an integer size
            short len = ToShort(buffer, offset);

            // Encoding's GetChars() converts an entire buffer, so extract just the string
            //part
            byte[] tmpBuffer = new byte[len];
            int dst = offset + sizeof(int);

            Array.Copy(buffer, dst, tmpBuffer, 0, len);

            theString = new string(Encoding.UTF8.GetChars(tmpBuffer));

            return (dst + len) - offset;
        }

        private double ToDouble(byte[] buffer, int offset)
        {
            string s;
            ToString(buffer, offset, out s);

            double d = double.Parse(s, CultureInfo.InvariantCulture);

            return d;
        }
    }
}
