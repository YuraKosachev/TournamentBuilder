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
            CreateMap<AppQuery<Tournament>, ListViewModel<TournamentViewModel>>()
             .ForMember(item => item.List, exp => exp.MapFrom(src => src.Select(i => Mapper.Map<TournamentViewModel>(i))))
                .AfterMap((src, dest) =>
                {
                    dest.CountItem = src.CountItem();
                });
            CreateMap<TournamentViewModel, Tournament>().ReverseMap();
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
                return Ok(Mapper.Map<ListViewModel<TournamentViewModel>>(list));
            });

        }

        [HttpGet]
        [Route("api/tournament/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return BaseActionResult(()=> {
                return Ok(Factory.TournamentService.Item(new Tournament { Id = id }));
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
        //implements filtring 
        
    }
}
