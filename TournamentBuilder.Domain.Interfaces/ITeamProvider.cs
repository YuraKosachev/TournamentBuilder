﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Core;


namespace TournamentBuilder.Domain.Interfaces
{
    public interface ITeamProvider:IRepository<Team>
    {
    }
}