using RocketLandingApp.Service;

namespace RocketLandingApp.Domain
{
    public sealed class LandingPlatform
    {
        public List<Position> LandingArea { get; set; }

        public LandingPlatform()
        {
            LandingArea = new List<Position>();
        }

        public void InitializeLandingArea(int size)
        {
            Position position;

            if (size == 1)
            {
                position = new Position(0, 0);
                LandingArea.Add(position);
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    position = new Position(x, y);

                    LandingArea.Add(position);
                }
            }

            LinkPositions(LandingArea, size);
        }

        public string EvaluateLanding(int positionX, int positionY)
        {
            (var landingResult, var canLand) = LandingService.ManageLandingPlatform(LandingArea, positionX, positionY);

            if (canLand)
                LandingService.DoLanding(LandingArea, positionX, positionY, canLand);

            return landingResult;
        }


        private void LinkPositions(List<Position> LandingArea, int size)
        {
            for (int i = 0; i < LandingArea.Count; i++)
            {
                var pos = LandingArea[i];

                //line above
                if (pos.PositionX - 1 >= 0)
                {
                    List<Position?> posAbove = new List<Position?>();

                    if (pos.PositionY - 1 >= 0)
                    {
                        posAbove.AddRange(LandingArea.FindAll(p => p.PositionX == pos.PositionX - 1));
                    }

                    if (pos.PositionY + 1 < size)
                    {
                        posAbove.AddRange(LandingArea.FindAll(p => p.PositionX == pos.PositionX - 1));
                    }

                    pos.NearPositions.UnionWith(posAbove);
                }

                //line bellow
                if (pos.PositionX + 1 < size)
                {
                    List<Position?> posBellow = new List<Position?>();

                    if (pos.PositionY - 1 >= 0)
                    {
                        posBellow.AddRange(LandingArea.FindAll(p => p.PositionX == pos.PositionX + 1));
                    }

                    if (pos.PositionY + 1 < size)
                    {
                        posBellow.AddRange(LandingArea.FindAll(p => p.PositionX == pos.PositionX + 1));
                    }

                    pos.NearPositions.UnionWith(posBellow);
                }

                //current line
                if (pos.PositionX <= size)
                {
                    List<Position?> posCurrent = new List<Position?>();

                    if (pos.PositionY - 1 >= 0)
                    {
                        posCurrent.AddRange(LandingArea.FindAll(p => p.PositionX == pos.PositionX && (pos.PositionY - 1 < size && p.PositionY != pos.PositionY)));
                    }

                    if (pos.PositionY + 1 < size)
                    {
                        posCurrent.AddRange(LandingArea.FindAll(p => p.PositionX == pos.PositionX && (pos.PositionY + 1 < size && p.PositionY > pos.PositionY)));
                    }

                    pos.NearPositions.UnionWith(posCurrent);
                }
            }
        }
    }
}
