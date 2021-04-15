using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FlightDetection;

namespace FlightDetection
{
    public class MyFlightClient : IFlightClient

    {

        Socket mySocket;
        public void connect(string ip, int port)
        {
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            mySocket.Connect(ip, port);
        }
        public void write(string command)
        {
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(command + "\r\n");
            mySocket.Send(byData);
        }
        public string read()
        {
            throw new NotImplementedException();
        }
        public void disconnact()
        {
            mySocket.Close();
        }

        void IFlightClient.disconnect()
        {
            throw new NotImplementedException();
        }


    }




}