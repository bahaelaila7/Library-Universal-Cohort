using Landis.Core;
using Landis.SpatialModeling;
using System.Dynamic;

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
        //---------------------------------------------------------------------
        CohortData Data
        {
            get;
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Computes how much of the cohort's biomass is non-woody.
        /// </summary>
        /// <param name="site">
        /// The site where the cohort is located.
        /// </param>
        int ComputeNonWoodyBiomass(ActiveSite site);
        //---------------------------------------------------------------------
        /// <summary>
        /// Increments the cohort's age by one year.
        /// </summary>
        void IncrementAge();
        //---------------------------------------------------------------------
        /// <summary>
        /// Changes the cohort's ANPP
        /// </summary>
        /// <param name="newForage"></param>
        /// <returns></returns>
        void ChangeANPP(double anpp);
        //---------------------------------------------------------------------
        void ChangeBiomass(int delta);
        //---------------------------------------------------------------------
        void ChangeParameters(ExpandoObject additionalParams);
        //---------------------------------------------------------------------
    }
}
