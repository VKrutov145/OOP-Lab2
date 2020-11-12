using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOP___Lab2
{
    public class DOM:IStrategy
    {
        XmlDocument doc = new XmlDocument();
        public List<Submarine> AnalyzeFile(Submarine mySearch, string path)
        {
            doc.Load(path);
            List<List<Submarine>> info = new List<List<Submarine>>();
            if(mySearch.subCountry == null && 
                mySearch.subType == null &&
                mySearch.subClass == null &&
                mySearch.subYear == null &&
                mySearch.ifSubNuclear == null &&
                mySearch.subLength == null)
            {
                return ErrorCatch(doc);
            }

            if (mySearch.subCountry != null) info.Add(SearchByAttribute("sub", "Country", mySearch.subCountry, doc));
            if (mySearch.subType != null) info.Add(SearchByAttribute("sub", "Type", mySearch.subType, doc));
            if (mySearch.subClass != null) info.Add(SearchByAttribute("sub", "Class", mySearch.subClass, doc));
            if (mySearch.subYear != null) info.Add(SearchByAttribute("sub", "Year", mySearch.subYear, doc));
            if (mySearch.ifSubNuclear != null) info.Add(SearchByAttribute("sub", "Nuclear", mySearch.ifSubNuclear, doc));
            if (mySearch.subLength != null) info.Add(SearchByAttribute("sub", "Length", mySearch.subLength, doc));

            return Cross(info, mySearch);

        }

        public List<Submarine> SearchByAttribute(string nodeName, string attribute, string myTemplate, XmlDocument doc)
        {
            List<Submarine> find = new List<Submarine>();

            if (myTemplate != null)
            {
                XmlNodeList lst = doc.SelectNodes("//" + nodeName + "[@" + attribute + "=\"" + myTemplate + "\"]");
                foreach(XmlNode e in lst)
                {
                    find.Add(Info(e));
                }
            }
            return find;
        }

        public List<Submarine> ErrorCatch(XmlDocument doc)
        {
            List<Submarine> result = new List<Submarine>();
            XmlNodeList lst = doc.SelectNodes("//" + "sub");
            foreach(XmlNode elem in lst)
            {
                result.Add(Info(elem));
            }
            return result;
        }

        public Submarine Info(XmlNode node)
        {
            Submarine search = new Submarine();
            search.subCountry = node.Attributes.GetNamedItem("Country").Value;
            search.subType = node.Attributes.GetNamedItem("Type").Value;
            search.subClass = node.Attributes.GetNamedItem("Class").Value;
            search.subYear = node.Attributes.GetNamedItem("Year").Value;
            search.ifSubNuclear = node.Attributes.GetNamedItem("Nuclear").Value;
            search.subLength = node.Attributes.GetNamedItem("Length").Value;

            return search;
        }

        public List<Submarine> Cross(List<List<Submarine>> list, Submarine myTemplate)
        {
            List<Submarine> result = new List<Submarine>();
            List<Submarine> clear = CheckNodes(list, myTemplate);
            foreach(Submarine elem in clear)
            {
                bool isln = false;
                foreach(Submarine s in result)
                {
                    if (s.Compare(elem))
                    {
                        isln = true;
                    }
                }
                if (!isln)
                {
                    result.Add(elem);
                }
            }
            return result;
        }

        public  List<Submarine> CheckNodes(List<List<Submarine>> list, Submarine myTemplate)
        {
            List<Submarine> newResult = new List<Submarine>();
            foreach(List<Submarine> elem in list)
            {
                foreach(Submarine s in elem)
                {
                    if((myTemplate.subCountry == s.subCountry || myTemplate.subCountry == null) &&
                        (myTemplate.subType == s.subType || myTemplate.subType == null) &&
                        (myTemplate.subClass == s.subClass || myTemplate.subClass == null) &&
                        (myTemplate.subYear == s.subYear || myTemplate.subYear == null) &&
                        (myTemplate.ifSubNuclear == s.ifSubNuclear || myTemplate.ifSubNuclear == null) &&
                        (myTemplate.subLength == s.subLength || myTemplate.subLength == null))
                    {
                        newResult.Add(s);
                    }
                }
            }
            return newResult;
        }
    }
}