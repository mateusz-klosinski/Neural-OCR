using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
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
            calculateMoments();
            calculateArcLength();
            calculateAxisLengths();
        }

        private void calculateMoments()
        {
            MCvMoments moments = CvInvoke.Moments(_contour, true);

            double centroidX = moments.M10 / moments.M00;
            double centroidY = moments.M01 / moments.M00;
            double area = moments.M00;

            _extractedFeatures.AddRange(
                new double[]
                {
                    centroidX, centroidY, area,
                    moments.Mu20, moments.Mu21, moments.Mu30
                });
        }

        private void calculateArcLength()
        {
            double arcLength = CvInvoke.ArcLength(_contour, true);
            _extractedFeatures.Add(arcLength);
        }

        private void calculateAxisLengths()
        {
            RotatedRect elipse = CvInvoke.FitEllipse(_contour);
            double majorAxis = elipse.Size.Height;
            double minorAxis = elipse.Size.Width;

            _extractedFeatures.AddRange(new double[] { majorAxis, minorAxis });
        }

    }
}
