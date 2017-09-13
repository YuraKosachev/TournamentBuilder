using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TournamentBuilder.Models
{
    public class PlayerViewModel
    {
        
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        public Guid? TeamId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
    }
}