//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_MTY.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetCourseUser
    {
        public string UserId { get; set; }
        public int CourseId { get; set; }
    
        public virtual AspNetCourse AspNetCourse { get; set; }
    }
}