using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Azure.Messaging.ServiceBus;
using System.Threading;

namespace WebBus
{
    public class Global : HttpApplication
    {
        private static ServiceBusProcessor _processor;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["BackgroundColor"] = "#f5aee7";

            StartColorListener(); // kick off listener
        }

        private async void StartColorListener()
        {
            string connectionString = "Endpoint=sb://webbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=...";
            string topicName = "bg-color";
            string subscriptionName = "bg-color-sub";

            var client = new ServiceBusClient(connectionString);
            _processor = client.CreateProcessor(topicName, subscriptionName, new ServiceBusProcessorOptions());

            _processor.ProcessMessageAsync += async args =>
            {
                Application["BackgroundColor"] = "#FF0000";
                //string colorHex = args.Message.Body.ToString();
                //if (System.Text.RegularExpressions.Regex.IsMatch(colorHex, "^#[0-9a-fA-F]{6}$"))
                //{
                //    Application["BackgroundColor"] = colorHex;
                //}

                //await args.CompleteMessageAsync(args.Message);
            };

            //_processor.ProcessErrorAsync += async args =>
            //{
            //    // Optional: Log or handle errors
            //};

            await _processor.StartProcessingAsync();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _processor?.CloseAsync().GetAwaiter().GetResult();
        }
    }
}