using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDados
{
    internal class Dados
    {
        private int _dado1;
        private int _dado2;
        private int _total;
        private Random aleatorio;

        public Dados()
        {
            this._dado1 = 1;
            this._dado2 = 1;
            this._total = _dado1 + _dado2;
            this.aleatorio = new Random();
        }

        public int dado1
        {
            get { return this._dado1; }
            set { _dado1 = value; }
        }

        public int dado2
        {
            get { return this._dado2; }
            set { _dado2 = value; }
        }

        public int total
        {
            get { return this._total; }
        }

        public void tirarDados()
        {
            _dado1 = aleatorio.Next(1, 7);
            _dado2 = aleatorio.Next(1, 7);
            _total = _dado1 + _dado2;
            Console.WriteLine("Dado 1: " + _dado1);
            Console.WriteLine("Dado 2: " + _dado2);
            Console.WriteLine("Total tirada: "+_total);
        }
    }
}
