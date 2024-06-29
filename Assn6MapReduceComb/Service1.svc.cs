using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace Assn6MapReduceComb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<KeyValuePair<string, int>> map(List<string> textDoc)
        {
            //for mapping I am making a list of keypair values.
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
            foreach (string text in textDoc)
            {
                //get rid of extra chars
                var justText = Regex.Replace(text, @"\.|;|:|,|[0-9]|'", "");
                // split words into individual words
                var words = Regex.Matches(justText, @"[\w]+");

                foreach (var word in words)
                {
                    //add each word with a value of 1 to the list.
                    KeyValuePair<string, int> pair = new KeyValuePair<string, int>(word.ToString().ToLower(), 1);
                    list.Add(pair);
                }
            }
            return list;
        }

        public Dictionary<string, int> reduce(List<KeyValuePair<string, int>> values)
        {
            //reduce the list of keyValuePairs to a dictionary.
            Dictionary<string, int> count = new Dictionary<string, int>();

            //for each pair
            foreach (KeyValuePair<string, int> pair in values)
            {
                if (count.ContainsKey(pair.Key))
                {
                    //if the word is already in the dictionary, increment the number of times it appears.
                    count[pair.Key] += 1;
                }
                else
                {
                    //else add the word with a value of 1
                    count.Add(pair.Key, 1);
                }
            }
            return count;
        }

        public Dictionary<string, int> combine(List<Dictionary<string, int>> toCombine)
        {
            //combine the threads list of dictionaries to a single one.
            Dictionary<string, int> finalCount = new Dictionary<string, int>();

            //for each dictionary in the list,
            foreach (Dictionary<string, int> dict in toCombine)
            {
                //for each word in each dictionary.
               foreach(string word in dict.Keys)
                {
                    if(finalCount.ContainsKey(word))
                    {
                        //if the word is already in the new dictionary add the the number of appearances together.
                        finalCount[word] += dict[word];
                    }
                    else
                    {
                        //else add the word with its number of appearances.
                        finalCount.Add(word, dict[word]);
                    }
                }
            }
            return finalCount;
        }
    }
}
