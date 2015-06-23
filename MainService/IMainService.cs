using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Domain;

namespace MainService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMainService" in both code and config file together.
    [ServiceContract]
    public interface IMainService
    {
        [OperationContract]
        bool Transfer(string fromAccount, string toAccount, decimal money);

        [OperationContract]
        void Seed();

        [OperationContract]
        List<Client> GetAllClients();

        [OperationContract]
        bool AddMoneyToAcc(string accountNumber, decimal moneyToAdd);

        [OperationContract]
        bool RemoveMoneyFromAcc(string accountNumber, decimal moneyToRemove);
    }
}
