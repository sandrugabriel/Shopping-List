using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Shopping_List.Models
{
    internal class List
    {

        private string nameStore;
        private int id;
        private int idClient;
        private string list;

        public List(int idClient, int id, string name, string list)
        {

            this.idClient = idClient;
            this.id = id;
            this.nameStore = name;
            this.list = list;

        }

        public List(string text)
        {

            string[] prop = text.Split(';');

            this.idClient = int.Parse(prop[0]);
            this.id = int.Parse(prop[1]);
            this.nameStore = prop[2];
            this.list = prop[3];

        }


        public int getIdClient()
        {
            return idClient;
        }

        public int getId()
        {
            return id;
        }

        public string getName()
        {
            return nameStore;
        }

        public void setName(string name)
        {
            this.nameStore = name;
        }

        public string getList()
        {
            return list;
        }

        public void setList(string list)
        {
            this.list = list;
        }

        public string toSave()
        {
            return idClient.ToString() + ";" + id.ToString() + ";" + nameStore + ";" + list;
        }


    }
}
