namespace Brevis.Importer.CsvReader
{
    using Brevis.Core.Models;
    public class CsvProgressCarreerTransformer : Core.IProgressCarreerTransformer
    {
        public ProgressCarreer Transform(object input)
        {
            string file = @"../Brevis.Files/approved_subjects.csv";
            var progressCarreer = new CsvImporter().Import<ProgressCarreer>(file);
            return progressCarreer;
        }
    }
}
