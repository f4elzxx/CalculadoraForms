using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        int n1;
        string ultimoOp;
        bool ApertouOp = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            TxbTela.Clear();
            TxbAux.Text = "";

        }
        private void Operador_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            try
            {
                //Obter o botao q esta chamando o evento 
                if (ApertouOp == false && TxbTela.Text != "" && TxbAux.Text == "")
                {
                    n1 = int.Parse(TxbTela.Text);
                    TxbTela.Clear();
                    TxbAux.Text = n1.ToString() + botao.Text;
                    ultimoOp = botao.Text;
                    ApertouOp = true;
                }
                else if (TxbAux.Text != "")
                {
                    BtnIgual.PerformClick();
                    TxbAux.Text = TxbTela.Text + botao.Text;
                    n1 = int.Parse(TxbTela.Text);
                    TxbTela.Text = "";
                    ultimoOp = botao.Text;
                }



            }
            catch
            {

            }

        }
        private void Numero_Click(object sender, EventArgs e)
        {

            //Obter o botao q esta chamando o evento 
            var botao = (Button)sender;
            TxbTela.Text += botao.Text;
            ApertouOp = false;

        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {

            if (TxbTela.Text != "")
            {
                

          
                switch (ultimoOp)
            {
                case "+":
                    TxbAux.Clear();
                    TxbTela.Text = (n1 + decimal.Parse(TxbTela.Text)).ToString();
                    TxbAux.Text = "";
            

                        break;

                case "-":
                    TxbAux.Clear();
                    TxbTela.Text = (n1 - decimal.Parse(TxbTela.Text)).ToString();
                    TxbAux.Text = "";
                        break;

                case "x":
                    TxbAux.Clear();
                    TxbTela.Text = (n1 * decimal.Parse(TxbTela.Text)).ToString();
                    TxbAux.Text = "";
                        break;

                case "÷":

                    if (int.Parse(TxbTela.Text) == 0)
                    {


                        TxbTela.Text = "*ERRO*";
                    }

                    else
                    {
                        TxbAux.Clear();
                        TxbTela.Text = (n1 / decimal.Parse(TxbTela.Text)).ToString();
                        TxbAux.Text = "";

                        }
                    break;
            }

            }
            else
            {
                MessageBox.Show("Coloque um número válido");
            }

        }

    }
}





