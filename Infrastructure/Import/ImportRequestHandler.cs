using ImportPattern.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImportPattern.Infrastructure.Import
{
    public class ImportRequestHandler : IRequestHandler<ImportRequest, int>
    {
        private readonly ICommandInvoker _invoker;
        public ImportRequestHandler(ICommandInvoker invoker)
        {
            _invoker = invoker;
        }
        public async Task<int> Handle(ImportRequest request, CancellationToken cancellationToken)
        {
            //Task importProcess = null;
            if (request.ModelList.Count() > 0)
            {
                //importProcess = new Task(() =>
                //{
                    //CommandInvoker invoker = new CommandInvoker();
                    var command = _invoker.GetCommand(request.CommandType);
                    await command.Execute(request.ModelList);
                //    }, TaskCreationOptions.LongRunning);
                //importProcess.Start();
               return await Task.FromResult(1);
            }
            return await Task.FromResult(0);



            //return await request.Begin();
        }
    }
}
