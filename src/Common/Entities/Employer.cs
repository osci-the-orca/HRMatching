﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Employer
    {
        public Employer()
        {
        }

        public Employer(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
