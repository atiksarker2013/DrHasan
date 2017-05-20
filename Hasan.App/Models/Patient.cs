using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hasan.App.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ChiefComplains { get; set; }
        public Nullable<int> Age { get; set; }
        public string Sex { get; set; }
        public string Mrno { get; set; }
    }
}