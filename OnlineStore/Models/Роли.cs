using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Роли
    {
        [Key]
        public int Код_Роли { get; set; }

        public string Наименование_роли { get; set; }
    }
}
