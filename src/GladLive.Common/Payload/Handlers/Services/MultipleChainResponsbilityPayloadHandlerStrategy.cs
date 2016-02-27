using GladNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common
{
	/// <summary>
	/// Combines strategies for payload handling in a chain of responsibility fashion.
	/// </summary>
	/// <typeparam name="TSessionType">The session type.</typeparam>
	public class MultipleChainResponsbilityPayloadHandlerStrategy<TSessionType> : IPayloadHandlerStrategy<TSessionType>
		where TSessionType : INetPeer
	{
		private IEnumerable<IPayloadHandlerStrategy<TSessionType>> strategyChain { get; }

		public MultipleChainResponsbilityPayloadHandlerStrategy(IEnumerable<IPayloadHandlerStrategy<TSessionType>> strategies)
		{
			strategyChain = strategies;
		}

		public MultipleChainResponsbilityPayloadHandlerStrategy(params IPayloadHandlerStrategy<TSessionType>[] strategies)
		{
			strategyChain = strategies;
		}

		public bool TryProcessPayload(PacketPayload payload, IMessageParameters parameters, TSessionType peer)
		{
			//Defer the request to each strat and if one handles it properly then we stop chaining
			foreach (IPayloadHandlerStrategy<TSessionType> s in strategyChain)
				if (s.TryProcessPayload(payload, parameters, peer))
					return true;

			return false;
		}
	}
}
