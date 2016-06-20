using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common.Payloads
{
	[Serializable]
	public enum LoginResponseCode : byte //even though this causes boxing in some cases it reduces bandwidth
	{
		Success = 0,
		Banned,
		Locked,
		Limited,
		AccountDoesntExist,
	}
}
