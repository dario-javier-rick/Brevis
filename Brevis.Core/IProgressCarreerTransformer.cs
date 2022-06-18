using Brevis.Core.Models;
using System.IO;

namespace Brevis.Core
{
    public interface IProgressCarreerTransformer
    {
        ProgressCarreer Transform(Stream input);
    }
}
