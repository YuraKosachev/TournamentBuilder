using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace TournamentBuilder.Domain.Core
{
    public class Team:IModel
    {
        [Key]
        public Guid Id { get; set; }
        public Nullable<Guid> ImageId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        //navi settings
        public virtual ICollection<Player> Players { get; set; }
    }
}
