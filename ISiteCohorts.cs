using Landis.Core;
using System.Collections.Generic;
using Landis.SpatialModeling;

namespace Landis.Library.UniversalCohorts
{
	/// <summary>
	/// All the cohorts at a site.
	/// </summary>
	public interface ISiteCohorts
		: IEnumerable<ISpeciesCohorts>
	{
		/// <summary>
		/// Gets the cohorts for a particular species.
		/// </summary>
		ISpeciesCohorts this[ISpecies species]
		{
			get;
		}
		//---------------------------------------------------------------------
		/// <summary>
		/// Is at least one sexually mature cohort present for a particular
		/// species?
		/// </summary>
		bool IsMaturePresent(ISpecies species);
		//---------------------------------------------------------------------
		/// <summary>
		/// Computes who much a disturbance damages the cohorts by reducing
		/// their biomass.
		/// </summary>
		/// <returns>
		/// The total of all the cohorts' biomass reductions.
		/// </returns>
		int ReduceOrKillBiomassCohorts(IDisturbance disturbance);
		//---------------------------------------------------------------------
		/// <summary>
		/// Removes the cohorts which are damaged by a disturbance.
		/// </summary>
		void RemoveMarkedCohorts(ICohortDisturbance disturbance);
		//---------------------------------------------------------------------
		/// <summary>
		/// Removes the cohorts which are damaged by a disturbance.
		/// </summary>
		void RemoveMarkedCohorts(ISpeciesCohortsDisturbance disturbance);
		//---------------------------------------------------------------------

		/// <summary>
		/// Removes the cohorts which are damaged by a disturbance.
		/// </summary>
		void Grow(ActiveSite site, bool isSuccessionTimestep, bool annualTimestep);
		//---------------------------------------------------------------------
	}
}
