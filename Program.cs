using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace TwitterFeedwithCore
{
    class Program
    {
        //File locations
        private static readonly string userTextFile = "App_Docs/user.txt";
        private static readonly string tweetTextFile = "App_Docs/tweet.txt";

        static void Main(string[] args)
        {
            //Declare the dictionaries to hold the lists for the user followers and the user tweets
            IDictionary<string, List<string>> userFollowers = new Dictionary<string, List<string>>();
            IDictionary<string, List<string>> userTweets = new Dictionary<string, List<string>>();

            List<string> users = new List<string>(); //List of all the users

            //Instances of the collections with data from the files
            UserFileReader userReader = new UserFileReader(userFollowers, users, userTextFile);
            TweetFileReader tweetReader = new TweetFileReader(userTweets, users, tweetTextFile, userFollowers);

            try
            {
                //Call the methods to read files and process their data
                userReader.fileReader();
                tweetReader.fileReader();

                users.Sort(); //Alphabetical order

                //Printing the sorted list
                foreach (string ukey in users)
                {
                    Console.WriteLine(ukey); //Printing the users' tweets

                    if (userTweets.ContainsKey(ukey))
                    {
                        List<string> tweetList = userTweets[ukey];

                        //Looping through the tweets and printing them out according to the user
                        foreach (string output in tweetList)
                        {
                            Console.WriteLine(output);
                        }
                    }
                    else
                    {
                        //In the case there are no tweets for the user, print blank text
                        Console.WriteLine("");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace.ToString()); //Catch file exception with detailed stacktrace
            }
            Console.ReadKey();
        }
    }
}
