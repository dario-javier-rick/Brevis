
namespace Brevis.Importer.CsvReader
{
    void Main()
    {
        string file = @"Brevis.Files/approvedSubjects.csv";
        var progressCarreer = new CsvImporter().Import<ProgressCarreer>(file);
        Console.WriteLine(progressCarreer);
    }
}