using System;
using static System.Console;
using System.Collections.Generic;
using CentralTelefonica.Entidades;

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
            int opcion = 0;
            do
            {
                WriteLine("1. Registrar llamada local");
                WriteLine("2. Registrar llamada departamental");
                WriteLine("3. Costo total de las llamadas locales");
                WriteLine("4. Costo total de las llamadas departamentales");
                WriteLine("5. Costo total de las llamadas");
                WriteLine("6. Mostrar detalle de llamadas");
                WriteLine("0. Salir");
                WriteLine("Ingrese su opción: ");
                string valor = ReadLine();
                opcion = Convert.ToInt32(valor);
                if (opcion == 1)
                {
                    RegistrarLlamada(opcion);
                }
                else if (opcion == 2)
                {
                    RegistrarLlamada(opcion);
                }
                else if (opcion == 6)
                {
                    MostrarDetalleForEach();
                    ReadKey();
                }
            } while (opcion != 0);
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
                llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion = duracion;
                ((LlamadaLocal)llamada).Precio = precioLocal;
            }
            else if (opcion == 2)
            {
                llamada = new LlamadaDepartamental();
                llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion = duracion;
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = 0;
            }
            else
            {
                WriteLine("Tipo de llamada no registrado");
            }
            this.listaDeLlamadas.Add(llamada);
        }
        //While
        public void MostrarDetalleWhile()
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
        }
    }
}
