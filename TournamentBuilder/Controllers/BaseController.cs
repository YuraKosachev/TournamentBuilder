using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TournamentBuilder.Infrastructure.Business;
using TournamentBuilder.Services.Interfaces;
using TournamentBuilder.Domain.Exceptions;
using TournamentBuilder.Models;

using AutoMapper;
using TournamentBuilder.Domain.Extensions;

namespace TournamentBuilder.Controllers
{
    //public abstract class BaseMapperProfile<TSource,TDest> : Profile
    // where TDest:class
    //    where TSource :class
    //{
    //    public BaseMapperProfile()
    //    {
    //        CreateMap<AppQuery<TSource>, ListViewModel<TDest>>()
    //         .ForMember(item => item.List, exp => exp.MapFrom(src => src.Select(i => Mapper.Map<TDest>(i))))
    //            .AfterMap((src, dest) =>
    //            {
    //                dest.CountItem = src.CountItem();
    //            });

    //    }

    //} 
    public abstract class BaseController : ApiController
    {
        public IServiceFactory Factory { get; protected set; }
        public BaseController(IServiceFactory factory)
        {
            Factory = factory;
        }
        public BaseController() : this(new ServiceFactory()) { }

        protected IHttpActionResult BaseActionResult(Func<IHttpActionResult> func)
        {
            try
            {
                return func();
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
