using System;
using System.Net;
using System.Net.Sockets;

namespace Helper.Net
{
    /// <summary>
    /// A Helper for Dns features.
	/// http://devauthority.com/blogs/krys/archive/2006/06/14/1330.aspx
    /// </summary>
    public static class DNSHelper
    {
		public static void Main()
		{
			System.Console.WriteLine(LocalIPAddress);
		}

        /// <summary>
        /// Returns the local machine IP address.
        /// Can be an IPv6 or IPv4
        /// </summary>
        static public IPAddress LocalIPAddress
        {
            get
            {
                //IPHostEntry localMachineInfo = Dns.Resolve(Dns.GetHostName());
				IPHostEntry localMachineInfo = Dns.GetHostEntry(Dns.GetHostName());

                // Search IPv6 Address (if supported)
                if (System.Net.Sockets.Socket.OSSupportsIPv6)
                    foreach (IPAddress ipAddress in localMachineInfo.AddressList)
                        if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
                            if ( ipAddress.ToString() != "::1" )
                                return ipAddress;

                // Search for IPv4
                foreach (IPAddress ipAddress in localMachineInfo.AddressList)
                    if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                        if ( ipAddress.ToString() != "127.0.0.1" )
                            return ipAddress;

                if (System.Net.Sockets.Socket.OSSupportsIPv6)
                    return IPAddress.Parse("::1");

                // IP = "127.0.0.1" ... No IP !!
                return IPAddress.Parse("127.0.0.1");
            }
        }

    }
}