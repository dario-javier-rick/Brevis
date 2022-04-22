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

            ICollection<Correlativities> correlativities = new List<Correlativities>();
            string file = @"../Brevis.Files/approved_subjects.csv";
            //(string)input how catch file???
            var progressCarreer = new CsvImporter().Import<ProgressCarreer>(file, correlativities);
            return progressCarreer;

        }
    }
}
