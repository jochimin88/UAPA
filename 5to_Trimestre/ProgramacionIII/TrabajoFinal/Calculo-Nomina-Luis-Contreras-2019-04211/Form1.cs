using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculo_Nomina_Luis_Contreras_2019_04211
{

    public partial class Form1 : Form
    {
        public object OwningWindowSettings { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Luis Contreras - Matricula 2019-04211
            // Esto es para que los valores se carguen automaticamente 
            float vafp = 0.0287f;
            afp.Text = vafp.ToString();
            float vars = 0.0304f;
            ars.Text = vars.ToString();
            float saltope = 33384.00f;
            salariotope.Text = saltope.ToString();
            float visr = 0.15f;
            isr.Text = visr.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Aplicamos controles de validacion

            // Me da un error cuando un valor se deja vacio e intentar volver al campo

            /*
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Por favor introducir CODIGO DE EMPLEADO!");
            }
            else if (txtNombre.Text == "")
            {
                MessageBox.Show("Por favor introducir NOMBRE DEL EMPLEADO!");
            }
            else if (txthoras.Text == "")
            {
                MessageBox.Show("Por favor introducir TOTAL HORAS TRABAJADAS!");
            }
            else if (txtpreciohoras.Text == "")
            {
                MessageBox.Show("Por favor introducir PRECIO X HORAS TRABAJADAS!");
            }
            else if (txtextras.Text == "")
            {
                MessageBox.Show("Por favor introducir TOTAL HORAS EXTRAS!");
            }
            else if (txtprecioextras.Text == "")
            {
                MessageBox.Show("Por favor introducir PRECIO X HORAS EXTRAS!");
            }
            else
            {
                MessageBox.Show("GRACIAS POR COMPLETAR LOS CAMPOS REQUERIDOS");
            }
            */

            // Aqui llevamos los valores a los textbox que estan deshabilitado para ser editados
                       
            rcodigo.Text = txtCodigo.Text;
            rnombre.Text = txtNombre.Text;
            rhoras.Text = txthoras.Text;
            rpreciohoras.Text = txtpreciohoras.Text;
            rextras.Text = txtextras.Text;
            rprecioextras.Text = txtprecioextras.Text;

            // Determinamos el Salario Mensual

           resSalario.Text = ((Convert.ToInt32(rhoras.Text) * Convert.ToInt32(rpreciohoras.Text))+ (Convert.ToInt32(rextras.Text) * Convert.ToInt32(rprecioextras.Text))).ToString();

         




            // Aplicamos descuentos de AFP y ARS

            float vafp = 0.0287f;
            float vars = 0.0304f;
            
            float desc_afp = (float.Parse(resSalario.Text) * vafp);
            resAFP.Text = desc_afp.ToString();
            float desc_ars = (float.Parse(resSalario.Text) * vars);
            resARS.Text = desc_ars.ToString();

            float desc_isr;




            // Condicion para calcular si el salario mensual aplica para el descuento de impuesto sobre la renta ISR
                       

            if(float.Parse(resSalario.Text) > float.Parse(salariotope.Text))
            {
                // float  desc_isr = ((Convert.ToString(resSalario.Text) - Convert.ToString(salariotope.Text)) * Convert.ToString(isr.Text));

               desc_isr = ((float.Parse(resSalario.Text) - float.Parse(salariotope.Text)) * float.Parse(isr.Text));

                resISR.Text = desc_isr.ToString();
                
            } else
            {
                desc_isr = 0;
            }


            // Sumamos todos los descuentos 

            float total_descuentos = desc_afp + desc_ars + desc_isr;
            resDescuentos.Text = total_descuentos.ToString();
            float sueldo_neto = (float.Parse(resSalario.Text)-total_descuentos);
            resSalarioNeto.Text = sueldo_neto.ToString();


           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Limpiamos los campos

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txthoras.Text = "";
            txtpreciohoras.Text = "";
            txtextras.Text = "";
            txtprecioextras.Text = "";
            rcodigo.Text = "";
            rnombre.Text = "";
            rhoras.Text = "";
            rpreciohoras.Text = "";
            rextras.Text = "";
            rprecioextras.Text = "";
            resSalario.Text = "";
            resAFP.Text = "";
            resARS.Text = "";
            resISR.Text = "";
            resDescuentos.Text = "";
            resSalarioNeto.Text = "";
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            // Este es un control para que ponga en mayusculas automaticamente el campo del nombre
            txtNombre.CharacterCasing = CharacterCasing.Upper;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta tarea fue realizada por Luis Contreras - Matricula 2019-04211";
            string titulo = "Ayuda";
            MessageBox.Show(mensaje, titulo);
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "Este tarea fue realizada por Luis Contreras - Matricula 2019-04211";
            string titulo = "Ayuda";
            MessageBox.Show(mensaje, titulo);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            // A cada textbox le pasamos un control para utilizar el enter como tab, es decir, si presionamos enter pasará al proximo campo

            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void txthoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void txtpreciohoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void txtextras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }
    }
}
