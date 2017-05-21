using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hasan.App.Models
{
    public class RxInvestigation
    {
        public int Id { get; set; }
        public Nullable<int> RxId { get; set; }
        public Nullable<int> InvestigationId { get; set; }
        public string Instruction { get; set; }

        public string InvestigationName { get; set; }

        public virtual tbl_Investigation tbl_Investigation { get; set; }
        public virtual tbl_Rx tbl_Rx { get; set; }
    }
}