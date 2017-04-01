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
    public class CandidatoReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public CandidatoReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            Trace.TraceInformation($"From: {message.From} \tContent: {message.Content}");

            switch (message.Content.ToString())
            {
                case "conheceSim":
                    await _sender.SendMessageAsync("Acesse o site http://gama.academy/pt/programas/experience/", message.From, cancellationToken);
                    break;
                case "conheceNao":
                    await _sender.SendMessageAsync("O Gama Experience é um programa de seleção e treinamento de talentos para trabalhar em startups.",
                        message.From, cancellationToken);
                    break;
                    
                default:
                    await _sender.SendMessageAsync(Util.candidatoState(), message.From, cancellationToken);
                    break;
            }
        }
    }
}
