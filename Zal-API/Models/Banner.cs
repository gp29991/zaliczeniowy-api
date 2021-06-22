using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zal_API.Models
{
    public class Banner
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Nie podano nazwy")]
        [MaxLength(30, ErrorMessage = "Nazwa nie może być dłuższa niż 30 znaków")]
        public string Name { get; set; }
    }
}
