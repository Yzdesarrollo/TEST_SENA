using ARGDriver.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ARGDriver.Shared.Models.Settings
{
    public class Rol
    {   
        // RAMA Yeison
        public int Id { get; set; }

        [Required(ErrorMessage ="*El campo nombre Rol es requerido.")]
        [RegularExpression("^[a-zA-Z áéíóú]+$", ErrorMessage = "*Solo se permiten letras.")]
        public string Name { get; set; }

        //Navigational Property
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
