﻿using System;
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

        [Display(Name = "Name*")]
        [Required(ErrorMessage = "Patient Name is required")]
        public string Name { get; set; }

        [Display(Name = "Address*")]
        [Required(ErrorMessage = "Patient Address is required")]
        public string Address { get; set; }

        [Display(Name = "ChiefComplains*")]
        [Required(ErrorMessage = "Patient ChiefComplains is required")]
        public string ChiefComplains { get; set; }

        [Display(Name = "Age*")]
        [Required(ErrorMessage = "Patient Age is required")]
        public Nullable<int> Age { get; set; }

        [Display(Name = "Sex*")]
        [Required(ErrorMessage = "Patient Sex is required")]
        public string Sex { get; set; }

       
        [Required(ErrorMessage = "Drug Id is required")]
        public Nullable<int> DrugId { get; set; }

        [Display(Name = "Drug Name*")]
        [Required(ErrorMessage = "Drug Name is required")]
        public string DrugName { get; set; }

        [Display(Name = "Drug Note*")]
        [Required(ErrorMessage = "Drug Note is required")]
        public string DrugNote { get; set; }




        public Nullable<int> MajorAreaId { get; set; }
        public string Rx { get; set; }
        public Nullable<int> PatientId { get; set; }
        public string NextVisit { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }

        public virtual tbl_MajorArea tbl_MajorArea { get; set; }
        public virtual tbl_Patient tbl_Patient { get; set; }
    }
}