using SimpleHttpServer.Models;
using System.IO;
using System.Text;
using System.Threading;

namespace SimpleHttpServer.Utilities
{
    public static class StreamUtils
    {
        public static string ReadLine(Stream stream)
        {
            int nextChar;
            StringBuilder data = new StringBuilder();
            while (true)
            {
                nextChar = stream.ReadByte();
                if (nextChar == '\n') { break; }
                if (nextChar == '\r') { continue; }
                if (nextChar == -1) { Thread.Sleep(1); break; };
                data.Append((char)nextChar);
            }
            return data.ToString();
        }
        public static void WriteResponse(Stream stream, HttpResponse response)
        {
            byte[] responseHeader = Encoding.UTF8.GetBytes(response.ToString());
            stream.Write(responseHeader, 0, responseHeader.Length);
            stream.Write(response.Content, 0, response.Content.Length);
        }
    }
}
