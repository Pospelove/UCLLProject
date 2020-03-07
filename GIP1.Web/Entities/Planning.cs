using System;
using System.Collections.Generic;

namespace GIP1.Web.Entities
{
    public partial class Planning
    {
        public Planning()
        {
            Les = new HashSet<Les>();
        }

        public string Planningcode { get; set; }
        public DateTime? Datumtijd { get; set; }

        public virtual ICollection<Les> Les { get; set; }
    }
}
