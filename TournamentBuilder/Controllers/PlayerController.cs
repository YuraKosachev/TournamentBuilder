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
using TournamentBuilder.Domain.Exceptions;

using AutoMapper;
using TournamentBuilder.Domain.Extensions;

namespace TournamentBuilder.Controllers
{
    public class PlayerMapperProfile: Profile// : BaseMapperProfile<Player, PlayerViewModel>
    {
        public PlayerMapperProfile()
        {
            CreateMap<AppQuery<Player>, ListViewModel<Player>>()
                .ForMember(item => item.List, exp => exp.MapFrom(src => src.Select(i => Mapper.Map<PlayerViewModel>(i))))
                .AfterMap((src, dest) =>
                {
                    dest.CountItem = src.CountItem();
                });

            CreateMap<PlayerViewModel, Player>().ReverseMap();
        }
    }

    public class PlayerController : BaseController
    {

        public PlayerController() : base() { }
        //Set
        [HttpPost]
        [Route("api/player")]
        public IHttpActionResult Post(PlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

             return  BaseActionResult(() =>
            {
                return Ok(Factory.PlayerService.Set(Mapper.Map<Player>(model)));
            });
          
        }
        //getItem
        [HttpGet]
        [Route("api/player/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return  BaseActionResult(() =>
            {
               return Ok(Factory.PlayerService.Item(new Player { Id = id }));
            });
         
        }
        //delete
        [HttpDelete]
        [Route("api/player/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            return BaseActionResult(() =>
            {
                return Ok(Factory.PlayerService.Delete(new Player { Id = id }));
            });
          
        }
        //update
        [HttpPut]
        [Route("api/player")]
        public IHttpActionResult Put(PlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return BaseActionResult(()=> {
                return Ok(Factory.PlayerService.Update(Mapper.Map<Player>(model)));
            });
        }

        [HttpGet]
        [Route("api/players/{property}/{asc:bool}/{current:int}/{size:int}")]
        public IHttpActionResult Get(string property,bool asc,int current,int size)//string property, bool asc, int current, int size)
        {

            return BaseActionResult(() =>
            {
                var list = Factory.PlayerService.OptionsList();
                property = string.IsNullOrEmpty(property) ? "NickName" : property;
                //if (model != null)
                //{
                //    //list.Filter(item => item.);
                //    //list.Sort(property, asc).TakePage(current, size);
                //    //list.ToList();
                //}
                list.Sort(property, false).TakePage(current, size);
                return Ok(Mapper.Map<ListViewModel<Player>>(list));
            });
           
        }

        [HttpGet]
        [Route("api/players/lookup")]
        public IHttpActionResult LookUp()
        {
            return BaseActionResult(()=> {

                return Ok(Factory.PlayerService.GetDictionary().Select(item=>new { Id = item.Key,Name = item.Value }));
            });

        }

        // GET: api/players
        [HttpGet]
        [Route("api/players")]
        public IHttpActionResult Get()
        {
            return BaseActionResult(() =>
            {
                var list = Factory.PlayerService.OptionsList();
                return Ok(Mapper.Map<ListViewModel<Player>>(list));
            });

        }
    }
}