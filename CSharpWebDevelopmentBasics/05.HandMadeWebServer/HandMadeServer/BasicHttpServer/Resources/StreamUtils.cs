namespace BasicHttpServer.Resources
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using Models;

    public class StreamUtils
    {
        public static string ReadLine(Stream stream)
        {
            StringBuilder builder = new StringBuilder();
                int currentByte;
                while (true)
                {
                    currentByte = stream.ReadByte();
                    
                    if (currentByte == '\n')
                    {
                        break;
                    }
                    if (currentByte == '\r')
                    {
                        continue;
                    }
                    if (currentByte == -1)
                    {
                        Thread.Sleep(1);
                        continue;
                    }
                char byteAsChar = (char)currentByte;
                builder.Append(byteAsChar);
                }
            return builder.ToString();
        }

        public static void WriteResponse(Stream stream, HttpResponse httpResponse)
        {
            Console.WriteLine(httpResponse.ToString());
            byte[] responseHeader = Encoding.UTF8.GetBytes(httpResponse.ToString());
            stream.Write(responseHeader,0, responseHeader.Length);

            stream.Write(httpResponse.Content, 0, httpResponse.Content.Length);
        }
    }
}
