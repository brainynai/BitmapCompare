using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapCompare
{
    public class DataCollection
    {
        internal static string[] getVersions(string filepath)
        {
            //Change this for actual..

            List<string> tempVersions = new List<string>();
            tempVersions.Add("1");
            tempVersions.Add("2");
            tempVersions.Add("3");

            return tempVersions.ToArray();
        }

    }
}
