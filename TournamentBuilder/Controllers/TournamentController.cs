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
    public class TournamentControllerProfile : Profile
    {
        public TournamentControllerProfile()
        {
            CreateMap<AppQuery<Tournament>, ListViewModel<ShortTournamentViewModel>>()
             .ForMember(item => item.List, exp => exp.MapFrom(src => src.Select(i => Mapper.Map<ShortTournamentViewModel>(i))))
                .AfterMap((src, dest) =>
                {
                    dest.CountItem = src.CountItem();
                });
            CreateMap<Tournament, ShortTournamentViewModel>();
              
                
            CreateMap<TournamentViewModel, Tournament>()
                .ReverseMap()
                .ForMember(item => item.Players, exp => exp.MapFrom(src => src.Players.Select(i => Mapper.Map<PlayerViewModel>(i))))
                //.ForMember(item=>item.Teams,exp=>exp.Ignore())
                .ForMember(item=>item.Teams,exp=>exp.MapFrom(src=>src.Teams.Select(i=>Mapper.Map<TeamViewModel>(i))))
                .ForMember(item => item.TournamentSetting, exp => exp.MapFrom(src => Mapper.Map<TournamentSettingsViewModel>(src.TournamentSetting)));
                
        }
       
    }


    public class TournamentController : BaseController
    {
        public TournamentController() : base() { }

        [HttpGet]
        [Route("api/tournaments")]
        public IHttpActionResult Get()
        {
            return BaseActionResult(()=> {
                var list = Factory.TournamentService.OptionsList();
                return Ok(Mapper.Map<ListViewModel<ShortTournamentViewModel>>(list));
            });

        }

        [HttpGet]
        [Route("api/tournament/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return BaseActionResult(()=> {
                var item = Factory.TournamentService.Item(new Tournament { Id = id });
                return Ok(Mapper.Map<TournamentViewModel>(item));
            });

        }
        [HttpPost]
        [Route("api/tournament")]
        public IHttpActionResult Post(TournamentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return BaseActionResult(()=> {

                return Ok(Factory.TournamentService.Set(Mapper.Map<Tournament>(model)));
            });
        }
        [HttpDelete]
        [Route("api/tournament/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            return BaseActionResult(()=> {
                return Ok(Factory.TournamentService.Delete(new Tournament { Id = id}));
            });
        }
        [HttpPut]
        [Route("api/tournament")]
        public IHttpActionResult Put(TournamentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return BaseActionResult(() => {

                return Ok(Factory.TournamentService.Update(Mapper.Map<Tournament>(model)));
            });
        }
        [HttpPost]
        [Route("api/tournament/teamparticipant")]
        public IHttpActionResult TeamParticipant(Guid id,TeamViewModel model)
        {
            return BaseActionResult(()=> {
                SetParticipant(id, Mapper.Map<Team>(model));
                return Ok();
            });
        }

        [HttpPost]
        [Route("api/tournament/playerparticipant")]
        public IHttpActionResult PlayerParticipant(Guid id, PlayerViewModel model)
        {
            return BaseActionResult(() => {

                return Ok(SetParticipant(id, Mapper.Map<Player>(model)));
            });
        }

        private IParticipant SetParticipant(Guid id, IParticipant model)
 
        { 
            return Factory.TournamentService.SetParticipant(new Tournament { Id = id }, model , model is Team);
        }

        //implements filtring 

    }
}
