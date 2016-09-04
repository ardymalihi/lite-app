﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Models
{
    public class Row
    {
        public string ClassName { get; set; }

        public List<Attribute> Attributes { get; set; }

        public List<Col> Cols { get; set; }

        public Row()
        {

            Attributes = new List<Attribute> { new Attribute { Name = "class", Value= "row" } };
            Cols = new List<Col>();
        }

        public string GetHtmlAttribute()
        {
            return string.Format("class = \"{0}\" ", ClassName) + string.Join(" ", Attributes.Where(o=>o.Name.ToLower() != "class").Select(o => string.Format("\"{0}\"=\"{1}\"",o.Name, o.Value)).ToArray());
        }
    }
}