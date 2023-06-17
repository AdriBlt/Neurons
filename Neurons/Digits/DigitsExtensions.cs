// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Neurons.Digits
{
    public static class DigitsExtensions
    {
        public static byte[][] DeepCopy(this byte[][] pixels)
        {
            int heigthLength = pixels.Length;
            byte[][] copy = new byte[heigthLength][];
            for (int i = 0; i < heigthLength; ++i)
            {
                int rowLength = pixels[i].Length;
                copy[i] = new byte[rowLength];
                for (int j = 0; j < rowLength; ++j)
                {
                    copy[i][j] = pixels[i][j];
                }
            }

            return copy;
        }

        public static string Print(this byte[][] pixels)
        {
            string s = "";
            foreach (byte[] line in pixels)
            {
                foreach (byte t in line)
                {
                    if (t == 0)
                    {
                        s += " "; // white
                    }
                    else if (t == 255)
                    {
                        s += "O"; // black
                    }
                    else
                    {
                        s += "."; // gray
                    }
                }
                s += "\n";
            }

            return s;
        }
    }
}
