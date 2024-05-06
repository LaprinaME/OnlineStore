using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Пункты_выдачи
    {
        [Key]
        public int Код_Пункта_выдачи { get; set; }

        [Required]
        [StringLength(255)]
        public string Адрес { get; set; }

        public int Оборот_заказов { get; set; }

        public float Рейтинг_пункта_выдачи { get; set; }

        public int Количество_доступных_мест { get; set; }
    }
}
