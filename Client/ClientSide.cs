using CommonInstances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public delegate void AddNewMessageToConversationDelegate (string message);

    /** Classe que concretiza os métodos expostos pelo cliente. A classe tem atributos e métodos estáticos porque só é "instanciada"
     * do lado do servidor; no entanto, precisa de ter referências, por exemplo, para a form do lado do cliente, pelo que
     * tem que ser esse (mais especificamente, a Form do cliente), ao chamar o método connectToServer (depois do utilizador ter 
     * carregado no botão), a atribuir a referência. O cliente nunca instancia esta classe; até poderia fazê-lo, mas essa instância
     * nunca seria a mesma do lado do servidor, que tem outra referência (um proxy). 
     * 
     */
    public class ClientSide : MarshalByRefObject, ClientSideInterface
    {
        //Proxy para o servidor, onde serão chamados metodos para ligar o cliente e submeter mensagens. 
        private static ServerSideInterface serverConnection;

        //Referência para a Form do cliente, para que esta possa ser actualizada consoante o que se recebe do servidor.
        //Estática para que o cliente possa passar a referência à classe, e o servidor possa depois aceder-lhe na sua instância da classe.
        public static Form1 ClientUserInterface;

        /** Regista este cliente no porto especificado.
         * ClientUserInterface já deverá referenciar a form quando este método é chamado. 
        **/
        public void RegisterClient(string port)
        {
            TcpChannel channel = new TcpChannel(Convert.ToInt32(port));
            ChannelServices.RegisterChannel(channel, true);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ClientSide),
                "ClientSideName",
                WellKnownObjectMode.Singleton);
        }

        /** O servidor deverá acrescentar este porto à sua lista de clientes ligados,
        * para que depois envie para aqui quaisquer mensagens submetidas. 
         * ClientUserInterface já deverá referenciar a form quando este método é chamado. 
        **/
        public void ConnectToServer(string port)
        {
            //Obtém uma referência para um proxy do servidor, no porto em que ele estará ligado. Regista este cliente no servidor.
            serverConnection = (ServerSideInterface)Activator.GetObject(typeof(ServerSideInterface), "tcp://localhost:8086/ServerSideName");
            serverConnection.ConnectClient(port);
        }

        /* O método Invoke é usado porque todo o contexto desta função é executado numa nova thread criada
         * pela função chamadora.
         * */
        public void ReceiveMessage(string message)
        {
            ClientUserInterface.Invoke(new AddNewMessageToConversationDelegate(ClientUserInterface.AddNewMessageToConversation), message);
        }

        public List<string> GetOldMessages()
        {
            return serverConnection.GetOldMessages();
        }

        public void sendMessageToServer(string message)
        {
            serverConnection.SendMessage(message);
        }

    }
}
