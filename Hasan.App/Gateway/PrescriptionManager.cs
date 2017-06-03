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

                ent.VisualAcuityLeftEye = prescriptionObj.VisualAcuityLeftEye;
                ent.VisualAcuityLeftEyeType = prescriptionObj.VisualAcuityLeftEyeType;
                ent.VisualAcuityRightEye = prescriptionObj.VisualAcuityRightEye;
                ent.VisualAcuityRightEyeType = prescriptionObj.VisualAcuityRightEyeType;


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

            }
            catch (Exception ex)
            {
                model.flag = 0;
                model.mess = ex.Message.ToString();
            }


            return model;
        }

        public Prescription FillMainPrescription(int id)
        {
            Prescription obj = new Prescription();
            tbl_Rx cust = db.tbl_Rx.Find(id);
            obj.Id = cust.Id;
            obj.MajorAreaId = cust.MajorAreaId;
            obj.MajorAreaName = cust.tbl_MajorArea.Name;
            obj.Rx = cust.Rx;
            obj.PatientId = cust.PatientId;

            obj.Mrno = cust.tbl_Patient.Mrno;
            obj.Name = cust.tbl_Patient.Name;
            obj.Address = cust.tbl_Patient.Address;
            obj.Age = cust.tbl_Patient.Age;



            obj.NextVisit = cust.NextVisit;
            obj.EntryDate = cust.EntryDate;

            obj.VisualAcuityLeftEye = cust.VisualAcuityLeftEye;
            obj.VisualAcuityLeftEyeType = cust.VisualAcuityLeftEyeType??0;
            obj.VisualAcuityRightEye = cust.VisualAcuityRightEye;
            obj.VisualAcuityRightEyeType = cust.VisualAcuityRightEyeType;

            tbl_VisualAcuityType leftVisual = db.tbl_VisualAcuityType.Find(obj.VisualAcuityLeftEyeType);
            obj.VisualAcuityLeftEyeTypeValue = leftVisual.Name;

            tbl_VisualAcuityType rightVisual = db.tbl_VisualAcuityType.Find(obj.VisualAcuityRightEyeType);
            obj.VisualAcuityRightEyeTypeValue = rightVisual.Name;

            obj.RxDrugList = new List<RxDrug>();
            obj.RxDrugList = GetPrescribrDrugList(id);

            obj.RxDropList = new List<RxDrop>();
            obj.RxDropList = GetPrescribrDropList(id);

            obj.RxInvestigationList = new List<RxInvestigation>();
            obj.RxInvestigationList = GetPrescribrInvestigationList(id);

            return obj;
        }


        public List<RxDrug> GetPrescribrDrugList(int id)
        {
            List<RxDrug> obj = new List<RxDrug>();
            var temp = from x in db.tbl_RxDrug
                       where x.RxId == id
                       select new RxDrug
                       {
                           DrugId = x.Id,
                           DrugName = x.tbl_Drug.Name,
                           Instruction = x.Instruction,
                           RxId = x.RxId
                       };
            obj = temp.ToList();
            return obj;
        }

        public List<RxDrop> GetPrescribrDropList(int id)
        {
            List<RxDrop> obj = new List<RxDrop>();
            var temp = from x in db.tbl_RxDrop
                       where x.RxId == id
                       select new RxDrop
                       {
                           DropId = x.DropId,
                           DropName = x.tbl_Drop.Name,
                           Instruction = x.Instruction,
                           RxId = x.RxId
                       };
            obj = temp.ToList();
            return obj;
        }

        public List<RxInvestigation> GetPrescribrInvestigationList(int id)
        {
            List<RxInvestigation> obj = new List<RxInvestigation>();
            var temp = from x in db.tbl_RxInvestigation
                       where x.RxId == id
                       select new RxInvestigation
                       {
                           InvestigationId = x.InvestigationId,
                           InvestigationName = x.tbl_Investigation.Name,
                           Instruction = x.Instruction,
                           RxId = x.RxId
                       };
            obj = temp.ToList();
            return obj;
        }
    }
}