using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TournamentBuilder.Services.Interfaces;
using TournamentBuilder.Infrastructure.Business;

namespace TournamentBuilder.Controllers
{
    public class PlayerController : ApiController
    {
        private IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        public PlayerController() : this(new PlayerService()) { }

        // GET: api/players
        [HttpGet]
        [Route("api/players")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}