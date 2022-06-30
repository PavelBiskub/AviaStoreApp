using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AviaStoreApp.Data.Models
{
    public class Order
    {  
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [StringLength(20, MinimumLength = 3)]
        [Required(ErrorMessage = "Имя должно содержать 3-20 символов")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public List<OrderDetail> orderDetail { get; set; }
    }
}
