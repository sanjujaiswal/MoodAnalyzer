using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MoodAnalyzer
{
            /// <summary>
            /// we should send our own instances
            /// </summary>
            /// <typeparam name="E"> Generic type</typeparam>
        public class MoodAnalyzerReflection<E>
        {
            /// <summary>
            /// Created createMoodAnalyser method for return the instance of class of generic.
            /// </summary>
            /// <param name="constructor"> It have the information about the contructor of any class </param>
            /// <param name="className"></param>
            /// <returns></returns>
            public object createMoodAnalyser(ConstructorInfo constructor, string className)
            {
                try
                {
                    Type type = typeof(E);
                    if (className != type.Name)
                    {
                        throw new moodAnalysisException(moodAnalysisException.ExceptionType.CLASS_NOT_FOUND, "Class Not Found");
                    }
                    if (constructor != type.GetConstructors()[0])
                    {
                        throw new moodAnalysisException(moodAnalysisException.ExceptionType.METHOD_NOT_FOUND, "Method Not Found");
                    }

                    var obj1 = constructor.Invoke(new object[0]);
                    //To activate the initialized object of E
                    E returnObject = Activator.CreateInstance<E>();
                    return returnObject;
                }
                catch (Exception ex)
                {
                    throw new moodAnalysisException(moodAnalysisException.ExceptionType.NO_OBJECT_IS_CREATED, ex.Message);
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns> geting the information about the constructor - newConstructor at index 0 </returns>
            public ConstructorInfo newConstructor()
            {
                try
                {
                    Type type = typeof(E);
                    ConstructorInfo[] constructor = type.GetConstructors();
                    foreach (ConstructorInfo c in constructor)
                    {
                        if (c.GetParameters().Length == 0)
                        {
                            Console.WriteLine(c);
                            return c;
                        }
                    }
                    return constructor[0];
                }
                catch (Exception e)
                {
                    throw new moodAnalysisException(moodAnalysisException.ExceptionType.CLASS_NOT_FOUND, "Class Not Available");

                }
            }
        }
    }