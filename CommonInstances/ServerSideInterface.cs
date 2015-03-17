using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInstances
{

    /**
     * Esta interface declara os métodos que podem ser executados pelo cliente quando quer fazer
     * algo sobre o servidor. A classe implementadora desta interface contém mais métodos;
     * no entanto, nenhum deles pode ser chamado pelo servidor. Existem apenas para serem chamados no
     * contexto do próprio servidor. 
     */
    public interface ServerSideInterface
    {
        void ConnectClient(string port);

        List<string> GetOldMessages();

        void SendMessage(string message);
    }
}
