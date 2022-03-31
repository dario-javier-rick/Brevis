namespace EstudiarEsElCamino.Core.BusinessProcess
{
    using EstudiarEsElCamino.Core.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SubjectBusinessProcess
    {
        public IEnumerable<Subject> Process(IEnumerable<SubjectStatus> subjectStatuses)
        {
            return subjectStatuses
                //.Where(x=> ) TODO...
                .Select(x => x.Subject);
        }
    }
}
