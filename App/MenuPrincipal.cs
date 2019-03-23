using System;
using static System.Console;
using System.Collections.Generic;
using CentralTelefonica.Entidades;
using CentralTelefonica.Until;

namespace CentralTelefonica.App
{
    public class MenuPrincipal
    {
        //Constantes
        //Nunca va a cambiar valor
        private const float precioUnoDepartamental = 0.65f;
        private const float precioDosDepartamental = 0.85f;
        private const float precioTresDepartamental = 0.98f;
        private const float precioLocal = 0.49f;
        public List<Llamada> listaDeLlamadas { get; set; }

        public MenuPrincipal()
        {
            this.listaDeLlamadas = new List<Llamada>();
        }
        public void mostrarMenu()
        {
            int opcion = 100;
            do
            {
                try
                {
                    Clear();
                    WriteLine("1. Registrar llamada local");
                    WriteLine("2. Registrar llamada departamental");
                    WriteLine("3. Costo total de las llamadas locales");
                    WriteLine("4. Costo total de las llamadas departamentales");
                    WriteLine("5. Costo total de las llamadas");
                    WriteLine("6. Mostrar detalle de llamadas");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese su opción: ");
                    string valor = ReadLine();
                    if (EsNumero(valor) == true)
                    {
                        opcion = Convert.ToInt16(valor);
                    }

                    if (opcion == 1)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 2)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 3)
                    {
                        MostrarCostoLlamadaLocales();
                    }
                    else if (opcion == 4)
                    {
                        MostrarDetalleLlamadasDepto();
                    }
                    else if (opcion == 6)
                    {
                        MostrarDetalle();
                        ReadKey();
                    }
                }
                catch (Exception)
                {
                    WriteLine("No puede ingresar una letra, debe ingresar un numero");
                    ReadKey();
                    //throw new MenuException();
                }

            } while (opcion != 0);
        }
        public Boolean EsNumero(string valor)
        {
            Boolean resultado = false;
            try
            {
                int numero = Convert.ToInt16(valor);
                resultado = true;
            }
            catch (Exception)
            {
                throw new MenuException();
            }
            return resultado;
        }

        public void RegistrarLlamada(int opcion)
        {
            string numeroOrigen = "";
            string numeroDestino = "";
            double duracion = 0;
            Llamada llamada = null;
            WriteLine("Ingrese el numero de origen");
            numeroOrigen = ReadLine();
            WriteLine("Ingrese el numero de destino");
            numeroDestino = ReadLine();
            WriteLine("Ingrese la duración de la llamada");
            string valor1 = ReadLine();
            duracion = Convert.ToDouble(valor1);
            if (opcion == 1)
            {
                llamada = new LlamadaLocal(numeroOrigen, numeroDestino, duracion);
                ((LlamadaLocal)llamada).Precio = precioLocal;
            }
            else if (opcion == 2)
            {
                llamada = new LlamadaDepartamental(numeroOrigen, numeroDestino, duracion);
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = calcularFranja(DateTime.Now);
            }
            else
            {
                WriteLine("Tipo de llamada no registrado");
            }
            this.listaDeLlamadas.Add(llamada);
        }
        //While
        /* public void MostrarDetalleWhile()
        {
            int i = 0;
            while (i < this.listaDeLlamadas.Count)
            {
                WriteLine(this.listaDeLlamadas[i]);
                i++;
            }
        }
        public void MostrarDetalleDoWhile()
        {
            int i = 0;
            do
            {
                WriteLine(this.listaDeLlamadas[i]);
                i++;
            } while (this.listaDeLlamadas.Count > i);
        }
        public void MostrarDetalleFor()
        {
            for (int i = 0; i < this.listaDeLlamadas.Count; i++)
            {
                WriteLine(this.listaDeLlamadas[i]);
            }
        }
        public void MostrarDetalleForEach()
        {
            foreach (var llamada in listaDeLlamadas)
            {
                WriteLine(llamada);
            }
        }*/
        public void MostrarDetalle()
        {
            foreach (var llamada in listaDeLlamadas)
            {
                WriteLine(llamada);
            }
        }

        public void MostrarCostoLlamadaLocales()
        {
            double tiempoLlamada = 0;
            double costoTotal = 0.0;
            foreach (var elemento in listaDeLlamadas)
            {
                if (elemento.GetType() == typeof(LlamadaLocal))
                {
                    tiempoLlamada += elemento.Duracion;
                    costoTotal += elemento.calcularPrecio();
                }
            }
            WriteLine($"Costo minuto: {precioLocal}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamada}");
            WriteLine($"Costo total: {costoTotal}");
        }
        public void MostrarDetalleLlamadasDepto()
        {
            double tiempoLlamadaFranjaUno = 0;
            double tiempoLlamadaFranjaDos = 0;
            double tiempoLlamadaFranjaTres = 0;
            double costoTotalFranjaUno = 0;
            double costoTotalFranjaDos = 0;
            double costoTotalFranjaTres = 0;
            foreach (var elemento in listaDeLlamadas)
            {
                if (elemento.GetType() == typeof(LlamadaDepartamental))
                {
                    switch (((LlamadaDepartamental)elemento).Franja)
                    {
                        case 0:
                            tiempoLlamadaFranjaUno += elemento.Duracion;
                            costoTotalFranjaUno += elemento.calcularPrecio();
                            break;

                        case 1:
                            tiempoLlamadaFranjaDos += elemento.Duracion;
                            costoTotalFranjaDos += elemento.calcularPrecio();
                            break;

                        case 2:
                            tiempoLlamadaFranjaTres += elemento.Duracion;
                            costoTotalFranjaTres += elemento.calcularPrecio();
                            break;
                    }
                }
            }
            WriteLine("Franja: 1");
            WriteLine($"Costo minuto: {precioUnoDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaUno}");
            WriteLine($"costo total: {costoTotalFranjaUno}");

            WriteLine("Franja: 2");
            WriteLine($"Costo minuto: {precioDosDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaDos}");
            WriteLine($"Costo total: {costoTotalFranjaDos}");

            WriteLine("Franja: 3");
            WriteLine($"Costo minuto: {precioTresDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaTres}");
            WriteLine($"Costo total: {costoTotalFranjaTres}");
        }
        public int calcularFranja(DateTime fecha)
        {
            int resultado = -1;
            return resultado;
        }
    }
}
