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
    internal class pnlCard:Panel
    {



        Label lblTitle;
        public Label lblTitle1;

        List list;
        Home form;

        RichTextBox shopping;

        private int id;

        public pnlCard(List list1, Home form1)
        {
            this.form = form1;
            this.Name = "pnlCard";
            this.Size = new System.Drawing.Size(433, 306);
            this.Location = new System.Drawing.Point(53, 43);
            this.BackColor = System.Drawing.Color.White;

            list = list1;

            Font font = new Font("Microsoft YaHei UI Light", 13);
            Font font1 = new Font("Microsoft YaHei UI Light", 12);

            //Title
            lblTitle = new Label();
            lblTitle1 = new Label();
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTitle1);
            this.lblTitle.Name = "lbltitle";
            this.lblTitle1.Name = "lblTitle1";

            this.lblTitle.Location = new System.Drawing.Point(112, 30);
            this.lblTitle1.Location = new System.Drawing.Point(155, 80);
            this.lblTitle.AutoSize = true;
            this.lblTitle1.AutoSize = true;
            this.lblTitle.Font = font;
            this.lblTitle1.Font = font1;
            this.lblTitle.Text = "Name Store";
            this.lblTitle1.Text = list.getName();

            //List
            shopping = new RichTextBox();
            this.Controls.Add(shopping);

            this.shopping.Location = new System.Drawing.Point(25, 154);
            this.shopping.Size = new System.Drawing.Size(341, 100);
            this.shopping.Font = font;
            this.shopping.Text = list.getList();
            this.shopping.ReadOnly = true;


            id = list1.getId();

        }

        public int getid()
        {

            return id;

        }





    }
}
