using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SeliseTask_003;
using System;
using Unity;
using Unity.Injection;

namespace TestLaboratory
{
    [TestClass]
    public class DatetimeTester
    {
        [TestMethod]
        public void CurrentQuarterTest()
        {
            UnityFactory.RegisterComponents();

            var datetimeProviderMock = new Mock<IDatetimeProvider>();
            datetimeProviderMock.SetupGet(dtp => dtp.UtcNow).Returns(new DateTime(2020, 6, 1));

            UnityFactory.container.RegisterType
                <DatetimeCalculator, DatetimeCalculator>
                (new InjectionConstructor(datetimeProviderMock.Object));

            DatetimeCalculator dtprocessor = UnityFactory.container.Resolve<DatetimeCalculator>();

            Assert.AreEqual(dtprocessor.CurrentQuarter, 2);
        }

        [TestMethod]
        public void LeapYearTest()
        {
            UnityFactory.RegisterComponents();

            var datetimeProviderMock = new Mock<IDatetimeProvider>();
            datetimeProviderMock.SetupGet(dtp => dtp.UtcNow).Returns(new DateTime(2020, 6, 1));

            UnityFactory.container.RegisterType<DatetimeCalculator, DatetimeCalculator>
                (new InjectionConstructor(datetimeProviderMock.Object));

            DatetimeCalculator dtprocessor = UnityFactory.container.Resolve<DatetimeCalculator>();

            Assert.IsTrue(dtprocessor.IsLeapYear());
        }
    }
}
