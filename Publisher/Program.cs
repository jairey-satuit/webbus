// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

Console.WriteLine("Starting!");

string connectionString = "Endpoint=sb://webbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=aSWenqtoKZBRTcm3CLrSrSKxnDWpa/MOZ+ASbACt5nM=";
var client = new ServiceBusClient(connectionString);
var sender = client.CreateSender("bg-color");

await sender.SendMessageAsync(new ServiceBusMessage("#336699"));

Console.WriteLine("Done!");
Console.ReadKey();
