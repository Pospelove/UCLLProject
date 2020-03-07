using System;
using System.Collections.Generic;

namespace GIP1.Web.Entities
{
    public partial class Lokaal
    {
        public Lokaal()
        {
            Les = new HashSet<Les>();
        }

        public string Lokaalcode { get; set; }
        public string Locatie { get; set; }
        public int? Capaciteit { get; set; }
        public string Opmerking { get; set; }
        public string Middelen { get; set; }

        public virtual ICollection<Les> Les { get; set; }
    }
}
