using CsvHelper;
using ImportPattern.Models;
using ImportPattern.Models.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImportPattern.Infrastructure.Import
{
    public class ImportRequest : IRequest<int>
    {
        public IEnumerable<IModel> ModelList { get; set; }
        public Type CommandType { get; set; }
        public delegate decimal UpdateProgress(decimal percentageCompleted);

        public ImportRequest(IEnumerable<IModel> modelList, Type commandType, UpdateProgress progress)
        {
            ModelList = modelList;
            CommandType = commandType;
        }

       
    }
}
