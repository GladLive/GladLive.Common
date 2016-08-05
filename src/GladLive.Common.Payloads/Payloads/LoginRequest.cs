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
	/// Includes serializable data such as <see cref="LoginString"/> and <see cref="EncryptedPassword"/>.
	/// </summary>
	[GladNetSerializationContract]
	[GladNetSerializationInclude((GladNetIncludeIndex)PayloadNumber.LoginRequest, typeof(PacketPayload), false)] //I don't really like this design. I wish Attributes could have generics and could compute things at compile time.
	public class LoginRequest : PacketPayload
	{
		/// <summary>
		/// String required for a login/authentication
		/// (Ex. Username, Email, One-off token)
		/// </summary>
		[GladNetMember(GladNetDataIndex.Index1, IsRequired = true)]
		public string LoginString { get; private set; }

		/// <summary>
		/// Encrypted password used for authentication
		/// Should not be plaintext.
		/// </summary>
		[GladNetMember(GladNetDataIndex.Index2, IsRequired = true)]
		public byte[] EncryptedPassword { get; private set; }

		/// <summary>
		/// Creates a new <see cref="LoginRequest"/> which can be sent over the wire
		/// to request a login.
		/// </summary>
		/// <param name="loginString">String required for a login/authentication.</param>
		/// <param name="encryptedPassword">Encrypted password used for authentication.</param>
		public LoginRequest(string loginString, byte[] encryptedPassword)
		{
			LoginString = loginString;
			EncryptedPassword = encryptedPassword;
		}

		/// <summary>
		/// Protected protobuf-net ctor.
		/// </summary>
		protected LoginRequest()
		{

		}
	}
}
