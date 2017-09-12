using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentBuilder.Domain.Core
{
    public class Player:IModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        [ForeignKey("Team")]
        public Guid? TeamId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }

        //navi settings
        public virtual Team Team { get; set; }
    }
}
