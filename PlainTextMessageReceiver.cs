using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using Takenet.MessagingHub.Client;
using Takenet.MessagingHub.Client.Listener;
using Takenet.MessagingHub.Client.Sender;
using System.Diagnostics;
using Lime.Messaging.Contents;

namespace chat_bot_gama
{
    public class PlainTextMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public PlainTextMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;


        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            Trace.TraceInformation($"From: {message.From} \tContent: {message.Content}");
            //switch (message.Content.ToString())
            //{
            //    case "": break;
            //}

            var document = new Select
            {
                Text = "Escolha uma opção:",
                Options = new[]
       {
            new SelectOption
            {
                Order = 1,
                Text = "Um texto inspirador!",
                Value = new PlainText { Text = "1" }
            },
            new SelectOption
            {
                Order = 2,
                Text = "Uma imagem motivacional!",
                Value = new PlainText { Text = "2" }
            },
            new SelectOption
            {
                Order = 3,
                Text = "Um link para algo interessante!",
                Value = new PlainText { Text = "3" }
            }
        }
            };

            await _sender.SendMessageAsync(document, message.From, cancellationToken);
        }
    }
}
