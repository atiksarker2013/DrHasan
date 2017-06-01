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
      //  [Required(ErrorMessage = "Patient Mrno is required")]
        public string Mrno { get; set; }

        [Display(Name = "Name*")]
       // [Required(ErrorMessage = "Patient Name is required")]
        public string Name { get; set; }

        [Display(Name = "Address*")]
       // [Required(ErrorMessage = "Patient Address is required")]
        public string Address { get; set; }

        [Display(Name = "ChiefComplains*")]
       // [Required(ErrorMessage = "Patient ChiefComplains is required")]
        public string ChiefComplains { get; set; }

        [Display(Name = "Age*")]
       // [Required(ErrorMessage = "Patient Age is required")]
        public Nullable<int> Age { get; set; }

        [Display(Name = "Sex*")]
       // [Required(ErrorMessage = "Patient Sex is required")]
        public string Sex { get; set; }

       
        //[Required(ErrorMessage = "Drug Id is required")]
        public Nullable<int> DrugId { get; set; }

        [Display(Name = "Drug Name*")]
       // [Required(ErrorMessage = "Drug Name is required")]
        public string DrugName { get; set; }

        [Display(Name = "Drug Note*")]
        //[Required(ErrorMessage = "Drug Note is required")]
        public string DrugNote { get; set; }

        public string RemoveDrugId { get; set; }


        public Nullable<int> DropId { get; set; }

        [Display(Name = "Drop Name*")]
        public string DropName { get; set; }

        [Display(Name = "Drop Note*")]
        public string DropNote { get; set; }

        public string RemoveDropId { get; set; }

        public Nullable<int> InvestigationId { get; set; }

        [Display(Name = "Investigation Name")]
        public string InvestigationName { get; set; }

        [Display(Name = "Investigation Note*")]
        public string InvestigationNote { get; set; }

        public string RemoveInvestigationId { get; set; }

        public Nullable<int> MajorAreaId { get; set; }


        [Display(Name = "Diagnosis")]
        public string MajorAreaName { get; set; }


        [Display(Name = "Adv:")]
        public string Rx { get; set; }
        public Nullable<int> PatientId { get; set; }

        [Display(Name = "Next Visit*")]
       // [Required(ErrorMessage = "Drug Id is required")]
        public string NextVisit { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }

        public virtual tbl_MajorArea tbl_MajorArea { get; set; }
        public virtual tbl_Patient tbl_Patient { get; set; }


        private List<RxDrug> _rxDrugList = new List<RxDrug>();
        public List<RxDrug> RxDrugList
        {
            get { return _rxDrugList; }
            set { _rxDrugList = value; }
        }

        private List<RxDrop> _rxDropList = new List<RxDrop>();
        public List<RxDrop> RxDropList
        {
            get { return _rxDropList; }
            set { _rxDropList = value; }
        }

        private List<RxInvestigation> _rxInvestigationList = new List<RxInvestigation>();
        public List<RxInvestigation> RxInvestigationList
        {
            get { return _rxInvestigationList; }
            set { _rxInvestigationList = value; }
        }


        [Display(Name = "Left Eye")]
        public string VisualAcuityLeftEye { get; set; }

        [Display(Name = "Right Eye")]
        public string VisualAcuityRightEye { get; set; }

       // [Display(Name = "Left Eye")]
        public int VisualAcuityLeftEyeType { get; set; }

        public int VisualAcuityRightEyeType { get; set; }
    }
}