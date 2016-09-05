﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Models
{
    public class Row
    {
        public string ClassName { get; set; }

        public List<Col> Cols { get; set; }

        public Row()
        {
            Cols = new List<Col>();
        }
    }
}
