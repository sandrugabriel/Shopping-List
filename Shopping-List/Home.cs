using Shopping_List.Controllers;
using Shopping_List.Models;
using Shopping_List.Panel_uri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_List
{
    public partial class Home : Form
    {
        private int id;

        ControllerClients controllerClients;
        ControllerLists controllerLists;
        List<List> lists;

        public Home(int id1)
        {
            InitializeComponent();
            InitializeComponent();
            id = id1;
            controllerClients = new ControllerClients();
            controllerLists = new ControllerLists();
            controllerClients.load();
            string name = controllerClients.numeById(id);

            label2.Text = controllerClients.numeById(id);

            lists = new List<List>();
            controllerLists.getLists(lists);

            this.Controls.Add(new pnlCards(id, lists, this));
            this.button3.Visible = false;
        }

        public void removepnl(string pnl)
        {

            Control control = null;

            foreach (Control c in this.Controls)
            {
                if (c.Name.Equals(pnl))
                {
                    control = c;
                }

            }

            this.Controls.Remove(control);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Controls.Add(new pnlAddList(id, this));
            this.removepnl("pnlCards");
            this.button5.Visible = false;
        }
    }
}
