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
        public Nullable<Guid> ImageId { get; set; }
        [ForeignKey("Team")]
        public Nullable<Guid> TeamId { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        //[Index(IsUnique = true)]
        public string Email { get; set; }

        //navi settings
        public virtual Team Team { get; set; }
    }
}
