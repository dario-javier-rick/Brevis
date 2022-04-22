using Brevis.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brevis.Core
{
    interface IProgressCarreerTransformer
    {
        ProgressCarreer Transform(Object input);
    }
}
