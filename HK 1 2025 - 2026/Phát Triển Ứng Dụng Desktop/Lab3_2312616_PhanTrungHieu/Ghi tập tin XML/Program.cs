using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Ghi_tập_tin_XML
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //using (XmlWriter writer = XmlWriter.Create("books.xml"))
            //{
            //    String pi = "type=\"text/xsl\" href=\"books.xsl\"";
            //    writer.WriteProcessingInstruction("xml-stylesheet", pi);
            //    writer.WriteDocType("catalog", null, null, "<!ENTITY h \"hardcover\">");
            //    writer.WriteComment("This is a book sample XML");
            //    writer.WriteStartElement("book");
            //    writer.WriteAttributeString("ISBN", "9831123212");
            //    writer.WriteAttributeString("yearpublished", "2002");
            //    writer.WriteElementString("author","Mahesh Chand");
            //    writer.WriteElementString("title", "Visua; C# Programming");
            //    writer.WriteElementString("price", "44.95");
            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //    writer.Flush();
            //}    
            var books = new List<Book>
            {
                new Book
                {
                    ISBN = "9831123212",
                    Title = "Visual C# Programming",
                    Author = "Mahesh Chand",
                    Price = 44.95M,
                    YearPublished = 2002
                },
                new Book
                {
                    ISBN = "9831123213",
                    Title = "Mastering ASP.NET",
                    Author = "Kogent Learning Solutions Inc.",
                    Price = 49.95M,
                    YearPublished = 2001
                },
                new Book
                {
                    ISBN = "9831123214",
                    Title = "Beginning Visual C# 2012",
                    Author = "Benjamin Perkins",
                    Price = 39.99M,
                    YearPublished = 2012
                }
            };
            SaveToXmlFile(books);
        }
        public static void SaveToXmlFile(List<Book> books)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));

            using (var writer = new StreamWriter("books.xml"))
            {
                serializer.Serialize(writer, books,null);
                writer.Close();
            }
        }
    }
}
