using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadConversion.Models
{
    public class ConversionDatabaseSettings : IConversionDatabaseSettings
    {
        public string ConversionsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IConversionDatabaseSettings
    {
        public string ConversionsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
