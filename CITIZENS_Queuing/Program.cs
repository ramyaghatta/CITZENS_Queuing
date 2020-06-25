using System;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace CITIZENS_Queuing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new AmazonSQSClient();

                // List all queues that start with "aws".
                var request = new ListQueuesRequest
                {
                    QueueNamePrefix = "CitizensQueue"
                };

                var response = client.ListQueues(request);
                var urls = response.QueueUrls;

                if (urls.Any())
                {
                    Console.WriteLine("Queue URLs:");

                    foreach (var url in urls)
                    {
                        Console.WriteLine("  " + url);
                    }
                }
                else
                {
                    Console.WriteLine("No queues.");
                }

                //this is the interface to SQS Service
                AmazonSQSClient SQSClient = new AmazonSQSClient();

                //create the message object
                SendMessageRequest MessageRequest = new SendMessageRequest();

                //read this URL from the AWS SQS console 
                MessageRequest.QueueUrl = "your queue URL";

                //set the message text
                MessageRequest.MessageBody = "This is a test";

                //send the message
                SQSClient.SendMessage(MessageRequest);

                //prevent the console window from closing
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                //display exception
                Console.WriteLine(ex.Message);
                //prevent the console window from closing
                Console.ReadLine();
            }
        }
    }
}
