// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

Console.WriteLine("Starting!");
var color = args[0] ?? "#000000";
string connectionString = "Endpoint=sb://webbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=aSWenqtoKZBRTcm3CLrSrSKxnDWpa/MOZ+ASbACt5nM=";
var client = new ServiceBusClient(connectionString);
var sender = client.CreateSender("bg-color");

await sender.SendMessageAsync(new ServiceBusMessage(color));

Console.WriteLine("Done!");
Console.ReadKey();
