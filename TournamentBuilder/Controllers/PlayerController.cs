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
    public class PlayerMapperProfile : Profile
    {
        public PlayerMapperProfile()
        {
            CreateMap<AppQuery<Player>, ListViewModel<Player>>()
                .ForMember(item => item.List, exp => exp.MapFrom(src => src.ToList()))
                .AfterMap((src, dest) =>
                {
                    dest.CountItem = src.CountItem();
                });

            CreateMap<PlayerViewModel, Player>();
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

        [HttpGet]
        [Route("api/players/{property}/{asc:bool}/{current:int}/{size:int}")]
        public IHttpActionResult Get(FilterViewModel model)//string property, bool asc, int current, int size)
        {

            return BaseActionResult(() =>
            {
                var list = Factory.PlayerService.OptionsList();
                if (model != null)
                {
                    //list.Filter(item => item.);
                    //list.Sort(property, asc).TakePage(current, size);
                    //list.ToList();
                }
                list.Sort("NickName", false).TakePage(1, 1);
                return Ok(Mapper.Map<ListViewModel<Player>>(list));
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
                list.Sort("NickName", false).TakePage(1, 1);
                return Ok(Mapper.Map<ListViewModel<Player>>(list));
            });

        }
    }
}