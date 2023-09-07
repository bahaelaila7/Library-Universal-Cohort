using Landis.Core;

namespace Landis.Library.UniversalCohorts
{
    /// <summary>
    /// An individual cohort for a species.
    /// </summary>
    public interface ICohort
    {
        /// <summary>
        /// The cohort's species.
        /// </summary>
        ISpecies Species
        {
            get;
        }
    }
}
