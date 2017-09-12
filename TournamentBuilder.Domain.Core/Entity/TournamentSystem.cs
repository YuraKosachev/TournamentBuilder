using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentBuilder.Domain.Core
{
    public class TournamentSystem : IModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Decriptions { get; set; }
    }
}
