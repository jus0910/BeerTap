namespace BeerTap.Model
{
    public enum KegState
    {
        /// <summary>
        /// Newly replaced keg
        /// </summary>
        New,

        /// <summary>
        /// Keg is Going down
        /// </summary>
        GoinDown,

        /// <summary>
        /// Keg is less than X ml
        /// </summary>
        AlmostEmpty,

        /// <summary>
        /// Keg is Dried out
        /// </summary>
        Dry
    }
}