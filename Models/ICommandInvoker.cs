using System;

namespace ImportPattern.Models
{
    public interface ICommandInvoker
    {
        ICommand GetCommand(Type commandType);
    }
}