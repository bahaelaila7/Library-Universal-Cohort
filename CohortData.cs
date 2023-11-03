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

        public void ChangeParameters(ExpandoObject additionalParams)
        {
            IDictionary<string, object> tempObject = this.AdditionalParameters;

            foreach (var parameter in additionalParams)
            {
                if (!tempObject.ContainsKey(parameter.Key))
                {
                    throw new System.Exception("No such parameter: '" + parameter.Key + "' exists in CohortData. Add the parameter first.");
                }
                else
                {
                    if (parameter.Value is sbyte)
                    {
                        tempObject[parameter.Key] = (sbyte)(tempObject[parameter.Key]) + (sbyte)(parameter.Value);
                    }
                    else if (parameter.Value is byte)
                    {
                        tempObject[parameter.Key] = (byte)(tempObject[parameter.Key]) + (byte)(parameter.Value);
                    }
                    else if (parameter.Value is short)
                    {
                        tempObject[parameter.Key] = (short)(tempObject[parameter.Key]) + (short)(parameter.Value);
                    }
                    else if (parameter.Value is ushort)
                    {
                        tempObject[parameter.Key] = (ushort)(tempObject[parameter.Key]) + (ushort)(parameter.Value);
                    }
                    else if (parameter.Value is int)
                    {
                        tempObject[parameter.Key] = (int)(tempObject[parameter.Key]) + (int)(parameter.Value);
                    }
                    else if (parameter.Value is uint)
                    {
                        tempObject[parameter.Key] = (uint)(tempObject[parameter.Key]) + (uint)(parameter.Value);
                    }
                    else if (parameter.Value is long)
                    {
                        tempObject[parameter.Key] = (long)(tempObject[parameter.Key]) + (long)(parameter.Value);
                    }
                    else if (parameter.Value is ulong)
                    {
                        tempObject[parameter.Key] = (ulong)(tempObject[parameter.Key]) + (ulong)(parameter.Value);
                    }
                    else if (parameter.Value is float)
                    {
                        tempObject[parameter.Key] = (float)(tempObject[parameter.Key]) + (float)(parameter.Value);
                    }
                    else if (parameter.Value is double)
                    {
                        tempObject[parameter.Key] = (double)(tempObject[parameter.Key]) + (double)(parameter.Value);
                    }
                    else if (parameter.Value is decimal)
                    {
                        tempObject[parameter.Key] = (decimal)(tempObject[parameter.Key]) + (decimal)(parameter.Value);
                    }
                    else if (parameter.Value is bool)
                    {
                        tempObject[parameter.Key] = (bool)(tempObject[parameter.Key]) || (bool)(parameter.Value);
                    }
                    else if (parameter.Value is char || parameter.Value is string)
                    {
                        tempObject[parameter.Key] = parameter.Value;
                    }
                }
            }
        }

        //---------------------------------------------------------------------
    }
}
