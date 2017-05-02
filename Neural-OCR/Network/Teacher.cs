using Neural_OCR.Parser;

namespace Neural_OCR.Network
{
    public class Teacher
    {
        private ImageParser _parser;
        private NeuralNetwork _network;

        public Teacher(NeuralNetwork network)
        {
            _parser = new ImageParser();
            _network = network;
        }


        public void Learn(int numberOfEpochs)
        {

        }

    }
}
