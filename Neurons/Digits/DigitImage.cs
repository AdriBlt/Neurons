namespace Neurons.Digits
{
    public class DigitImage
    {
        public byte[][] Pixels;
        public byte Label;

        public DigitImage(byte[][] pixels, byte label)
        {
            Pixels = pixels;
            Label = label;
        }

        public override string ToString()
        {
            return Pixels.Print() + Label.ToString();
        }
    }
}