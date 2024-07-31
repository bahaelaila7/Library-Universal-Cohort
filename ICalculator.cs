//  Authors:  Robert M. Scheller, James B. Domingo

using Landis.Core;
using Landis.SpatialModeling;
using Landis.Utilities;
using System.Dynamic;

namespace Landis.Library.UniversalCohorts
{
    /// <summary>
    /// A calculator for computing the change in an individual cohort's biomass
    /// due to annual growth and mortality.
    /// </summary>
    public interface ICalculator
    {

        //---------------------------------------------------------------------

        /// <summary>
        /// Computes the change in an individual cohort's parameters due to annual
        /// growth and mortality.
        /// </summary>
        /// <param name="cohort">
        /// The cohort whose biomass the change is to be computed for.
        /// </param>
        /// <param name="site">
        /// The site where the cohort is located.
        /// </param>
        /// <param name="otherChanges">
        /// Object containing the changes for additional parameters from the extension and their changes
        /// </param>
        /// /// <returns>
        /// The change in biomass
        /// </returns>

        double ComputeChange(ICohort cohort,
                          ActiveSite site,
                          out int ANPP,
                          out ExpandoObject otherChanges);

        //---------------------------------------------------------------------

        /// <summary>
        /// Computes the percentage of a cohort's biomass that is non-woody.
        /// </summary>
        /// <param name="cohort">
        /// The cohort.
        /// </param>
        /// <param name="site">
        /// The site where the cohort is located.
        /// </param>
        Percentage ComputeNonWoodyPercentage(ICohort    cohort,
                                             ActiveSite site);

    }
}
