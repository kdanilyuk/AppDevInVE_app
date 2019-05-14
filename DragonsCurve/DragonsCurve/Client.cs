using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DragonsCurve
{
    class Client
    {

        private const int PORT = 8005;
        private const int SIZE = 1024;
        private static string textServer = null;

        public static int GetComplexity(){
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORT);
                Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                s1.Connect(ipEndPoint);

                byte[] byteRec = new byte[SIZE];

                int len = s1.Receive(byteRec);

                textServer = Encoding.ASCII.GetString(byteRec, 0, len);
                s1.Shutdown(SocketShutdown.Both);
                s1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadLine();
            }
            return int.Parse(textServer);
        }
    }
}
