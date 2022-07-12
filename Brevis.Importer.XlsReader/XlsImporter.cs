namespace Brevis.Importer.XlsReader
{
    using Brevis.Core.Models;
    using NPOI;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using NPOI.HSSF.UserModel;
    using System;

    public class XlsImporter
    {
        //https://www.writeafunction.com/generic-method-to-import-csv-data-into-a-list-in-csharp/
        const string separator = "-";
        public ProgressCarreer Import<T>(Stream stream)
        {
            var curriculumCode = string.Empty;
            List<Subject> subjects = new List<Subject>();
            var excelWorkbook = new HSSFWorkbook(stream);
            var worksheet = excelWorkbook.GetSheetAt(0);
            curriculumCode = worksheet.GetRow(0).GetCell(0).StringCellValue;
            for (int i = 1; i < worksheet.LastRowNum; i++)
            {
                var cell = worksheet.GetRow(i).GetCell(0);
                var value = cell.StringCellValue.Trim();
                if (!string.IsNullOrEmpty(value))
                {
                    subjects.Add(new Subject { Code = value });
                }
            }


            ProgressCarreer progressCarreer = new ProgressCarreer
            {
                CurriculumCode = curriculumCode,
                ApprovedSubjects = subjects
            };
            return progressCarreer;
        }
    }
}
