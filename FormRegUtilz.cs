using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace mini
{
    public partial class FormRegUtilz : Form
    {
        string pathCd = "Credenciais.txt";

        public FormRegUtilz()
        {
            InitializeComponent();
        }

        private void buttonRegistar_Click(object sender, EventArgs e)
        {

            if (textBoxUser.Text != "" && textBoxPass.Text != "")
            {
                if (textBoxPass.Text == textBoxRepPass.Text)
                {

                    if (!UtilizadorJaExiste(textBoxUser.Text))
                        RegistarUtilizador();
                    else
                    {
                        MessageBox.Show("Utilizador já existente!Insira novos dados");
                        textBoxUser.Text = "";
                        textBoxPass.Text = "";
                        textBoxRepPass.Text = "";
                        textBoxUser.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("As passwords não coincidem!!");
                    textBoxPass.Text = "";
                    textBoxRepPass.Text = "";
                    textBoxPass.Focus();
                }
            }


        }
        private bool UtilizadorJaExiste(string user)
        {
            if (File.Exists(pathCd))
            {
                try
                {
                    string[] dadosUsers = File.ReadAllLines(pathCd);
                    foreach (string linha in dadosUsers)
                    {
                        string[] dadosUsr = linha.Split(":");
                        if (user == dadosUsr[0]) return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            return false;
        }

        private void RegistarUtilizador()
        {
            try
            {
                string texto = "\n" + textBoxUser.Text + ":" + textBoxPass.Text;
                File.AppendAllText(pathCd, texto);
                MessageBox.Show("Novo utilizador registado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
