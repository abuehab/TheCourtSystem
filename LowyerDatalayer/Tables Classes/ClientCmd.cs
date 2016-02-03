using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace LowyerDatalayer.Tables_Classes
{

    /// <summary>
    /// 
    /// </summary>
    public class ClientCmd:DataBase
    {
        public bool NewClient(Client client)
        {
            DbContext = new DbDataContext();
            DbContext.Clients.InsertOnSubmit(client);
            DbContext.SubmitChanges();
            return true;
        }

        public bool EditClient(Client cli,int x)
        {
            cli.Id = x;
            var q = CompiledQuery.Compile((DbDataContext db, int i) =>
                db.Clients.Where(p => p.Id == i));
            var newclient = q(DbContext, x).Single();
          //  newclient.Id = cli.Id;  مين قال لك انه لازم نعدل حثلل المفتاح الاساسي
            newclient.ClientName = cli.ClientName;
            newclient.Account = cli.Account;           
            newclient.Address = cli.Address;
            newclient.Described = cli.Described;
            newclient.Email = cli.Email;           
            newclient.IdNumber = cli.IdNumber;
            newclient.Phone = cli.Phone;
            DbContext.SubmitChanges();  //  كيف بتنسى تحفظ 
            return true;
        }
    }
}
