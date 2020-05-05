using MoodAnalyzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalysis
    {
        private string massage;
        public MoodAnalysis(string massage)
        {
            this.massage = massage;
        }
        //Throw and catch generated exception 
        public string analysisOfMood()
        {
            try
            {
                if (massage.Length == 0)
                {
                    throw new moodAnalysisException(moodAnalysisException.ExceptionType.EMPTY, "Mood is empty,Please enter valid mood!");
                }
                if (massage.Contains("Sad"))
                {
                    return "Sad";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (NullReferenceException e)
            {
                throw new moodAnalysisException(moodAnalysisException.ExceptionType.NULL, "Please enter valid mood!");
            }

        }
    }
}



