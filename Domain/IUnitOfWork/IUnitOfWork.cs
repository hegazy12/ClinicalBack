using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Domain.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> SaveChangesAsync();

    }
}
