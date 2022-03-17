namespace LandingSystem
{
    public static class ArrangeService
    {
        public static Square MakeSafetySquare(Arrange arrange)
        {
            var leftCorner = new Arrange(arrange.X - 1, arrange.Y - 1);
            return new Square(3, leftCorner);
        }

        public static bool IsArrangeSquare(Square square, Arrange arrange)
        {
            var leftCorner = square.LeftCorner;
            var size = square.Size;

            var result = arrange.X >= leftCorner.X &&
                         arrange.X <= leftCorner.X + size - 1 &&
                         arrange.Y >= leftCorner.Y &&
                         arrange.Y <= leftCorner.Y + size - 1;
            return result;
        }
    }
}