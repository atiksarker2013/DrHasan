using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hasan.App.Models
{
    public class RxDrop
    {
        public int Id { get; set; }
        public Nullable<int> RxId { get; set; }
        public Nullable<int> DropId { get; set; }
        public string Instruction { get; set; }

        public virtual tbl_Drop tbl_Drop { get; set; }
        public virtual tbl_Rx tbl_Rx { get; set; }
    }
}