using Brevis.Core;
using Microsoft.AspNetCore.Http;

namespace Brevis.Web.Pages
{
    internal class TransformableObject : IProgressCarreerTransformable
    {
        private IFormFile file;

        public TransformableObject(IFormFile file)
        {
            this.file = file;
        }
    }
}