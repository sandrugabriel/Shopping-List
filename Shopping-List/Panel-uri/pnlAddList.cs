using Shopping_List.Controllers;
using Shopping_List.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_List.Panel_uri
{
    internal class pnlAddList:Panel
    {

        Label lblName;
        TextBox txtName;

        Label lblList;
        RichTextBox txtList;

        Button btnSave;

        Home form;

        ControllerLists controllerList;


        private int idClient;

        List<string> erori;

        public pnlAddList(int idClient1, Home form1)
        {
            controllerList = new ControllerLists();
            form = form1;
            idClient = idClient1;
            erori = new List<string>();
            this.Name = "pnlAddList";
            this.Size = new System.Drawing.Size(950, 507);
            this.Location = new System.Drawing.Point(6, 82);
            this.BackColor = System.Drawing.Color.MistyRose;

            Font font = new Font("Microsoft YaHei UI Light", 20);
            Font font1 = new Font("Microsoft YaHei UI Light", 14);

            //Name
            lblName = new Label();
            txtName = new TextBox();
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.lblName.Text = "Name store";
            this.lblName.Font = font;
            this.lblName.Location = new System.Drawing.Point(102, 79);
            this.lblName.AutoSize = true;
            this.txtName.Font = font1;
            this.txtName.Size = new System.Drawing.Size(198, 34);
            this.txtName.Location = new System.Drawing.Point(126, 130);



            //List
            lblList = new Label();
            txtList = new RichTextBox();
            this.Controls.Add(lblList);
            this.Controls.Add(txtList);
            this.lblList.Text = "Shopping List";
            this.lblList.Font = font;
            this.lblList.Location = new System.Drawing.Point(524, 79);
            this.lblList.AutoSize = true;
            this.txtList.Font = font1;
            this.txtList.Size = new System.Drawing.Size(378, 269);
            this.txtList.Location = new System.Drawing.Point(467, 130);

            //Save
            btnSave = new System.Windows.Forms.Button();
            this.Controls.Add(btnSave);
            this.btnSave.Location = new System.Drawing.Point(130, 350);
            this.btnSave.Text = "Save";
            this.btnSave.Font = font;
            this.btnSave.Size = new System.Drawing.Size(110, 55);
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Click += new EventHandler(btnSave_Click);

            this.form.button5.Visible = true;
        }

        private void errors()
        {

            erori.Clear();

            if (txtName.Text.Equals(""))
            {
                erori.Add("You have not entered the name store");
            }

            if (txtList.Text.Equals(""))
            {
                erori.Add("You have not entered the list");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            errors();

            if (erori.Count > 0)
            {
                for (int i = 0; i < erori.Count; i++)
                {
                    MessageBox.Show(erori[i], "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {


                this.form.button5.Visible = true;

                int id = controllerList.generareId();
                string name = txtName.Text;
                string list = txtList.Text;

                string textul = idClient.ToString() + ";" + id.ToString() + ";" + name + ";" + list;

                controllerList.save(textul);
                controllerList.load();
                List<List> lists = new List<List>();
                controllerList.getLists(lists);
                this.form.Controls.Add(new pnlCards(idClient, lists, form));
                this.form.removepnl("pnlAddList");

            }

        }








    }
}
