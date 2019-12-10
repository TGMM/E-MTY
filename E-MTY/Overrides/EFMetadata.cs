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
        public string Name;


        [Required(ErrorMessage = "La dirección se requiere.")]
        [StringLength(128)]
        public string Address;


        [Required]
        public int Value;
    }
}