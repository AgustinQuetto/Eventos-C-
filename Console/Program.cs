using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria;

namespace Main
{
    class Program
    {
        static void Manejador()
        {
            Console.WriteLine("Estoy en el manejador");
        }

        public void Manejador2(Empleado emp)
        {
            Console.WriteLine("El empleado posee un sueldo fuera de los parámetros preestablecidos.");
        }

        public void Manejador3(Empleado emp, double value) {
            Console.WriteLine(emp.ToString() + " | Intento de asignacion de sueldo: "+ value);
        }

        static void Main(string[] args)
        {
            try
            {
                Empleado empleado = new Empleado();
                Program prog = new Program();
                empleado.LimiteSueldo += new DelEmp(Program.Manejador);
                empleado.LimiteSueldo2 += new LimiteSueldoEmp(prog.Manejador2);
                empleado.LimiteSueldo3 += new FueraLimite(prog.Manejador3);
                empleado.Nombre = "Agustin";
                empleado.Apellido = "Quetto";
                empleado.Sueldo = 10000;


            }
            catch (Exception)
            {

                throw new Exception();
            }

            Console.ReadLine();
        }
    }
}
