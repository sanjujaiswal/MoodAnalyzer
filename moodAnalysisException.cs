using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
   public class moodAnalysisException : Exception
    {
        public enum ExceptionType
        {
            EMPTY, NULL,
            CLASS_NOT_FOUND,
            NO_OBJECT_IS_CREATED,
            METHOD_NOT_FOUND
        }
        ExceptionType type;
        public moodAnalysisException(ExceptionType type, string massage) : base(massage)
        {
            this.type = type;
        }
    }
}
