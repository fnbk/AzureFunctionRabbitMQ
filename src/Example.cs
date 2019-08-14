// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace AzureFunctionRabbitMQ
{
    public static class Example
    {
        public static void TimerTrigger_StringOutput(
            [TimerTrigger("00:00:01")] TimerInfo timer,
            [RabbitMQ(
                HostName = "localhost",
                QueueName = "ruby")] out string outputMessage,
            ILogger logger)
        {
            outputMessage = "new";
            logger.LogInformation($"RabbitMQ output binding message: {outputMessage}");
        }

        public static void RabbitMQTrigger_StringInput(
             [RabbitMQTrigger("localhost", "ruby")] string message,
             string consumerTag,
             ILogger logger)
        {
            logger.LogInformation($"RabbitMQ queue trigger function processed message consumer tag: {consumerTag}");
            logger.LogInformation($"RabbitMQ queue trigger function processed message: {message}");
        }
    }
}
