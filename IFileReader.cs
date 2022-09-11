using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterFeedwithCore
{
    interface IFileReader
    {
        string textFile { get; set; }  //Location of the file
        IDictionary<string, List<string>> dictionaryList { get; set; }  //Collection of the data read from the file using a dictionary
        List<string> users { get; set; } //List of users

        void fileReader();  //Method to process the data read from the files
    }
}
