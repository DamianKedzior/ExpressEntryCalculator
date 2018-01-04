namespace ExpressEntryCalculator.Core
{
    public class LanguagePoints
    {
        public LanguagePoints()
        {

        }

        public LanguagePoints(LanguageExamTypes examType, double speakingPoints, double writingPoints, double readingPoints, double listeningPoints)
        {
            this.languageExamType = examType;
            this.speakingPoints = speakingPoints;
            this.readingPoints = readingPoints;
            this.writingPoints = writingPoints;
            this.listeningPoints = listeningPoints;

            CalculateCLBPoints();
        }

        public enum LanguageExamTypes
        {
            IELTS = 1,
            CELPIP,
            TEF
        }

        public static LanguageExamTypes IdentifyingTheTypeOfExam(string exam)
        {
            switch (exam)
            {
                case "1":
                    return LanguageExamTypes.IELTS;
                case "2":
                    return LanguageExamTypes.CELPIP;
                case "3":
                    return LanguageExamTypes.TEF;
                default:
                    return LanguageExamTypes.IELTS;
            }
        }

        public static LanguagePoints.LanguageExamTypes IdentifyingTheTypeOfExam(int exam)
        {
            return IdentifyingTheTypeOfExam(exam.ToString());
        }

        LanguageExamTypes languageExamType;
        double speakingPoints;
        double writingPoints;
        double readingPoints;
        double listeningPoints;

        int clbspeakingPoints;
        int clbwritingPoints;
        int clbreadingPoints;
        int clblisteningPoints;

        public LanguageExamTypes LanguageExamType
        {
            get
            {
                return languageExamType;
            }
            set
            {
                languageExamType = value;
            }
        }


        public int CLBSpeakingPoints
        {
            get
            {
                return clbspeakingPoints;
            }
        }

        public int CLBWritingPoints
        {
            get
            {
                return clbwritingPoints;
            }
        }

        public int CLBReadingPoints
        {
            get
            {
                return clbreadingPoints;
            }
        }

        public int CLBListeningPoints
        {
            get
            {
                return clblisteningPoints;
            }
        }
         
        private void CalculateCLBPoints()
        {
            
            switch (LanguageExamType)
            {
                case LanguageExamTypes.IELTS:
                    CalculateCLBPointsForIELTS();
                    break;
                case LanguageExamTypes.CELPIP:
                    CalculateCLBPointsForCELPIP();
                    break;
                case LanguageExamTypes.TEF:
                    CalculateCLBPointsForTEF();
                    break;
                default:
                    break;
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

        private void CalculateCLBPointsForIELTS()
        {
            clbspeakingPoints = CalculateIELTStoCLB(speakingPoints);
            clbwritingPoints = CalculateIELTStoCLB(writingPoints);
       
            if (readingPoints >= 8)
            {
                clbreadingPoints = 10;
            }
            else if (readingPoints >= 7 && readingPoints < 8)
            {
                clbreadingPoints = 9;
            }
            else if (readingPoints == 6.5)
            {
                clbreadingPoints = 8;
            }
            else if (readingPoints == 6)
            {
                clbreadingPoints = 7;
            }
            else if (readingPoints >= 5 && readingPoints < 6)
            {
                clbreadingPoints = 6;
            }
            else if (readingPoints >= 4 && readingPoints < 5)
            {
                clbreadingPoints = 5;
            }
            else if (readingPoints == 3.5)
            {
                clbreadingPoints = 4;
            }
            else
            {
                clbreadingPoints = 0;
            }

            if (listeningPoints >= 8.5)
            {
                clblisteningPoints = 10;
            }
            else if (listeningPoints == 8)
            {
                clblisteningPoints = 9;
            }
            else if (listeningPoints == 7.5)
            {
                clblisteningPoints = 8;
            }
            else if (listeningPoints >= 6 && listeningPoints < 7.5)
            {
                clblisteningPoints = 7;
            }
            else if (listeningPoints == 5.5)
            {
                clblisteningPoints = 6;
            }
            else if (listeningPoints == 5)
            {
                clblisteningPoints = 5;
            }
            else if (listeningPoints == 4.5)
            {
                clblisteningPoints = 4;
            }
            else
            {
                clblisteningPoints = 0;
            }
        }

        private int CalculateCELPIPtoCLB (double pointsCELPIP)
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

        private void CalculateCLBPointsForCELPIP()
        {
            clbspeakingPoints = CalculateCELPIPtoCLB(speakingPoints);
            clbwritingPoints = CalculateCELPIPtoCLB(writingPoints);
            clbreadingPoints = CalculateCELPIPtoCLB(readingPoints);
            clblisteningPoints = CalculateCELPIPtoCLB(listeningPoints);
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

        private void CalculateCLBPointsForTEF()
        {
            clbspeakingPoints = CalculateTEFtoCLB(speakingPoints);
            clbwritingPoints = CalculateTEFtoCLB(writingPoints);

            // calculate reading points
            if (readingPoints >= 263 && readingPoints <= 277)
            {
                clbreadingPoints = 10;
            }
            else if (readingPoints >= 248 && readingPoints <= 262)
            {
                clbreadingPoints = 9;
            }
            else if (readingPoints >= 233 && readingPoints <= 247)
            {
                clbreadingPoints = 8;
            }
            else if (readingPoints >= 207 && readingPoints <= 232)
            {
                clbreadingPoints = 7;
            }
            else if (readingPoints >= 181 && readingPoints <= 206)
            {
                clbreadingPoints = 6;
            }
            else if (readingPoints >= 151 && readingPoints <= 180)
            {
                clbreadingPoints = 5;
            }
            else if (readingPoints >= 121 && readingPoints <= 150)
            {
                clbreadingPoints = 4;
            }
            else
            {
                clbreadingPoints = 0;
            }

            // calculate listening points
            if (listeningPoints >= 316 && listeningPoints <= 333)
            {
                clblisteningPoints = 10;
            }
            else if (listeningPoints >= 298 && listeningPoints <= 315)
            {
                clblisteningPoints = 9;
            }
            else if (listeningPoints >= 280 && listeningPoints <= 297)
            {
                clblisteningPoints = 8;
            }
            else if (listeningPoints >= 249 && listeningPoints <= 279)
            {
                clblisteningPoints = 7;
            }
            else if (listeningPoints >= 217 && listeningPoints <= 248)
            {
                clblisteningPoints = 6;
            }
            else if (listeningPoints >= 181 && listeningPoints <= 216)
            {
                clblisteningPoints = 5;
            }
            else if (listeningPoints >= 145 && listeningPoints <= 180)
            {
                clblisteningPoints = 4;
            }
            else
            {
                clblisteningPoints = 0;
            }
        }

    }
}
