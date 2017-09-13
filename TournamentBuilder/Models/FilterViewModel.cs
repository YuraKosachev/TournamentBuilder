using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentBuilder.Models
{
    public class FilterViewModel
    {
        public string Property { get; set; }
        public bool Ascending { get; set; }
        public int Current { get; set; }
        public int Size { get; set; }
     
    }
}