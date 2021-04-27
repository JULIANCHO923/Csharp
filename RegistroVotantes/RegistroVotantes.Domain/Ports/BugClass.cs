using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroVotantes.Domain.Ports
{
    class BugClass
    {

        private BugClass() { }

        public void suma(int a, int b)
        {
            try
            {

                int c = a / b;
            }
            catch
            {
            }

        }

    }
}
