using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        double clbspeakingPoints;
        double clbwritingPoints;
        double clbreadingPoints;
        double clblisteningPoints;

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


        public double CLBSpeakingPoints
        {
            get
            {
                return clbspeakingPoints;
            }
        }

        public double CLBWritingPoints
        {
            get
            {
                return clbwritingPoints;
            }
        }

        public double CLBReadingPoints
        {
            get
            {
                return clbreadingPoints;
            }
        }

        public double CLBListeningPoints
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


        private void CalculateCLBPointsForIELTS()
        {
            if (SpeakingPoints >= 7.5)
            {
                clbspeakingPoints = 10;
            }
            else if (SpeakingPoints == 7.0)
            {
                clbspeakingPoints = 9;
            }
            else if (SpeakingPoints == 6.5)
            {
                clbspeakingPoints = 8;
            }
            else if (SpeakingPoints == 6)
            {
                clbspeakingPoints = 7;
            }
            else if (SpeakingPoints == 5.5)
            {
                clbspeakingPoints = 6;
            }
            else if (SpeakingPoints == 5)
            {
                clbspeakingPoints = 5;
            }
            else if (SpeakingPoints < 5 && SpeakingPoints>=4)
            {
                clbspeakingPoints = 4;
            }
            else
            {
                clbspeakingPoints = 0;
            }

            if (WritingPoints >= 7.5)
            {
                clbwritingPoints = 10;
            }
            else if (WritingPoints == 7)
            {
                clbwritingPoints = 9;
            }
            else if (WritingPoints == 6.5)
            {
                clbwritingPoints = 8;
            }
            else if (WritingPoints == 6)
            {
                clbwritingPoints = 7;
            }
            else if (WritingPoints == 5.5)
            {
                clbwritingPoints = 6;
            }
            else if (WritingPoints == 5)
            {
                clbwritingPoints = 5;
            }
            else if (WritingPoints < 5 && WritingPoints >= 4)
            {
                clbwritingPoints = 4;
            }
            else
            {
                clbwritingPoints = 0;
            }

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
        private void CalculateCLBPointsForCELPIP()
        {

        }
        private void CalculateCLBPointsForTEF()
        {

        }
    }
}
