using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP___Lab2
{
    public class LINQ:IStrategy
    {
        private List<Submarine> find = null;
        XDocument doc = new XDocument();

        public List<Submarine> AnalyzeFile(Submarine mySearch, string path)
        {
            doc = XDocument.Load(@path);
            find = new List<Submarine>();
            List<XElement> matches = (from val in doc.Descendants("sub")
                where ((mySearch.subCountry == null || mySearch.subCountry == val.Attribute("Country").Value) &&
                       (mySearch.subType == null || mySearch.subType == val.Attribute("Type").Value) &&
                       (mySearch.subClass == null || mySearch.subClass == val.Attribute("Class").Value) &&
                       (mySearch.subYear == null || mySearch.subYear == val.Attribute("Year").Value) &&
                       (mySearch.ifSubNuclear == null || mySearch.ifSubNuclear == val.Attribute("Nuclear").Value) &&
                       (mySearch.subLength == null || mySearch.subLength == val.Attribute("Length").Value))
                select val).ToList();
            foreach(XElement match in matches)
            {
                Submarine res = new Submarine();
                res.subCountry = match.Attribute("Country").Value;
                res.subType = match.Attribute("Type").Value;
                res.subClass = match.Attribute("Class").Value;
                res.subYear = match.Attribute("Year").Value;
                res.ifSubNuclear = match.Attribute("Nuclear").Value;
                res.subLength = match.Attribute("Length").Value;
                find.Add(res);
            }
            return find;
        }
    }
}