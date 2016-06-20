using GladNet.Common;
using GladNet.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common.Payloads
{
	[GladNetSerializationContract]
	[GladNetSerializationInclude((int)PayloadNumber.LoginRequest, typeof(PacketPayload), false)] //I don't really like this design. I wish Attributes could have generics and could compute things at compile time.
	public class LoginRequest : PacketPayload
	{
		/// <summary>
		/// String required for a login/authentication
		/// (Ex. Username, Email, One-off token)
		/// </summary>
		[GladNetMember(1, IsRequired = true)]
		public string LoginString { get; private set; }

		/// <summary>
		/// Encrypted password used for authentication
		/// Should not be plaintext.
		/// </summary>
		[GladNetMember(2, IsRequired = true)]
		public byte[] EncryptedPassword { get; private set; }

		/// <summary>
		/// Protected protobuf-net ctor.
		/// </summary>
		protected LoginRequest()
		{

		}
	}
}
