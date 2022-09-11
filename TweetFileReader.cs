using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TwitterFeedwithCore
{
    class TweetFileReader : IFileReader
    {
        //Implements the textFile property on the IFileReader interface
        private string _tweetTextFile;
        public string textFile
        {
            get => _tweetTextFile;
            set => _tweetTextFile = value;
        }

        //Implements the dictionaryList property on the IFileReader interface
        private IDictionary<string, List<string>> _userTweets;
        public IDictionary<string, List<string>> dictionaryList
        {
            get => _userTweets;
            set => _userTweets = value;
        }

        //Implements the users property on the IFileReader interface
        private List<string> _users;
        public List<string> users
        {
            get => _users;
            set => _users = value;
        }

        //Variable to get and initialize the user followers collection
        private readonly IDictionary<string, List<string>> userFollowers;

        //Constructor to initialize values
        public TweetFileReader(IDictionary<string, List<string>> d, List<string> u, string tweetTextFile, IDictionary<string, List<string>> f)
        {
            this.dictionaryList = d;
            this.users = u;
            this.textFile = tweetTextFile;
            this.userFollowers = f;
        }

        //Implements the method to read and process the file data on the IFileReader interface
        public void fileReader()
        {
            try
            {
                //Reading from the file using stream reader which does it line by line
                StreamReader tweetFile = new StreamReader(_tweetTextFile); 

                if (File.Exists(_tweetTextFile))
                {
                    using (tweetFile)
                    {
                        string line;
                        string tweet;
                        string tweetUser;

                        while ((line = tweetFile.ReadLine()) != null)
                        {
                            string separatingStrings = ">";
                            string[] tweetsList = line.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
                            tweetUser = tweetsList[0]; //Name of user the tweets belong to (before the split)
                            tweet = tweetsList[1]; //The tweets that belong to their users (after the split)

                            //Adding the tweet to the user's tweets
                            if (_userTweets.ContainsKey(tweetUser))
                            {
                                //Adds the tweets to the existing tweets if user has already tweeted
                                List<string> existingTweets = _userTweets[tweetUser];
                                existingTweets.Add($"\t @{tweetUser} : {tweet} ");
                                _userTweets[tweetUser] = existingTweets;
                            }
                            else
                            {
                                //Adds a new tweet to the list if user has not tweeted yet
                                List<string> uTweets = new List<string>
                                {
                                    $"\t @{tweetUser} : {tweet} "
                                };
                                _userTweets[tweetUser] = uTweets;
                            }

                            //List<string> keyList = new List<string>(userFollowers.Keys);
                            //keyList = userFollowers[tweetUser];

                            //Adding the tweet to the user's followers list
                            List<string> uFollowers = userFollowers[tweetUser];

                            if (uFollowers != null)
                            {
                                //Looping through the followers and adding the user's tweets to those followers list
                                foreach (string f in uFollowers)
                                {
                                    if (_userTweets.ContainsKey(f))
                                    {
                                        //If the followers already has user's tweets, it add them to the existing list
                                        List<string> followerTweets = _userTweets[f];
                                        followerTweets.Add($"\t @{tweetUser} : {tweet} ");
                                        _userTweets[f] = followerTweets;
                                    }
                                    else
                                    {
                                        //If not then add the new tweets
                                        List<string> ft = new List<string>
                                        {
                                            $"\t @{tweetUser} : {tweet} "
                                        };
                                        _userTweets[f] = ft;
                                    }
                                }
                            }
                        }
                    }
                }
                tweetFile.Close(); //Dispose of the file once done using it
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());  //Catch file exception with detailed stacktrace
            }
        }
    }
}
