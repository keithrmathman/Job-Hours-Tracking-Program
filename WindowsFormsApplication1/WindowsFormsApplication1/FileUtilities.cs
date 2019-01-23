using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WindowsFormsApplication1
{
    class FileUtilities
    {
        string filepath;

        public void write_to_file( string filepath, string s) 
        {
            try
            {
                File.Create(filepath).Close();

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    
                    file.Write(s);
                }
            }

            catch(FileNotFoundException fex)
            {
                //Console.Out.WriteLine("Invalid File Path.");
                Console.Out.WriteLine(fex);
            }

            
        }

        public string read_from_file(string filepath)
        {

            string text ="";

            //if (!Directory.Exists(filepath))
            //{
            //    Console.Out.WriteLine("File not Found");
            //    return "";
            //}
            try
            {
                 text =  System.IO.File.ReadAllText(@filepath);
            }

            catch (FileNotFoundException fex)
            {
                //Console.Out.WriteLine("Invalid File Path.");
                Console.Out.WriteLine(fex);
            }

            return text;
        }

        public void clear(string filepath)
        {
            File.Create(filepath).Close();
        }
    }
}
