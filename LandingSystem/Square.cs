namespace LandingSystem
{
    public class Square
    {
        public Arrange LeftCorner { get; set; }
        public int Size { get; set; }

        public Square(int size, Arrange leftCorner)
        {
            Size = size;
            LeftCorner = leftCorner;
        }
    }
}