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


        [Required(ErrorMessage = "El valor se requiere.")]
        [Display(Name = "Valor en miles de pesos")]
        public int Value;
    }

    [MetadataType(typeof(AspNetCourseMetadata))]
    public partial class AspNetCourse
    {
        // No field here
    }

    internal sealed class AspNetCourseMetadata
    {
        [Display(Name = "Nombre del curso")]
        [StringLength(128)]
        [Required(ErrorMessage = "El nombre se requiere.")]
        public string Name { get; set; }
        [Display(Name = "Fecha de creación")]
        [Required(ErrorMessage = "La fecha se requiere.")]
        public System.DateTime Date { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(140)]
        [Required(ErrorMessage = "La descripción se requiere.")]
        public string Description { get; set; }
    }

    [MetadataType(typeof(AspNetProjectMetadata))]
    public partial class AspNetProject
    {
        // No field here
    }

    internal sealed class AspNetProjectMetadata
    {
        [Display(Name = "Nombre del projecto")]
        [StringLength(128)]
        [Required(ErrorMessage = "El nombre se requiere.")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(140)]
        [Required(ErrorMessage = "La descripción se requiere.")]
        public string Description { get; set; }
        [Display(Name = "Imagen")]
        public byte[] Preview { get; set; }
    }
}