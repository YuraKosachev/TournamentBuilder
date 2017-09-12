using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TournamentBuilder.Infrastructure.Business;
using TournamentBuilder.Services.Interfaces;

namespace TournamentBuilder.Controllers
{
    public abstract class BaseController : ApiController
    {
        public IServiceFactory Factory { get; private set; }
        public BaseController(IServiceFactory factory)
        {
            Factory = factory;
        }
        public BaseController() : this(new ServiceFactory()) { }
    }
}
