﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KnightsArcadeV2.Models
{
    public partial class TestsQueue
    {
        [Required]
        public int? GameId { get; set; }
        public int? RetryCount { get; set; }
    }
}
