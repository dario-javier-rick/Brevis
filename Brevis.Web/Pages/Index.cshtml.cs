﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Brevis.Core;
using Brevis.Core.Models;
using Brevis.Web.Controllers;
using Brevis.Web.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Brevis.Web.ServiceResolver;

namespace Brevis.Web.Pages
{
    public class IndexModel : PageModel
    {
        public Dictionary<string, string> _progressCarreerTransformerImplementations = new Dictionary<string, string>();
        public string selectedProgressCarreer;

        public IProgressCarreerTransformer _progressCarreerTransformer;

        ProgressCarreerTransformerResolver _progressCarreerTransformerResolver;
        public IndexModel(ProgressCarreerTransformerResolver progressCarreerTransformerResolver)
        {
            _progressCarreerTransformerResolver = progressCarreerTransformerResolver;
        }

        public void OnGet()
        {
            //TODO: Find a proper way to make this. The fact is that the ProgressCarreerTransformerResolver knows how to
            //resolve them, but it can't list them all
            var implementations = new Dictionary<string, string>();
            implementations.Add("CSV", "Brevis.Importer.CsvReader.CsvProgressCarreerTransformer");
            implementations.Add("XLS", "Brevis.Importer.XlsReader.XlsProgressCarreerTransformer");

            foreach (var implementation in implementations)
            {
                try
                {
                    var progressCarreerTransformer = _progressCarreerTransformerResolver(implementation.Value);
                    _progressCarreerTransformerImplementations.Add(implementation.Key, implementation.Value);
                }
                catch (ArgumentException ex)
                {
                    //The implementation isn't registered
                }
            }
        }


        [BindProperty]
        public IFormFile File { get; set; }
        public async Task<IActionResult> OnPostAsync(string selectedProgressCarreer)
        {
            //Getting file meta data
            var fileName = Path.GetFileName(File.FileName);
            var contentType = File.ContentType;

            // MVC Pattern
            var model = new StudyPath();
            var view = new StudyPathView(model);
            var controller = new StudyPathController(view);

            model.AttachObserver(controller);
            //model.AttachObserver(view);

            _progressCarreerTransformer = _progressCarreerTransformerResolver(selectedProgressCarreer); //Pass XLS, CSV, etc.

            ProgressCarreer progressCarrer;


            if (File.Length == 0)
            {
                throw new ArgumentException("File is empty");
            }

            using (var ms = new MemoryStream())
            {
                File.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);

                progressCarrer = _progressCarreerTransformer.Transform(ms);
            }

            var subjects = controller.GetCriticalStudyPath(progressCarrer);

            model.Notify();

            return RedirectToPage("Tree", new { subjects = subjects });
        }
    }
}
