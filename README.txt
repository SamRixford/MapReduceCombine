Made in a web form application (option 1)

When uploading a file, you must first select the file, upload it, then select the file again before running the Map/Reduce/Combine command.

This is because I was having issues the the filepath upon several uploads and runs. 

Also due to the limitations of ASP.net, if you run just one thread on the given text file it will cause an error where the size of the text file is too big for the application. 3 or more threads should work for this though.

I also provide an example image of output I was able to get.