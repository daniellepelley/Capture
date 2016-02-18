using System.Linq;
using Castle.Components.DictionaryAdapter.Xml;
using NUnit.Framework;

namespace Capture.Core.Test
{
    public class MonitorInterceptorTest
    {
        [Test]
        public void MonitorTest_ReturnValue()
        {
            var monitor = new MonitorInterceptor<IDemoClass>(new DemoClass());
            monitor.Object.Process("foo");
            Assert.AreEqual("foo", monitor.List.First().ReturnValue);
        }

        [Test]
        public void MonitorTest_Arguments()
        {
            var monitor = new MonitorInterceptor<IDemoClass>(new DemoClass());
            monitor.Object.Process("foo");
            Assert.AreEqual("foo", monitor.List.First().Arguments.First().ToString());
        }

        [Test]
        public void MonitorTest_Type()
        {
            var monitor = new MonitorInterceptor<IDemoClass>(new DemoClass());
            monitor.Object.Process("foo");
            Assert.AreEqual("Capture.Core.Test.DemoClass", monitor.List.First().InvocationTarget.GetComponentType().FullName);
        }

        [Test]
        public void MonitorTest_Method()
        {
            var monitor = new MonitorInterceptor<IDemoClass>(new DemoClass());
            monitor.Object.Process("foo");
            Assert.AreEqual("Process", monitor.List.First().Method.Name);
        }
    }
}
