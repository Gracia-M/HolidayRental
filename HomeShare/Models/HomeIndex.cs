using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class HomeIndex
    {
        public IEnumerable<BienEchangeList> BiensEchanges { get; set; }
        public IEnumerable<BienEchangeList> BienEchange5Last { get; set; }
        public IEnumerable<PaysDetails> ListePays { get; set; }
        public IEnumerable<MembreDetails> Membres { get; set; }
        public ConnectionForm Connection { get; set; }
        public MembreCreate CreationMembre { get; set; }
    }
}
