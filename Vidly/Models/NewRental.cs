﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class NewRental
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}