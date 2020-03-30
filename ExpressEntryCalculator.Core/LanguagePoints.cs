using System;

namespace ExpressEntryCalculator.Core
{
    public interface ILanguagePointsCalculator
    {
        int ClbspeakingPoints { get; }
        int ClbwritingPoints { get; }
        int ClbreadingPoints { get; }
        int ClblisteningPoints { get; }
        void Calculate();
    }

    public class LanguagePoints
    {
        double speakingPoints;
        double writingPoints;
        double readingPoints;
        double listeningPoints;

        public enum LanguageExamTypes
        {
            IELTS = 1,
            CELPIP,
            TEF,
            TCF
        }

        public LanguagePoints()
        {
        }

        public LanguagePoints(LanguageExamTypes examType, double speakingPoints, double writingPoints, double readingPoints, double listeningPoints)
        {
            this.LanguageExamType = examType;
            this.speakingPoints = speakingPoints;
            this.readingPoints = readingPoints;
            this.writingPoints = writingPoints;
            this.listeningPoints = listeningPoints;

            CalculateCLBPoints();
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
                case "4":
                    return LanguageExamTypes.TCF;
                default:
                    return LanguageExamTypes.IELTS;
            }
        }

        public static LanguageExamTypes IdentifyingTheTypeOfExam(int exam)
        {
            return IdentifyingTheTypeOfExam(exam.ToString());
        }

        public LanguageExamTypes LanguageExamType { get; private set; }

        public int CLBSpeakingPoints { get; private set; }

        public int CLBWritingPoints { get; private set; }

        public int CLBReadingPoints { get; private set; }

        public int CLBListeningPoints { get; private set; }

        private void CalculateCLBPoints()
        {
            ILanguagePointsCalculator calculator = null;

            switch (LanguageExamType)
            {
                case LanguageExamTypes.IELTS:
                    calculator = new IeltsPointsCalculator(speakingPoints, writingPoints, readingPoints, listeningPoints);
                    break;
                case LanguageExamTypes.CELPIP:
                    calculator = new CelpipPointsCalculator(speakingPoints, writingPoints, readingPoints, listeningPoints);
                    break;
                case LanguageExamTypes.TEF:
                    calculator = new TefPointsCalculator(speakingPoints, writingPoints, readingPoints, listeningPoints);
                    break;
                case LanguageExamTypes.TCF:
                    calculator = new TcfPointsCalculator(speakingPoints, writingPoints, readingPoints, listeningPoints);
                    break;
                default:
                    throw new NotImplementedException("Language test calculation not supported");
            }

            calculator.Calculate();

            CLBListeningPoints = calculator.ClblisteningPoints;
            CLBSpeakingPoints = calculator.ClbspeakingPoints;
            CLBWritingPoints = calculator.ClbwritingPoints;
            CLBReadingPoints = calculator.ClbreadingPoints;
        }
    }
}
