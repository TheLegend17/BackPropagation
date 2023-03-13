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
        Image dataA1, dataA2, testImage, dataB1, dataB2, dataC1, dataC2, dataD1, dataD2,
            dataE1, dataE2, dataF1, dataF2, dataG1, dataG2, dataH1, dataH2, dataI1, dataI2,
            dataJ1, dataJ2;
        Bitmap A1, A2, test, B1, B2,C1, C2, D1, D2, E1, E2, F1, F2, G1, G2, H1, H2, I1, I2, J1, J2;

        public Form1()
        {
            InitializeComponent();
            dataA1 = Image.FromFile("D:\\TrainingData\\A\\A1.jpg");
            dataA2 = Image.FromFile("D:\\TrainingData\\A\\A2.jpg");
            dataB1 = Image.FromFile("D:\\TrainingData\\B\\B1.jpg");
            dataB2 = Image.FromFile("D:\\TrainingData\\B\\B2.jpg");
            dataC1 = Image.FromFile("D:\\TrainingData\\C\\C1.jpg");
            dataC2 = Image.FromFile("D:\\TrainingData\\C\\C2.jpg");
            dataD1 = Image.FromFile("D:\\TrainingData\\D\\D1.jpg");
            dataD2 = Image.FromFile("D:\\TrainingData\\D\\D2.jpg");
            dataE1 = Image.FromFile("D:\\TrainingData\\E\\E1.jpg");
            dataE2 = Image.FromFile("D:\\TrainingData\\E\\E2.jpg");
            dataF1 = Image.FromFile("D:\\TrainingData\\F\\F1.jpg");
            dataF2 = Image.FromFile("D:\\TrainingData\\F\\F2.jpg");
            dataG1 = Image.FromFile("D:\\TrainingData\\G\\G1.jpg");
            dataG2 = Image.FromFile("D:\\TrainingData\\G\\G2.jpg");
            dataH1 = Image.FromFile("D:\\TrainingData\\H\\H1.jpg");
            dataH2 = Image.FromFile("D:\\TrainingData\\H\\H2.jpg");
            dataI1 = Image.FromFile("D:\\TrainingData\\I\\I1.jpg");
            dataI2 = Image.FromFile("D:\\TrainingData\\I\\I2.jpg");
            dataJ1 = Image.FromFile("D:\\TrainingData\\J\\J1.jpg");
            dataJ2 = Image.FromFile("D:\\TrainingData\\J\\J2.jpg");
            A1 = (Bitmap)dataA1;
            A2 = (Bitmap)dataA2;
            B1 = (Bitmap)dataB1;
            B2 = (Bitmap)dataB2;
            C1 = (Bitmap)dataC1;
            C2 = (Bitmap)dataC2;
            D1 = (Bitmap)dataD1;
            D2 = (Bitmap)dataD2;
            E1 = (Bitmap)dataE1;
            E2 = (Bitmap)dataE2;
            F1 = (Bitmap)dataF1;
            F2 = (Bitmap)dataF2;
            G1 = (Bitmap)dataG1;
            G2 = (Bitmap)dataG2;
            H1 = (Bitmap)data1;
            H2 = (Bitmap)dataD2;
            I1 = (Bitmap)dataD1;
            I2 = (Bitmap)dataD2;
            J1 = (Bitmap)dataD1;
            J2 = (Bitmap)dataD2;
            nn = new NeuralNet(dataA1.Width * dataA1.Height, 20, 4);
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
            testImage = pictureBox2.Image;
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
            label1.Text = "" + nn.getOuputData(0) + "\n" + nn.getOuputData(1) + "\n" + nn.getOuputData(2) + "\n" + nn.getOuputData(3);
            if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5)
                pictureBox1.Image = Resize(A1);
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5)
                pictureBox1.Image = Resize(B1);
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5)
                pictureBox1.Image = Resize(C1);
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5)
                pictureBox1.Image = Resize(D1);
            else
                label1.Text = "Unable to Recognize";
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                // A = 1000
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
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
                // A = 1000
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
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
                // B = 0100
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
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
                // B = 0100
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
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
                // C = 0010
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
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
                // C = 0010
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
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
                // D = 0001
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
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
                // D = 0001
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.learn();
            }
            Console.WriteLine("Done");
        }
    }
}
