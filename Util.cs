using Lime.Messaging.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_bot_gama
{
    public class Util
    {
        public static Select initialState() {
            return new Select
            {
                Text = "Olá, eu sou o Chatbot\nSelecione uma opção abaixo:",
                Options = new[]
                {
                    new SelectOption
                    {
                        Order = 1,
                        Text = "Sou Candidato",
                        Value = new PlainText { Text = "candidato" }
                    },
                    new SelectOption
                    {
                        Order = 2,
                        Text = "Sou Contratante",
                        Value = new PlainText { Text = "contratante" }
                    }
                }
            };
        }

        public static Select candidatoState()
        {
            return new Select
            {
                Text = "Você já conhece o Gama?",
                Options = new[]
                {
                    new SelectOption
                    {
                        Order = 1,
                        Text = "Sim",
                        Value = new PlainText { Text = "conheceSim" }
                    },
                    new SelectOption
                    {
                        Order = 2,
                        Text = "Não",
                        Value = new PlainText { Text = "conheceNao" }
                    }
                }
            };
        }

        public static Select contratanteState()
        {
            return new Select
            {
                Text = "Feira agendada?",
                Options = new[]
                {
                    new SelectOption
                    {
                        Order = 1,
                        Text = "Sim",
                        Value = new PlainText { Text = "agendada" }
                    },
                    new SelectOption
                    {
                        Order = 2,
                        Text = "Não",
                        Value = new PlainText { Text = "naoAgendada" }
                    }
                }
            };
        }
    }
}
