using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterSpecs.Tests
{
    [TestClass]
    public class SpecContextTests : SpecContext
    {

        [TestMethod]
        public void describe_speccontext_while_using_it()
        {
            describe["when use SpecContext class"] = () =>
            {
                context["with other internal context"] = () =>
                {
                    it["it is work very well"] = () => Assert.IsTrue(true);
                    it["it is work very well"] = () => Assert.IsTrue(true);
                    it["it is work very well"] = () => Assert.IsTrue(true);
                };

                context["with second internal context"] = () =>
                {
                    it["it is work very well too!!!"] = () => Assert.IsTrue(true);
                };

                context["Great!!!"] = () => Assert.IsTrue(true);
            };
        }

        [TestMethod]
        public void mix_contexts()
        {
            context["when use SpecContext class"] = () =>
            {
                context["with other internal context"] = () =>
                {
                    it["it is work very well"] = () => Assert.IsTrue(true);
                    it["it is work very well"] = () => Assert.IsTrue(true);
                    it["it is work very well"] = () => Assert.IsTrue(true);
                };
            };
        }

        [TestMethod]
        public void using_let()
        {
            var test1 = string.Empty;
            var test2 = string.Empty;

            let.Add("test1", () => { test1 = "value"; return test1; });
            let.Add("test2", () => { test2 = "value"; return test2; });

            context["with other internal context"] = () =>
            {
                it["test is empty"] = () => Assert.AreEqual("", test1);
                it["test is full"] = () => Assert.AreEqual("value", let["test1"]);

                it["test is empty"] = () => Assert.AreEqual("", test2);
                it["test is full"] = () => Assert.AreEqual("value", let["test2"]);
            };
        }
    }
}
