using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsConsoleApp
{
    public class DataInvalidaException : ApplicationException
    {
        private DateTime data;

        public DataInvalidaException(DateTime data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            return string.Format("{0} é um dia da semana não permitido para fazer saques", data.DayOfWeek);
        }
    }
}
