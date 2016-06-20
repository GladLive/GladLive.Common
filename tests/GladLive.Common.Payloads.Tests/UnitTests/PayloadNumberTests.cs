using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common.Payloads.Tests
{
	[TestFixture]
	public static class PayloadNumberTests
	{
		[Test]
		public static void Test_Payload_Numbers_Stay_Positive()
		{
			//arrange
			PayloadNumber[] values = Enum.GetValues(typeof(PayloadNumber)) as PayloadNumber[];

			//Assert
			foreach (PayloadNumber num in values)
				Assert.True((int)num > 0, $"All {nameof(PayloadNumber)} values must be greater than 0.");
		}
	}
}
