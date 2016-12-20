using System;

namespace Cybersource.Client
{
    internal class VoidCreditApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public VoidCreditApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/credits/" + transactionDetails[1] + "/voids";
        }

        string IApiAccessor.GetTransactionResourcePath()
        {
            return this.transactionDetails;
        }

        public string GetTransactionType()
        {
            return this.transactionType;
        }
    }
}