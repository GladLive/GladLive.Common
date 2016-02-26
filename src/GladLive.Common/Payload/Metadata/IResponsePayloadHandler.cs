using GladNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common.Payload
{
	/// <summary>
	/// IoC/Meta-data Market for Response handlers.
	/// </summary>
	/// <typeparam name="TPeerType">Type of the peer.</typeparam>
	/// <typeparam name="TPayloadType">Type of the payload</typeparam>
	public interface IResponsePayloadHandler<in TPeerType, TPayloadType> : IPayloadHandler<TPeerType, TPayloadType>
		where TPeerType : INetPeer where TPayloadType : PacketPayload
	{

	}
}
