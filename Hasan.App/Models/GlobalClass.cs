﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hasan.App.Models
{
    public class GlobalClass
    {
        static private string _MasterSession = "MasterSession";
        public static bool MasterSession
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._MasterSession] == null)
                {
                    return false;
                }
                else
                {
                    return (bool)(HttpContext.Current.Session[GlobalClass._MasterSession]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._MasterSession] = value;
            }
        }
        static private string _AnchorID = "AnchorID";
        public static int AnchorID
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._AnchorID] == null)
                {
                    return -99;
                }
                else
                {
                    return (int)(HttpContext.Current.Session[GlobalClass._AnchorID]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._AnchorID] = value;
            }
        }
        static private string _SystemSession = "SystemSession";
        public static bool SystemSession
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._SystemSession] == null)
                {
                    return false;
                }
                else
                {
                    return (bool)(HttpContext.Current.Session[GlobalClass._SystemSession]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._SystemSession] = value;
            }
        }
        static private string _LoginUser = "LoginUser";
        public static StaffList LoginUser
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._LoginUser] == null)
                {
                    return null;
                }
                else
                {
                    return (StaffList)(HttpContext.Current.Session[GlobalClass._LoginUser]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._LoginUser] = value;
            }
        }
        static private string _Company = "Company";
        public static Company Company
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._Company] == null)
                {
                    return null;
                }
                else
                {
                    return (Company)(HttpContext.Current.Session[GlobalClass._Company]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._Company] = value;
            }
        }
        static private string _TempGuid = "TempGuid";
        public static int TempGuid
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._TempGuid] == null)
                {
                    return -99;
                }
                else
                {
                    return (int)(HttpContext.Current.Session[GlobalClass._TempGuid]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._TempGuid] = value;
            }
        }
        static private string _StoreGuid = "StoreGuid";
        public static Guid StoreGuid
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._StoreGuid] == null)
                {
                    return Guid.Empty;
                }
                else
                {
                    return (Guid)(HttpContext.Current.Session[GlobalClass._StoreGuid]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._StoreGuid] = value;
            }
        }
        static private string _StoreGuid1 = "StoreGuid1";
        public static Guid StoreGuid1
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._StoreGuid1] == null)
                {
                    return Guid.Empty;
                }
                else
                {
                    return (Guid)(HttpContext.Current.Session[GlobalClass._StoreGuid1]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._StoreGuid1] = value;
            }
        }


        static private string _GuidList = "GuidList";
        public static List<Guid> GuidList
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._GuidList] == null)
                {
                    return null;
                }
                else
                {
                    return (List<Guid>)(HttpContext.Current.Session[GlobalClass._GuidList]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._GuidList] = value;
            }
        }


        //static private string _GlobalDecimal = "GlobalDecimal";
        //public static decimal GlobalDecimal
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[GlobalClass._GlobalSales] == null)
        //        {
        //            return 0;
        //        }
        //        else
        //        {
        //            return (decimal)(HttpContext.Current.Session[GlobalClass._GlobalSales]);
        //        }
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session[GlobalClass._GlobalSales] = value;
        //    }
        //}

        static private string _MenuGuid = "MenuGuid";
        public static Guid MenuGuid
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._MenuGuid] == null)
                {
                    return Guid.Empty;
                }
                else
                {
                    return (Guid)(HttpContext.Current.Session[GlobalClass._MenuGuid]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._MenuGuid] = value;
            }
        }

        static private string _GlobalURL = "GlobalURL";
        public static string GlobalURL
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._GlobalURL] == null)
                {
                    return "";
                }
                else
                {
                    return (string)(HttpContext.Current.Session[GlobalClass._GlobalURL]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._GlobalURL] = value;
            }
        }




        static private string _drugList = "DragList";
        public static List<RxDrug> DragList
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._drugList] == null)
                {
                    return null;
                }
                else
                {
                    return (List<RxDrug>)(HttpContext.Current.Session[GlobalClass._drugList]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._drugList] = value;
            }
        }


        static private string _dropList = "DropList";
        public static List<RxDrop> DropList
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._dropList] == null)
                {
                    return null;
                }
                else
                {
                    return (List<RxDrop>)(HttpContext.Current.Session[GlobalClass._dropList]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._dropList] = value;
            }
        }


        static private string _investigationList = "InvestigationList";
        public static List<RxInvestigation> InvestigationList
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._investigationList] == null)
                {
                    return null;
                }
                else
                {
                    return (List<RxInvestigation>)(HttpContext.Current.Session[GlobalClass._investigationList]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._investigationList] = value;
            }
        }



        static private string _rxId = "RxId";
        public static string RxId
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._rxId] == null)
                {
                    return "";
                }
                else
                {
                    return (string)(HttpContext.Current.Session[GlobalClass._rxId]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._rxId] = value;
            }
        }
    }
}