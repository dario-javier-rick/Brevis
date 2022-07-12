using Brevis.Core.Models;
using System.IO;

namespace Brevis.Importer.XlsReader
{
    public class XlsProgressCarreerTransformer : Core.IProgressCarreerTransformer
    {
        public ProgressCarreer Transform(Stream input)
        {
            var progressCarreer = new XlsImporter().Import<ProgressCarreer>(input);
            return progressCarreer;
        }
    }
}
