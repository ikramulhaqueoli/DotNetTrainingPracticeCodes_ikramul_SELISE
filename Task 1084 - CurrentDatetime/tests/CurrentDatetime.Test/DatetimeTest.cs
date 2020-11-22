using CurrentDatetime.API.Models;
using Moq;
using System;
using Unity.Injection;
using Xunit;

namespace CurrentDatetime.Test
{
    public class DatetimeTest
    {
        [Fact]
        public void CurrentQuarterTest()
        {
            var datetimeProviderMock = new Mock<IDatetimeProvider>();
            datetimeProviderMock.Setup(dtp => dtp.UtcNow).Returns(new DateTime(2020, 6, 1));

                
            var dateProcessor = new DatetimeCalculator(datetimeProviderMock.Object);

            Assert.Equal(2, dateProcessor.CurrentQuarter);
        }
    }
}
