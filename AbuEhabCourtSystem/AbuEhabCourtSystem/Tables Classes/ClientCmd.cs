using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace AbuEhabCourtSystem.Tables_Classes
{
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
            newclient.Id = cli.Id;
            newclient.ClientName = cli.ClientName;
            newclient.Account = cli.Account;
            newclient.AccountId = cli.AccountId;
            newclient.Address = cli.Address;
            newclient.Client1 = cli.Client1;
            newclient.Client2 = cli.Client2;
            newclient.Described = cli.Described;
            newclient.Email = cli.Email;
            newclient.FollowUpIssues = cli.FollowUpIssues;
            newclient.IdNumber = cli.IdNumber;
            newclient.Phone = cli.Phone;
            
            return true;
        }
    }
}
