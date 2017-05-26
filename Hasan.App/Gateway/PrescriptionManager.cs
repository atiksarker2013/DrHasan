using Hasan.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hasan.App.Gateway
{
    public class PrescriptionManager
    {
        HasanHoutoneEntities db = new HasanHoutoneEntities();

        internal DataReturn SaveMainData(Prescription prescriptionObj)
        {
            DataReturn model = new DataReturn();

            try
            {
                tbl_Rx ent = new tbl_Rx();
               // ent.Id = prescriptionObj.Id;
                 ent.MajorAreaId = prescriptionObj.MajorAreaId;
                ent.Rx = prescriptionObj.Rx;
                ent.PatientId = prescriptionObj.PatientId;
                ent.NextVisit = prescriptionObj.NextVisit;
                ent.EntryDate = DateTime.Now;
                db.tbl_Rx.Add(ent);
                db.SaveChanges();
                model.flag = 1;
                model.mess = "Data has been saved successfully.";
               // model.key = ent.Id;

            }
            catch (Exception ex)
            {
                model.flag = 0;
                model.mess = ex.Message.ToString();
            }


            return model;
        }
    }
}