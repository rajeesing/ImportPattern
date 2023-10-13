using ImportPattern.Models.Customer;
using ImportPattern.Models.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Models
{
    public class CommandInvoker : ICommandInvoker
    {
        private List<ICommand> commandList = new List<ICommand>();
        public IMediator _mediator { get; set; }
        public CommandInvoker(IMediator mediator)
        {
            _mediator = mediator;
            //commandList.Add(new CustomerCommand());
            commandList.Add(new ProductCommand(_mediator));
        }

        public ICommand GetCommand(Type commandType)
        {
            foreach(var commandObject in commandList)
            {
                if(commandObject.GetType() == commandType)
                {
                    return commandObject;
                }
            }
            return null;
        }
    }
}
