﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Exceptions.Commons
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string? message) : base(message) { }
    }
}
