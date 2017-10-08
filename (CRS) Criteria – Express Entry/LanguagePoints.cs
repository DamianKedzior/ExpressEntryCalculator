namespace _CRS__Criteria___Express_Entry
{
    class LanguagePoints
    {
        public enum LanguageExamTypes
        {
            IELTS = 1,
            CELPIP,
            TEF
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


        public double SpeakingPoints
        {
            get
            {
                return speakingPoints;
            }
            set
            {
                speakingPoints = value;
            }
        }


        public double WritingPoints
        {
            get
            {
                return writingPoints;
            }
            set
            {
                writingPoints = value;
            }
        }


        public double ReadingPoints
        {
            get
            {
                return readingPoints;
            }
            set
            {
                readingPoints = value;
            }
        }


        public double ListeningPoints
        {
            get
            {
                return listeningPoints;
            }
            set
            {
                listeningPoints = value;
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
         
        public void CalculateCLBPoints()
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
            clbspeakingPoints = CalculateIELTStoCLB(SpeakingPoints);
            clbwritingPoints = CalculateIELTStoCLB(WritingPoints);
       
            if (ReadingPoints >= 8)
            {
                clbreadingPoints = 10;
            }
            else if (ReadingPoints >= 7 && ReadingPoints < 8)
            {
                clbreadingPoints = 9;
            }
            else if (ReadingPoints == 6.5)
            {
                clbreadingPoints = 8;
            }
            else if (ReadingPoints == 6)
            {
                clbreadingPoints = 7;
            }
            else if (ReadingPoints >= 5 && ReadingPoints < 6)
            {
                clbreadingPoints = 6;
            }
            else if (ReadingPoints >= 4 && ReadingPoints < 5)
            {
                clbreadingPoints = 5;
            }
            else if (ReadingPoints == 3.5)
            {
                clbreadingPoints = 4;
            }
            else
            {
                clbreadingPoints = 0;
            }

            if (ListeningPoints >= 8.5)
            {
                clblisteningPoints = 10;
            }
            else if (ListeningPoints == 8)
            {
                clblisteningPoints = 9;
            }
            else if (ListeningPoints == 7.5)
            {
                clblisteningPoints = 8;
            }
            else if (ListeningPoints >= 6 && ListeningPoints < 7.5)
            {
                clblisteningPoints = 7;
            }
            else if (ListeningPoints == 5.5)
            {
                clblisteningPoints = 6;
            }
            else if (ListeningPoints == 5)
            {
                clblisteningPoints = 5;
            }
            else if (ListeningPoints == 4.5)
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
            clbspeakingPoints = CalculateCELPIPtoCLB(SpeakingPoints);
            clbwritingPoints = CalculateCELPIPtoCLB(WritingPoints);
            clbreadingPoints = CalculateCELPIPtoCLB(ReadingPoints);
            clblisteningPoints = CalculateCELPIPtoCLB(ListeningPoints);
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
            clbspeakingPoints = CalculateTEFtoCLB(SpeakingPoints);
            clbwritingPoints = CalculateTEFtoCLB(WritingPoints);

            // calculate reading points
            if (ReadingPoints >= 263 && ReadingPoints <= 277)
            {
                clbreadingPoints = 10;
            }
            else if (ReadingPoints >= 248 && ReadingPoints <= 262)
            {
                clbreadingPoints = 9;
            }
            else if (ReadingPoints >= 233 && ReadingPoints <= 247)
            {
                clbreadingPoints = 8;
            }
            else if (ReadingPoints >= 207 && ReadingPoints <= 232)
            {
                clbreadingPoints = 7;
            }
            else if (ReadingPoints >= 181 && ReadingPoints <= 206)
            {
                clbreadingPoints = 6;
            }
            else if (ReadingPoints >= 151 && ReadingPoints <= 180)
            {
                clbreadingPoints = 5;
            }
            else if (ReadingPoints >= 121 && ReadingPoints <= 150)
            {
                clbreadingPoints = 4;
            }
            else
            {
                clbreadingPoints = 0;
            }

            // calculate listening points
            if (ListeningPoints >= 316 && ListeningPoints <= 333)
            {
                clblisteningPoints = 10;
            }
            else if (ListeningPoints >= 298 && ListeningPoints <= 315)
            {
                clblisteningPoints = 9;
            }
            else if (ListeningPoints >= 280 && ListeningPoints <= 297)
            {
                clblisteningPoints = 8;
            }
            else if (ListeningPoints >= 249 && ListeningPoints <= 279)
            {
                clblisteningPoints = 7;
            }
            else if (ListeningPoints >= 217 && ListeningPoints <= 248)
            {
                clblisteningPoints = 6;
            }
            else if (ListeningPoints >= 181 && ListeningPoints <= 216)
            {
                clblisteningPoints = 5;
            }
            else if (ListeningPoints >= 145 && ListeningPoints <= 180)
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
