using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_MTY.Data
{
    public class EFMetadata
    {

    }

    [MetadataType(typeof(AspNetBusinessMetadata))]
    public partial class AspNetBusiness
    {
        // No field here
    }

    internal sealed class AspNetBusinessMetadata
    {
        [Required(ErrorMessage = "El nombre se requiere.")]
        [StringLength(25)]
        [Display(Name ="Nombre de la empresa")]
        public string Name;


        [Required(ErrorMessage = "La dirección se requiere.")]
        [StringLength(128)]
        [Display(Name = "Dirección")]
        public string Address;


        [Required]
        [Display(Name = "Valor en miles de pesos")]
        public int Value;
    }
}