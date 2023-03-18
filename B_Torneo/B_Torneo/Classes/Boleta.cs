using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace B_Torneo.Classes
{
    /* La clase boleta solo sirve para llenar las listas de boletas disponibles en los objetos
       enfrentamiento. Esta solo recibe su número, el cual es un atributo de clase de la clase
       enfrentamiento y aumenta con cada instanciación */
    public class Boleta
    {
        private ushort numero;
        
        public Boleta(ushort numero)
        {
            Numero = numero;
        }

        public ushort Numero { get => numero; private set => numero = value; }
    }
}
