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
            nn = new NeuralNet(3000, 30, 5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap trainingImage;
            Bitmap temp;
            int bCounter;
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                // Training for A
                string[] filesA = Directory.GetFiles("D:\\TrainingData\\AFinal");
                foreach (string file in filesA)
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
                    // A - 1 - 00001
                    nn.setDesiredOutput(0, 0.0);
                    nn.setDesiredOutput(1, 0.0);
                    nn.setDesiredOutput(2, 0.0);
                    nn.setDesiredOutput(3, 0.0);
                    nn.setDesiredOutput(4, 1.0);
                    nn.learn();
                }
                // Training for B
                string[] filesB = Directory.GetFiles("D:\\TrainingData\\BFinal");
                foreach (string file in filesB)
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
            }
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
            Image testImage = pictureBox2.Image;
            test = (Bitmap)testImage;
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
            // Test picture A
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
            //A
            if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //B
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\BFinal\\B356.jpg");
                pictureBox1.Image = Resize(output);
            }
            /*//C
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //D
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //E 
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //F Here below not yet set
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //G
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //H
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //I
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //J
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //K
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //L
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //M
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //N
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //O
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //P
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //Q
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //R
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //S
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //T
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //U
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //V
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //W
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //X
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //Y
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
                pictureBox1.Image = Resize(output);
            }
            //Z
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\AFinal\\A1091.jpg");
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
