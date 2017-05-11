using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Neural_OCR.Network;
using System.Collections.Generic;
using System.Drawing;

namespace Neural_OCR.Parser
{
    public class ImageParser
    {

        private Mat _processedImage;
        private VectorOfPoint _contour;
        private List<double> _pixelValues;



        public ImageParser()
        {
            _pixelValues = new List<double>();
        }



        public TeachingElement CreateTeachingElementFromImage(string path, int expectedDigit)
        {
            _pixelValues.Clear();

            loadImageFromFile(path);
            preprocessImage();
            resizeImage();
            addPixelValues();


            return new TeachingElement
            {
                Inputs = _pixelValues,
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
        }

        private void resizeImage()
        {
            CvInvoke.Resize(_processedImage, _processedImage, new Size(7, 10));
            CvInvoke.Threshold(_processedImage, _processedImage, 100, 255, ThresholdType.Binary);
        }


        private void addPixelValues()
        {
            double value = 0;

            for (int i = 0; i < _processedImage.Height; i++)
            {
                for (int j = 0; j < _processedImage.Width; j++)
                {
                    value = _processedImage.Bitmap.GetPixel(j, i).R;

                    if (value > 100)
                    {
                        value = 1;
                    }
                    else
                    {
                        value = -1;
                    }
                    _pixelValues.Add(value);
                    value = 0;
                }
            }
        }

    }
}
