using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EstudiarEsElCamino.Core.BusinessProcess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EstudiarEsElCamino.Web.Pages
{
    public class IndexModel : PageModel
    {
        private SubjectBusinessProcess _subjectBusinessProcess { get; set; }

        public void OnGet()
        {

        }


        [BindProperty]
        public IFormFile File { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            //Getting file meta data
            var fileName = Path.GetFileName(File.FileName);
            var contentType = File.ContentType;

            // to do something with the above data
            //_subjectBusinessProcess....


            // to do : return something
            throw new NotImplementedException();
        }
    }
}
