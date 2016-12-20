using System;

namespace Cybersource.Client
{
    internal class RetrieveAllCreditApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public RetrieveAllCreditApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/credits";
        }

        public string GetTransactionResourcePath()
        {
            return transactionDetails;
        }

        public string GetTransactionType()
        {
            return this.transactionType;
        }
    }
}