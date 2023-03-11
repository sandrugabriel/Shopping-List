﻿using Shopping_List.Controllers;
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
            this.Size = new System.Drawing.Size(1265, 566);
            this.Location = new System.Drawing.Point(5, 82);
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;

            lists = lists;
            controllerLists.getMyLists(lists, idClient);
            createCard(2);


            //Info
            this.lblInfo = new Label();
            this.Controls.Add(this.lblInfo);

            this.lblInfo.Text = "To change the data and delete a client, click on card";
            this.lblInfo.BackColor = System.Drawing.Color.Yellow;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10);

            this.form = form1;

            controllerLists.load();

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