using System;
using System.Collections.Generic;
using System.Text;

namespace oop2
{
    public partial class BoolVector
    {
        public override string ToString()
        {
            return "Vector: " + "ID" + ID + "Name: " + name + "lenght: " + length + " Value: " + Value + " weight:  " + weight;
        }
        public override bool Equals(object obj)
        {
            // если параметр метода представляет тип BoolVector
            // то возвращаем true, если фамилии совпадают
            if (obj is BoolVector boolVector) return Value == boolVector.Value;
            return false;
        }
        // вместе с методом Equals следует реализовать метод GetHashCode
        public override int GetHashCode() => Value.GetHashCode();
    }
}
