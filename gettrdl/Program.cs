using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace gettrdl
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient webClient = new WebClient())
            {
                var input = "";

                try
                {
                    input = args[0];
                } catch (Exception ex)
                {
                    Console.WriteLine("Please provide a link to a gettr post containing a video!");
                    return;
                }

                if(!input.Contains("gettr.com/post/") && !input.Contains("gettr.com/comment/"))
                {
                    Console.WriteLine("Please provide a link to a gettr post containing a video!");
                    return;
                }
                

                var id = "";
                if (input.Contains("gettr.com/post/"))
                {
                    id = input.Substring(input.IndexOf("/post"));
                }
                else
                {
                    id = input.Substring(input.IndexOf("/comment"));
                }

                var url = "https://api.gettr.com/u" + id;

                var result = webClient.DownloadString(url);

                JObject r = JObject.Parse(result);
                var rip = "";
                try
                {
                    rip = r["result"]["data"]["ovid"].ToString();
                } catch (Exception ex) {
                    throw new FileNotFoundException("Could not locate video in post,");
                }
                



                webClient.DownloadFile("https://media.gettr.com/" + rip, rip.Split("/").Last());
            }


        }
    }
}
