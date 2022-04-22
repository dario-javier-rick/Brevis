using Brevis.Core.Model;
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
        public List<T> Import<T>(string csvFile)
        {
            List<T> list = new List<T>();
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
                var record = 0;
                foreach (var prop in props)
                {
                    var column = columns.SingleOrDefault(c => c.Name == prop.Name);
                    var value = data[column.Position];
                    //                    var typeOfProp = prop.PropertyType;
                    if (column.Position == 0 && record == 0) // codigo de carrera
                    {
                        StudyPlan studyPlan = new StudyPlan();
                        prop.SetValue(obj, studyPlan);

                    } else {
                        Subject subject = new Subject();
                        subject.Code = value;
                        prop.SetValue(obj, subject);
                    }
                    //                    prop.SetValue(obj, Convert.ChangeType(value, typeOfProp));
                }
                list.Add(obj);
            });
            return list;
        }
    }
}
