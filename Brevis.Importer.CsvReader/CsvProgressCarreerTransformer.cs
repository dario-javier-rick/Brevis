using Brevis.Core.Models;
using System.IO;

namespace Brevis.Importer.CsvReader
{
    public class CsvProgressCarreerTransformer : Core.IProgressCarreerTransformer
    {
        public ProgressCarreer Transform(Stream input)
        {
            var progressCarreer = new CsvImporter().Import<ProgressCarreer>(input);
            return progressCarreer;
        }
    }
}
