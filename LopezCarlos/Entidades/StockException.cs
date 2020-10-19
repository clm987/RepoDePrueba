using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class StockException: Exception
    {
      /*  public StockException()
        {
                
        }*/

        public StockException(string message): base(message)
        {

        }
    }
}
