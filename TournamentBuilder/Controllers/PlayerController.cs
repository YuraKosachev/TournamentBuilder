using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Services.Interfaces;
using TournamentBuilder.Infrastructure.Business;
using TournamentBuilder.Models;

namespace TournamentBuilder.Controllers
{
    public class PlayerController : BaseController
    {

        public PlayerController() : base() { }

        [HttpGet]
        [Route("api/players/{property:string}/{asc:bool}/{current:int}/{size:int}")]
        public IHttpActionResult Get(string property,bool asc,int current,int size)
        {
            try
            {
                var list = Factory.PlayerService.OptionsList();
                //list.Filter(item => item.);
                list.Sort(property,asc).TakePage(current, size);
                //list.ToList();


                return Ok(new ListViewModel<Player> {
                    List = list.ToList(),
                    CountItem = list.CountItem()
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        
        

        // GET: api/players
        [HttpGet]
        [Route("api/players")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}