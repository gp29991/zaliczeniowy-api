using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zal_API.Models
{
    public class Hussar
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Nie podano imienia")]
        [MaxLength(30, ErrorMessage = "Imię nie może być dłuższe niż 30 znaków")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nie podano nazwiska")]
        [MaxLength(30, ErrorMessage = "Nazwisko nie może być dłuższe niż 30 znaków")]
        public string LastName { get; set; }

        public int? BannerID { get; set; }

        public virtual Banner Banner { get; set; }
    }
}
