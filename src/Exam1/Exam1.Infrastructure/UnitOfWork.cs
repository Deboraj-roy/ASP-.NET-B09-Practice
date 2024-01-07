﻿using Exam1.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public virtual void Dispose() => _dbContext?.Dispose();

        public virtual async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

        public virtual void Save() => _dbContext?.SaveChanges();

        public virtual async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
