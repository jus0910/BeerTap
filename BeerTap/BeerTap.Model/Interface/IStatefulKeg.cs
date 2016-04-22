namespace BeerTap.Model.Interface
{
    public interface IStatefulKeg
    {
        KegState KegState { get; }
    }
}