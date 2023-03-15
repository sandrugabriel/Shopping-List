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
    internal class pnlUpdate:Panel
    {


        Label lblName;
        TextBox txtName;

        Label lblList;
        RichTextBox txtList;

        Button btnUpdate;
        Button btnDelete;

        Home form;

        ControllerLists controllerList;


        private int idClient;
        private int id;

        List<List> list;

        public pnlUpdate(int idClient1, int id1, Home form1)
        {
            controllerList = new ControllerLists();
            form = form1;
            idClient = idClient1;
            id = id1;
            list = new List<List>();
            this.Name = "pnlUpdate";
            this.Size = new System.Drawing.Size(1500,800);
            this.Location = new System.Drawing.Point(6, 82);
            this.BackColor = System.Drawing.Color.MistyRose;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

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

            this.txtName.Text = controllerList.nameById(id);
            this.txtList.Text = controllerList.listById(id);

            //Update
            btnUpdate = new System.Windows.Forms.Button();
            this.Controls.Add(btnUpdate);
            this.btnUpdate.Location = new System.Drawing.Point(210, 350);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Font = font;
            this.btnUpdate.Size = new System.Drawing.Size(125, 60);
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);

            //Delete
            btnDelete = new System.Windows.Forms.Button();
            this.Controls.Add(btnDelete);
            this.btnDelete.Location = new System.Drawing.Point(60, 350);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Font = font;
            this.btnDelete.Size = new System.Drawing.Size(125, 60);
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Click += new EventHandler(btnDelete_Click);

            this.form.button5.Visible = true;


            list = new List<List>();
            controllerList.getLists(list);

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            controllerList.deleteList(id);
            this.form.removepnl("pnlUpdate");
            controllerList.getLists(list);
            this.form.Controls.Add(new pnlCards(list, form));


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            controllerList.setNume(id, txtName.Text);
            controllerList.setList(id, txtList.Text);
            controllerList.save();


            this.form.button5.Visible = true;

            this.form.removepnl("pnlUpdate");
            this.form.Controls.Add(new pnlCards(list, form));
            this.form.button4.Visible = true;


        }


    }
}
