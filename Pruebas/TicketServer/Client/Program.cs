using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

class MyClient
{
    public static void Main()
    {
        TcpChannel tcpChannel = new TcpChannel();
        ChannelServices.RegisterChannel(tcpChannel, false);

        Type requiredType = typeof(MovieTicketInterface);

        MovieTicketInterface remoteObject = (MovieTicketInterface)Activator.GetObject(requiredType, "tcp://localhost:9998/MovieTicketBooking");

        Console.WriteLine(remoteObject.GetTicketStatus("Ticket No: 3344"));
        Console.ReadLine();
    }
}