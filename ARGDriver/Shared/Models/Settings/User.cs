using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ARGDriver.Shared.Models.Settings
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*El campo nombre Usuario es requerido.")]
        [RegularExpression("^[a-zA-Z áéíóú]+$", ErrorMessage = "*Solo se permiten letras.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*El campo Apellidos  es requerido.")]
        [RegularExpression("^[a-zA-Z áéíóú]+$", ErrorMessage = "*Solo se permiten letras.")]
        public string Surname { get; set; }
       
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "*El campo Tipo documento es requerido.")]
        public string Document { get; set; }

        public string Address { get; set; }

        public int RolId { get; set; }

        public Rol Rol { get; set; }

        public bool Status { get; set; }

        
    }
}
