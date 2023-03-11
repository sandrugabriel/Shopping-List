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

        public void getMyLists(List<List> list1, int idClient)
        {

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].getIdClient() == idClient)
                {

                    List a = lists[i];
                    list1.Add(a);
                }

            }


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

        public void getLists(List<List> recipes1)
        {

            for (int i = 0; i < lists.Count; i++)
            {

                List a = lists[i];
                recipes1.Add(a);
            }


        }



        public List getListById(int id)
        {

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].getId() == id)
                {
                    return lists[i];
                }
            }

            return null;
        }

        public int generareId()
        {
            Random random = new Random();

            int id = random.Next();
            while (this.getListById(id) != null)
            {

                id = random.Next();

            }


            return id;

        }

        public void save(string textul)
        {

            string text = textul;
            string path = Application.StartupPath + @"/data/shoppingLists.txt";
            File.AppendAllText(path, text + "\n");


        }

        public string nameById(int id)
        {

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].getId() == id)
                {
                    return (lists[i].getName());
                }
            }

            return null;
        }

        public string listById(int id)
        {

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].getId() == id)
                {
                    return (lists[i].getList());
                }
            }

            return null;
        }

        public string toSaveFisier()
        {

            string t = "";

            for (int i = 0; i < lists.Count; i++)
            {
                t += lists[i].toSave() + "\n";
            }

            return t;
        }

        public void save()
        {
            String path = Application.StartupPath + @"/data/shoppingLists.txt";
            StreamWriter streamWriter = new StreamWriter(path);

            streamWriter.Write(this.toSaveFisier());

            streamWriter.Close();
        }



        public void setNume(int id, string nume)
        {

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].getId() == id)
                {
                    lists[i].setName(nume);
                }
            }


        }


        public void setList(int id, string list)
        {

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].getId() == id)
                {
                    lists[i].setList(list);
                }
            }


        }


        public int pozID(int id)
        {

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].getId() == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public void stergere(int id)
        {
            int p = pozID(id);
            if (p == pozID(id))
                lists.RemoveAt(p);

        }

        public void deleteList(int id)
        {
            this.stergere(id);

            string path = Application.StartupPath + @"/data/shoppingLists.txt";
            StreamWriter stream = new StreamWriter(path);

            stream.Write(this.toSaveFisier());

            stream.Close();
        }




    }
}
