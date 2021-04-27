using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroVotantes.Domain.Ports
{
    class BugClass
    {

        private BugClass() { }

        public int diviSIon(int a, int b)
        {
            int c = 0;
            try
            {

                c = a / b;
                return c;
            }
            catch
            {
            }

                return c;
            
        }

        public int suma(int a, int b)
        {
            int c = 0;
            try
            {

                c = a + b;
                return c;
            }
            catch(Exception e)
            {
            }

            return c;

        }

    }
}
