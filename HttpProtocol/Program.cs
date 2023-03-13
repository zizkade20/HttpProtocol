using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace HttBS
{

    class Program
    {
        static void Main()
        {
            bool a = true;
            while (a)
            {
                try
                {
                    Console.WriteLine("Napiš adresu, kterou chceš ověřit:");

                    string url = Console.ReadLine();

                    var regex = new Regex(@"^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$\r\n");

                    

                    if (regex.IsMatch(url))
                    {

                        WebRequest request = WebRequest.Create(url);

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                        int integerStatus = (int)response.StatusCode;
                        string stringStatus = response.StatusDescription;

                        Console.WriteLine(integerStatus + " (" + stringStatus + ")");
                    } else
                    {
                        Console.WriteLine("Input neni validni");
                    }


                }
                catch (WebException e)
                {
                    //HttpWebResponse response = (HttpWebResponse)e.Response;
                    Console.WriteLine(e.Message);
                }
                Thread.Sleep(1000);
            }
            


        }
    }
    
}
