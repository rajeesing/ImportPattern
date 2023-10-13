using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportPattern.Models
{
    public interface ICommand
    {
        Task Execute(IEnumerable<IModel> model);
    }
}
