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

        private ExpandoObject additionalParameters;
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
            this.additionalParameters = parametersToAdd;
        }
        //---------------------------------------------------------------------

        public dynamic AdditionalParameters
        {
            get
            {
                dynamic addParm = additionalParameters;
                return addParm;
            }
            set
            {
                dynamic addParm = additionalParameters;
                addParm = value;
            }
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
            this.additionalParameters = parametersToAdd;
        }
        //---------------------------------------------------------------------

        public CohortData(CohortData data, ExpandoObject parametersToAdd)
        {
            this.Age = data.Age;
            this.Biomass = data.Biomass;
            this.ANPP = data.ANPP;
            this.additionalParameters = parametersToAdd;
        }
        //---------------------------------------------------------------------

        /// <summary>
        /// Called in every new cohorts to 
        /// </summary>
        public void AddAdditionalCohortParameters(ExpandoObject parametersToAdd)
        {
            if (this.AdditionalParameters == null)
            {
                this.AdditionalParameters = new ExpandoObject();
            }
            IDictionary<string, object> tempObject = this.AdditionalParameters;

            foreach (var parameter in parametersToAdd)
            {
                if (!tempObject.ContainsKey(parameter.Key))
                {
                    tempObject.Add(parameter.Key, parameter.Value);
                }
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
                        tempObject[parameter.Key] = System.Convert.ToSByte(tempObject[parameter.Key]) + System.Convert.ToSByte(parameter.Value);
                    }
                    else if (parameter.Value is byte)
                    {
                        tempObject[parameter.Key] = System.Convert.ToByte(tempObject[parameter.Key]) + System.Convert.ToByte(parameter.Value);
                    }
                    else if (parameter.Value is short)
                    {
                        tempObject[parameter.Key] = System.Convert.ToInt16(tempObject[parameter.Key]) + System.Convert.ToInt16(parameter.Value);
                    }
                    else if (parameter.Value is ushort)
                    {
                        tempObject[parameter.Key] = System.Convert.ToUInt16(tempObject[parameter.Key]) + System.Convert.ToUInt16(parameter.Value);
                    }
                    else if (parameter.Value is int)
                    {
                        tempObject[parameter.Key] = System.Convert.ToInt32(tempObject[parameter.Key]) + System.Convert.ToInt32(parameter.Value);
                    }
                    else if (parameter.Value is uint)
                    {
                        tempObject[parameter.Key] = System.Convert.ToUInt32(tempObject[parameter.Key]) + System.Convert.ToUInt32(parameter.Value);
                    }
                    else if (parameter.Value is long)
                    {
                        tempObject[parameter.Key] = System.Convert.ToInt64(tempObject[parameter.Key]) + System.Convert.ToInt64(parameter.Value);
                    }
                    else if (parameter.Value is ulong)
                    {
                        tempObject[parameter.Key] = System.Convert.ToUInt64(tempObject[parameter.Key]) + System.Convert.ToUInt64(parameter.Value);
                    }
                    else if (parameter.Value is float)
                    {
                        tempObject[parameter.Key] = System.Convert.ToSingle(tempObject[parameter.Key]) + System.Convert.ToSingle(parameter.Value);
                    }
                    else if (parameter.Value is double)
                    {
                        tempObject[parameter.Key] =  System.Convert.ToDouble(tempObject[parameter.Key]) + System.Convert.ToDouble(parameter.Value);
                    }
                    else if (parameter.Value is decimal)
                    {
                        tempObject[parameter.Key] = System.Convert.ToDecimal(tempObject[parameter.Key]) + System.Convert.ToDecimal(parameter.Value);
                    }
                    else if (parameter.Value is bool)
                    {
                        tempObject[parameter.Key] = System.Convert.ToBoolean(tempObject[parameter.Key]) | System.Convert.ToBoolean(parameter.Value);
                    }
                    else if (parameter.Value is char)
                    {
                        tempObject[parameter.Key] = System.Convert.ToChar(parameter.Value);
                    }
                    else if (parameter.Value is string)
                    {
                        tempObject[parameter.Key] = System.Convert.ToString(parameter.Value);
                    }
                }
            }
        }

        //---------------------------------------------------------------------
    }
}
