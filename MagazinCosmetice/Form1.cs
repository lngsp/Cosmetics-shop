/**************************************************************************
 *                                                                        *
 *  File:        Form1.cs                                                 *
 *  Copyright:   (c) 2022, Alexandra-Catalina Poleac                      *
 *  Description: Aplicatie pentru administrare magazin de cosmetice       *
 *                                                                        *
 *                                                                        *
 **************************************************************************/

using Management;
using Produse;
using ProxyUserAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazinCosmetice
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Clasa care implementeaza Form si are logica alicatiei grafice
        /// </summary>
        Proxy _useradmin;
        List<Panel> listPanel = new List<Panel>();
        private string _username;
        private string _password;
        private IManagement _management;
        private int _count = 0;

        /// <summary>
        /// Constructorul clasei
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            _useradmin = new Proxy();
            _management = new Produs();
        }


        /// <summary>
        /// Metoda care incarca interfata grafica
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(panelLogin);
            listPanel.Add(panel);
            listPanel.Add(panelAdmin);

            listPanel[0].BringToFront();
            PopulateComboBox();
        }

        /// <summary>
        /// Metoda care afiseaza lista cu produse din interfata
        /// </summary>
        private void PopulateComboBox()
        {
            string[] produse = _management.ListAll();
            comboBoxSterge.Items.Clear();
            comboBoxAdaugaCos.Items.Clear();
            for (int i = 0; i < _management.ListCount(); ++i)
            {
                comboBoxSterge.Items.Add(produse[i]);
                comboBoxAdaugaCos.Items.Add(produse[i]);

            }
            comboBoxAdaugaCos.SelectedIndex = 0;
            comboBoxSterge.SelectedIndex = 0;

        }

        /// <summary>
        /// Functionalitatea butonului de login
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            _username = textBoxUsername.Text;
            _password = textBoxPassword.Text;
            
            bool ok = _useradmin.Login(_username, _password);
            if (!ok)
            {
                MessageBox.Show("Login error! Verify username and password");
                return;
            }

            if (_username.Equals("admin"))
            {
                listPanel[2].BringToFront();
            }
            else
            {
                listPanel[1].BringToFront();
            }

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda care populeaza cosul de cumparaturi cu produsele selectate
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void buttonAdaugaCos_Click(object sender, EventArgs e)
        {
            string produs = (String)(comboBoxAdaugaCos.SelectedItem);
            textBoxCos.AppendText(String.Format(produs + System.Environment.NewLine));
            _count++;
            textBoxProduseCos.Text = "" + _count;
        }

        private void comboBoxAdaugaCos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda care goleste cosul de cumparaturi
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void buttonStergeProdus_Click(object sender, EventArgs e)
        {
            textBoxCos.Text = "";
            _count = 0;
            textBoxProduseCos.Text = "" + _count;
        }

        /// <summary>
        /// Metoda care deschide fereastra ajutatoare pentru client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelpClient_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Client.chm");
        }

        private void textBoxProduseCos_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdaugaProdusNou_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda care populeaza lista de produse cu unele noi
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void buttonAdaugaProdusNou_Click(object sender, EventArgs e)
        {
            string produsNou = textBoxAdaugaProdusNou.Text;
            if (produsNou.Equals(""))
            {
                MessageBox.Show("Enter a product!");
                return;
            }
            _management.AddProdus(produsNou);
            PopulateComboBox();
            textBoxAdaugaProdusNou.Text = "";
        }

        private void comboBoxSterge_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda care sterge un produs din lista 
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void buttonSterge_Click(object sender, EventArgs e)
        {
            string produsDeSters = (String)comboBoxSterge.SelectedItem;
            _management.DeleteProdus(produsDeSters);
            PopulateComboBox();
        }

        /// <summary>
        /// Metoda care deschide fereastra ajutatoare pentru admin
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void buttonHelpAdmin_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Admin.chm");
        }

        /// <summary>
        /// Metoda pentru logout din contul de admin
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void buttonIesireContAdmin_Click(object sender, EventArgs e)
        {
            listPanel[0].BringToFront();
            textBoxPassword.Text = "";
            textBoxUsername.Text = "";
        }

        /// <summary>
        /// Metoda pentru logout din contul de client
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void buttonIesireContClient_Click(object sender, EventArgs e)
        {
            listPanel[0].BringToFront();
            textBoxPassword.Text = "";
            textBoxUsername.Text = "";
            if (textBoxProduseCos.Text.Equals(""))
            {
                listPanel[0].BringToFront();

            }
            else
            {
                MessageBox.Show("Be careful you have products in the cart!");
                return;
            }
        }

        /// <summary>
        /// Metoda care plaseaza comanda din cosul de cumparaturi
        /// </summary>
        /// <param name="sender">Referinta catre eveniment</param>
        /// <param name="e">Instanta unui eveniment</param>
        private void buttonPlaseazaComanda_Click(object sender, EventArgs e)
        {
            if (textBoxCos.Text.Equals(""))
            {
                MessageBox.Show("Your cart is empty! Please add products!");
            }
            else
            {
                MessageBox.Show("Your order has been successfully processed! Thank you! ");
                Close();
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
