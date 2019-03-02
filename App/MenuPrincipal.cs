using System;
using static System.Console;
namespace CentralTelefonica.App
{
    public class MenuPrincipal
    {
         public void mostrarMenu()
         {
             WriteLine("1. Registrar llamada local");
             WriteLine("2. Registrar llamada departamental");
             WriteLine("3. Costo total de las llamadas locales");
             WriteLine("4. Costo total de las llamadas departamentales");
             WriteLine("5. Costo total de las llamadas");
         }   
    }
}