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

        public pnlCards(List<List> lists1, Home form1)
        {
            controllerLists = new ControllerLists();

            this.Name = "pnlCards";
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Size = new System.Drawing.Size(1550,800);
            this.Location = new System.Drawing.Point(230, 82);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.AutoScroll = true;
    
            this.form = form1;
            lists = lists1;

            this.form.Resize += new EventHandler(form_Resize);

            createCard(2);



        }

        private void form_Resize(object sender, EventArgs e)
        {
            
            if(form.Width >= 1500)
            {
                createCard(3);
            }
            else
            {

                createCard(2);
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
