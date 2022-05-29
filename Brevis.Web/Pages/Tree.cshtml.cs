using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevis.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Brevis.Web.Pages
{
    public class TreeModel : PageModel
    {
        public string _jsonSubjects ;


        public void OnGet(IEnumerable<Subject> subjects)
         {
            //var _subjects = subjects;
            var _subjects = new List<Subject> { 
                 new Subject { Code = "1", Name="A" }
                , new Subject { Code = "2", Name="B" }
                , new Subject { Code = "3", Name="C" }
                };
            
            var returnedSubjects = _subjects.Select(t =>
                            new {
                                Id = Int16.Parse(t.Code),
                                Label = t.Name
                            }).ToArray();
            _jsonSubjects = JsonConvert.SerializeObject(returnedSubjects);
        }
    }
}
