// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons.Digits
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class DigitReader
    {
        public bool IsDebug { get; set; } = false;

        public List<DigitImage> ReadDigitFiles(string labelsPath, string imagesPath)
        {
            List<DigitImage> images = new List<DigitImage>();

            try
            {
                // Images
                FileStream imagesFile = new FileStream(imagesPath, FileMode.Open);
                BinaryReader imagesReader = new BinaryReader(imagesFile);
                int magic1 = imagesReader.ReadInt32();
                int numImages = imagesReader.ReadInt32();
                int numRows = imagesReader.ReadInt32();
                int numCols = imagesReader.ReadInt32();

                // Labels
                FileStream labelsFile = new FileStream(labelsPath, FileMode.Open); 
                BinaryReader labelsReader = new BinaryReader(labelsFile);
                int magic2 = labelsReader.ReadInt32();
                int numLabels = labelsReader.ReadInt32();

                // Init Pixels
                int imagesSize = 28;
                byte[][] pixels = new byte[imagesSize][];
                for (int i = 0; i < pixels.Length; ++i)
                {
                    pixels[i] = new byte[imagesSize];
                }

                // Read all
                for (int di = 0; di < 10000; ++di)
                {
                    for (int i = 0; i < imagesSize; ++i)
                    {
                        for (int j = 0; j < imagesSize; ++j)
                        {
                            byte b = imagesReader.ReadByte();
                            pixels[i][j] = b;
                        }
                    }

                    byte lbl = labelsReader.ReadByte();

                    DigitImage dImage = new DigitImage(pixels.DeepCopy(), lbl);
                    images.Add(dImage);
                }

                imagesFile.Close();
                imagesReader.Close();
                labelsFile.Close();
                labelsReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            return images;
        }
    }
}
