using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brevis.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Brevis.Web.Pages
{
    public class TreeModel : PageModel
    {
        public IEnumerable<Subject> _subjects ;


        public void OnGet(IEnumerable<Subject> subjects)
        {
            //_subjects = subjects;
            _subjects = new List<Subject> { new Subject { Code = "A" } };

        }
    }
}
