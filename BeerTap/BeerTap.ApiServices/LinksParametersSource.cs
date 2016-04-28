namespace BeerTap.ApiServices
{
    /// <summary>
    /// The class is used to pass additional parameters to hypermedia links definitions in resource specifications.
    /// </summary>
    public class LinksParametersSource
    {
        public LinksParametersSource(int officeId, int beerTapId)
        {
            OfficeId = officeId;
            BeerTapId = beerTapId;
        }

        public int OfficeId { get; private set; }

        public int BeerTapId { get; set; }
    }
}