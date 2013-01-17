namespace DomainLayer.Interfaces
{
    public interface IDomainModel<K>
    {
        K Id { get; set; }
    }
}