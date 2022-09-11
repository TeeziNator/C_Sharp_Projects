using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TwitterFeedwithCore
{
    class UserFileReader : IFileReader
    {
        //Implements the textFile property on the IFileReader interface
        private string _userTextFile;
        public string textFile
        {
            get => _userTextFile;
            set => _userTextFile = value;
        }

        //Implements the dictionaryList property on the IFileReader interface
        private IDictionary<string, List<string>> _userFollowers;
        public IDictionary<string, List<string>> dictionaryList
        {
            get => _userFollowers;
            set => _userFollowers = value;
        }

        //Implements the users property on the IFileReader interface
        private List<string> _users;
        public List<string> users
        {
            get => _users;
            set => _users = value;
        }

        //Constructor to initialize values
        public UserFileReader(IDictionary<string, List<string>> f, List<string> u, string userTextFile)
        {
            this.dictionaryList = f;
            this.users = u;
            this.textFile = userTextFile;
        }

        //Implements the method to read and process the file data on the IFileReader interface
        public void fileReader()
        {
            try
            {
                //Reading from the file using stream reader which does it line by line
                StreamReader userFile = new StreamReader(_userTextFile);

                if (File.Exists(_userTextFile))
                {
                    using (userFile)
                    {
                        string line;
                        string follower;
                        string key;

                        while ((line = userFile.ReadLine()) != null)
                        {
                            string[] separatingStrings = { " follows ", ", " };
                            string[] strArray = line.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
                            follower = strArray[0]; //Name of the user (before the split)

                            //Looping through the user list and getting all the followers (after the split)
                            if (!_users.Contains(follower))
                            {
                                _users.Add(follower);
                            }

                            for (int i = 0; i < strArray.Length; i++)
                            {
                                key = strArray[i];

                                //Add the user to the dictionary if they already exist in the list
                                if (_userFollowers.ContainsKey(key))
                                {
                                    List<string> existingList = _userFollowers[key];
                                    _userFollowers[key] = existingList;
                                }
                                else
                                {
                                    //Adding the user followers to a new list if they do not exist
                                    List<string> followersList = new List<string>
                                    {
                                        follower
                                    };
                                    _userFollowers[key] = followersList;
                                }

                                //Add all users to the dictionary collection
                                if (!_users.Contains(key))
                                {
                                    _users.Add(key);
                                }
                            }
                        }
                    }
                }
                userFile.Close();  //Dispose of the file once done using it
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());  //Catch file exception with detailed stacktrace
            }
        }
    }
}
