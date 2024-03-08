using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.ViewModels
{
    public class OrderDialogViewModel
    {
        [Display(Name ="Pizza Name")]
        public string PizzaName { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethodEnum PaymentMethod { get; set; }

        [Display(Name = "Is order delivered")]
        public bool IsDelivered { get; set; }

        public int Id { get; set; }
    }
}
