using System.Collections.Generic;
using System.Numerics;

namespace INPTPZ1
{
    class ComplexNumbersModel
    {
        public List<Complex> Roots { get; set; }
        public List<Complex> Derive { get; set; }
        public List<Complex> StartPoints { get; set; }

        public ComplexNumbersModel()
        {
            Roots = new List<Complex>();
            Derive = new List<Complex>();
            StartPoints = new List<Complex>();
        }
    }
}
