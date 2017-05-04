using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class TeachingElement
    {
        public List<double> Inputs { get; set; }
        public List<double> ExpectedOutputs { get; set; }
    }
}
