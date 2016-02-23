using GladNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common
{
	/// <summary>
	/// Provides chain of responsibility style semantics for payload handling.
	/// </summary>
	/// <typeparam name="TPeerType">Peer type to handle.</typeparam>
	public class ChainPayloadHandler<TPeerType> : IPayloadHandler<TPeerType>, IPayloadHandlerRegistry<TPeerType>
		where TPeerType : INetPeer
	{
		/// <summary>
		/// Collection of handles to chain over.
		/// </summary>
		private IList<IPayloadHandler<TPeerType>> handlers;

		public ChainPayloadHandler()
		{
			handlers = new List<IPayloadHandler<TPeerType>>();
		}

		public bool Register<THandlerPeerType, TPayloadType>(IPayloadHandler<THandlerPeerType, TPayloadType> payloadHandler)
			where THandlerPeerType : TPeerType
			where TPayloadType : PacketPayload
		{
			IPayloadHandler<TPeerType> h = payloadHandler as IPayloadHandler<TPeerType>;

			//Adds the handler to the collection
			//In the future we can do fancier things like checking to see if it has already been registered
			//We can also maybe lock to prepare for multithreading
			if (h != null)
			{
				handlers.Add(h);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Attempts to handle the <typeparamref name="TPayloadType"/> with static parameters.
		/// </summary>
		/// <typeparam name="TPayloadType">Payload type.</typeparam>
		/// <param name="payload">Payload instance.</param>
		/// <param name="parameters">Parameters the message was sent with.</param>
		/// <param name="peer">Peer that is involved with the message.</param>
		/// <returns>True if the handler can handle the type of packet.</returns>
		public bool TryProcessPayload(PacketPayload payload, IMessageParameters parameters, TPeerType peer)
		{
			bool result = false;

			foreach(IPayloadHandler<TPeerType> h in handlers)
			{
				result = h.TryProcessPayload(payload, parameters, peer) || result;
			}

			return result;
		}
	}
}
