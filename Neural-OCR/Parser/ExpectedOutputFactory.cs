using System.Collections.Generic;

namespace Neural_OCR.Parser
{
    public static class ExpectedOutputFactory
    {
        public static List<double> getExpectedOutput(int number)
        {
            switch (number)
            {
                case 0:
                    return new List<double>(new double[] { 1, -1, -1, -1, -1, -1, -1, -1, -1, -1 });
                case 1:
                    return new List<double>(new double[] { -1, 1, -1, -1, -1, -1, -1, -1, -1, -1 });
                case 2:
                    return new List<double>(new double[] { -1, -1, 1, -1, -1, -1, -1, -1, -1, -1 });
                case 3:
                    return new List<double>(new double[] { -1, -1, -1, 1, -1, -1, -1, -1, -1, -1 });
                case 4:
                    return new List<double>(new double[] { -1, -1, -1, -1, 1, -1, -1, -1, -1, -1 });
                case 5:
                    return new List<double>(new double[] { -1, -1, -1, -1, -1, 1, -1, -1, -1, -1 });
                case 6:
                    return new List<double>(new double[] { -1, -1, -1, -1, -1, -1, 1, -1, -1, -1 });
                case 7:
                    return new List<double>(new double[] { -1, -1, -1, -1, -1, -1, -1, 1, -1, -1 });
                case 8:
                    return new List<double>(new double[] { -1, -1, -1, -1, -1, -1, -1, -1, 1, -1 });
                case 9:
                    return new List<double>(new double[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, 1 });
                default:
                    return null;

            }
        }
    }
}
