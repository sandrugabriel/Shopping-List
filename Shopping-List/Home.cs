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
            id = id1;
            controllerClients = new ControllerClients();
            controllerLists = new ControllerLists();
            controllerClients.load();

            string name = controllerClients.numeById(id);
           MessageBox.Show(name);

            this.lblNume.Text = name;

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
            lists.Clear();
            controllerLists.getLists(lists);

            this.Controls.Add(new pnlCards(id, lists, this));
            this.removepnl("pnlAddList");
            this.removepnl("pnlMyLists");
            this.removepnl("pnlUpdate");
            this.button5.Visible = true;
            this.button3.Visible = false;
            this.button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lists.Clear();
            this.button4.Visible = false;
            this.button3.Visible = true;
            this.button5.Visible = true;
            this.removepnl("pnlCards");
            this.removepnl("pnlAddList");
            controllerLists.getMyLists(lists, id);
            this.Controls.Add(new pnlMyLists(id, lists, this));
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Controls.Add(new pnlAddList(id, this));
            this.removepnl("pnlCards");
            this.removepnl("pnlMyLists");
            this.button5.Visible = false;
            this.button3.Visible = true;
            this.button4.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
