using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentBuilder.Domain.Core
{
    public class Player:IModel,IParticipant
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        [ForeignKey("Team")]
        public Guid? TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        //[Index(IsUnique = true)]
        public string Email { get; set; }

        //navi settings
        public virtual ICollection<Tournament> Tournaments { get; set; }
        public virtual Team Team { get; set; }
        
    }
}
