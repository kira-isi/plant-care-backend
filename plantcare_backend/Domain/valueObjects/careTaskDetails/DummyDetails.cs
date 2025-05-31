using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.valueObjects.careTaskDetails
{
    public class DummyDetails : ICareTaskDetails
    {
        public string Summary => "Test";
    }
}
