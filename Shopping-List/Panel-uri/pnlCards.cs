using Shopping_List.Controllers;
using Shopping_List.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Shopping_List.Panel_uri
{
    internal class pnlCards:Panel
    {

        List<List> lists = new List<List>();

        Home form;

        ControllerLists controllerLists;

        private int idClient;

        public pnlCards(int idClient1, List<List> lists1, Home form1)
        {
            idClient = idClient1;
            controllerLists = new ControllerLists();

            this.Name = "pnlCards";
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Size = new System.Drawing.Size(1265, 566);
            this.Location = new System.Drawing.Point(5, 82);

            lists = lists1;

            createCard(2);

            this.form = form1;


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
