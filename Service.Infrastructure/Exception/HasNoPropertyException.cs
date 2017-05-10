using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exception
{
    public class HasNoPropertyException : System.Exception
    {
        public HasNoPropertyException(string type,string property)
            :base($"{type} doesn't has property with name {property}")
        {

        }
    }
}
