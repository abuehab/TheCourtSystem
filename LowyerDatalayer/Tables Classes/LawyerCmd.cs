using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace LowyerDatalayer.Tables_Classes
{
    public class LawyerCmd : DataBase
    {


        /// <summary>
        ///  This Method Saved New Lowyer 
        /// </summary>
        /// <param name="law"> "أيمن شوف كيف ممكن الكومنت يساعد في حالة التيم وورك"Insert Lowyer Object Table </param>
        /// <returns>return Boolean Value </returns>
        public bool NewLawyer(Lowyer law)
        {
            DbContext = new DbDataContext();
            DbContext.Lowyers.InsertOnSubmit(law);
            DbContext.SubmitChanges();

            return true;
        }



        /// <summary>
        /// This Method for edit lowyer Data
        /// </summary>
        /// <param name="law"> Insert Lowyer Object Name As Table </param>
        /// <param name="lawId"> Lowyer Id </param>
        /// <returns> Return True Value if Proccess is Successeded</returns>

        public bool EditLawyer(Lowyer law, int lawId)
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
            //
            return true;
        }
       /// <summary>
       /// This Mehtod Loading All Lowyers
       /// </summary>
       /// <returns> Return List  oF lowyers</returns>
        
        public List<Lowyer> AllLowyers()
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext x) => x.Lowyers
                    .Where( c=>  c.Status =="Active"));

                var lowyers = q(DbContext).ToList();
                return lowyers;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Lowyer> LowyerList_ByName(string name)
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext dbx, string n) =>
                    dbx.Lowyers.Where(p => p.LowyerName.Contains(n) &&   p.Status =="Active")
                    );
                var xlowyer = q(DbContext, name).ToList();
                return xlowyer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Lowyer GetLowyerByName(string name)
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext db, string n) =>
                  db.Lowyers.Where(p => p.LowyerName == n &&   p.Status =="Active"));
                var xlowyer = q(DbContext, name).Single();
                return xlowyer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Lowyer GetLowyerById(int x)
        {
            try
            {
                var q = CompiledQuery.Compile((DbDataContext db, int i) =>
                    db.Lowyers.Where(p => p.Id == i));
                var xlowyer = q(DbContext, x).Single();
                return xlowyer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteLowyer(Lowyer low, int x)
        {
            var q = CompiledQuery.Compile((DbDataContext db, int i) =>
                db.Lowyers.Where(p => p.Id == i));
            var Dlowyer = q(DbContext, x).Single();
            DbContext.Lowyers.DeleteOnSubmit(Dlowyer);
            DbContext.SubmitChanges();
            return true;
        }
    }
}
