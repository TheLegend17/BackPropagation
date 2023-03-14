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
            nn = new NeuralNet(3000, 40, 5);
            button6.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap trainingImageA, trainingImageB, trainingImageC, trainingImageD, trainingImageE, trainingImageF, trainingImageG
                , trainingImageH, trainingImageK, trainingImageN, trainingImageQ, trainingImageT, trainingImageW, trainingImageY
                , trainingImageI, trainingImageL, trainingImageO, trainingImageR, trainingImageU, trainingImageX, trainingImageZ
                , trainingImageJ, trainingImageM, trainingImageP, trainingImageS, trainingImageV;
            Bitmap tempA, tempB, tempC, tempD, tempE, tempF, tempG, tempH, tempI, tempJ, tempK, tempL, tempM, tempN
                , tempO, tempP, tempQ, tempR, tempS, tempT, tempU, tempV, tempW, tempX, tempY, tempZ;
            int bCounter;
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                // Training for A and B
                // Get all the test Images from folder A and B
                var filesA = Directory.GetFiles("D:\\TrainingData\\A");
                var filesB = Directory.GetFiles("D:\\TrainingData\\B");
                var filesC = Directory.GetFiles("D:\\TrainingData\\C");
                var filesD = Directory.GetFiles("D:\\TrainingData\\D");
                var filesE = Directory.GetFiles("D:\\TrainingData\\E");
                var filesF = Directory.GetFiles("D:\\TrainingData\\F");
                var filesG = Directory.GetFiles("D:\\TrainingData\\G");
                var filesH = Directory.GetFiles("D:\\TrainingData\\H");
                var filesI = Directory.GetFiles("D:\\TrainingData\\I");
                var filesJ = Directory.GetFiles("D:\\TrainingData\\J");
                var filesK = Directory.GetFiles("D:\\TrainingData\\K");
                var filesL = Directory.GetFiles("D:\\TrainingData\\L");
                var filesM = Directory.GetFiles("D:\\TrainingData\\M");
                var filesN = Directory.GetFiles("D:\\TrainingData\\N");
                var filesO = Directory.GetFiles("D:\\TrainingData\\O");
                var filesP = Directory.GetFiles("D:\\TrainingData\\P");
                var filesQ = Directory.GetFiles("D:\\TrainingData\\Q");
                var filesR = Directory.GetFiles("D:\\TrainingData\\R");
                var filesS = Directory.GetFiles("D:\\TrainingData\\S");
                var filesT = Directory.GetFiles("D:\\TrainingData\\T");
                var filesU = Directory.GetFiles("D:\\TrainingData\\U");
                var filesV = Directory.GetFiles("D:\\TrainingData\\V");
                var filesW = Directory.GetFiles("D:\\TrainingData\\W");
                var filesX = Directory.GetFiles("D:\\TrainingData\\X");
                var filesY = Directory.GetFiles("D:\\TrainingData\\Y");
                var filesZ = Directory.GetFiles("D:\\TrainingData\\Z");
                // Loop until 30 - number of training images each character
                for (int s = 0; s < filesA.Length; s++)
                {
                    // Get each images
                    tempA = (Bitmap)Image.FromFile(filesA[s]);
                    tempB = (Bitmap)Image.FromFile(filesB[s]);
                    tempC = (Bitmap)Image.FromFile(filesC[s]);
                    tempD = (Bitmap)Image.FromFile(filesD[s]);
                    tempE = (Bitmap)Image.FromFile(filesE[s]);
                    tempF = (Bitmap)Image.FromFile(filesF[s]);
                    tempG = (Bitmap)Image.FromFile(filesG[s]);
                    tempH = (Bitmap)Image.FromFile(filesH[s]);
                    tempI = (Bitmap)Image.FromFile(filesI[s]);
                    tempJ = (Bitmap)Image.FromFile(filesJ[s]);
                    tempK = (Bitmap)Image.FromFile(filesK[s]);
                    tempL = (Bitmap)Image.FromFile(filesL[s]);
                    tempM = (Bitmap)Image.FromFile(filesM[s]);
                    tempN = (Bitmap)Image.FromFile(filesN[s]);
                    tempO = (Bitmap)Image.FromFile(filesO[s]);
                    tempP = (Bitmap)Image.FromFile(filesP[s]);
                    tempQ = (Bitmap)Image.FromFile(filesQ[s]);
                    tempR = (Bitmap)Image.FromFile(filesR[s]);
                    tempS = (Bitmap)Image.FromFile(filesS[s]);
                    tempT = (Bitmap)Image.FromFile(filesT[s]);
                    tempU = (Bitmap)Image.FromFile(filesU[s]);
                    tempV = (Bitmap)Image.FromFile(filesV[s]);
                    tempW = (Bitmap)Image.FromFile(filesW[s]);
                    tempX = (Bitmap)Image.FromFile(filesX[s]);
                    tempY = (Bitmap)Image.FromFile(filesY[s]);
                    tempZ = (Bitmap)Image.FromFile(filesZ[s]);
                    // Resize into a 50x60 pixel
                    trainingImageA = Resize(tempA);
                    trainingImageB = Resize(tempB);
                    trainingImageC = Resize(tempC);
                    trainingImageD = Resize(tempD);
                    trainingImageE = Resize(tempE);
                    trainingImageF = Resize(tempF);
                    trainingImageG = Resize(tempG);
                    trainingImageH = Resize(tempH);
                    trainingImageI = Resize(tempI);
                    trainingImageJ = Resize(tempJ);
                    trainingImageK = Resize(tempK);
                    trainingImageL = Resize(tempL);
                    trainingImageM = Resize(tempM);
                    trainingImageN = Resize(tempN);
                    trainingImageO = Resize(tempO);
                    trainingImageP = Resize(tempP);
                    trainingImageQ = Resize(tempQ);
                    trainingImageR = Resize(tempR);
                    trainingImageS = Resize(tempS);
                    trainingImageT = Resize(tempT);
                    trainingImageU = Resize(tempU);
                    trainingImageV = Resize(tempV);
                    trainingImageW = Resize(tempW);
                    trainingImageX = Resize(tempX);
                    trainingImageY = Resize(tempY);
                    trainingImageZ = Resize(tempZ);
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
                    // Training for E
                    bCounter = 0;
                    for (int x = 0; x < trainingImageE.Width; x++)
                    {
                        for (int y = 0; y < trainingImageE.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageE.GetPixel(x, y);
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
                    // Training for F                  
                    bCounter = 0;
                    for (int x = 0; x < trainingImageF.Width; x++)
                    {
                        for (int y = 0; y < trainingImageF.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageF.GetPixel(x, y);
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
                    // Training for G                 
                    bCounter = 0;
                    for (int x = 0; x < trainingImageG.Width; x++)
                    {
                        for (int y = 0; y < trainingImageG.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageG.GetPixel(x, y);
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
                    // Training for H            
                    bCounter = 0;
                    for (int x = 0; x < trainingImageH.Width; x++)
                    {
                        for (int y = 0; y < trainingImageH.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageH.GetPixel(x, y);
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
                    // Training for I             
                    bCounter = 0;
                    for (int x = 0; x < trainingImageI.Width; x++)
                    {
                        for (int y = 0; y < trainingImageI.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageI.GetPixel(x, y);
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
                    // Training for J                  
                    bCounter = 0;
                    for (int x = 0; x < trainingImageJ.Width; x++)
                    {
                        for (int y = 0; y < trainingImageJ.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageJ.GetPixel(x, y);
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
                    // Training for K             
                    bCounter = 0;
                    for (int x = 0; x < trainingImageK.Width; x++)
                    {
                        for (int y = 0; y < trainingImageK.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageK.GetPixel(x, y);
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
                    // Training for L              
                    bCounter = 0;
                    for (int x = 0; x < trainingImageL.Width; x++)
                    {
                        for (int y = 0; y < trainingImageL.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageL.GetPixel(x, y);
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
                    // Training for M                  
                    bCounter = 0;
                    for (int x = 0; x < trainingImageM.Width; x++)
                    {
                        for (int y = 0; y < trainingImageM.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageM.GetPixel(x, y);
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
                    // Training for N                 
                    bCounter = 0;
                    for (int x = 0; x < trainingImageN.Width; x++)
                    {
                        for (int y = 0; y < trainingImageN.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageN.GetPixel(x, y);
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
                    // Training for O                
                    bCounter = 0;
                    for (int x = 0; x < trainingImageO.Width; x++)
                    {
                        for (int y = 0; y < trainingImageO.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageO.GetPixel(x, y);
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
                    // Training for P       
                    bCounter = 0;
                    for (int x = 0; x < trainingImageP.Width; x++)
                    {
                        for (int y = 0; y < trainingImageP.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageP.GetPixel(x, y);
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
                    // Training for Q    
                    bCounter = 0;
                    for (int x = 0; x < trainingImageQ.Width; x++)
                    {
                        for (int y = 0; y < trainingImageQ.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageQ.GetPixel(x, y);
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
                    // Training for R         
                    bCounter = 0;
                    for (int x = 0; x < trainingImageR.Width; x++)
                    {
                        for (int y = 0; y < trainingImageR.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageR.GetPixel(x, y);
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
                    // Training for S
                    bCounter = 0;
                    for (int x = 0; x < trainingImageS.Width; x++)
                    {
                        for (int y = 0; y < trainingImageS.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageS.GetPixel(x, y);
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
                    // Training for T
                    bCounter = 0;
                    for (int x = 0; x < trainingImageT.Width; x++)
                    {
                        for (int y = 0; y < trainingImageT.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageT.GetPixel(x, y);
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
                    // Training for U   
                    bCounter = 0;
                    for (int x = 0; x < trainingImageU.Width; x++)
                    {
                        for (int y = 0; y < trainingImageU.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageU.GetPixel(x, y);
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
                    // Training for V        
                    bCounter = 0;
                    for (int x = 0; x < trainingImageV.Width; x++)
                    {
                        for (int y = 0; y < trainingImageV.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageV.GetPixel(x, y);
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
                    // Training for W     
                    bCounter = 0;
                    for (int x = 0; x < trainingImageW.Width; x++)
                    {
                        for (int y = 0; y < trainingImageW.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageW.GetPixel(x, y);
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
                    // Training for X         
                    bCounter = 0;
                    for (int x = 0; x < trainingImageX.Width; x++)
                    {
                        for (int y = 0; y < trainingImageX.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageX.GetPixel(x, y);
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
                    // Training for Y
                    bCounter = 0;
                    for (int x = 0; x < trainingImageY.Width; x++)
                    {
                        for (int y = 0; y < trainingImageY.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageY.GetPixel(x, y);
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
                    // Training for Z         
                    bCounter = 0;
                    for (int x = 0; x < trainingImageZ.Width; x++)
                    {
                        for (int y = 0; y < trainingImageZ.Height; y++)
                        {
                            // Get the color of pixel
                            Color pixelColor = trainingImageZ.GetPixel(x, y);
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

        public Bitmap Resizer(Bitmap a, int w, int h)
        {
            int targetWidth = w;
            int targetHeight = h;
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
                pictureBox2.Image = Resizer(new Bitmap(openFileDialog1.FileName), 150, 160);
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
            Bitmap output = null;
            //A - 1 - 00001
            if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\A\\A632.jpg");
                label3.Text += "A";
            }
            //B - 2 - 00010
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\B\\B1.jpg");
                label3.Text += "B";
            }
            //C - 3 - 00011
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\C\\C91.jpg");
                label3.Text += "C";
            }
            //D - 4 - 00100
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\D\\D1698.jpg");
                label3.Text += "D";
            }
            //E - 5 - 00101
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\E\\E100.jpg");
                label3.Text += "E";
            }
            //F - 6 - 00110
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\F\\F100.jpg");
                label3.Text += "F";
            }
            //G - 7 - 00111
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\G\\G100.jpg");
                label3.Text += "G";
            }
            //H - 8 - 01000
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\H\\H100.jpg");
                label3.Text += "H";
            }
            //I - 9 - 01001
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\I\\I100.jpg");
                label3.Text += "I";
            }
            //J - 10- 01010 
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\J\\J100.jpg");
                label3.Text += "J";
            }
            //K - 11- 01011
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\K\\K100.jpg");
                label3.Text += "K";
            }
            //L - 12- 01100
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\L\\L100.jpg");
                label3.Text += "L";
            }
            //M - 13- 01101
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\M\\M100.jpg");
                label3.Text += "M";
            }
            //N - 14- 01110
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\N\\N100.jpg");
                label3.Text += "N";
            }
            //O - 15- 01111
            else if (nn.getOuputData(0) < .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\O\\O100.jpg");
                label3.Text += "O";
            }
            //P - 16- 10000
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\P\\P100.jpg");
                label3.Text += "P";
            }
            //Q - 17- 10001
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\Q\\Q100.jpg");
                label3.Text += "Q";
            }
            //R - 18- 10010
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\R\\R100.jpg");
                label3.Text += "R";
            }
            //S - 19- 10011
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\S\\S100.jpg");
                label3.Text += "S";
            }
            //T - 20- 10100
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\T\\T100.jpg");
                label3.Text += "T";
            }
            //U - 21- 10101
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\U\\U100.jpg");
                label3.Text += "U";
            }
            //V - 22- 10110
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\V\\V100.jpg");
                label3.Text += "V";
            }
            //W - 23- 10111
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) < .5 && nn.getOuputData(2) > .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\W\\W100.jpg");
                label3.Text += "W";
            }
            //X - 24- 11000
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\X\\X100.jpg");
                label3.Text += "X";
            }
            //Y - 25- 11001
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) < .5 && nn.getOuputData(4) > .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\Y\\Y100.jpg");
                label3.Text += "Y";
            }
            //Z - 26- 11010
            else if (nn.getOuputData(0) > .5 && nn.getOuputData(1) > .5 && nn.getOuputData(2) < .5 && nn.getOuputData(3) > .5 && nn.getOuputData(4) < .5)
            {
                output = (Bitmap)Image.FromFile("D:\\TrainingData\\Z\\Z100.jpg");
                label3.Text += "Z";
            }
            else
                label1.Text = "Unable to Recognize";
            pictureBox1.Image = Resizer(output, 150, 160);
        }
    }
}
