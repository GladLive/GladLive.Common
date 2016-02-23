using GladLive.Common;
using GladNet.Common;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladLive.Common.Tests
{
	[TestFixture]
	public static class ChainPayloadHandlerTests
	{
		[Test]
		public static void Test_Ctor_Doesnt_Throw()
		{
			//arrange
			Assert.DoesNotThrow(() => new ChainPayloadHandler<INetPeer>());
		}

		[Test]
		public static void Test_Can_Add_New_Handler()
		{
			//arrange
			var chain = new ChainPayloadHandler<INetPeer>();
			Mock<IPayloadHandler<INetPeer, PacketPayload>> handler = new Mock<IPayloadHandler<INetPeer, PacketPayload>>();

			//act
			bool result = chain.Register(handler.Object);

			//assert
			Assert.IsTrue(result, "Couldn't add a handler to the chain.");
		}

		[Test]
		public static void Test_Indicates_Add_Failure_On_Null()
		{
			//arrange
			var chain = new ChainPayloadHandler<INetPeer>();

			//act
			bool result = chain.Register<INetPeer, PacketPayload>(null);

			//assert
			Assert.IsFalse(result, "Was able to add a null handler.");
		}

		//Can't do this test because we can't cast
		/*[Test]
		public static void Test_Chain_Handler_Calls_Handle_Methods_On_Handlers()
		{
			//arrange
			var chain = new ChainPayloadHandler<INetPeer>();
			Mock<IPayloadHandler<INetPeer, PacketPayload>> handler = new Mock<IPayloadHandler<INetPeer, PacketPayload>>();

			handler.Setup(x => x.TryProcessPayload(It.IsAny<PacketPayload>(), It.IsAny<IMessageParameters>(), It.IsAny<INetPeer>()))
				.Returns(true);

			//act
			bool result = chain.Register(handler.Object);
			Assert.IsTrue(result, "Couldn't add a handler to the chain.");

			chain.TryProcessPayload(Mock.Of<PacketPayload>(), Mock.Of<IMessageParameters>(), Mock.Of<INetPeer>());

			//assert
			handler.Verify(x => x.TryProcessPayload(It.IsAny<PacketPayload>(), It.IsAny<IMessageParameters>(), It.IsAny<INetPeer>()), Times.Once());
		}*/
	}
}
