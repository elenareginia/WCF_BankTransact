﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainService.MoneyAddService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MoneyAddService.IMoneyAddService")]
    public interface IMoneyAddService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMoneyAddService/AddMoneyToAcc", ReplyAction="http://tempuri.org/IMoneyAddService/AddMoneyToAccResponse")]
        [System.ServiceModel.TransactionFlowAttribute(System.ServiceModel.TransactionFlowOption.Allowed)]
        bool AddMoneyToAcc(string accountNumber, decimal moneyToAdd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMoneyAddService/AddMoneyToAcc", ReplyAction="http://tempuri.org/IMoneyAddService/AddMoneyToAccResponse")]
        System.Threading.Tasks.Task<bool> AddMoneyToAccAsync(string accountNumber, decimal moneyToAdd);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMoneyAddServiceChannel : MoneyAddService.IMoneyAddService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MoneyAddServiceClient : System.ServiceModel.ClientBase<MoneyAddService.IMoneyAddService>, MoneyAddService.IMoneyAddService {
        
        public MoneyAddServiceClient() {
        }
        
        public MoneyAddServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MoneyAddServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MoneyAddServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MoneyAddServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddMoneyToAcc(string accountNumber, decimal moneyToAdd) {
            return base.Channel.AddMoneyToAcc(accountNumber, moneyToAdd);
        }
        
        public System.Threading.Tasks.Task<bool> AddMoneyToAccAsync(string accountNumber, decimal moneyToAdd) {
            return base.Channel.AddMoneyToAccAsync(accountNumber, moneyToAdd);
        }
    }
}
