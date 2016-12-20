﻿using System;

namespace Cybersource.Client
{
    internal class RetrieveAllSaleApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public RetrieveAllSaleApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/sales";
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