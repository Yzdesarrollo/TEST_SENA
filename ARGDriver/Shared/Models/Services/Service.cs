using ARGDriver.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARGDriver.Shared.Models.Services
{
    public class Service
    {
        // RAMA wilfer

        public int Id { get; set; }

        [Required(ErrorMessage = "*El expediente es requerido.")]
        [Display(Name = "Expediente")]
        public string Proceedings { get; set; }

        [Required(ErrorMessage = "*La placa es requerida.")]
        [Display(Name = "Placa del veh�culo")]
        public string LicensePlate { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }
        [Display(Name = "Direcci�n inicial")]
        public string StartingAdress { get; set; }
        [Display(Name = "Direcci�n final")]
        public string EndingAdress { get; set; }
        [Display(Name = "T�cnico encargado")]
        public string Tecnician { get; set; }
        public bool IsActive { get; set; }
        public int IdEvidence { get; set; }
        [Display(Name = "Descripci�n del servicio")]
        public string Description { get; set; }       

    }
}
