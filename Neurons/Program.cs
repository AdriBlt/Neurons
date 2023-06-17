// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons
{
    using System;
    using System.Collections.Generic;
    using Neurons.Digits;

    public class Program
    {
        public static void Main(string[] args)
        {
            DigitReader reader = new DigitReader{ IsDebug = true };
            string repository = @"C:\dev\Neurons\Data\";
            string instance = "t10k";
            string labelsPath = repository + $@"{instance}-images-idx3-ubyte\{instance}-images.idx3-ubyte";
            string imagesPath = repository + $@"{instance}-labels-idx1-ubyte\{instance}-labels.idx1-ubyte";
            List<DigitImage> images = reader.ReadDigitFiles(labelsPath, imagesPath);

            foreach (DigitImage image in images)
            {
                Console.WriteLine(image.ToString());
                Console.ReadLine();
            }

            Console.WriteLine("## END ##");
            Console.ReadLine();
        }
    }
}
