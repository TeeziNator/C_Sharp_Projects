================================================================================================================
									Themba Khumalo Twitter Simulator Project
================================================================================================================


****************************************************************************************************************
Problem Description
****************************************************************************************************************

Twitter Feed Coding Assignment

Please write a program to simulate a twitter-like feed. Your program will receive two seven-bit ASCII files. The first file contains a list of users and their
followers. The second file contains tweets. Given the users, followers and tweets, the objective is to display a simulated twitter feed for each user to the
console. You will receive sample text files to use as input.

The program should be well designed, handle errors, have unit tests and should be of sufficient quality to run on a production system. Indicate all
assumptions made in completing the assignment.

Each line of a well-formed user file contains a user, followed by the word 'follows' and then a comma separated list of users they follow. Where there is
more than one entry for a user, consider the union of all these entries to determine the users they follow.
Lines of the tweet file contain a user, followed by greater than, space and then a tweet that may be at most 140 characters in length. The tweets are
considered to be posted by each user in the order they are found in this file.

Your program needs to write console output as follows. For each user / follower (in alphabetical order) output their name on a line. Then for each tweet,
emit a line with the following format: <tab>@user: <space>message

Here is an example. Given user file named user.txt:
Ward follows Alan
Alan follows Martin
Ward follows Martin, Alan

And given tweet file named tweet.txt:
Alan> If you have a procedure with 10 parameters, you probably missed some.
Ward> There are only two hard things in Computer Science: cache invalidation, naming things and off-by-1 errors.
Alan> Random numbers should not be generated with a method chosen at random.

So invoking your program with user.txt and tweet.txt as arguments should produce the following console output:
Alan
@Alan: If you have a procedure with 10 parameters, you probably missed some.
@Alan: Random numbers should not be generated with a method chosen at random.
Martin
Ward
@Alan: If you have a procedure with 10 parameters, you probably missed some.
@Ward: There are only two hard things in Computer Science: cache invalidation, naming things and off-by-1 errors.
@Alan: Random numbers should not be generated with a method chosen at random.


**************************************************************************************************
How To Run The Code?
***************************************************************************************************

1. If you are using Visual Studio to run the code, please select both files in their respective folders, 
	right click and select properties. Under properties look for "Build Action" and set the value to Content 
	and under "Copy to Output Directory" select Copy Always.
2. Make sure that both the file are under the folder App_Docs for reading purposes.
3. Compile and execute the Program.cs file by running the project.
4. Test the logic and the solution by using the provided text files and compare the output with the problem description results.

**************************************************************************************************
Assumptions
**************************************************************************************************

1. The soluton gets the input from the two text files and user input is not required in terms of the data.
2. The files need to be on the same folder all the time.
3. You will need .NET Core 3.1 to be able to run this program as it was build using that platform
4. The solution has all the files below:
	IFileReader.cs
	Program.cs
	TweetFileReader.cs
	UserFileReader.cs
	App_Docs -> ReadMe.txt, tweet.txt and user.txt
