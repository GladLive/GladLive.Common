using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common.Payloads
{
	//This isn't the greatest design but we need to keep unique numbers that map to unique payload types
	//across all of our servers. There is likely a better design, such as having all payloads in the same project and just using
	//conditional compile, but this is how it will be done for now. Check the other projects Payload projs.
	//Reference: https://github.com/GladLive/GladLive.Server.Common/blob/master/src/GladLive.Server.Common/Payload/PayloadNumber.cs
	public enum PayloadNumber : int
	{
		LoginRequest = 1,
		LoginResponse = 2,
	}
}
