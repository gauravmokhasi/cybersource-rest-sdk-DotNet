# C Sharp Module for REST API calls

## Installing the SDK 

1. Download the cybersource-rest-sdk-DotNet-master.zip package into a directory of your choice. 

2. Extract and go to the cybersource-rest-sdk-DotNet-master directory.

3. Open Solution CyberSource in Visual Studio.

4. Build/Rebuild the Solution.

## Usage

1. Register on Visa Developer Platform.

2. Create an application on VDP.

3. Payload has to be in the form of a json file. Mention path of the payload file in app.config.

4. Put API key and Shared Secret in app.config. For more information on `app.config` refer : [Manual](https://github.com/visa/SampleCode/wiki/Manual) 

5. Load the solution into your Visual Studio using the .sln or .csproj file.

6. Mention the transaction type as a command line argument.

6. Go to **Tests -> Debug -> All Tests**

7. You can see the results under the option Debug console in your output window.

## Payment Services Keywords

| Service Name | Keyword |
| ------------ | ------- |
| Authorize a Credit Card | authorizations |
| Capture Funds for an Authorized Amount | capture |
| Create a Sales Transaction | sale |
| Refund A Capture | refundCapture |
| Refund A Sale | refundSale |
| Create A Credit | credit |
| Void A Capture | voidCapture |
| Void A Sale | voidSale |
| Void A Refund | voidRefund |
| Void A Credit | voidCredit |
| Reverse An Authorization | authreversal |
| Payments Search | paymentSearch |
| Payments Search by Id | paymentSearchId |
| Retrieve a Payment Authorization | retrieveAuth |
| Retrieve a Capture | retrieveCapture |
| Retrieve Capture By Authorization Id | retrieveAuthId |
| Search for Specific Sale | searchSale |
| Retrieve A Refund | retrieveRefund |
| Retrieve Refund By Capture Id | refundCaptureId |
| Retrieve Refund By Sale Id | refundSaleID |
| Retrieve A Credit | retieveCredit |
| Retrieve A Reversal | retrieveReversal |
| Retrieve A Void Transaction | retrieveVoid |
| Retrieve All Authorizations | retrieveAllAuth |
| Retrieve All Captures | retrieveAllCapture |
| Retrieve All Sales | retrieveAllSale |
| Retrieve All Refunds | retrieveAllRefund |
| Retrieve All Credits | retrieveAllCredit |
