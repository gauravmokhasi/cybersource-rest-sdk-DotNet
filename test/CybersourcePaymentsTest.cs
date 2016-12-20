using Cybersource.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Cybersource.Test
{

    [TestClass]
    public class CybersourcePaymentsTest
    {
        private string paymentServiceRequest;
        private VisaAPIClient visaAPIClient;

        public CybersourcePaymentsTest()
        {
            visaAPIClient = new VisaAPIClient();
        }

        [TestMethod]
        public string TestPaymentServices(string []transactionDetails)
        {
            string baseUri = "cybersource/";
            try
            {
                string queryString = "apikey=" + ConfigurationManager.AppSettings["apiKey"];
                using (HttpWebResponse response = visaAPIClient.DoXPayTokenCall(baseUri, transactionDetails, queryString, "Cybersouce Payments Authorization Test", paymentServiceRequest) as HttpWebResponse)
                {
                    return GetTemplate(response.StatusCode.ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            //Assert.AreEqual(status, "Created");"",
        }
        static void Main(string[] args)
        {
            CybersourcePaymentsTest cybstest = new CybersourcePaymentsTest();
            cybstest.paymentServiceRequest = System.IO.File.ReadAllText(ConfigurationManager.AppSettings["sampleFile"]);

            try
            {
                string status = cybstest.TestPaymentServices(args);
                Console.WriteLine(status);
            }

            catch (EndpointNotFoundException e)
            {
                // This is thrown when a remote endpoint could not be found or reached.  
                // The remote endpoint is down, the client network connection is down, 
                // the remote endpoint is unreachable, or because the remote network is unreachable.

                SaveOrderState();
                HandleException(e);
            }
            catch (ChannelTerminatedException e)
            {
                // This is typically thrown on the client when a channel is terminated due to the server closing the connection.
                SaveOrderState();
                HandleException(e);
            }
            //System.ServiceModel.Security Exception example.
            catch (MessageSecurityException e)
            {
                //Represents an exception that occurred when there is something wrong with the security applied on a message. Possibly a bad signature.
                SaveOrderState();
                HandleSecurityException(e);
            }
            //System.Security.Cryptography exception    
            catch (CryptographicException ce)
            {
                //Represents a problem with your X509 certificate (.p12 file) or a problem creating a signature from the certificate.
                SaveOrderState();
                HandleCryptoException(ce);
            }
            //System.Net exception    
            catch (WebException we)
            {
                //The WebException class is thrown by classes descended from WebRequest and WebResponse that implement pluggable protocols for accessing the Internet.
                SaveOrderState();
                HandleWebException(we);
            }
            //Any other exception!
            catch (Exception e)
            {
                SaveOrderState();
                HandleException(e);
            }

            Console.WriteLine("Press Return to end...");
            Console.ReadLine();
        }

        private static void HandleException(Exception e)
        {
            string template = GetTemplate("ERROR");

            /*
             * The string returned in this sample is mostly to demonstrate
             * how to retrieve the exception properties.  Your application
             * should display user-friendly messages.
             */
            string content = String.Format(
                "\nAn Exception was returned with Message: '{0}'\n and Stack Trace:" +
                "'{1}'.", e.Message, e.StackTrace);

            Console.WriteLine(template, content);
        }

        private static void SaveOrderState()
        {
            /*
			 * This is where you store the order state in your system for
			 * post-transaction analysis.  Information to store include the
			 * invoice, the values of the reply fields, or the details of the
			 * exception that occurred, if any.
			 */
        }

        private static void HandleSecurityException(MessageSecurityException e)
        {
            string template = GetTemplate("ERROR");

            /*
             * The string returned in this sample is mostly to demonstrate
             * how to retrieve the exception properties.  Your application
             * should display user-friendly messages.
             */
            string content = String.Format(
                "\nA Security exception was returned with message '{1}'.", e.Message);

            Console.WriteLine(template, content);
        }

        private static void HandleCryptoException(Exception e)
        {
            string template = GetTemplate("ERROR");

            /*
             * The string returned in this sample is mostly to demonstrate
             * how to retrieve the exception properties.  Your application
             * should display user-friendly messages.
             */
            string content = String.Format(
                "\nA Cryptographic error occurred. Check to make sure that you have a certificate (.p12) file at the location supplied in the configuration file.  Error Message:'{0}'\n\nStack Trace:" +
                "'{1}'.", e.Message, e.StackTrace);

            Console.WriteLine(template, content);
        }

        private static void HandleWebException(WebException we)
        {
            string template = GetTemplate("ERROR");

            /*
			 * The string returned in this sample is mostly to demonstrate
			 * how to retrieve the exception properties.  Your application
			 * should display user-friendly messages.
			 */
            string content = String.Format(
                "\nFailed to get a response with status '{0}' and " +
                "message '{1}'", we.Status, we.Message);

            Console.WriteLine(template, content);

            if (IsCriticalError(we))
            {
                /*
				 * The transaction may have been completed by CyberSource.
				 * If your request included a payment service, you should
				 * notify the appropriate department in your company (e.g. by
				 * sending an email) so that they can confirm if the request
				 * did in fact complete by searching the CyberSource Support
				 * Screens using the value of the merchantReferenceCode in
				 * your request.
				 */
            }
        }

        private static string GetTemplate(string decision)
        {
            /*
			 * This is where you retrieve the HTML template that corresponds
			 * to the decision.  This template has 'boiler-plate' wording and
			 * can be stored in files or a database.  This is just one way to
			 * retrieve feedback pages.  Use what is appropriate for your
			 * system (e.g. ASP.NET pages).
			 */
            if ("Created".Equals(decision))
            {
                return ("The transaction succeeded.{0}");
            }

            if ("REJECT".Equals(decision))
            {
                return ("Your order was not approved.{0}");
            }

            // ERROR
            return (
                "Your order could not be completed at this time.{0}" +
                "\nPlease try again later.");
        }

        private static bool IsCriticalError(WebException we)
        {
            switch (we.Status)
            {
                case WebExceptionStatus.ProtocolError:
                    if (we.Response != null)
                    {
                        HttpWebResponse response
                            = (HttpWebResponse)we.Response;

                        // GatewayTimeout may be returned if you are
                        // connecting through a proxy server.
                        return (response.StatusCode ==
                            HttpStatusCode.GatewayTimeout);

                    }

                    // In case of ProtocolError, the Response property
                    // should always be present.  In the unlikely case 
                    // that it is not, we assume something went wrong
                    // along the way and to be safe, treat it as a
                    // critical error.
                    return (true);

                case WebExceptionStatus.ConnectFailure:
                case WebExceptionStatus.NameResolutionFailure:
                case WebExceptionStatus.ProxyNameResolutionFailure:
                case WebExceptionStatus.SendFailure:
                    return (false);

                default:
                    return (true);
            }
        }
    }
}
