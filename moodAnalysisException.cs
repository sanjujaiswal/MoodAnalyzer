using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    class moodAnalysisException : Exception
    {
        public enum ExceptionType
        {
            EMPTY, NULL
        }
        ExceptionType type;
        public moodAnalysisException(ExceptionType type, string massage) : base(massage)
        {
            this.type = type;
        }
    }
}
