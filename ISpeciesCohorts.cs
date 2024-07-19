using Landis.Core;
using System.Collections.Generic;

namespace Landis.Library.UniversalCohorts
{
    /// <summary>
    /// The cohorts for a particular species at a site.
    /// </summary>
    public interface ISpeciesCohorts
        : IISpeciesCohorts<ICohort>
    {
    }
}
