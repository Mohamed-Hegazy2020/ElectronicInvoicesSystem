using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Servcies
{
   public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}
