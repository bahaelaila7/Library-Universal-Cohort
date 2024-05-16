namespace Landis.Library.UniversalCohorts
{
    /// <summary>
    /// Represents a method that handles cohort-death events.
    /// </summary>
    public delegate void MortalityEventHandler<TMortalityEventArgs>(object          sender,
                                                            TMortalityEventArgs eventArgs);
}
