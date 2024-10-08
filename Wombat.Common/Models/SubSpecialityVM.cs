﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wombat.Common.Models
{
    public class SubSpecialityVM
    {
        public SubSpecialityVM()
        {
            Name = "";
        }
        //public int Id {
        //    get => _id;
        //    set
        //    {
        //        _id = value;
        //        DisplayId = _id;
        //    }
        //}

        public int Id { get; set; }

        public string Name { get; set; }

        public int? SpecialityId { get; set; }
        public SpecialityVM? Speciality { get; set; }

        public int DisplayId { get; set; }
        static public int NextDisplayId { get; set; } = 1;
    }
}
