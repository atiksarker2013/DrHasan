using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hasan.App.Models
{
    public class Prescription
    {
        public int Id { get; set; }

        [Display(Name = "Mrno*")]
        [Required(ErrorMessage = "Patient Mrno is required")]
        public string Mrno { get; set; }

        public Nullable<int> MajorAreaId { get; set; }
        public string Rx { get; set; }
        public Nullable<int> PatientId { get; set; }
        public string NextVisit { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }

        public virtual tbl_MajorArea tbl_MajorArea { get; set; }
        public virtual tbl_Patient tbl_Patient { get; set; }
    }
}