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
    public class ContratanteReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public ContratanteReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            Trace.TraceInformation($"From: {message.From} \tContent: {message.Content}");

            switch (message.Content.ToString())
            {
                case "naoAgendada":
                    await _sender.SendMessageAsync("Obrigado pelo interesse, infelizmente no momento não temos feira de contratação em aberto. Mas acompanhe o site para editais futuros: http://gama.academy/", message.From, cancellationToken);
                    break;
                case "agendada":
                    await _sender.SendMessageAsync("A feira está agendada para o dia 08/04 às 18 horas. Para saber mais informações acesse http://bit.ly/2oLyMOs",
                        message.From, cancellationToken);
                    break;

                default:
                    await _sender.SendMessageAsync(Util.contratanteState(), message.From, cancellationToken);
                    break;
            }
        }
    }
}
