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
                          int biomass,
                          ExpandoObject parametersToAdd)
        {
            this.Age = age;
            this.Biomass = biomass;
            this.ANPP = biomass;
            this.AdditionalParameters = new ExpandoObject();
            AddAdditionalCohortParameters(parametersToAdd);
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
                          int biomass, int ANPP,
                          ExpandoObject parametersToAdd)
        {
            this.Age = age;
            this.Biomass = biomass;
            this.ANPP = ANPP;
            this.AdditionalParameters = new ExpandoObject();
            AddAdditionalCohortParameters(parametersToAdd);
        }
        //---------------------------------------------------------------------

        public CohortData(CohortData data, ExpandoObject parametersToAdd)
        {
            this.Age = data.Age;
            this.Biomass = data.Biomass;
            this.ANPP = data.ANPP;
            this.AdditionalParameters = new ExpandoObject();
            AddAdditionalCohortParameters(parametersToAdd);
        }
        //---------------------------------------------------------------------

        /// <summary>
        /// Called in every new cohorts to 
        /// </summary>
        public void AddAdditionalCohortParameters(ExpandoObject parametersToAdd)
        {
            IDictionary<string, object> tempObject = this.AdditionalParameters;

            foreach (var parameter in parametersToAdd)
            {
                tempObject.Add(parameter.Key, parameter.Value);
            }
        }
        //---------------------------------------------------------------------
    }
}
