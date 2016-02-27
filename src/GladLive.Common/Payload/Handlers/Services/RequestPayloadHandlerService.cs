using GladNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common
{
	public class RequestPayloadHandlerService<TSessionType> : IRequestPayloadHandlerService<TSessionType>
		where TSessionType : INetPeer
	{
		private IPayloadHandlerStrategy<TSessionType> handlerStrat;

		public RequestPayloadHandlerService(IPayloadHandlerStrategy<TSessionType> strat)
		{
			handlerStrat = strat;
		}

		public bool TryProcessPayload(PacketPayload payload, IMessageParameters parameters, TSessionType peer)
		{
			return handlerStrat.TryProcessPayload(payload, parameters, peer);
		}
	}
}
