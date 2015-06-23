using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MoneyRemoveService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MoneyRemoveService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MoneyRemoveService.svc or MoneyRemoveService.svc.cs at the Solution Explorer and start debugging.
    public class MoneyRemoveService : IMoneyRemoveService
    {

        public bool RemoveMoneyFromAcc(string accountNumber, decimal moneyToRemove)
        {
            if (accountNumber != string.Empty)
            {
                using (EfDbContext context = new EfDbContext())
                {
                    var client = context.Clients
                        .FirstOrDefault(p => p.AccountNumber == accountNumber);
                    if (client != null && client.Balance >= moneyToRemove)
                    {
                        client
                              .Balance -= moneyToRemove;
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
