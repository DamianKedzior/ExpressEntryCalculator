namespace ExpressEntryCalculator.Core
{
    public class IeltsPointsCalculator : ILanguagePointsCalculator
    {
        readonly double speakingPoints;
        readonly double writingPoints;
        readonly double readingPoints;
        readonly double listeningPoints;

        public IeltsPointsCalculator(
            double speakingPoints, 
            double writingPoints, 
            double readingPoints, 
            double listeningPoints)
        {
            this.speakingPoints = speakingPoints;
            this.readingPoints = readingPoints;
            this.writingPoints = writingPoints;
            this.listeningPoints = listeningPoints;
        }

        public int ClbspeakingPoints { get; private set; }

        public int ClbwritingPoints { get; private set; }

        public int ClbreadingPoints { get; private set; }

        public int ClblisteningPoints { get; private set; }

        public void Calculate()
        {
            ClbspeakingPoints = CalculateIELTStoCLB(speakingPoints);
            ClbwritingPoints = CalculateIELTStoCLB(writingPoints);

            if (readingPoints >= 8)
            {
                ClbreadingPoints = 10;
            }
            else if (readingPoints >= 7 && readingPoints < 8)
            {
                ClbreadingPoints = 9;
            }
            else if (readingPoints == 6.5)
            {
                ClbreadingPoints = 8;
            }
            else if (readingPoints == 6)
            {
                ClbreadingPoints = 7;
            }
            else if (readingPoints >= 5 && readingPoints < 6)
            {
                ClbreadingPoints = 6;
            }
            else if (readingPoints >= 4 && readingPoints < 5)
            {
                ClbreadingPoints = 5;
            }
            else if (readingPoints == 3.5)
            {
                ClbreadingPoints = 4;
            }
            else
            {
                ClbreadingPoints = 0;
            }

            if (listeningPoints >= 8.5)
            {
                ClblisteningPoints = 10;
            }
            else if (listeningPoints == 8)
            {
                ClblisteningPoints = 9;
            }
            else if (listeningPoints == 7.5)
            {
                ClblisteningPoints = 8;
            }
            else if (listeningPoints >= 6 && listeningPoints < 7.5)
            {
                ClblisteningPoints = 7;
            }
            else if (listeningPoints == 5.5)
            {
                ClblisteningPoints = 6;
            }
            else if (listeningPoints == 5)
            {
                ClblisteningPoints = 5;
            }
            else if (listeningPoints == 4.5)
            {
                ClblisteningPoints = 4;
            }
            else
            {
                ClblisteningPoints = 0;
            }
        }

        private int CalculateIELTStoCLB(double pointsIELTS)
        {
            if (pointsIELTS >= 7.5)
            {
                return 10;
            }
            else if (pointsIELTS == 7.0)
            {
                return 9;
            }
            else if (pointsIELTS == 6.5)
            {
                return 8;
            }
            else if (pointsIELTS == 6)
            {
                return 7;
            }
            else if (pointsIELTS == 5.5)
            {
                return 6;
            }
            else if (pointsIELTS == 5)
            {
                return 5;
            }
            else if (pointsIELTS < 5 && pointsIELTS >= 4)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
    }
}
