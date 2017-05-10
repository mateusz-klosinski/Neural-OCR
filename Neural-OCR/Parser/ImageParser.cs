using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Neural_OCR.Network;
using System;
using System.Collections.Generic;
using System.Drawing;

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
            _extractedFeatures.Clear();

            HOGDescriptor descriptor = new HOGDescriptor(new Size(64, 128), new Size(64, 64), new Size(64, 64), new Size(32, 32));
            CvInvoke.Resize(_processedImage, _processedImage, new Size(64, 128));
            float[] result = descriptor.Compute(_processedImage);

            double[] doubleResult = Array.ConvertAll(result, x => (double)(x / 0.5) * (1 + 1) - 1);

            _extractedFeatures.AddRange(doubleResult);
        }

    }
}
