﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Code { get; set; }
        public ICollection<Person>? People { get; set; } 
    }
}
