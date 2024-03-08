using PizzaApp.Models.Enums;


namespace PizzaApp.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public bool IsDelivered { get; set; }  
    }
}
