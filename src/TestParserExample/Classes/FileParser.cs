using CommonLib.Classes;
using CommonLib.Interfaces;
using CommonLib.Interfaces.DataManagers;
using CommonLib.Interfaces.Mappers;
using CommonLib.Interfaces.Validators;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParserExample.Classes
{
    public class FileParser : IFileParser
    {
        private readonly ILogger<FileParser> _logger;
        private readonly IBaseDataManager _dataManager;
        private readonly IBaseMapper _mapper;
        private readonly IBaseValidator _validator;

        public FileParser(ILogger<FileParser> logger, IBaseDataManager dataManager, IBaseMapper mapper, IBaseValidator validator)
        {
            _logger = logger;
            _dataManager = dataManager;
            _mapper = mapper;
            _validator = validator;
        }

        public ParsingResult Parse(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
