using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOP___Lab2
{
    public class SAX: IStrategy
    {
        private List<Submarine> lastResult = null;
        public List<Submarine> AnalyzeFile(Submarine mySearch, string path)
        {
            XmlReader reader = XmlReader.Create(path);
            List<Submarine> result = new List<Submarine>();

            Submarine find = null;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "sub")
                        {
                            find = new Submarine();
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "Country")
                                {
                                    find.subCountry = reader.Value;
                                }
                                if (reader.Name == "Type")
                                {
                                    find.subType = reader.Value;
                                }
                                if (reader.Name == "Class")
                                {
                                    find.subClass = reader.Value;
                                }
                                if (reader.Name == "Year")
                                {
                                    find.subYear = reader.Value;
                                }
                                if (reader.Name == "Nuclear")
                                {
                                    find.ifSubNuclear = reader.Value;
                                }
                                if (reader.Name == "Length")
                                {
                                    find.subLength = reader.Value;
                                }
                            }
                            result.Add(find);
                        }
                        break;
                }
            }
            lastResult = Filter(result, mySearch);
            return lastResult;
        }

        private List<Submarine> Filter(List<Submarine> allRes, Submarine myTemplate)
        {
            List<Submarine> newResult = new List<Submarine>();
            if (allRes != null)
            {
                foreach (Submarine i in allRes)
                {
                    if((myTemplate.subCountry == i.subCountry || myTemplate.subCountry == null) &&
                        (myTemplate.subType == i.subType || myTemplate.subType == null) &&
                        (myTemplate.subClass == i.subClass || myTemplate.subClass == null) &&
                        (myTemplate.subYear == i.subYear || myTemplate.subYear == null) &&
                        (myTemplate.ifSubNuclear == i.ifSubNuclear || myTemplate.ifSubNuclear == null) &&
                        (myTemplate.subLength == i.subLength || myTemplate.subLength == null))
                    {
                        newResult.Add(i);
                    }
                }
            }
            return newResult;
        }
    }
}