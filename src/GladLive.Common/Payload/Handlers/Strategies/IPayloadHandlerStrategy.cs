using GladNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common
{
	public interface IPayloadHandlerStrategy<TSessionType>
		where TSessionType : INetPeer
	{
		bool TryProcessPayload(PacketPayload payload, IMessageParameters parameters, TSessionType peer);
	}
}
