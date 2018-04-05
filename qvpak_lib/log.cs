using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace qvpak_lib
{
    public class log
    {
        public void run(string logfile, string content)
        {

            using (StreamWriter sw = File.AppendText(logfile))
            {

                sw.WriteLine(DateTime.Now.ToString() + " - " + content + ";");
          
            }

        }
    }
}
