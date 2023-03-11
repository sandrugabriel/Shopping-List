using Shopping_List.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_List.Controllers
{
    internal class ControllerLists
    {
        private List<List> lists;

        public ControllerLists()
        {

            lists = new List<List>();

            load();

        }

        public void load()
        {
            string path = Application.StartupPath + @"/data/shoppingLists.txt";
            StreamReader streamReader = new StreamReader(path);

            string text;

            while ((text = streamReader.ReadLine()) != null)
            {
                List list = new List(text);

                lists.Add(list);

            }

            streamReader.Close();
        }



        public int idByNume(string nume)
        {

            for (int i = 0; i < lists.Count; i++)
            {

                if (lists[i].getName().Equals(nume))
                {
                    return lists[i].getId();
                }

            }

            return -1;
        }

        public void getRecipes(List<List> recipes1)
        {

            for (int i = 0; i < lists.Count; i++)
            {

                List a = lists[i];
                recipes1.Add(a);
            }


        }










    }
}
