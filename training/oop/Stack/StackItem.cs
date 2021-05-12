using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class StackItem : Stack
    {
        //attr
        private int _itemID;
        private DateTime _created;

        private static int _idCounter;


        //props
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }


        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }


        //ctors

        //public StackItem()
        //{
        //    _itemID = _idCounter;
        //    _idCounter++;
        //}

        public StackItem()
        {
            _itemID = _idCounter;
            _idCounter++;
            _created = DateTime.Now;
        }


        //methods
        public override string ToString()
        {
            return $"Item ID: {_itemID}\n\nCreated: {_created}";

        }
    }
}
