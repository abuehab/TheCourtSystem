using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbuEhabCourtSystem.Tables_Classes
{
   public  class LawyerCmd:DataBase
    {
       public bool NewLawyer(Lowyer law)
       {
           DbContext=new DbDataContext();
           DbContext.Lowyers.InsertOnSubmit(law);
           DbContext.SubmitChanges();
           return true;
       }

       public bool EditLawyer(Lowyer law,int lawId)
       {
           law.Id = lawId;

           return true;
       }
    }
}
