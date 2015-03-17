using CommonInstances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ServerSide : MarshalByRefObject, ServerSideInterface
    {
        //Lista com os clientes ligados.
        private static List<ClientSideInterface> connectedClients = new List<ClientSideInterface>();

        //Lista com todas as mensagens já trocadas no chat
        private static List<string> exchangedMessages = new List<string>();

        public List<string> ExchangedMessages { get { return exchangedMessages; } private set { exchangedMessages = value; } }

        public void RegisterServer()
        {
            TcpChannel channel = new TcpChannel(8086);
            ChannelServices.RegisterChannel(channel, true);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ServerSide),
                "ServerSideName",
                WellKnownObjectMode.Singleton);
        }

        /* Adiciona um proxy para o cliente que se está a tentar ligar. O proxy será usado para o servidor enviar para o cliente as mensagens recebidas
         * de ele próprio (o cliente) e outros eventuais clientes. A variável "port" é o porto em que o cliente está à espera de receber mensagens.
         * Este método é chamado pelo próprio cliente, e assim ele submete o seu porto. 
         */
        public void ConnectClient(string port)
        {
            connectedClients.Add((ClientSideInterface)Activator.GetObject(typeof(ClientSideInterface), "tcp://localhost:" + port + "/ClientSideName"));
            Console.WriteLine("Connected to a new client at port" + port);
        }

        public List<string> GetOldMessages()
        {
            return ExchangedMessages;
        }

        /** É necessário criar uma nova thread que chame o metodo broadcastMessage. Isto é necessário porque se assim não for,
         * a thread principal bloqueia-se à espera que o canal de comunicação fique aberto para executar o ciclo "for"
         * que existe no metodo BroadcastMessage. Como o canal só desbloqueia quando a aplicação retorna de SendMessage,
         * e a aplicação não sai de SendMessage enquanto o canal não desbloqueia, a aplicação fica em deadlock.
         * Com a nova tarefa, evita-se esse problema. 
         * 
         * Resta saber: por que razão, ao certo, o canal está bloqueado?
         */
        public void SendMessage(string message)
        {
            ExchangedMessages.Add(message);
            Thread thread = new Thread(delegate() { broadcastMessage(message); });
            thread.Start();
        }

        private void broadcastMessage(string message)
        {
            foreach (ClientSideInterface connectedClient in connectedClients)
            {
                connectedClient.ReceiveMessage(message);
            }
        }

    }
}
