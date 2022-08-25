using RocketLandingApp.Core;
using RocketLandingApp.Domain;

namespace RocketLandingApp.Service
{
    public static class LandingService
    {
        private static (string, bool) CanLand(List<Position> positions, int desirableLandingPositionX, int desirableLandingPositionY)
        {
            if (positions.Any(p => p.PositionX >= desirableLandingPositionX && p.PositionY >= desirableLandingPositionY))
            {
                if (positions.First(p => p.PositionX == desirableLandingPositionX && p.PositionY == desirableLandingPositionY).Occupied)
                {
                    return (Constants.Clash, false);
                }
                else
                {
                    return (Constants.OkForLanding, true);
                }
            }
            else
            {
                return (Constants.OutOfPlatform, false);
            }
        }

        public static (string, bool) ManageLandingPlatform(List<Position> positions, int desirableLandingPositionX, int desirableLandingPositionY)
        {
            (var landingResult, var canLand) = CanLand(positions, desirableLandingPositionX, desirableLandingPositionY);

            return (landingResult, canLand);
        }

        public static void DoLanding(List<Position> positions, int desirableLandingPositionX, int desirableLandingPositionY, bool canLand)
        {
            var landPosition = positions.Find(p => p?.PositionX == desirableLandingPositionX && p?.PositionY == desirableLandingPositionY);

            landPosition.Occupied = canLand;

            foreach(var position in landPosition.NearPositions)
            {
                position.Occupied = canLand;
            }
        }
    }
}
