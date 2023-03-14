using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using Backprop;


namespace BackpropagationForSignLanguage
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        Bitmap test;

        public Form1()
        {
            InitializeComponent();
            nn = new NeuralNet(3000, 10, 5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap trainingImageA, trainingImageB, trainingImageC, trainingImageD;
            Bitmap tempA, tempB, tempC, tempD;
            int bCounter;
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                // Training for A and B
                // Get all the test Images from folder A and B
                var filesA = Directory.GetFiles("D:\\TrainingData\\A");
                var filesB = Directory.GetFiles("D:\\TrainingData\\B");
                var filesC = Directory.GetFiles("D:\\TrainingData\\C");
                var filesD = Directory.GetFiles("D:\\TrainingData\\D");
                // Loop until 30 - number of training images each character
                for (int s = 0; s < 30; s++)
                {
                    // Get each images
                    tempA = (Bitmap)Image.FromFile(filesA[s]); 
                    tempB = (Bitmap)Image.FromFile(filesB[s]);
                    tempC = (Bitmap)Image.FromFile(filesC[s]);
                    tempD = (Bitmap)Image.FromFile(filesD[s]);
                    // Resize into a 50x60 pixel
                    trainingImageA = Resize(tempA);
                    trainingImageB = Resize(tempB);
                    trainingImageC = Resize(tempC);
                    trainingImageD = Resize(tempD);
                    // Set counter 0
                    bCounter = 0;
                    // Get each pixel for A
                    for (int x = 0; x < trainingImageA.Width; x++)
                    {
                        for (int y = 0; y < trainingImageA.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageA.GetPixel(x, y);
                            // Calculate is grayscale Value
                            int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                            // Feed to our network
                            nn.setInputs(bCounter, grayscaleValue);
                            bCounter++;
                        }
                    }
                    // A - 1 - 00001
                    nn.setDesiredOutput(0, 0.0);
                    nn.setDesiredOutput(1, 0.0);
                    nn.setDesiredOutput(2, 0.0);
                    nn.setDesiredOutput(3, 0.0);
                    nn.setDesiredOutput(4, 1.0);
                    nn.learn();
                    // For B
                    bCounter = 0;
                    for (int x = 0; x < trainingImageB.Width; x++)
                    {
                        for (int y = 0; y < trainingImageB.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageB.GetPixel(x, y);
                            // Calculate is grayscale Value
                            int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                            // Feed to our network
                            nn.setInputs(bCounter, grayscaleValue);
                            bCounter++;
                        }
                    }
                    // B - 2 - 00010
                    nn.setDesiredOutput(0, 0.0);
                    nn.setDesiredOutput(1, 0.0);
                    nn.setDesiredOutput(2, 0.0);
                    nn.setDesiredOutput(3, 1.0);
                    nn.setDesiredOutput(4, 0.0);
                    nn.learn();
                    //For C
                    bCounter = 0;
                    for (int x = 0; x < trainingImageC.Width; x++)
                    {
                        for (int y = 0; y < trainingImageC.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageC.GetPixel(x, y);
                            // Calculate is grayscale Value
                            int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                            // Feed to our network
                            nn.setInputs(bCounter, grayscaleValue);
                            bCounter++;
                        }
                    }
                    // C - 3 - 00011
                    nn.setDesiredOutput(0, 0.0);
                    nn.setDesiredOutput(1, 0.0);
                    nn.setDesiredOutput(2, 0.0);
                    nn.setDesiredOutput(3, 1.0);
                    nn.setDesiredOutput(4, 1.0);
                    nn.learn();
                    // Training for D
                    bCounter = 0;
                    for (int x = 0; x < trainingImageD.Width; x++)
                    {
                        for (int y = 0; y < trainingImageD.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageD.GetPixel(x, y);
                            // Calculate is grayscale Value
                            int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                            // Feed to our network
                            nn.setInputs(bCounter, grayscaleValue);
                            bCounter++;
                        }
                    }
                    // D - 4 - 00100
                    nn.setDesiredOutput(0, 0.0);
                    nn.setDesiredOutput(1, 0.0);
                    nn.setDesiredOutput(2, 1.0);
                    nn.setDesiredOutput(3, 0.0);
                    nn.setDesiredOutput(4, 0.0);
                    nn.learn();
                }
            }
            /*// Training for B
            files.Clear();
            files = Directory.GetFiles("D:\\TrainingData\\B").ToList();
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // B - 2 - 00010
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for C
            files.Clear();
            files = Directory.GetFiles("D:\\TrainingData\\C").ToList();
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // C - 3 - 00011
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for D
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\D");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // D - 4 - 00100
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for E
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\E");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // E - 5 - 00101
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for F
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\F");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // F - 6 - 00110
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for G
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\G");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // G - 7 - 00111
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for H
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\H");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // H - 8 - 01000
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for I
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\I");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // I - 9 - 01001
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for J
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\J");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // J - 10- 01010 
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for K
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\K");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // K - 11- 01011
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for L
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\L");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // L - 12- 01100
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for M
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\M");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // M - 13- 01101
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for N
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\N");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // N - 14- 01110
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for O
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\O");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // O - 15- 01111
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for P
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\P");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // P - 16- 10000
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for Q
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\Q");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // Q - 17- 10001
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for R
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\R");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // R - 18- 10010
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for S
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\S");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // S - 19- 10011
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for T
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\T");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // T - 20- 10100
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for U
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\U");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // U - 21- 10101
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for V
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\V");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // V - 22- 10110
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for W
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\W");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // W - 23- 10111
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for X
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\X");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // X - 24- 11000
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }
            // Training for Y
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\Y");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                //Y - 25- 11001
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            // Training for Z
            files = null;
            files = Directory.GetFiles("D:\\TrainingData\\Z");
            foreach (string file in files)
            {
                temp = (Bitmap)Image.FromFile(file);
                trainingImage = Resize(temp);
                bCounter = 0;
                for (int x = 0; x < trainingImage.Width; x++)
                {
                    for (int y = 0; y < trainingImage.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = trainingImage.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // Z - 26- 11010
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
            }*/
        //}
                Console.WriteLine("Done Training");
        }

        public Bitmap Resize(Bitmap a)
        {
            int targetWidth = 50;
            int targetHeight = 60;
            int xTarget, yTarget, xSource, ySource;
            int width = a.Width;
            int height = a.Height;
            Bitmap b = new Bitmap(targetWidth, targetHeight);

            for (xTarget = 0; xTarget < targetWidth; xTarget++)
            {
                for (yTarget = 0; yTarget < targetHeight; yTarget++)
                {
                    xSource = xTarget * width / targetWidth;
                    ySource = yTarget * height / targetHeight;
                    b.SetPixel(xTarget, yTarget, a.GetPixel(xSource, ySource));
                }
            }
            return b;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PictureBox PictureBox1 = new PictureBox();

                // Create a new Bitmap object from the picture file on disk,
                // and assign that to the PictureBox.Image property
                pictureBox2.Image = Resize(new Bitmap(openFileDialog1.FileName));
            }
            test = (Bitmap)pictureBox2.Image;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nn.saveWeights("D:\\TestData\\saveWeights.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            nn.loadWeights("D:\\TestData\\saveWeights.txt");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Bitmap testPicture = Resize(test);
            int bCounter = 0;
            for (int x = 0; x < testPicture.Width; x++)
            {
                for (int y = 0; y < testPicture.Height; y++)
                {
                    // Get the color of pixel
                    Color pixelColor = testPicture.GetPixel(x, y);
                    // Calculate is grayscale Value
                    int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                    // Feed to our network
                    nn.setInputs(bCounter, grayscaleValue);
                    bCounter++;
                }
            }
            nn.run();
            label1.Text = "" + nn.getOuputData(0) + "\n" + nn.getOuputData(1) + "\n" + nn.getOuputData(2) + "\n" + nn.getOuputData(3) + "\n" + nn.getOuputData(4);
            Bitmap output;
            //A - 1 - 00001
            if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\A\\A1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //B - 2 - 00010
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\B\\B1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //C - 3 - 00011
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\C\\C1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //D - 4 - 00100
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\D\\D1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //E - 5 - 00101
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\E\\E1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //F - 6 - 00110
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\F\\F1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //G - 7 - 00111
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\G\\G1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //H - 8 - 01000
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\H\\H1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //I - 9 - 01001
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\I\\I1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //J - 10- 01010 
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\J\\J1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //K - 11- 01011
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\K\\K1.jpg");
                pictureBox1.Image = Resize(output);
            }
            /*//L - 12- 01100
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\L\\L1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //M - 13- 01101
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\M\\M1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //N - 14- 01110
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\N\\N1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //O - 15- 01111
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\O\\O1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //P - 16- 10000
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\P\\P1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //Q - 17- 10001
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\Q\\Q1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //R - 18- 10010
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\R\\R1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //S - 19- 10011
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\S\\S1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //T - 20- 10100
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\T\\T1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //U - 21- 10101
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\U\\U1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //V - 22- 10110
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\V\\V1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //W - 23- 10111
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\W\\W1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //X - 24- 11000
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\X\\X1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //Y - 25- 11001
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\Y\\Y1.jpg");
                pictureBox1.Image = Resize(output);
            }
            //Z - 26- 11010
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\Z\\Z1.jpg");
                pictureBox1.Image = Resize(output);
            }*/
            else
                label1.Text = "Unable to Recognize";
        }

        /*private void button1_Click_1(object sender, EventArgs e)
        {
            int epoch = Convert.ToInt32(textBox1.Text);
            // Training A1
            Bitmap a = Resize(A1);
            int bCounter = 0;
            for (int i = 0; i < epoch; i++)
            {
                for (int x = 0; x < a.Width; x++)
                {
                    for (int y = 0; y < a.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = a.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // A - 1 - 00001
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
                // Learn A2
                Bitmap b = Resize(A2);
                bCounter = 0;
                for (int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = b.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // A - 1 - 00001
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
                // Learn B1
                b = Resize(B1);
                bCounter = 0;
                for (int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = b.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // B - 2 - 00010
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
                // Learn B2
                b = Resize(B2);
                bCounter = 0;
                for (int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = b.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // B - 2 - 00010
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
                // Learn C1
                b = Resize(C1);
                bCounter = 0;
                for (int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = b.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // C - 3 - 00011
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
                // Learn C2
                b = Resize(C2);
                bCounter = 0;
                for (int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = b.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // C - 3 - 00011
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
                // Learn D1
                b = Resize(D1);
                bCounter = 0;
                for (int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = b.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // D - 4 - 00100
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
                // Learn D2
                b = Resize(D2);
                bCounter = 0;
                for (int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = b.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // D - 4 - 00100
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.learn();
                // Learn E1
                b = Resize(E1);
                bCounter = 0;
                for (int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = b.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // E - 5 - 00101
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
                // Learn E2
                b = Resize(E2);
                bCounter = 0;
                for (int x = 0; x < b.Width; x++)
                {
                    for (int y = 0; y < b.Height; y++)
                    {
                        // Get the color of pixel
                        Color pixelColor = b.GetPixel(x, y);
                        // Calculate is grayscale Value
                        int grayscaleValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                        // Feed to our network
                        nn.setInputs(bCounter, grayscaleValue);
                        bCounter++;
                    }
                }
                // E - 5 - 00101
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.learn();
            }
            Console.WriteLine("Done");
        }*/
    }
}
