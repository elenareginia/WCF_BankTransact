using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using MainService.MoneyAddService;
using MainService.MoneyRemoveService;

namespace MainService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MainService.svc or MainService.svc.cs at the Solution Explorer and start debugging.
    public class MainService : IMainService
    {
        private MoneyRemoveServiceClient remover;
        private MoneyAddServiceClient adder;
        public bool Transfer(string fromAccount, string toAccount, decimal money)
        {

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                   remover = new MoneyRemoveServiceClient();
                    adder = new MoneyAddServiceClient();
                    if (remover.RemoveMoneyFromAcc(fromAccount, money))
                    {
                        adder.AddMoneyToAcc(toAccount, money);
                        //context.SaveChanges();
                        ts.Complete();
                        return true;
                    }
                    else
                    {
                        ts.Dispose();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                    return false;
                }

            }
        }

        public void Seed()
        {
            using (EfDbContext context = new EfDbContext())
            {
                var clients = new List<Client>
                {
                    new Client
                    {
                        FirstName = "Jack",
                        SecondName = "Smith",
                        AccountNumber = "5157543365437123",
                        Balance = 10000
                    },
                    new Client
                    {
                        FirstName = "Anna",
                        SecondName = "Dawson",
                        AccountNumber = "5157845684569855",
                        Balance = 5650
                    },
                    new Client
                    {
                        FirstName = "Tony",
                        SecondName = "Spark",
                        AccountNumber = "5157095600443356",
                        Balance = 15000
                    }
                };

                clients.ForEach(p => context.Clients.Add(p));
                context.SaveChanges();
            }
        }

        public List<Client> GetAllClients()
        {
                using (var context = new EfDbContext())
                {
                    if (context.Clients.Count() != 0)
                    {
                        return context.Clients.ToList();
                    }
                    return null;
                }            
        }

        public bool RemoveMoneyFromAcc(string accountNumber, decimal moneyToRemove)
        {
            remover = new MoneyRemoveServiceClient();
            return remover.RemoveMoneyFromAcc(accountNumber, moneyToRemove);
        }

        public bool AddMoneyToAcc(string accountNumber, decimal moneyToAdd)
        {
            adder = new MoneyAddServiceClient();
            return adder.AddMoneyToAcc(accountNumber, moneyToAdd);
        }

    }
}
