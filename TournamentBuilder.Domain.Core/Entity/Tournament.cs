using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentBuilder.Domain.Core
{
    public class Tournament:IModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OwnId { get; set; }
        public Guid? ImageId { get; set; }
        
        public Guid? TournamentSettingsId { get; set; }
        public Guid? CMSSettingsId { get; set; }
        public Guid? ResultsId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }



        //navi setting
        public virtual ICollection<TournamentGameResults> Result { get; set; }
        public virtual TournamentSettings TournamentSetting { get; set; }

    }
}
