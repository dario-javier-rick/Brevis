using Brevis.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Brevis.Importer.CsvReader
{
    public class CsvImporter
    {
        //https://www.writeafunction.com/generic-method-to-import-csv-data-into-a-list-in-csharp/
        const string separator = "-";
        public ProgressCarreer Import<T>(Stream stream)
        {
            List<Subject> subjects = new List<Subject>();

            // convert stream to string
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();

            var lines = text.Split("\r\n");
            var dataLines = lines.Skip(1).ToList();
            dataLines.ToList().ForEach(line =>
            {
                var lineWithData = line.Split(separator).ToList();
                subjects.Add(new Subject { Code = lineWithData[0] });
            });
            ProgressCarreer progressCarreer = new ProgressCarreer
            {
                CurriculumCode = lines.First(),
                ApprovedSubjects = subjects
            };
            return progressCarreer;
        }
    }
}
