using System;

namespace DZ12
{
    /// <summary>
    /// сам товар
    /// </summary>
    internal class Item
    {
        private int _id = 0;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
         
        private string _name = "";
        public string Name 
        {
            get 
            { 
                return _name;
            }
            set
            {
                _name = value;
            } 
        }
        public Item()
        { }

        public Item(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
