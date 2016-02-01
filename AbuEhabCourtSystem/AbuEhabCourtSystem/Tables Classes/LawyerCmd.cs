using System;
using System.Collections.Generic;
using System.Data.Linq;
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
           var q = CompiledQuery.Compile((DbDataContext dx, int i) => dx.Lowyers.Single(p => p.Id == i));
           var lawyer = q(DbContext, lawId);
           lawyer.LowyerName = law.LowyerName;
           lawyer.Address = law.Address;
           lawyer.Account = law.Account;
           lawyer.Mobile = law.Mobile;
           lawyer.Phone = law.Phone;
           lawyer.AccountId = law.AccountId;
           lawyer.FollowUpIssues = law.FollowUpIssues;
           lawyer.Description = law.Description;
           lawyer.Status = law.Status;

           DbContext.SubmitChanges();
           
           return true;
       }
    }
}
