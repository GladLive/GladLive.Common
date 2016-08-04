using GladNet.Common;
using GladNet.Payload;
using GladNet.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common.Payloads
{
	/// <summary>
	/// Packet payload used to request a login to a server.
	/// Includes serializable data such as <see cref="LoginResponseCode"/>.
	/// </summary>
	[GladNetSerializationContract]
	[GladNetSerializationInclude((GladNetIncludeIndex)PayloadNumber.LoginResponse, typeof(PacketPayload), false)] //I don't really like this design. I wish Attributes could have generics and could compute things at compile time.
	public class LoginResponse : PacketPayload
	{
		/// <summary>
		/// String required for a login/authentication
		/// (Ex. Username, Email, One-off token)
		/// </summary>
		[GladNetMember(GladNetDataIndex.Index1, IsRequired = true)]
		public LoginResponseCode Code { get; private set; }

		/// <summary>
		/// Creates a login response payload with the specified <see cref="LoginResponseCode"/>.
		/// </summary>
		/// <param name="code">Response code indicating the result of a <see cref="LoginRequest"/>.</param>
		public LoginResponse(LoginResponseCode code)
		{
			Code = code;
		}

		/// <summary>
		/// Protected protobuf-net ctor.
		/// </summary>
		protected LoginResponse()
		{

		}
	}
}
