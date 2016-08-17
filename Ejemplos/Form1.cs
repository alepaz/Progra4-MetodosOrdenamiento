using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplos
{
    public partial class Form1 : Form
    {
        //Bandera publica si todos los datos estan correctos
        private bool bandera = true;
        private int Num1;
        private int contador = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bandera = true;

            //Validamos y obtenemos los valores
            Num1 = obtener_valor(txtNum);

            if (bandera)
            {
                lbxInput.Items.Add(Num1);

            }

            limpiar_input();

            txtNum.Focus();
        }

        public void limpiar_input()
        { //Para limpiar el textbox llamado "Pantalla"

            txtNum.Text = "";

        }

        public int obtener_valor(TextBox t1)
        { //Para transformar lo que se digite en el textbox a formato
            //numerico
            int valor = 0;

            //Si el control esta vacio
            if (t1.Text.Length > 0)
            {
                //Si el control tiene caracteres
                if (int.TryParse(t1.Text, out valor))
                {
                    
                        valor = Convert.ToInt16(t1.Text);
                }
                else
                {
                    bandera = false;
                    MessageBox.Show("El valor debe ser numerico");
                }

            }
            else
            {
                bandera = false;
                MessageBox.Show("El control se encuentra vacio");
            }

            return valor;

        }

        public static void QuickSort(int[] nums, int left, int right)
        {
            int i = left, j = right;
            int pivot = nums[(left + right) / 2];

            while (i <= j)
            {
                while (nums[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (nums[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    //Cambio o swap informatico
                    int tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;

                    i++;
                    j--;
                }
            }
            //Llamadas recursivas
            if (left < j)
            {
                QuickSort(nums, left, j);
            }

            if (i < right)
            {
                QuickSort(nums, i, right);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbxInput.Items.Clear();
            lbxOutput.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbxOutput.Items.Clear();
            contador = lbxInput.Items.Count;
            MessageBox.Show(contador.ToString());
            int i;
            int[]  arreglo = new int[contador];

            for (i = 0; i < contador; i++) {

                arreglo[i] = int.Parse(lbxInput.Items[i].ToString());

            }

            ShellSort(arreglo);

            for (i = 0; i < contador; i++) {
                lbxOutput.Items.Add(arreglo[i]);
            }
        }

        static void ShellSort(int[] array)
        {
            int i, j, increment;
            int temp;

            increment = array.Length / 2;
            while (increment > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    temp = array[i];
                    while ((j >= increment) && (array[j - increment].CompareTo(temp) > 0))
                    {
                        array[j] = array[j - increment];
                        j = j - increment;
                    }
                    array[j] = temp;
                }
                if (increment == 2)
                    increment = 1;
                else
                    increment = increment * 5 / 11;

            }
            Console.WriteLine("Arreglo Ordenado");
            for (i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
        }
    }
}
