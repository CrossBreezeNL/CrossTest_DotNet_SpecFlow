using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossBreeze.CrossTest.SpecFlow.Utils
{
    public class DataTypeUtils
    {
        public static byte[] StringToByteArray(String hex)
        {
            String hexToProcess = hex;
            // If the hex starts with 0x, strip it of before creating the byte array.
            if (hexToProcess.StartsWith("0x"))
                hexToProcess = hexToProcess.Substring(2);

            int NumberChars = hexToProcess.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hexToProcess.Substring(i, 2), 16);
            return bytes;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            hex.Append("0x");
            foreach (byte b in ba)
                hex.AppendFormat("{0:X2}", b);
            return hex.ToString();
        }
    }
}
