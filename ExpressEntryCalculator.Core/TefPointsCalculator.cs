namespace ExpressEntryCalculator.Core
{
    public class TefPointsCalculator : ILanguagePointsCalculator
    {
        readonly double speakingPoints;
        readonly double writingPoints;
        readonly double readingPoints;
        readonly double listeningPoints;

        public TefPointsCalculator(
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
            ClbspeakingPoints = CalculateTEFtoCLB(speakingPoints);
            ClbwritingPoints = CalculateTEFtoCLB(writingPoints);

            // calculate reading points
            if (readingPoints >= 263 && readingPoints <= 277)
            {
                ClbreadingPoints = 10;
            }
            else if (readingPoints >= 248 && readingPoints <= 262)
            {
                ClbreadingPoints = 9;
            }
            else if (readingPoints >= 233 && readingPoints <= 247)
            {
                ClbreadingPoints = 8;
            }
            else if (readingPoints >= 207 && readingPoints <= 232)
            {
                ClbreadingPoints = 7;
            }
            else if (readingPoints >= 181 && readingPoints <= 206)
            {
                ClbreadingPoints = 6;
            }
            else if (readingPoints >= 151 && readingPoints <= 180)
            {
                ClbreadingPoints = 5;
            }
            else if (readingPoints >= 121 && readingPoints <= 150)
            {
                ClbreadingPoints = 4;
            }
            else
            {
                ClbreadingPoints = 0;
            }

            // calculate listening points
            if (listeningPoints >= 316 && listeningPoints <= 333)
            {
                ClblisteningPoints = 10;
            }
            else if (listeningPoints >= 298 && listeningPoints <= 315)
            {
                ClblisteningPoints = 9;
            }
            else if (listeningPoints >= 280 && listeningPoints <= 297)
            {
                ClblisteningPoints = 8;
            }
            else if (listeningPoints >= 249 && listeningPoints <= 279)
            {
                ClblisteningPoints = 7;
            }
            else if (listeningPoints >= 217 && listeningPoints <= 248)
            {
                ClblisteningPoints = 6;
            }
            else if (listeningPoints >= 181 && listeningPoints <= 216)
            {
                ClblisteningPoints = 5;
            }
            else if (listeningPoints >= 145 && listeningPoints <= 180)
            {
                ClblisteningPoints = 4;
            }
            else
            {
                ClblisteningPoints = 0;
            }
        }

        private int CalculateTEFtoCLB(double pointsTEF)
        {
            if (pointsTEF >= 393 && pointsTEF <= 415)
            {
                return 10;
            }
            else if (pointsTEF >= 371 && pointsTEF <= 392)
            {
                return 9;
            }
            else if (pointsTEF >= 349 && pointsTEF <= 370)
            {
                return 8;
            }
            else if (pointsTEF >= 310 && pointsTEF <= 348)
            {
                return 7;
            }
            else if (pointsTEF >= 271 && pointsTEF <= 309)
            {
                return 6;
            }
            else if (pointsTEF >= 226 && pointsTEF <= 270)
            {
                return 5;
            }
            else if (pointsTEF >= 181 && pointsTEF <= 225)
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
