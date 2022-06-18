using System;
using System.Collections.Generic;
using System.Linq;
using Brevis.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Brevis.Web.Pages
{
    public class TreeModel : PageModel
    {
        public string _jsonSubjects;


        public void OnGet(IEnumerable<Subject> subjects)
        {
            var returnedSubjects = subjects.Select(t =>
                            new
                            {
                                Id = Int16.Parse(t.Code),
                                Label = t.Name
                            }).ToArray();
            _jsonSubjects = JsonConvert.SerializeObject(returnedSubjects);
        }
    }
}
