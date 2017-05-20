using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hasan.App.Models
{
    public class RxDrug
    {
        public int Id { get; set; }
        public Nullable<int> RxId { get; set; }
        public Nullable<int> DrugId { get; set; }
        public string Instruction { get; set; }

        public virtual tbl_Drug tbl_Drug { get; set; }
        public virtual tbl_Rx tbl_Rx { get; set; }
    }
}