using CurrentDatetime.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrentDatetime.API.Controllers
{
    [ApiController]
    public class DatetimeController : ControllerBase
    {
        private static IDatetimeProvider _datetimeProvider;         
        //(static) to allow mocking datetime calling API

        public DatetimeController(IDatetimeProvider datetimeProvider)
        {
            if(_datetimeProvider == null) _datetimeProvider = datetimeProvider;
        }
        // GET: api/<DatetimeController>
        [HttpGet]
        [Route("api/datetime/now")]
        public DateTime Now()
        {
            return _datetimeProvider.UtcNow;
        }

        [HttpPost]
        [Route("api/datetime/mock")]
        public void Mock([FromBody] DateTime datetime)
        {
            var datetimeProviderMock = new Mock<IDatetimeProvider>();
            datetimeProviderMock.Setup(dtp => dtp.UtcNow).Returns(datetime);

            _datetimeProvider = datetimeProviderMock.Object;
        }
    }
}
