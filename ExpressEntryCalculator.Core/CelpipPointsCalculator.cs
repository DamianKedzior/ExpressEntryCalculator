namespace ExpressEntryCalculator.Core
{
    public class CelpipPointsCalculator : ILanguagePointsCalculator
    {
        readonly double speakingPoints;
        readonly double writingPoints;
        readonly double readingPoints;
        readonly double listeningPoints;

        public CelpipPointsCalculator(
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
            ClbspeakingPoints = CalculateCELPIPtoCLB(speakingPoints);
            ClbwritingPoints = CalculateCELPIPtoCLB(writingPoints);
            ClbreadingPoints = CalculateCELPIPtoCLB(readingPoints);
            ClblisteningPoints = CalculateCELPIPtoCLB(listeningPoints);
        }

        private int CalculateCELPIPtoCLB(double pointsCELPIP)
        {
            if (pointsCELPIP >= 10)
            {
                return 10;
            }
            else if (pointsCELPIP == 9)
            {
                return 9;
            }
            else if (pointsCELPIP == 8)
            {
                return 8;
            }
            else if (pointsCELPIP == 7)
            {
                return 7;
            }
            else if (pointsCELPIP == 6)
            {
                return 6;
            }
            else if (pointsCELPIP == 5)
            {
                return 5;
            }
            else if (pointsCELPIP == 4)
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
