//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace facultyWebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class student
    {
        public string s_id { get; set; }
        public string s_name { get; set; }
        public decimal s_mobile { get; set; }
        public decimal s_age { get; set; }

        [NotMapped]
        public string f_id { get; set; }
    }    
}
