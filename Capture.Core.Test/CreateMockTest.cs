using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Moq;
using NUnit.Framework;

namespace Capture.Core.Test
{
    public class CreateMockTest
    {
        [Test]
        public void MonitorTest2()
        {
            var monitor = new MonitorInterceptor<IDemoClass>(new DemoClass());
            monitor.Object.Process("World");

            var sb = new StringBuilder();
            sb.AppendLine("var mock = new Mock<IDemoClass>();");
            sb.AppendLine(@"mock.Setup(x => x.Process(""World""))");
            sb.AppendLine(@"    .Returns(""World"");");

            var expected = sb.ToString();

            var actual = CreateMock(monitor.List);

            Assert.AreEqual(expected, actual);
        }

        private string CreateMock(IEnumerable<IInvocation> invocations)
        {
            var sb = new StringBuilder();
            sb.AppendLine("var mock = new Mock<IDemoClass>();");

            foreach (var invocation in invocations)
            {
                sb.AppendLine(string.Format(@"mock.Setup(x => x.Process(""{0}""))", invocation.Arguments.First()));
                sb.AppendLine(string.Format(@"    .Returns(""{0}"");", invocation.ReturnValue));
            }
            return sb.ToString();
        }
    }

    public class MockTest
    {
        [Test]
        public void Test1()
        {
            var mock = new Mock<IDemoClass>();

            mock.Setup(x =>
                x.Process(It.Is<Dto>(dto => dto.Value1 == "hi" && dto.Number == 2)))
                .Returns(
                    new Dto
                    {
                        Number = 2,
                        Value1 = "hi"
                    });
        }
    }
}