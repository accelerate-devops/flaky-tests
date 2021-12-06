using System;

namespace SystemUnderTest
{
    public class Sut
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public string Random(int a, string b)
        {
            if (string.IsNullOrEmpty(b))
                throw new ArgumentNullException();

            string result = $"ABC{a}DEF";

            if ((a % 3) == 0) 
            {
                result = $"A{a}BCDEF";
            }

            if ((a % 2) == 0)
            {
                result = $"ABCDE{a}F";
            } 

            return result;
        }
    }
}
