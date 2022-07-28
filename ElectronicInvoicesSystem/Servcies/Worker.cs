using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tidal_ERP_System.Electronic_Invoice;

namespace ElectronicInvoicesSystem.Servcies
{
    public class Worker : IWorker
    {
        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (EInvoice_Helper._accessToken == null || EInvoice_Helper._accessToken.access_token == string.Empty)
                {
                    EInvoice_Helper.FetchToken();
                }
                await Task.Delay(20000);
            }
        }
    }
}
