namespace SimpleHttpServer.Utilities
{
    using System.IO;
    using System.Text;
    using System.Threading;
    using Models;

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
                if (nextChar == -1) { Thread.Sleep(millisecondsTimeout: 1); break; };
                data.Append(value: (char)nextChar);
            }

            return data.ToString();
        }

        public static void WriteResponse(Stream stream, HttpResponse response)
        {
            byte[] responseHeader = Encoding.UTF8.GetBytes(s: response.ToString());
            stream.Write(buffer: responseHeader, offset: 0, count: responseHeader.Length);
            stream.Write(buffer: response.Content, offset: 0, count: response.Content.Length);
        }
    }
}
