using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MoneyRemoveService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMoneyRemoveService" in both code and config file together.
    [ServiceContract]
    public interface IMoneyRemoveService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool RemoveMoneyFromAcc(string accountNumber, decimal moneyToRemove);
    }
}
