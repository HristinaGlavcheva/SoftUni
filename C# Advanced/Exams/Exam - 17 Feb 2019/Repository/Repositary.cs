using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private int id;
        private Dictionary<int, Person> data;

        public Repository()
        {
            this.id = 0;
            this.data = new Dictionary<int, Person>();
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Person person)
        {
            this.data.Add(id++, person);
        }

        public Person Get(int id)
        {
            return this.data[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (!this.ValidateId(id))
            {
                return false;
            }

            this.data[id] = newPerson;

            return true;
        }

        public bool Delete(int id)
        {
            if (!this.ValidateId(id)) 
            {
                return false;
            }

            this.data.Remove(id);

            return true;
        }

        public bool ValidateId(int id)
        {
            if (!this.data.ContainsKey(id))
            {
                return false;
            }

            return true;
        }
    }
}
