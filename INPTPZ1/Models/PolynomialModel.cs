using System.Collections.Generic;
using System.Numerics;

namespace INPTPZ1
{
    class PolynomialModel
    {
        public List<Complex> Roots { get; set; } = new List<Complex>();
        public List<Complex> Derivate { get; set; } = new List<Complex>();
        public List<Complex> StartPoints { get; set; } = new List<Complex>();
    }
}
