﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class RandomViewModel
    {

        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}