using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Neural_OCR.Network;
using System.Collections.Generic;

namespace Neural_OCR.Parser
{
    public class ImageParser
    {

        private Mat _processedImage;
        private VectorOfPoint _contour;
        private List<double> _extractedFeatures;



        public ImageParser()
        {
            _extractedFeatures = new List<double>();
        }



        public TeachingElement CreateTeachingElementFromImage(string path, int expectedDigit)
        {
            _extractedFeatures.Clear();

            loadImageFromFile(path);
            preprocessImage();
            findContour();
            extractFeaturesFromContour();

            return new TeachingElement
            {
                Inputs = _extractedFeatures,
                ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(expectedDigit)
            };
        }


        private void loadImageFromFile(string path)
        {
            _processedImage = CvInvoke.Imread(path, LoadImageType.Grayscale);
        }


        private void preprocessImage()
        {
            CvInvoke.Threshold(_processedImage, _processedImage, 100, 255, ThresholdType.Binary);
            CvInvoke.Canny(_processedImage, _processedImage, 50, 100);
        }


        private void findContour()
        {
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(_processedImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            _contour = contours[contours.Size - 1];
        }



        private void extractFeaturesFromContour()
        {

        }

    }
}
