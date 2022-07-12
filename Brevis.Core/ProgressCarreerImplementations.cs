using System.Collections.Generic;

namespace Brevis.Core
{
    /// <summary>
    /// Auxiliary class in order to list the registered implementations
    /// </summary>
    public class ProgressCarreerImplementations
    {
        public Dictionary<string, IProgressCarreerTransformer> registeredImplementations { get; }

        public ProgressCarreerImplementations(Dictionary<string, IProgressCarreerTransformer> implementations)
        {
            this.registeredImplementations = implementations;
        }
    }
}
