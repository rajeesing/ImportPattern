using ImportPattern.Models.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImportPattern.Application.Command.Create.Customer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, int>
    {
        Task importProcess = null;
        private static readonly Task<int> ZeroTask = Task.FromResult(0);
        public Task<int> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {

            if (!cancellationToken.IsCancellationRequested)
            {
                if (request.CustomerList.Count() > 0)
                {
                    var progress = new Progress<double>();
                    progress.ProgressChanged += Progress_ProgressChanged;
                    importProcess = new Task(() =>
                    {
                        BeginProcess(request.CustomerList);
                    }, TaskCreationOptions.LongRunning);
                    importProcess.Start();
                }
            }
            return ZeroTask;
        }

        private void Progress_ProgressChanged(object sender, double e)
        {
            throw new NotImplementedException();
        }

        private void BeginProcess(IEnumerable<CustomerModel> customerList, IProgress<double> progress = null)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //var total = bannersPhrases.Select(p => p.Phrase).Count();
            //var pageSize = 10; // set your page size, which is number of records per page

            //var page = 1; // set current page number, must be >= 1 (ideally this value will be passed to this logic/function from outside)

            //var skip = pageSize * (page - 1);

            //var canPage = skip < total;

            //if (!canPage) // do what you wish if you can page no further
            //    return;

            //Phrases = bannersPhrases.Select(p => p.Phrase)
            //             .Skip(skip)
            //             .Take(pageSize)
            //             .ToArray();



            double percentCompleted = 0;
            int startPage = 1, pageSize = 20;
            foreach (var obj in customerList)
            {
                //var customer = (CustomerModel)obj;
                Parallel.Invoke(
                        () => ProcessPartialArray(customerList, startPage, startPage * pageSize, out percentCompleted)
                    );
                startPage = (startPage * pageSize) + 1;
                progress?.Report(percentCompleted);
            }
        }

        private void ProcessPartialArray(IEnumerable<CustomerModel> customerList, int begin, int end, out double percentCompleted)
        {
            foreach (var obj in customerList)
            {
                var customer = (CustomerModel)obj;
                
            }
            percentCompleted = 1;
        }
    }
}
