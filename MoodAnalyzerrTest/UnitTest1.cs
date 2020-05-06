using MoodAnalyzer;
using NUnit.Framework;
using System;
using System.Reflection;

namespace MoodAnalyzerrTest
{
    public class Tests
    {

        public class moodAnalyzerTest
        {
            MoodAnalysis obj = null;

            [Test]
            public void checkForSad()
            {
                obj = new MoodAnalysis("i am in Sad mood");
                string mood = obj.analysisOfMood();
                Assert.AreEqual("Sad", mood);
            }

            [Test]
            public void checkForHappy()
            {
                obj = new MoodAnalysis("i am in any mood");
                string mood = obj.analysisOfMood();
                Assert.AreEqual("Happy", mood);
            }

            [Test]
            public void checkForEmptyException()
            {
                string massage = "";
                obj = new MoodAnalysis(massage);
                try
                {
                    string mood = obj.analysisOfMood();
                }
                catch (moodAnalysisException exception)
                {
                    Assert.AreEqual("Mood is empty,Please enter valid mood!", exception.Message);
                }
            }

            [Test]
            public void checkForNullException()
            {
                obj = new MoodAnalysis(null);
                try
                {
                    string mood = obj.analysisOfMood();
                }
                catch (moodAnalysisException exception)
                {
                    Assert.AreEqual("Please enter valid mood!", exception.Message);
                }
            }

            [Test]
            public void checkForClassNotFound()
            {
                try
                {
                    MoodAnalyzerReflection<MoodAnalysis> analyser = new MoodAnalyzerReflection<MoodAnalysis>();
                    var returnObject = analyser.newConstructor();
                    var constructor = analyser.createMoodAnalyser(returnObject, "mood");
                }

                catch (Exception e)
                {
                    Assert.AreEqual("Class Not Found", e.Message);
                }
            }

            [Test]
            public void checkForMethodNotFound()
            {
                try
                {
                    MoodAnalyzerReflection<MoodAnalysis> analyser = new MoodAnalyzerReflection<MoodAnalysis>();
                    var returnObject = analyser.newConstructor();
                    ConstructorInfo mood = null;
                    var constructor = analyser.createMoodAnalyser(mood, "MoodAnalysis");
                }
                catch (Exception e)
                {
                    Assert.AreEqual("Method Not Found", e.Message);
                }
            }
        }
    }
}