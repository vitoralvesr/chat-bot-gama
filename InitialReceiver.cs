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
    public class InitialReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public InitialReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            Trace.TraceInformation($"From: {message.From} \tContent: {message.Content}");

            await _sender.SendMessageAsync(Util.initialState(), message.From, cancellationToken);
        }
    }
}
