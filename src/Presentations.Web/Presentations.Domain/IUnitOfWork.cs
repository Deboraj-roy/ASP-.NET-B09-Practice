using System;
using System.Collections.Generic;
using System.Text;

namespace Presentations.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
    }
}
