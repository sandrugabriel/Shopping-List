using Shopping_List.Controllers;
using Shopping_List.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_List.Panel_uri
{
    internal class pnlMyLists:Panel
    {


        List<List> lists = new List<List>();

        Label lblInfo;

        Home form;

        private int idClient;

        ControllerLists controllerLists;

        public pnlMyLists(int idClient1, List<List> list1, Home form1)
        {
            idClient = idClient1;
            controllerLists = new ControllerLists();

            this.Name = "pnlMyLists";
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Size = new System.Drawing.Size(1550, 800);
            this.Location = new System.Drawing.Point(5, 82);
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            lists = lists;
            controllerLists.getMyLists(lists, idClient);
           


            //Info
            this.lblInfo = new Label();
            this.Controls.Add(this.lblInfo);

            this.lblInfo.Text = "To change the data and delete a client, click on card";
            this.lblInfo.BackColor = System.Drawing.Color.Yellow;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10);

            this.form = form1;

            this.form.Resize += new EventHandler(form_Resize);

            createCard(3);

            controllerLists.load();

        }

        private void form_Resize(object sender, EventArgs e)
        {

            if(form.Width >= 1500)
            {
                createCard(2);
            }
            else if(form.Width <=1400)
            {
                createCard(3);
            }

            this.form.WindowState = FormWindowState.Maximized;
        }

        public void createCard(int nrCollums)
        {

            this.Controls.Clear();

            int x = 20, y = 43, ct = 0;

            foreach (List list in lists)
            {
                ct++;
                pnlCard pnlcard = new pnlCard(list, form);
                pnlcard.Location = new System.Drawing.Point(x, y);
                this.Controls.Add(pnlcard);
                pnlcard.Click += new EventHandler(pnlcard_Click);
                void pnlcard_Click(object sender, EventArgs e)
                {
                    string title = pnlcard.lblTitle1.Text;
                    int id = controllerLists.idByNume(title);
                    this.form.removepnl("pnlMyLists");
                    this.form.Controls.Add(new pnlUpdate(idClient, id, form));
                }
                x += 450;

                if (ct % nrCollums == 0)
                {
                    x = 20;
                    y += 330;
                }
                if (y > this.Height)
                {
                    this.AutoScroll = true;
                }
            }


        }






    }
}
