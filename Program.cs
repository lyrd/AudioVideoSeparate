﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVideoSeparate
{
    class Program
    {
        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        static void Main(string[] args)
        {
            byte[] buffer = ReadFile(Directory.GetCurrentDirectory() +  "\\1111.mp4");
            string path = Directory.GetCurrentDirectory() + "\\2222.mp4";

            File.WriteAllBytes(path, buffer);

            //Console.WriteLine("Ok");
            //Console.ReadKey();
        }
    }
}
