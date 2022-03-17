using System;

namespace LandingSystem
{
    public class LandingSystem
    {
        private const int DefaultLandingAreaSize = 100;
        private const int DefaultLandingPlatformSize = 10;

        private const int LandingAreaTopLeft = 1;
        private const int LandingPlatformTopLeft = 5;

        private const string ExceptionMessage = "This landing is wrong !!!";
        private const string Clash = "clash";
        private const string Okforlanding = "ok for landing";
        private const string Outofplatform = "out of platform";

        private Square LandingArea { get; set; }
        private Square LandingPlatform { get; set; }
        private Square PreviousRocketLandingPosition { get; set; }

        public LandingSystem()
        {
            LandingArea = new Square(DefaultLandingAreaSize, new Arrange(LandingAreaTopLeft, LandingAreaTopLeft));
            LandingPlatform = new Square(DefaultLandingPlatformSize, new Arrange(LandingPlatformTopLeft, LandingPlatformTopLeft));
        }

        public LandingSystem(int size)
        {
            if (size + LandingPlatformTopLeft > DefaultLandingAreaSize)
                throw new Exception(ExceptionMessage);
            LandingArea = new Square(DefaultLandingAreaSize, new Arrange(LandingAreaTopLeft, LandingAreaTopLeft));
            LandingPlatform = new Square(size, new Arrange(LandingPlatformTopLeft, LandingPlatformTopLeft));
        }

        public string LandingRequest(Arrange arrangeLanding)
        {
            string result;
            if (PreviousRocketLandingPosition != null &&
                ArrangeService.IsArrangeSquare(PreviousRocketLandingPosition, arrangeLanding))
                result = Clash;
            else if (ArrangeService.IsArrangeSquare(LandingPlatform, arrangeLanding))
                result = Okforlanding;
            else
                result = Outofplatform;

            PreviousRocketLandingPosition = ArrangeService.MakeSafetySquare(arrangeLanding);
            return result;
        }

    }
}