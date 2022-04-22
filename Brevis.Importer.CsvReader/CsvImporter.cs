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
        public ProgressCarreer Import<T>(string csvFile, Correlativities correlativities)
        {
          
            List<Subject> subjects = new List<Subject>();
            StudyPlan studyPlan = new StudyPlan(correlativities);

            var lines = System.IO.File.ReadAllLines(csvFile);
            var headerLine = lines.First();
            var columns = headerLine.Split(separator).ToList().Select((v, i) => new { Position = i, Name = v });
            var dataLines = lines.Skip(1).ToList();
            var type = typeof(T);
            var props = type.GetProperties();

            dataLines.ForEach(line =>
            {
                T obj = (T)Activator.CreateInstance(type);
                var data = line.Split(separator).ToList();
                foreach (var prop in props)
                {
                    var column = columns.SingleOrDefault(c => c.Name == prop.Name);
                    var value = data[column.Position];
                    if (column.Position == 1)
                    {
                        Subject subject = new Subject();
                        subject.Code = value;
                        subjects.Add(subject);
                    }
                }

            });
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.StudyPlan = studyPlan;
            progressCarreer.ApprovedSubjects = subjects;
            return progressCarreer;
        }
    }
}
