using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDados
{
    internal class Juego
    {
        private int _dineroActual;
        private int _dineroPerdidio;
        private int _dineroGanado;
        private int _balance;
        private int _tiros;
        private int _cont2;
        private int _cont3;
        private int _cont4;
        private int _cont5;
        private int _cont6;
        private int _cont7;
        private int _cont8;
        private int _cont9;
        private int _cont10;
        private int _cont11;
        private int _cont12;
        private int _numMasTiros;
        private int _numVecesMasTiros;
        private int _numMenosTiros;
        private int _numVecesMenosTiros;
        private int _extremos;
        private int _medios;
        private int _pares;
        private int _impares;
        private Dados _dados;
        private List<int> _tiradas;


        public Juego()
        {
            _dineroActual = 300;
            _dineroPerdidio = 0;
            _dineroGanado = 0;
            _balance = 0;
            _tiros = 0;
            _cont2 = 0;
            _cont3 = 0;
            _cont4 = 0;
            _cont5 = 0;
            _cont6 = 0;
            _cont7 = 0;
            _cont8 = 0;
            _cont9 = 0;
            _cont10 = 0;
            _cont11 = 0;
            _cont12 = 0;
            _numMasTiros = 0;
            _numVecesMasTiros = 0;
            _numMenosTiros = 0;
            _numVecesMenosTiros = 10;
            _extremos = 0;
            _medios = 0;
            _pares = 0;
            _impares = 0;
            _dados = new Dados();
            _tiradas = new List<int>();
        }

        public void menuPrincipal()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            Console.WriteLine("Dinero actual: " + _dineroActual);
            if (_dineroActual > 0)
            {
                do
                {
                    Console.WriteLine("Elija una opcion");
                    Console.WriteLine("[1] Apostar");
                    Console.WriteLine("[2] Ver historial de tiros");
                    Console.WriteLine("[3] Ver estadisticas de tiros");
                    Console.WriteLine("[4] Salir");
                } while (!validarMenu(4, ref opcionSeleccionada));

                switch (opcionSeleccionada)
                {
                    case 1:
                        int seleccion = 0;
                        do
                        {
                            Console.WriteLine("[1] Apostar a numero especifco");
                            Console.WriteLine("[2] Apostar a extremo");
                            Console.WriteLine("[3] Apostar a medios");
                            Console.WriteLine("[4] Apostar a par o impar");
                        } while (!validarMenu(4, ref seleccion));
                        switch (seleccion)
                        {
                            case 1:
                                apostarEspecifico();
                                break;
                            case 2:
                                apostarExtremo();
                                break;
                            case 3:
                                apostarMedio();
                                break;
                            case 4:
                                apostarParImpar();
                                break;

                        }
                        break;
                    case 2:
                        Console.WriteLine("Historial tiros:");
                        foreach(int t in _tiradas)
                        {
                            Console.WriteLine(t);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Tiradas realizadas: " + _tiros);
                        Console.WriteLine("Balance: " + _balance);
                        Console.WriteLine("Numero mas tirado: " + _numMasTiros);
                        Console.WriteLine("Numero menos tirado: " + _numMenosTiros);
                        Console.WriteLine("Resultados extremos: " + _extremos);
                        Console.WriteLine("Resultados medios: " + _medios);
                        Console.WriteLine("Resultados pares: " + _pares);
                        Console.WriteLine("Resultados impares: " + _impares);
                        break;
                }
                if (opcionSeleccionada != 4)
                {
                    Console.WriteLine("Puse enter para volver...");
                    Console.ReadLine();
                    menuPrincipal();
                }
            }
            if (_dineroActual <= 0)
            {
                Console.WriteLine("Se ha quedado sin dinero");
            }
            Console.WriteLine("Dinero ganado: " + _dineroGanado);
            Console.WriteLine("Dinero perdido: " + _dineroPerdidio);
            Environment.Exit(0);
        }

        private Boolean validarMenu(int opciones, ref int opcionesSeleccion)
        {
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n <= opciones)
                {
                    opcionesSeleccion = n;
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opción invalida");
                    return false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Valor invalido, se debe ingresar un número.");
                return false;
            }
        }

        private Boolean validarApuesta(int apuesta)
        {
            if(apuesta%10 == 0)
            {           
                return true;
            }
            else
            {
                Console.WriteLine("Solo se pueden apostar valores multiplos de 10");
                return false;
            }
        }

        private int tirarDados()
        {
            _dados.tirarDados();
            int numeroTirado = _dados.total;
            int numeroDado1 = _dados.dado1;
            int numeroDado2 = _dados.dado2;
            _tiros = _tiros + 1;
            _tiradas.Add(numeroTirado);
            if (numeroDado1 == numeroDado2)
            {
                _balance = _balance + 1;
            }
            if (numeroTirado == 2 || numeroTirado == 3 || numeroTirado == 4 || numeroTirado == 10 || numeroTirado == 11 || numeroTirado == 12)
            {
                _extremos = _extremos + 1;
            }
            if (numeroTirado == 5 || numeroTirado == 6 || numeroTirado == 7 || numeroTirado == 8 || numeroTirado == 9)
            {
                _medios = _medios + 1;
            }
            if (numeroTirado % 2 == 0)
            {
                _pares = _pares + 1;
            }
            else
            {
                _impares = _impares + 1;
            }

            if (numeroTirado == 2)
            {
                _cont2 = _cont2 + 1;
            }
            else if (numeroTirado == 3)
            {
                _cont3 = _cont3 + 1;
            }
            else if (numeroTirado == 4)
            {
                _cont4 = _cont4 + 1;
            }
            else if (numeroTirado == 5)
            {
                _cont5 = _cont5 + 1;
            }
            else if (numeroTirado == 6)
            {
                _cont6 = _cont6 + 1;
            }
            else if (numeroTirado == 7)
            {
                _cont7 = _cont7 + 1;
            }
            else if (numeroTirado == 8)
            {
                _cont8 = _cont8 + 1;
            }
            else if (numeroTirado == 9)
            {
                _cont9 = _cont9 + 1;
            }
            else if (numeroTirado == 10)
            {
                _cont10 = _cont10 + 1;
            }
            else if (numeroTirado == 11)
            {
                _cont11 = _cont11 + 1;
            }
            else if (numeroTirado == 12)
            {
                _cont12 = _cont12 + 1;
            }

            if(_cont2 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont2;
                _numMasTiros = 2;
            }else if (_cont3 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont3;
                _numMasTiros = 3;
            }
            else if (_cont4 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont4;
                _numMasTiros = 4;
            }
            else if (_cont5 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont5;
                _numMasTiros = 5;
            }
            else if (_cont6 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont6;
                _numMasTiros = 6;
            }
            else if (_cont7 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont7;
                _numMasTiros = 7;
            }
            else if (_cont8 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont8;
                _numMasTiros = 8;
            }
            else if (_cont10 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont10;
                _numMasTiros = 10;
            }
            else if (_cont11 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont11;
                _numMasTiros = 11;
            }
            else if (_cont12 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont12;
                _numMasTiros = 12;
            }
            else if (_cont9 > _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont9;
                _numMasTiros = 9;
            }


            if (_cont2 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont2;
                _numMenosTiros = 2;
            }
            else if (_cont3 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont3;
                _numMenosTiros = 3;
            }
            else if (_cont4 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont4;
                _numMenosTiros = 4;
            }
            else if (_cont5 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont5;
                _numMenosTiros = 5;
            }
            else if (_cont6 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont6;
                _numMenosTiros = 6;
            }
            else if (_cont7 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont7;
                _numMenosTiros = 7;
            }
            else if (_cont8 < _numVecesMasTiros)
            {
                _numVecesMasTiros = _cont8;
                _numMenosTiros = 8;
            }
            else if (_cont10 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont10;
                _numMenosTiros = 10;
            }
            else if (_cont11 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont11;
                _numMenosTiros = 11;
            }
            else if (_cont12 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont12;
                _numMenosTiros = 12;
            }
            else if (_cont9 < _numVecesMenosTiros)
            {
                _numVecesMenosTiros = _cont9;
                _numMenosTiros = 9;
            }

            return numeroTirado;
        }

        public void apostarEspecifico()
        {
            int apuesta=0;
            do
            {
                Console.WriteLine("Cantidad a apostar:");
                apuesta = Int32.Parse(Console.ReadLine());
            } while (!validarApuesta(apuesta));

            int numApuesta = 0;
            do
            {
                Console.WriteLine("Numero a apostar:");
                numApuesta = Int32.Parse(Console.ReadLine());
            } while (!(numApuesta >= 2 && numApuesta <= 12));

            int tirada = tirarDados();
            if (numApuesta == tirada)
            {
                Console.WriteLine("Felicidades, gano!");
                _dineroActual = _dineroActual + apuesta * 10;
                _dineroGanado = _dineroGanado + apuesta * 10;
            }
            else
            {
                Console.WriteLine("Mala suerte, perdio");
                _dineroActual = _dineroActual - apuesta;
                _dineroPerdidio = _dineroPerdidio + apuesta;
            }
        }

        public void apostarExtremo()
        {
            int apuesta = 0;
            do
            {
                Console.WriteLine("Cantidad a apostar:");
                apuesta = Int32.Parse(Console.ReadLine());
            } while (!validarApuesta(apuesta));

            
            int tirada = tirarDados();
            if (tirada == 2 || tirada == 3 || tirada == 4 || tirada == 10 || tirada == 11 || tirada == 12)
            {
                Console.WriteLine("Felicidades, gano!");
                _dineroActual = _dineroActual + apuesta * 8;
                _dineroGanado = _dineroGanado + apuesta * 8;
            }
            else
            {
                Console.WriteLine("Mala suerte, perdio");
                _dineroActual = _dineroActual - apuesta;
                _dineroPerdidio = _dineroPerdidio + apuesta;
            }
        }

        public void apostarMedio()
        {
            int apuesta = 0;
            do
            {
                Console.WriteLine("Cantidad a apostar:");
                apuesta = Int32.Parse(Console.ReadLine());
            } while (!validarApuesta(apuesta));


            int tirada = tirarDados();
            if (tirada == 5 || tirada == 6 || tirada == 7 || tirada == 8 || tirada == 9)
            {
                Console.WriteLine("Felicidades, gano!");
                _dineroActual = _dineroActual + apuesta * 4;
                _dineroGanado = _dineroGanado + apuesta * 4;
            }
            else
            {
                Console.WriteLine("Mala suerte, perdio");
                _dineroActual = _dineroActual - apuesta;
                _dineroPerdidio = _dineroPerdidio + apuesta;
            }
        }

        public void apostarParImpar()
        {
            int apuesta = 0;
            do
            {
                Console.WriteLine("Cantidad a apostar:");
                apuesta = Int32.Parse(Console.ReadLine());
            } while (!validarApuesta(apuesta));

            string eleccionApuesta = "";
            do
            {
                Console.WriteLine("A que va a apostar (par o impar):");
                eleccionApuesta = Console.ReadLine();
            } while (!(eleccionApuesta=="par" || eleccionApuesta=="impar"));

            int tirada = tirarDados();
            if (tirada%2 ==0 && eleccionApuesta == "par")
            {
                Console.WriteLine("Felicidades, gano!");
                _dineroActual = _dineroActual + apuesta * 2;
                _dineroGanado = _dineroGanado + apuesta * 2;
            }
            else if(tirada % 2 != 0 && eleccionApuesta == "impar")
            {
                Console.WriteLine("Felicidades, gano!");
                _dineroActual = _dineroActual + apuesta * 2;
                _dineroGanado = _dineroGanado + apuesta * 2;
            }
            else
            {
                Console.WriteLine("Mala suerte, perdio");
                _dineroActual = _dineroActual - apuesta;
                _dineroPerdidio = _dineroPerdidio + apuesta;
            }
        }
    }
}
