using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Domain;

namespace MoneyAddService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MoneyAddService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MoneyAddService.svc or MoneyAddService.svc.cs at the Solution Explorer and start debugging.
    public class MoneyAddService : IMoneyAddService
    {
        public bool AddMoneyToAcc(string accountNumber, decimal moneyToAdd)
        {
            if (accountNumber != string.Empty)
            {
                using (EfDbContext context = new EfDbContext())
                {
                    var client = context.Clients
                        .FirstOrDefault(p => p.AccountNumber == accountNumber);
                    if (client != null)
                    {
                        client
                              .Balance += moneyToAdd;
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
