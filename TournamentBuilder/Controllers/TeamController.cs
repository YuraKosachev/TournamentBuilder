using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using System.Web.Http;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Models;
using TournamentBuilder.Domain.Extensions;

namespace TournamentBuilder.Controllers
{
    public class TeamMapperProfile : Profile
    {
        public TeamMapperProfile()
        {
            CreateMap<AppQuery<Team>, ListViewModel<Team>>()
                .ForMember(item => item.List, exp => exp.MapFrom(src => src.Select(t=>Mapper.Map<TeamViewModel>(t))))
                .AfterMap((src, dest) =>
                {
                    dest.CountItem = src.CountItem();
                });
            CreateMap<TeamViewModel, Team>()
                .ReverseMap()
                .ForMember(item => item.Players, exp => exp.MapFrom(src => src.Players.Select(p=>Mapper.Map<PlayerViewModel>(p))));
        }
    }

    public class TeamController : BaseController
    {
        public TeamController() : base() { }
        
        //Get api/team/id
        [HttpGet]
        [Route("api/team/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return BaseActionResult(()=> {
                var item = Factory.TeamService.Item(new Team { Id = id });
                return Ok(Mapper.Map<TeamViewModel>(item));
            });
        }
        //Post api/team
        [HttpPost]
        [Route("api/team")]
        public IHttpActionResult Post(TeamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return BaseActionResult(() => {
                return Ok(Factory.TeamService.Set(Mapper.Map<Team>(model)));
            });
        }
        //Delete api/team/{id}
        [HttpDelete]
        [Route("api/team/{id}")]
        public IHttpActionResult Delete(Guid id)
        {

            return BaseActionResult(()=> {
                return Ok(Factory.TeamService.Delete(new Team { Id = id }));
            });
        }
        //Put api/team
        [HttpPut]
        [Route("api/team")]
        public IHttpActionResult Put(TeamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return BaseActionResult(()=> {
                return Ok(Factory.TeamService.Update(Mapper.Map<Team>(model)));
            });
        }
        //list api/teams
        [HttpGet]
        [Route("api/teams")]
        public IHttpActionResult List()
        {
            return BaseActionResult(()=> {
                var list = Factory.TeamService.OptionsList();
                return Ok(Mapper.Map<ListViewModel<Team>>(list));
            });
        }
        [HttpGet]
        [Route("api/teams/lookup")]
        public IHttpActionResult LookUp()
        {
            return BaseActionResult(() => {

                return Ok(Factory.TeamService.GetDictionary().Select(item => new { Id = item.Key, Name = item.Value }));
            });

        }
    }
}
