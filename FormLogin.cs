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
    public partial class FormLogin : Form
    {
        string pathCd = "credenciais.txt";
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            Form1.login = false;
            string user = textBoxUser.Text;
            string pass = textBoxPass.Text;
            if (user == "mini" && pass == "mini")
                Form1.login = true;
            else
                VerificarLogin(user, pass);
            this.Close();
        }

        private bool VerificarLogin(string us, string ps)
        {
            if(File.Exists(pathCd))
            {
                string[] users = File.ReadAllLines(pathCd);
                foreach (string s in users)
                {
                    string[] dataUser = s.Split(':');
                    if (us == dataUser[0] && ps == dataUser[1])
                        return true;
                }
                                    
            }
            MessageBox.Show("Seja bemvindo !!" + us);
            return false;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Form1.login = false;
            this.Close();
        }

        private void linkLabelMostrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(linkLabelMostrar.Text=="Mostrar")
            {
                textBoxPass.UseSystemPasswordChar = false;
                linkLabelMostrar.Text = "Ocultar";
            }
            else
            {
                textBoxPass.UseSystemPasswordChar = true;
                linkLabelMostrar.Text = "Mostrar";
            }
        }
    }
}
