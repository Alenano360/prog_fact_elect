using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class ServerRequest
    {
        private WebRequest request;
        private Stream dataStream;

        private string status;
        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public ServerRequest(string url)
        {
            // Create a request using a URL that can receive a post.

            request = WebRequest.Create(url);
            request.Timeout = 60000;
        }

        public ServerRequest(string url, string method)
            : this(url)
        {

            if (method.Equals("GET") || method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                request.Method = method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }
        }

        public ServerRequest(string url, string receipt_key, string customerid, string action)
            : this(url, "GET")
        {
            // Set the ContentType property of the WebRequest.
            
            request.Headers.Add("customer_id", customerid);
            request.Headers.Add("receipt_key", receipt_key);
            request.Headers.Add("mode", action);
            

        }


        public ServerRequest(string url, string method, string data, string customerid, string action)
            : this(url, method)
        {

            // Create POST data and convert it to a byte array.

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(data);
            string base64 = System.Convert.ToBase64String(plainTextBytes);
            base64 = "{\"document\":\"" + base64 + "\"}";

            //string postData = base64;
            byte[] byteArray = Encoding.UTF8.GetBytes(base64);

            // Set the ContentType property of the WebRequest.

            request.ContentType = "application/json";
            request.Headers.Add("customer_id", customerid);
            request.Headers.Add("action", action);

            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

        }



        public ServerRequest(string url, string method, string data, string userid,string usertoken, string customerid)
            : this(url, method)
        {
            var fields = data.Split(' ');

            string payload = "{\"client_dgtd_username\":\""+ fields[0] + "\",\"client_pass\":\"" + fields[1] + "\",\"client_key_pass\":\"" + fields[2] + "\",\"client_key_b64\":\"" + fields[3]+"\"}";


            
            byte[] byteArray = Encoding.UTF8.GetBytes(payload);

            // Set the ContentType property of the WebRequest.

            request.ContentType = "application/json";
            request.Headers.Add("client_internal_id", customerid);
            request.Headers.Add("user_id", userid);
            request.Headers.Add("user_token", usertoken);

            
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();
        }

        public string GetResponse()
        {
            try
            {
                // Get the original response.
                WebResponse response = request.GetResponse();

                this.Status = ((HttpWebResponse)response).StatusDescription;
                // Get the stream containing all content returned by the requested server.
                dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                // Read the content fully up to the end.
                string responseFromServer = reader.ReadToEnd();

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer;
            }
            catch (Exception e )
            {
                MessageBox.Show(e.ToString());
                return "";
            }
        }
        
    }
}
