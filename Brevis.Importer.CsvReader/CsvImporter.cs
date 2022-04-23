using Brevis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brevis.Importer.CsvReader
{
    public class CsvImporter
    {
        //https://www.writeafunction.com/generic-method-to-import-csv-data-into-a-list-in-csharp/
        const string separator = ",";
        public ProgressCarreer Import<T>(string csvFile)
        {
            List<Subject> subjects = new List<Subject>();
            var lines = System.IO.File.ReadAllLines(csvFile);
            var dataLines = lines.Skip(1).ToList();
            dataLines.ToList().ForEach(line => 
            {
                var lineWithData = line.Split(separator).ToList();
                foreach (var item in lineWithData)
                {
                    subjects.Add(new Subject { Code = item });
                }
            });
            ProgressCarreer progressCarreer = new ProgressCarreer
            {
                StudyPlanCode = getStudyPlanCode(lines),
                ApprovedSubjects = subjects
            };
            return progressCarreer;
        }
        private string getStudyPlanCode(string[] lines)
        {
            var StudyPlanCode = lines[1].Split(separator)[1];
            return StudyPlanCode;
        }
    }
}
