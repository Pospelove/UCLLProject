﻿using System;
using System.Collections.Generic;

namespace GIP1.Web.Entities
{
    public partial class Vak
    {
        public Vak()
        {
            Les = new HashSet<Les>();
        }

        public string Vakcode { get; set; }
        public string Vaknaam { get; set; }
        public int? Studiepunten { get; set; }

        public virtual ICollection<Les> Les { get; set; }
    }
}
