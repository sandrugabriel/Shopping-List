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
    internal class pnlFilters:Panel
    {
        Label lblFilter;

        Label lblSearch;
        TextBox txtSearch;

        Button btnSearch;
        Button btnClear;

        ControllerLists controllerLists;

        Home form;

        List<List> lists2;

        public pnlFilters(Home form1, List<List> lists1)
        {

            controllerLists = new ControllerLists();

            form = form1;
            lists2 = new List<List>();
            lists2 = lists1;

            this.Name = "pnlFilters";
            this.Size = new System.Drawing.Size(225, 800);
            this.Location = new System.Drawing.Point(3, 82);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;

            lblFilter = new Label();
            this.Controls.Add(lblFilter);

            Font font = new Font("Microsoft YaHei UI Light", 20);

            //lblFilters
            this.lblFilter.Location = new System.Drawing.Point(12,17);
            this.lblFilter.AutoSize = true;
            this.lblFilter.Text = "Filters";
            this.lblFilter.Font = font;

            //lblSearch
            lblSearch = new Label();
            this.Controls.Add(lblSearch);
            txtSearch = new TextBox();
            this.Controls.Add(txtSearch);

            lblSearch.Location = new System.Drawing.Point(20, 69);
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Microsoft YaHei UI Light", 17);
            this.lblSearch.Text = "Search";

            txtSearch.Location = new System.Drawing.Point(20,110);
            this.txtSearch.Size = new System.Drawing.Size(159, 38);
            this.txtSearch.Font = new Font("Microsoft YaHei UI Light", 15);

            //BtnFilters
            btnSearch = new Button();
            this.Controls.Add(btnSearch);

            btnSearch.Location = new System.Drawing.Point(32, 377);
            this.btnSearch.Size = new System.Drawing.Size(138, 53);
            this.btnSearch.Font = new Font("Microsoft YaHei UI Light", 17);
            this.btnSearch.Text = "Filter";
            this.btnSearch.Click += new EventHandler(btnSearch_Click);

            //BtnClear
            btnClear = new Button();
            this.Controls.Add(btnClear);

            btnClear.Location = new System.Drawing.Point(32, 300);
            this.btnClear.Size = new System.Drawing.Size(138, 53);
            this.btnClear.Font = new Font("Microsoft YaHei UI Light", 17);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new EventHandler(btnClear_Click);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            this.form.removepnl("pnlCards");
            this.form.Controls.Add(new pnlCards(lists2, form));


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            List<List> lists = new List<List>();

            string cuv = txtSearch.Text;
            int dim = cuv.Length;

            controllerLists.getListFilter(lists, cuv, dim);
            this.form.removepnl("pnlCards");
            this.form.Controls.Add(new pnlCards(lists, form));


        }






    }
}
