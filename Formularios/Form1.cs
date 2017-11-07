using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria;

namespace Formularios
{
    public partial class Form1 : Form
    {
        static void Manejador()
        {
            MessageBox.Show("En el manejador");
        }

        public void Manejador2(Empleado emp)
        {
            MessageBox.Show("El empleado posee un sueldo fuera de los parámetros preestablecidos.");
        }

        public void Manejador3(Empleado emp, double value)
        {
            MessageBox.Show("Intento de asignacion de sueldo: " + value);
        }

        public void Manejador4(Object emp, EventArgs e)
        {
            MessageBox.Show(((Empleado)emp).ToString() + ((EmpleadoEventArgs)e).sueldo.ToString());
        }

        public void ManejadorGenerico(Object obj, EventArgs e)
        {
            if (obj is TextBox)
            {
                ((TextBox)obj).ForeColor = Color.AliceBlue;
                ((TextBox)obj).Size = new Size(new Point(100,50));
                ((TextBox)obj).Font = new Font("Comic Sans", 12);
            }
            else if (obj is Button)
            {
                ((Button)obj).Location = new Point(0, 0);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado();
            //Empleado emp = new Empleado(this.textBox1.Text, this.textBox2.Text, double.Parse(this.textBox3.Text));
            emp.LimiteSueldo += new DelEmp(Form1.Manejador);
            emp.LimiteSueldo2 += new LimiteSueldoEmp(this.Manejador2);
            emp.LimiteSueldo3 += new FueraLimite(this.Manejador3);
            emp.LimiteSueldo4 += new FueraLimiteEvento(this.Manejador4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                item.Click += new EventHandler(ManejadorGenerico);
            }
        }
    }
}