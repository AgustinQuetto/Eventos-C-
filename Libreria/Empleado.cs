using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public delegate void DelEmp();
    public delegate void LimiteSueldoEmp(Empleado emp);
    public delegate void FueraLimite(Empleado emp, double value);
    public delegate void FueraLimiteEvento(Object obj, EventArgs e);

    public class EmpleadoEventArgs : EventArgs {
        public double sueldo;

        public EmpleadoEventArgs(double sueldo) {
            this.sueldo = sueldo;
        }
    }

    public class Empleado
    {
        private string _nombre;
        private string _apellido;
        private double _sueldo;
        public event DelEmp LimiteSueldo;
        public event LimiteSueldoEmp LimiteSueldo2;
        public event FueraLimite LimiteSueldo3;
        public event FueraLimiteEvento LimiteSueldo4;
        public EmpleadoEventArgs empE;


        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = value;
            }
        }

        public double Sueldo
        {
            get
            {
                return this._sueldo;
            }
            set
            {
                if (value > 0 && value < 9500)
                {
                    this._sueldo = value;
                }
                else if(value > 9500)
                {
                    this.LimiteSueldo();
                    this.LimiteSueldo2(this);
                    this.LimiteSueldo3(this, value);
                    empE = new EmpleadoEventArgs(value);
                    this.LimiteSueldo4(this, empE);
                }else{
                    throw new Exception();
                }
            }
        }

        /*public Empleado(string nombre, string apellido, double sueldo) {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Sueldo = sueldo;
        }*/

        public override string ToString()
        {
            return this.Apellido + " | " + this.Nombre + " | " + this.Sueldo;
        }

        
    }
}
