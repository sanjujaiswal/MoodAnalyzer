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
        public string analysisOfMood()
        {
            if (massage.Contains("Sad"))
            {
                return "Sad";
            }
            else
            {
                return "Happy";
            }
        }
    }
}
