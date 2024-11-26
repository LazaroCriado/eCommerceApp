﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Brand
    {
        public int Id { get; set; }
        [DisplayName("Marca")]
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
