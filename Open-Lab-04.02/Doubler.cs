using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Open_Lab_04._02
{
    public class Doubler
    {
        public string DoubleChar(string original)
        {
            string odpoved = "";
            original.ToCharArray().ToList().ForEach(prop => odpoved += prop + prop.ToString());
            return odpoved;
        }
        
    }
}
