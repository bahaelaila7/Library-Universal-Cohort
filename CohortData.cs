using System.Collections.Generic;
using System.Dynamic;

namespace Landis.Library.UniversalCohorts
{
    /// <summary>
    /// Data for an individual cohort that is not shared with other cohorts.
    /// </summary>
    public struct CohortData
    {
        /// <summary>
        /// The cohort's age (years).
        /// </summary>
        public ushort Age;

        //---------------------------------------------------------------------

        /// <summary>
        /// The cohort's biomass (g/m2).
        /// </summary>
        public int Biomass;

        //---------------------------------------------------------------------
        /// <summary>
        /// The cohort's annual NPP (g/m2).
        /// </summary>
        public int ANPP;
        //---------------------------------------------------------------------

        public ExpandoObject AdditionalParameters;
        //---------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="age">
        /// The cohort's age.
        /// </param>
        /// <param name="biomass">
        /// The cohort's biomass.
        /// </param>
        public CohortData(ushort age,
                          int biomass)
        {
            this.Age = age;
            this.Biomass = biomass;
            this.ANPP = biomass;
            this.AdditionalParameters = new ExpandoObject();
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="age">
        /// The cohort's age.
        /// </param>
        /// <param name="biomass">
        /// The cohort's biomass.
        /// </param>
        public CohortData(ushort age,
                          int biomass, int ANPP)
        {
            this.Age = age;
            this.Biomass = biomass;
            this.ANPP = ANPP;
            this.AdditionalParameters = new ExpandoObject();
        }

        public CohortData(CohortData data)
        {
            this.Age = data.Age;
            this.Biomass = data.Biomass;
            this.ANPP = data.ANPP;
            this.AdditionalParameters = data.AdditionalParameters;
        }
    }
}
