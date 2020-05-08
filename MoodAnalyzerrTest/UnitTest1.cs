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
                obj = new MoodAnalysis("I am in Sad mood");
                string mood = obj.analysisOfMood();
                Assert.AreEqual("Sad", mood);
            }

            [Test]
            public void checkForHappy()
            {
                obj = new MoodAnalysis("I am in any mood");
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
            public void fordefaultConstructor()
            {
               
                MoodAnalyzerReflection<MoodAnalysis> obj = new MoodAnalyzerReflection<MoodAnalysis>();
                ConstructorInfo returnObject = obj.newConstructor();
                object constructor = obj.createMoodAnalyser(returnObject, "MoodAnalysis", "Class Not Found");
                Assert.IsInstanceOf(typeof(MoodAnalysis), constructor);
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
            /// <summary>
            /// Test parameterised constructor
            /// </summary>
            [Test]
            public void forParamterisedConstructor()
            {
                MoodAnalysis obj = new MoodAnalysis("I am in sad mood!");
                MoodAnalyzerReflection<MoodAnalysis> analyser = new MoodAnalyzerReflection<MoodAnalysis>();
                ConstructorInfo returnObject = analyser.ParameterisedConstructor(1);
                object constructor = analyser.createMoodAnalyser(returnObject, "MoodAnalysis", "I am in sad mood!");
                Assert.IsInstanceOf(typeof(MoodAnalysis), constructor);

            }

            [Test]
            public void classNotFoundForParameterisedConstructor()
            {
                try
                {
                    MoodAnalyzerReflection<MoodAnalysis> analyser = new MoodAnalyzerReflection<MoodAnalysis>();
                    ConstructorInfo returnObject = analyser.ParameterisedConstructor(1);
                    object constructor = analyser.createMoodAnalyser(returnObject, "mood", "I am in sad mood!");
                }

                catch (Exception e)
                {
                    Assert.AreEqual("Class Not Found", e.Message);
                }
            }
            /// <summary>
            /// test method not found in parameterised constructor
            /// </summary>
            [Test]
            public void methodNotFoundForParameterisedConstructor()
            {
                try
                {
                    MoodAnalyzerReflection<MoodAnalysis> analyser = new MoodAnalyzerReflection<MoodAnalysis>();
                    ConstructorInfo returnObject = analyser.ParameterisedConstructor(1);
                    ConstructorInfo mood = null;
                    object constructor = analyser.createMoodAnalyser(mood, "MoodAnalyzer", "I am in sad mood!");
                }

                catch (Exception e)
                {
                    Assert.AreEqual("Class Not Found", e.Message);
                }
            }

        }
    }
}