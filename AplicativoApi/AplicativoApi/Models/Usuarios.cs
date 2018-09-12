using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PluginApi.Models
{
    public class Usuarios
    {
        [Key]
        public int id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required, StringLength(50), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(50), DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        public Guid Token { get; set; }
    }
}