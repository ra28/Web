using Newtonsoft.Json;
using SchoolApp.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SchoolApp.Web.Scripts
{
    public class BookService
    {
        public List<Book> GetListOfBooks()
        {
            string json = string.Empty;
            string url = @"http://localhost:63894/api/Books";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            List<Book> items = JsonConvert.DeserializeObject<List<Book>>(json);

            return items;
        }

        public Book GetBookById(int id)
        {
            string json = string.Empty;
            string url = @"http://localhost:63894/api/Books/"+ id.ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            Book item = JsonConvert.DeserializeObject<Book>(json);

            return item;
        }
    }
}