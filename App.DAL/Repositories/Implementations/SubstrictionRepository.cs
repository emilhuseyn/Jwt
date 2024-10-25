﻿using App.Core.Entities;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Implementations
{
    public class SubstrictionRepository : Repository<Substrictions>, ISubstrictionRepository
    {
        public SubstrictionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
