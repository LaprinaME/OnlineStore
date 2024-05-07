using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Пользователи
    {
        [Key]
        public int Код_Пользователя { get; set; }

        public string Логин { get; set; }

        public string Пароль { get; set; }

        [ForeignKey("Код_Роли")]
        public int Код_Роли { get; set; }

        public Роли Роли { get; set; }
    }
}
