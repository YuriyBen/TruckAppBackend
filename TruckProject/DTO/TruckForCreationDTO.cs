﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.DTO
{
    public class TruckForCreationDTO:TruckForManipulationDTO
    {
        public string BrandSearch { get; set; }

        public long UserId { get; set; }

    }
}
