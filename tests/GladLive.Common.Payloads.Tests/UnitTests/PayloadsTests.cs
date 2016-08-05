using GladLive.Common.Payloads;
using GladNet.Common;
using GladNet.Payload;
using GladNet.Serializer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common.Payloads.Tests
{
	[TestFixture]
	public class PayloadsTests
	{
		[Test]
		public static void Test_Payloads_Dont_Have_Duplicate_GladNetSerializationInclude_Values()
		{
			//arrange

			//These are all the payload types.
			IEnumerable<Type> payloadTypes = typeof(LoginRequest).Assembly.GetTypes()
				.Where(t => t.BaseType == typeof(PacketPayload));

			//assert: Make sure all have unique ids in the include
			foreach(Type p1 in payloadTypes)
			{
				foreach(Type p2 in payloadTypes)
				{
					//Don't compare same types IDs.
					if (p1 == p2)
						continue;

					Assert.AreNotEqual(p1.GetCustomAttributes(true)
					.Where(o => o.GetType() == typeof(GladNetSerializationIncludeAttribute))
					.Cast<GladNetSerializationIncludeAttribute>().First().TagID, p2.GetCustomAttributes(true)
					.Where(o => o.GetType() == typeof(GladNetSerializationIncludeAttribute))
					.Cast<GladNetSerializationIncludeAttribute>().First().TagID);
				}
			}
		}
	}
}
