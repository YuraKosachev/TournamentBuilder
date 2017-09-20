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
    public class TournamentSettingsControllerProfile : Profile
    {
        public TournamentSettingsControllerProfile()
        {
            //CreateMap<AppQuery<TournamentSettings>, ListViewModel<TournamentSettingsViewModel>>()
            //.ForMember(item => item.List, exp => exp.MapFrom(src => src.Select(i => Mapper.Map<TournamentSettingsViewModel>(i))))
            //   .AfterMap((src, dest) =>
            //   {
            //       dest.CountItem = src.CountItem();
            //   });
            CreateMap<TournamentSettingsViewModel, TournamentSettings>().ReverseMap();
        }
    }

    public class TournamentSettingsController : BaseController
    {
        public TournamentSettingsController() : base() { }

        [HttpGet]
        [Route("api/settings/tournament/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            return BaseActionResult(()=> {
                var item = Factory.TournamentSettingsService.Item(new TournamentSettings { Id = id });
                return Ok(Mapper.Map<TournamentSettingsViewModel>(item));
               
            });
        }
        [HttpPost]
        [Route("api/settings/tournament")]
        public IHttpActionResult Post(TournamentSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return BaseActionResult(()=> {
                var item = Factory.TournamentSettingsService.Set(Mapper.Map<TournamentSettings>(model));
                return Ok(item);
            });
        }
        [HttpPut]
        [Route("api/settings/tournament")]
        public IHttpActionResult Put(TournamentSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return BaseActionResult(() => {
                var item = Factory.TournamentSettingsService.Set(Mapper.Map<TournamentSettings>(model));
                return Ok(item);
            }); ;
        }
     

    }
}
