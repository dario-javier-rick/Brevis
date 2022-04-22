using Brevis.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brevis.Importer.CsvReader
{
    public class CsvProgressCarreerTransformer : Core.IProgressCarreerTransformer
    {
        public ProgressCarreer Transform(object input)
        {
            //TODO by Ale :)
            string file = @"Brevis.Files/approvedSubjects.csv";
            var progressCarreer = new CsvImporter().Import<ProgressCarreer>(file);
            System.Console.WriteLine(progressCarreer);
            throw new NotImplementedException();
        }
    }
}
