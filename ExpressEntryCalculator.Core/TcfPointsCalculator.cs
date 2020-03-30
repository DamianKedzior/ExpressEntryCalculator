namespace ExpressEntryCalculator.Core
{
    public class TcfPointsCalculator : ILanguagePointsCalculator
    {
        readonly double speakingPoints;
        readonly double writingPoints;
        readonly double readingPoints;
        readonly double listeningPoints;

        public TcfPointsCalculator(
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
            // calculate reading 
            if (readingPoints < 342)
            {
                ClbreadingPoints = 0;
            }
            else if (readingPoints >= 342 && readingPoints <= 374)
            {
                ClbreadingPoints = 4;
            }
            else if (readingPoints >= 375 && readingPoints <= 405)
            {
                ClbreadingPoints = 5;
            }
            else if (readingPoints >= 406 && readingPoints <= 452)
            {
                ClbreadingPoints = 6;
            }
            else if (readingPoints >= 453 && readingPoints <= 498)
            {
                ClbreadingPoints = 7;
            }
            else if (readingPoints >= 499 && readingPoints <= 523)
            {
                ClbreadingPoints = 8;
            }
            else if (readingPoints >= 524 && readingPoints <= 548)
            {
                ClbreadingPoints = 9;
            }
            else
            {
                ClbreadingPoints = 10;
            }

            // calculate writing
            ClbwritingPoints = CalculateCLBPointsForTCF(writingPoints);

            //calculate listening
            if (listeningPoints < 331)
            {
                ClblisteningPoints = 0;
            }
            else if (listeningPoints >= 331 && listeningPoints <= 368)
            {
                ClblisteningPoints = 4;
            }
            else if (listeningPoints >= 369 && listeningPoints <= 397)
            {
                ClblisteningPoints = 5;
            }
            else if (listeningPoints >= 398 && listeningPoints <= 457)
            {
                ClblisteningPoints = 6;
            }
            else if (listeningPoints >= 458 && listeningPoints <= 502)
            {
                ClblisteningPoints = 7;
            }
            else if (listeningPoints >= 503 && listeningPoints <= 522)
            {
                ClblisteningPoints = 8;
            }
            else if (listeningPoints >= 523 && listeningPoints <= 548)
            {
                ClblisteningPoints = 9;
            }
            else
            {
                ClblisteningPoints = 10;
            }

            //calculate speaking
            ClbspeakingPoints = CalculateCLBPointsForTCF(speakingPoints);
        }

        private int CalculateCLBPointsForTCF(double points)
        {
            if (points < 4)
            {
                return 0;
            }
            else if (points >= 4 && points <= 5)
            {
                return 4;
            }
            else if (points == 6)
            {
                return 5;
            }
            else if (points >= 7 && points <= 9)
            {
                return 6;
            }
            else if (points >= 10 && points <= 11)
            {
                return 7;
            }
            else if (points >= 12 && points <= 13)
            {
                return 8;
            }
            else if (points >= 14 && points <= 15)
            {
                return 9;
            }
            else
            {
                return 10;
            }
        }
    }
}
