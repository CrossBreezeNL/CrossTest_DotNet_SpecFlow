using System;
using System.IO;
using System.Text;

namespace CrossBreeze.CrossTest.SpecFlow.Utils
{
    class MemoryStreamUtils
    {
        /// <summary>
        /// Write a byte into a memory stream.
        /// </summary>
        /// <param name="memoryStream"></param>
        /// <param name="bytesToWrite"></param>
        public static void WriteBytes(MemoryStream memoryStream, byte[] bytesToWrite)
        {
            memoryStream.Write(bytesToWrite, 0, bytesToWrite.Length);
        }

        public static void WriteInt(MemoryStream memoryStream, int intToWrite)
        {
            MemoryStreamUtils.WriteBytes(memoryStream, BitConverter.GetBytes(intToWrite));
        }

        public static void WriteString(MemoryStream memoryStream, string stringToWrite)
        {
            MemoryStreamUtils.WriteBytes(memoryStream, Encoding.Unicode.GetBytes((string)stringToWrite));
        }
    }
}
