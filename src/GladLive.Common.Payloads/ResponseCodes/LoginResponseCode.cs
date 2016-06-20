using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common.Payloads
{
	//Based on: https://github.com/GladLive/GladLive.Web.Payloads/blob/master/src/GladLive.Web.Payloads.Authentication/Payloads/AuthResponseCode.cs
	//This is basically the clientside available subset of return codes.
	/// <summary>
	/// Indicates the result of a <see cref="LoginRequest"/>.
	/// </summary>
	[Serializable]
	public enum LoginResponseCode : byte //even though this causes boxing in some cases it reduces bandwidth
	{
		/// <summary>
		/// Indicates that the login was successful.
		/// </summary>
		Success = 0,

		/// <summary>
		/// Indicates that the login failed due to the user being banned.
		/// </summary>
		Banned,

		/// <summary>
		/// Indicates that the login failed due to the user account being temporarily locked.
		/// </summary>
		Locked,

		/// <summary>
		/// Indicates that the login failed to a general failure.
		/// </summary>
		Failed,

		/// <summary>
		/// Indicates that the login failed due to the authentication server being unreachable or unavailable.
		/// </summary>
		AuthServerUnavailable,
	}
}
