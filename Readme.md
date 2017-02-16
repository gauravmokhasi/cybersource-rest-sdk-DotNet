# C Sharp Module for REST API calls

## Installing the SDK 
- Download the `cybersource-rest-sdk-DotNet-master.zip` package into a directory of your choice. 
- Extract and go to the `cybersource-rest-sdk-DotNet-master` directory.
- Open Solution `cybersource-rest-sdk-DotNet` in Visual Studio.
- Build/Rebuild the Solution.

## Usage
- Register on [VDP (Visa Developer Platform)](https://developer.visa.com/ "Visa Developer Platform").
- Create an application on VDP. Make sure "CyberSource Payment API" is checked before creating the application.
- The Cybersource REST APIs require their payload to be in the form of a json file. Mention the path of the payload file in the `App.config`.
  - See the project's [sample payloads](../master/test/samples/) for examples.
- Put API key and Shared Secret in `App.config`. Cybersource Payment API uses X-Pay-Token authentication method.
  - For more information, refer to the [VDP Manual](https://github.com/visa/SampleCode/wiki/Manual#x-pay-token-authentication "VDP Manual on Github").
- Load the solution into your Visual Studio using the `cybersource-rest-sdk-DotNet.sln` file.
- Under Solution Explorer, right click on the `cybersource-rest-sdk-DotNet` project, then click **Properties**.
  - Click on **Debug**. Then under **Command line arguments**, specify the [payment service keyword](../master/Readme.md#payment-services-keywords) for the transaction type that you want to execute.
  - Some transaction types require more than one command line argument. For example, the command line arguments for `refundSale` transactions would be `refundSale {sales-id}`. See more information on request attributes at the [VDP documentation](https://developer.visa.com/products/cybersource/reference "Cybersource Payments documentation on VDP").
- Right click on the `cybersource-rest-sdk-DotNet` project, then click **Debug** and **Start new instance**.
- You can see the results under the option Debug console in your output window.

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
