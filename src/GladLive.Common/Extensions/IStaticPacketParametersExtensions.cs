using GladNet.Common;
using GladNet.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common.Extensions
{
	public static class IStaticPacketParametersExtensions
	{
		public static bool MatchesMessageParameters(this IStaticPayloadParameters payload, IMessageParameters messageParameters)
		{
			return payload.Channel == messageParameters.Channel && payload.DeliveryMethod == messageParameters.DeliveryMethod && messageParameters.Encrypted == payload.Encrypted;
		}
	}
}
