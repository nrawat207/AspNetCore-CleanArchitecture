namespace ApplicationCore.Entities.CustomerAggregate
{
    public class PaymentDetail : BaseEntity
    {
        public string Alias { get; private set; }
        public string CardId { get; private set; } 
        public string Last4 { get; private set; }
    }
}
