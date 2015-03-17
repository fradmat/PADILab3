using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInstances
{
    /**
     * Esta interface declara os métodos que podem ser executados pelo servidor quando quer fazer
     * algo sobre o cliente. A classe implementadora desta interface contém mais métodos;
     * no entanto, nenhum deles pode ser chamado pelo servidor. Existem apenas para serem chamados no
     * contexto do próprio cliente. 
     */
    public interface ClientSideInterface
    { 
        void ReceiveMessage(string message);
    }
}
