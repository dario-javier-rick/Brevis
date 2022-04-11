using System.IO;
using System.Threading.Tasks;
using EstudiarEsElCamino.Core.Model;
using EstudiarEsElCamino.Web.Controllers;
using EstudiarEsElCamino.Web.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EstudiarEsElCamino.Web.Pages
{
    public class IndexModel : PageModel
    {
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

            // MVC Pattern
            var model = new StudyPath();
            var view = new StudyPathView(model);
            var controller = new StudyPathController(view);

            model.AttachObserver(controller);
            //model.AttachObserver(view);

            // to do : return something
            var subjects = controller.GetCriticalStudyPath("{}"); //json de prueba. TODO: hacer mapping
            model.Notify();

            return new JsonResult(subjects);
        }
    }
}
