using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

public class URLChecker
{
    public void Run()
    {
        Console.WriteLine("Napiš adresu, kterou chceš ověřit:");
        string url = Console.ReadLine();
        bool a = true;
        while (a)
        {
            try
            {
                

                if (IsValidUrl(url))
                {
                    HttpWebResponse response = SendRequest(url);
                    int integerStatus = (int)response.StatusCode;
                    string stringStatus = response.StatusDescription;
                    Console.WriteLine(integerStatus + " (" + stringStatus + ")");
                }
                else
                {
                    Console.WriteLine("Input neni validni");
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(1000);
        }
    }

    private bool IsValidUrl(string url)
    {
        var regex = new Regex("^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$");
        return regex.IsMatch(url);
    }

    private HttpWebResponse SendRequest(string url)
    {
        WebRequest request = WebRequest.Create(url);
        return (HttpWebResponse)request.GetResponse();
    }

}
