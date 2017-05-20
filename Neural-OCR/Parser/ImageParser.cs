using AForge.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Neural_OCR.Network;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Neural_OCR.Parser
{
    public class ImageParser
    {

        private Mat _processedImage;
        private List<double> _extractedFeatures;
        private string _dataSetFolder;


        public ImageParser(string dataSetFolder)
        {
            _extractedFeatures = new List<double>();
            _dataSetFolder = dataSetFolder;
        }



        public TeachingElement CreateTeachingElementFromImage(Bitmap image, int expectedDigit = 0)
        {

            Image<Bgr, Byte> imageCV = new Image<Bgr, byte>(image);
            _processedImage = imageCV.Mat;
            CvInvoke.Resize(_processedImage, _processedImage, new Size(70, 100));

            return createTeachingElement(expectedDigit);
        }


        public TeachingElement CreateTeachingElementFromImage(string path, int expectedDigit)
        {
            _processedImage = CvInvoke.Imread(path, LoadImageType.Grayscale);

            return createTeachingElement(expectedDigit);
        }




        private TeachingElement createTeachingElement(int expectedDigit)
        {
            _extractedFeatures.Clear();

            preprocessImage();
            removeBlankPlaces();
            findHorizontalCrossings();
            findVerticalCrossings();
            findHeightDiagonalCrossings();
            findWidthDiagonalCrossings();
            normalizeInputs();


            if (_dataSetFolder == "MixedLetters")
            {
                return new TeachingElement
                {
                    Inputs = new List<double>(_extractedFeatures),
                    ExpectedOutputs = ExpectedLetterOutputFactory.getExpectedOutput(expectedDigit)
                };
            }

            return new TeachingElement
            {
                Inputs = new List<double>(_extractedFeatures),
                ExpectedOutputs = ExpectedDigitOutputFactory.getExpectedOutput(expectedDigit)
            };
        }


        private void preprocessImage()
        {
            CvInvoke.Threshold(_processedImage, _processedImage, 100, 255, ThresholdType.Binary);
        }

        private void removeBlankPlaces()
        {
            Shrink shrinkFilter = new Shrink(Color.FromArgb(255, 255, 255));
            ResizeNearestNeighbor resizeFilter = new ResizeNearestNeighbor(0, 0);

            Bitmap tempImage = shrinkFilter.Apply(_processedImage.Bitmap);

            // image dimenstoin
            int width = _processedImage.Width;
            int height = _processedImage.Height;
            // shrinked image dimension
            int tw = tempImage.Width;
            int th = tempImage.Height;
            // resize factors
            float fx = (float)width / (float)tw;
            float fy = (float)height / (float)th;

            if (fx > fy)
                fx = fy;
            // set new size of shrinked image
            int nw = (int)Math.Round(fx * tw);
            int nh = (int)Math.Round(fy * th);
            resizeFilter.NewWidth = nw;
            resizeFilter.NewHeight = nh;

            // resize image
            Bitmap tempImage2 = resizeFilter.Apply(tempImage);

            Image<Bgr, Byte> imageCV = new Image<Bgr, byte>(tempImage2);

            _processedImage = imageCV.Mat;
        }



        private void findHorizontalCrossings()
        {
            int numberOfLines = 40;
            double percentageOfHeightWhereWillBeLastLine = 0.97;
            double step = percentageOfHeightWhereWillBeLastLine / numberOfLines;


            Bitmap tempOriginalImage = new Bitmap(_processedImage.Bitmap);


            double currentStep = step;
            for (int i = 0; i < numberOfLines; i++)
            {
                bool foundCrossing = false;
                int crossings = 0;

                int currentHeight = (int)(tempOriginalImage.Height * currentStep);

                for (int j = 0; j < tempOriginalImage.Width; j++)
                {
                    var color = tempOriginalImage.GetPixel(j, currentHeight);

                    if (color.R == 0)
                    {
                        if (!foundCrossing)
                        {
                            foundCrossing = true;
                            crossings++;
                        }
                    }
                    else
                    {
                        foundCrossing = false;
                    }
                }

                _extractedFeatures.Add(crossings);
                foundCrossing = false;
                crossings = 0;

                currentStep += step;
            }
        }

        private void findVerticalCrossings()
        {
            int numberOfLines = 40;
            double percentageOfWidthWhereWillBeLastLine = 0.97;
            double step = percentageOfWidthWhereWillBeLastLine / numberOfLines;


            Bitmap tempOriginalImage = new Bitmap(_processedImage.Bitmap);


            double currentStep = step;
            for (int i = 0; i < numberOfLines; i++)
            {
                bool foundCrossing = false;
                int crossings = 0;

                int currentWidth = (int)(tempOriginalImage.Width * currentStep);

                for (int j = 0; j < tempOriginalImage.Height; j++)
                {
                    var color = tempOriginalImage.GetPixel(currentWidth, j);

                    if (color.R == 0)
                    {
                        if (!foundCrossing)
                        {
                            foundCrossing = true;
                            crossings++;
                        }
                    }
                    else
                    {
                        foundCrossing = false;
                    }
                }

                _extractedFeatures.Add(crossings);
                foundCrossing = false;
                crossings = 0;

                currentStep += step;
            }
        }


        private void findHeightDiagonalCrossings()
        {
            int numberOfLines = 20;
            double percentageOfWidthWhereWillBeLastLine = 0.97;
            double step = percentageOfWidthWhereWillBeLastLine / numberOfLines;


            Bitmap tempOriginalImage = new Bitmap(_processedImage.Bitmap);


            double currentStep = step;
            for (int i = 0; i < numberOfLines; i++)
            {
                bool foundCrossing = false;
                int crossings = 0;

                int currentHeight = (int)(tempOriginalImage.Height * currentStep);

                for (int j = 0, k = currentHeight; j < tempOriginalImage.Width && k < tempOriginalImage.Height; j++, k++)
                {
                    var color = tempOriginalImage.GetPixel(j, k);

                    if (color.R == 0)
                    {
                        if (!foundCrossing)
                        {
                            foundCrossing = true;
                            crossings++;
                        }
                    }
                    else
                    {
                        foundCrossing = false;
                    }
                }

                _extractedFeatures.Add(crossings);
                foundCrossing = false;
                crossings = 0;

                currentStep += step;
            }
        }

        private void findWidthDiagonalCrossings()
        {
            int numberOfLines = 20;
            double percentageOfWidthWhereWillBeLastLine = 0.97;
            double step = percentageOfWidthWhereWillBeLastLine / numberOfLines;


            Bitmap tempOriginalImage = new Bitmap(_processedImage.Bitmap);


            double currentStep = step;
            for (int i = 0; i < numberOfLines; i++)
            {
                bool foundCrossing = false;
                int crossings = 0;

                int currentWidth = (int)(tempOriginalImage.Width * currentStep);

                for (int j = currentWidth, k = 0; j < tempOriginalImage.Width && k < tempOriginalImage.Height; j++, k++)
                {
                    var color = tempOriginalImage.GetPixel(j, k);


                    if (color.R == 0)
                    {
                        if (!foundCrossing)
                        {
                            foundCrossing = true;
                            crossings++;
                        }
                    }
                    else
                    {
                        foundCrossing = false;
                    }
                }

                _extractedFeatures.Add(crossings);
                foundCrossing = false;
                crossings = 0;

                currentStep += step;
            }
        }

        private void normalizeInputs()
        {
            for (int i = 0; i < _extractedFeatures.Count; i++)
            {
                _extractedFeatures[i] = (_extractedFeatures[i] - 1) / (5 - 1) * (1 - (-1)) + (-1);
            }
        }


    }
}
