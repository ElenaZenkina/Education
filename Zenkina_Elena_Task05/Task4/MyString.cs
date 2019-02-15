using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class MyString
    {
        public string oneString;

        public MyString(string oneString)
        {
            this.oneString = oneString;
        }


        public static MyString operator +(MyString firstString, MyString secondString)
        {
            if (firstString is null)
            {
                return secondString;
            }
            if (secondString is null)
            {
                return firstString;
            }
            return new MyString(firstString.oneString + secondString.oneString);
        }


        public static MyString operator -(MyString firstString, MyString secondString)
        {
            if (firstString is null || String.IsNullOrEmpty(firstString.oneString))
            {
                return null;
            }

            if (secondString is null || String.IsNullOrEmpty(secondString.oneString))
            {
                return firstString;
            }

            int n = firstString.oneString.IndexOf(secondString.oneString);
            if (n != -1)
            {
                return new MyString(firstString.oneString.Remove(n, secondString.oneString.Length));
            }
            else
            {
                return firstString;
            }
        }


        public static bool operator ==(MyString firstString, MyString secondString)
        {
            if (firstString is null && secondString is null) return true;

            if (firstString is null || secondString is null) return false;

            return (firstString.oneString == secondString.oneString);
        }


        public static bool operator !=(MyString firstString, MyString secondString)
        {
            if (firstString is null && secondString is null) return false;

            if (firstString is null || secondString is null) return true;

            return (firstString.oneString != secondString.oneString);
        }

        public override string ToString()
        {
            return oneString;
        }

    }
}
