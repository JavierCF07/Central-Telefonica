using System;
namespace CentralTelefonica.Until
{
    public class MenuException : Exception
    {        
        private string message = "Error, debe ingresar un número";
        public override string Message
        {
            get { return message;}
        }
        
    }
}