using System;
using System.Collections.Generic;

namespace GIP1.Web.Entities
{
    public partial class Les
    {
        public int LesId { get; set; }
        public string Vakcode { get; set; }
        public string Lokaalcode { get; set; }
        public string Planningcode { get; set; }
        public string Lesnaam { get; set; }

        public virtual Lokaal LokaalcodeNavigation { get; set; }
        public virtual Planning PlanningcodeNavigation { get; set; }
        public virtual Vak VakcodeNavigation { get; set; }
    }
}
