using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace SweepstakesOS
{
    public class FileOperations
    {

        /// <summary>
        /// Reads CSV Headers, returns <code>List[string]</code>
        /// </summary>
        /// <param name="filepath">Path of CSV</param>
        /// <returns></returns>
        public static List<string> ReadHeadersCSV(string filepath)
        {
            string[] field_names = new string[1];

            using(StreamReader reader = new StreamReader(filepath))
            {
                string first_line = reader.ReadLine();
                field_names = first_line.Split(',');
            }

            return field_names.ToList<string>();
        }

        public static List<string[]> ReadCSV(string filepath)
        {
            List<string[]> Entrants = new List<string[]>();
            string input_file = filepath;

            if(!File.Exists(input_file))
            {
                throw new FileNotFoundException("File does not exist.");
            }

            int lines_read = 0;
            using(StreamReader input_reader = new StreamReader(input_file))
            {
                //Iterate Lines
                string line = "";
                while((line = input_reader.ReadLine()) != null)
                {
                    //Remove "\"" and enclosed ','
                    if(line.Contains("\""))
                    {
                        int start = line.IndexOf("\"");
                        int end = line.IndexOf("\"", start + 1);

                        if(end < start)
                        {

                        }
                        else
                        {
                            string enclosed = line.Substring(start + 1, end - start - 1);
                            string new_enclosed = enclosed.Replace(",", " ");
                            line = line.Replace(enclosed, new_enclosed);
                        }
                    }

                    line = line.Replace("\"", "");

                    string[] new_line = line.Split(',');
                    for(int i = 0; i < new_line.Length; i++)
                    {
                        new_line[i] = new_line[i].Trim();
                    }

                    Entrants.Add(new_line);

                    lines_read++;
                }
            }

            return Entrants;
        }

        public static List<string> ReadXLS(string filepath)
        {
            throw new NotImplementedException();
        }

        public static string WriteCSV(string filepath_original, string filepath_exclude, int column_original, int column_exclude)
        {
            //SaveAsCSV(filepath_original, "temp_original");
            //SaveAsCSV(filepath_exclude, "temp_exclude");

            #region Fill Exclude Data To Match

            if(!File.Exists(filepath_exclude))
            {
                throw new FileNotFoundException("File does not exist.");
            }

            List<string> match_list = new List<string>();
            int lines_written = 0;
            using(StreamReader input_reader = new StreamReader(filepath_exclude))
            {
                string line;
                while((line = input_reader.ReadLine()) != null)
                {
                    //Remove "\"" and enclosed ','
                    if(line.Contains("\""))
                    {
                        int start = line.IndexOf("\"");
                        int end = line.IndexOf("\"", start + 1);

                        if(end < start)
                        {

                        }
                        else
                        {
                            string enclosed = line.Substring(start + 1, end - start - 1);
                            string new_enclosed = enclosed.Replace(",", " ");
                            line = line.Replace(enclosed, new_enclosed);
                        }
                    }

                    //line = line.Replace("\n","");
                    string[] fields = line.Split(',');
                    match_list.Add(fields[column_exclude]);
                }
            }

            #endregion

            string input_file = filepath_original;
            string output_file = Path.GetDirectoryName(input_file)
                + @"\" + Path.GetFileNameWithoutExtension(input_file) + "_exclude"
                + Path.GetExtension(input_file);

            if(!File.Exists(input_file))
            {
                throw new FileNotFoundException("File does not exist.");
            }

            lines_written = 0;
            int excludes = 0;
            List<string> matches = new List<string>();
            using(StreamReader input_reader = new StreamReader(input_file))
            using(StreamWriter output_writer = new StreamWriter(output_file, false))
            {
                //Copy Headers
                output_writer.WriteLine(input_reader.ReadLine());
                lines_written++;

                //Exclude
                string line = "";
                while((line = input_reader.ReadLine()) != null)
                {
                    //Remove "\"" and enclosed ','
                    if(line.Contains("\""))
                    {
                        int start = line.IndexOf("\"");
                        int end = line.IndexOf("\"", start + 1);

                        if(end < start)
                        {

                        }
                        else
                        {
                            string enclosed = line.Substring(start + 1, end - start - 1);
                            string new_enclosed = enclosed.Replace(",", " ");
                            line = line.Replace(enclosed, new_enclosed);
                        }
                    }

                    string[] fields = line.Split(',');

                    if(!match_list.Contains(fields[column_original]))
                    {
                        //NO MATCH, write
                        output_writer.WriteLine(line);
                        lines_written++;
                    }
                    else
                    {
                        matches.Add(fields[column_original]);
                        excludes++;
                    }
                }
            }

            //Remove duplicates in matches
            matches = matches.Distinct().ToList();

            StringBuilder msg = new StringBuilder(lines_written + " lines written.\n\n" + excludes + " Excluded\n\n");
            foreach(string s in matches)
                msg.AppendLine(s);

            //MessageBox.Show(msg.ToString());

            return output_file;
        }
        
        public static string SaveAsCSV(string path, string output_filename)
        {
            string directory = Path.GetDirectoryName(path);
            string new_file = directory + @"\" + output_filename + ".csv";

            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(path);
            wb.SaveAs(new_file, Excel.XlFileFormat.xlCSVWindows);
            wb.Close(false);
            app.Quit();

            return new_file;
        }

        //public static string SaveAsCSV

    }
}
