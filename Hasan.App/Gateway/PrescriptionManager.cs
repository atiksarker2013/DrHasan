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

                model.Pkey = ent.Id;

                foreach (var drug in GlobalClass.DragList)
                {
                    tbl_RxDrug drugEnt = new tbl_RxDrug();
                    drugEnt.DrugId = drug.Id;
                    drugEnt.RxId = model.Pkey;
                    drugEnt.Instruction = drug.Instruction;

                    db.tbl_RxDrug.Add(drugEnt);
                    db.SaveChanges();
                }

                foreach (var drop in GlobalClass.DropList)
                {
                    tbl_RxDrop dropEnt = new tbl_RxDrop();
                    dropEnt.DropId = drop.Id;
                    dropEnt.RxId = model.Pkey;
                    dropEnt.Instruction = drop.Instruction;

                    db.tbl_RxDrop.Add(dropEnt);
                    db.SaveChanges();

                }

                foreach (var invest in GlobalClass.InvestigationList)
                {
                    tbl_RxInvestigation investEnt = new tbl_RxInvestigation();
                    investEnt.InvestigationId = invest.InvestigationId;
                    investEnt.RxId = model.Pkey;
                    investEnt.Instruction = invest.Instruction;

                    db.tbl_RxInvestigation.Add(investEnt);
                    db.SaveChanges();

                }



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