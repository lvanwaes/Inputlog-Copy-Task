# Inputlog-Copy-Task
Multilingual copy task flow and copy task creator: Measuring motor and typing skills in writing studies. 

Installation

GitHub
The Inputlog-Copy-Task uses Git as a version control system. Follow the instructions on the GitHub Guides to learn how to set up a repository

Visual Studio 
Visual Studio 15 or higher - Community Edition was used to develop the Inputlog-Copy-Task. When installing Visual Studio, make sure that the following components are installed:
•	Visual C#
•	Visual Web Developer
•	.NET Framework 4.5 or higher
•	Office Developer Tools

Bigram Resources
An excel with bigrams (character-character pairs) for several (western) languages. For every bigram, an indication of the use frequency based on a large text corpus of the given language. The handedness of the bigram is the position of the two characters on a keyboard: LL = both on the left-hand side; LR = on left and one right; RR = both on the right-hand side, etc.

Documentation
Instructions on how to use the copy task, starting with the creation of a task, the execution of the exercises and finally the analysis of the logged writing process.

Task Creator
The copy task creator is written in C# (2015) on top of the .NET Framework version 4.5 and can be used as a standalone program. It is also possible to access the Task Creator via the Inputlog desktop program (http://www.inputlog.net/). The output generates an XML file with a specific set of tags that are recognized by the copy task JavaScript. Inputlog supports the creation of an analysis of the copy task output file. The Copy Task Creator expects Windows 8 and higher.

Web
The copy task is developed in JavaScript (with jQuery 2.1.0) is web based and is tested on most common browsers (Chrome, Internet Explorer, Firefox, Safari and Opera - OSX/Windows). The web application contains all the JavaScript libraries it depends on in the web/scripts/ folder. 
