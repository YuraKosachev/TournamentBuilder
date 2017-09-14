using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TournamentBuilder.Controllers;

namespace TournamentBuilder
{
    public class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(
                cfg =>
                {
                  cfg.AddProfile<PlayerMapperProfile>();
                    cfg.AddProfile<TeamMapperProfile>();

                }
            );
        }
    }
}