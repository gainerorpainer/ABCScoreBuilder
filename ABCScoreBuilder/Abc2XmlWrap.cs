using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ABCScoreBuilder
{
    internal class Abc2XmlWrap
    {
        readonly FileStream tmpFile;

        public Abc2XmlWrap()
        {
            tmpFile = new FileStream(Path.GetTempFileName(), new FileStreamOptions()
            {
                Access = FileAccess.Write,
                Options = FileOptions.DeleteOnClose
            });

            File.WriteAllBytes(tmpFile.Name, Properties.Resources.abc2xml);
        }

        public void Convert(string from, string to, Abc2XmlOptions options)
        {
            Process.Start(tmpFile.Name, options.ToString());
        }

        ~Abc2XmlWrap()
        {
            tmpFile.Close();    
        }
    }

    class Abc2XmlOptions
    {
        public bool WholeMeasureInMergeStaff { get; set; }

        public override string ToString()
        {
            return WholeMeasureInMergeStaff ? "-r" : "";
        }
    }
}
