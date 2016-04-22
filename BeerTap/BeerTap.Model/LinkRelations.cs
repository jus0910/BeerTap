namespace BeerTap.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string Office = "iq:Office";

        public const string Keg = "iq:Keg";

        public static class Offices
        {
            public const string GetTap = "iq:OfficeTap";
            public const string ChangeTap = "iq:ChangeOfficeTap";
        }
    }
}
