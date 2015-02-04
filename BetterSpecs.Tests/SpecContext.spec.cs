using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterSpecs.Tests
{
    [TestClass]
    public class SpecContextTests : SpecContext
    {

        [TestInitialize]
        public void before_each()
        {
            Speclog.Current.Clear();
        }

        [TestMethod]
        public void describe_speccontext_while_using_it()
        {
            context["when use SpecContext class"] = () =>
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
        public void describe_before()
        {
            context["when use SpecContext class"] = () =>
            {
                before = () => Console.WriteLine("Calling 'before' statment");

                context["with other internal context"] = () =>
                {
                    it["it is work very well"] = () => Assert.IsTrue(true);
                    it["it is work very well"] = () => Assert.IsTrue(true);
                    it["it is work very well"] = () => Assert.IsTrue(true);
                };
            };
        }

        [TestMethod]
        public void describe_speccontext_log()
        {
            context["with other internal context"] = () =>
            {
                it["it is work very well"] = () => Assert.IsTrue(true);
            };

            Console.WriteLine(Speclog.Current.ToString());
        }

    }
}
