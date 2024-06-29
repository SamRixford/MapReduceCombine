using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Web.Security;
using System.Reflection.Emit;
using System.Web.Configuration;

namespace CSE446Assignment6
{
    public partial class _Default : Page
    {
        int threads = 0;
        StreamReader reader;
        string finalpath = "";
        List<Dictionary<string, int>> reduceList = new List<Dictionary<string, int>>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uploadFile(object sender, EventArgs e)
        {
            //Copied this from the slides.
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    string path = Server.MapPath("~/") + "Files/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    FileUpload1.SaveAs(path + filename);
                }
                catch (Exception ex)
                {
                    Label5.Text = "ERROR, file may have already been uploaded." + ex.Message;
                }
            }
        }

        protected void mainFunc(object sender, EventArgs e)
        {
            //process of data structures:
            //Read in text to a List of strings -> map the list of strings to a List of KeyPairValues<string, int> -> reduce to a dictionary of <string, int> -> add the dictionary to a list of dictionaries -> combine the list into one dictionary.

            threads = Convert.ToInt32(TextBox1.Text);
            //NameNode from assignment Doc:
            List<string> text = new List<string>();
            //Getting the file path again since had errors with uploading files and grabbing them. This makes sure the path is always correct.
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    string path = Server.MapPath("~/") + "Files/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    finalpath = path + filename;
                }
                catch (Exception ex)
                {
                    Label5.Text = ex.Message;
                }
            }

            //Read the path name for the streamReader and add to list of text.
            StreamReader reader = new StreamReader(finalpath);
            string line = reader.ReadLine().Trim();
            while(line != null)
            {
                text.Add(line);
                line = reader.ReadLine();
            }
            //To properly split the length of the text for the threads I divided the length of the array by the number of threads to get lines for each thread to use.
            var textArrary = text.ToArray();
            int length = textArrary.Length;
            int dividingLines = length / threads;
            
                        //TaskTracker
                        //create number of threads with i to seperate the amount of text for each thread.
                        Parallel.For(0, threads, i =>
                        {
                            string[] textToMap;
                            if (i == threads - 1)
                            {
                                //if this is the last thread, take the rest of the text.
                                textToMap = textArrary.Skip(dividingLines*i).ToArray();
                            }
                            else
                            {
                                //else take the current threads portion of lines by skipping the first i threads sections.
                                textToMap = textArrary.Skip(dividingLines*i).Take(dividingLines).ToArray();
                            }
                            ServiceReference1.Service1Client servClient = new ServiceReference1.Service1Client();
                            //map to keypair values
                            List<KeyValuePair<string, int>> valuepairs = servClient.map(textToMap.ToList<string>());
                            //reduce to dictionary
                            reduceList.Add(servClient.reduce(valuepairs));
                            //add dictionay to list of dictionaries above
                        }
                        );

                        //Combiner
                        //take list of dictionaries and combine into one.
                        ServiceReference1.Service1Client combiner = new ServiceReference1.Service1Client();
                        Dictionary<string, int> finalDict = combiner.combine(reduceList);

            //sort the dictionary with LINQ
            var sortedDict = from entry in finalDict orderby entry.Value descending select entry;
            string finalOutput = "";
            foreach (var word in sortedDict)
            {
                //for each word add the word and its value (the new line doesn't actually work no matter how I tried to implement it, its just a space).
                finalOutput += (word.Key + " " + word.Value.ToString() + Environment.NewLine);
            }
            //add dictionay to list of dictionaries above
            Label5.Text = finalOutput;

        }
    }
}