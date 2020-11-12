
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Lab2
{
    public interface IStrategy
    {
        List<Submarine> AnalyzeFile(Submarine mySearch, string path);
    }
}