using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SweepstakesOS
{
    public class FileStructure
    {

        private readonly string m_filepath;
        private readonly string m_extension;
        private readonly List<string> m_headers;

        public string FilePath
        {
            get
            {
                return m_filepath;
            }
        }

        public List<string> Headers
        {
            get
            {
                return m_headers;
            }
        }

        public string FileName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(m_filepath);
            }
        }

        public string FileExtension
        {
            get
            {
                return m_extension;
            }
        }

        public long Filesize
        {
            get
            {
                return (new FileInfo(m_filepath)).Length;
            }
        }

        public FileStructure(string filepath)
        {
            m_filepath = filepath;
            m_extension =  Path.GetExtension(m_filepath);
            m_headers = PopulateFields(filepath);
        }

        private List<string> PopulateFields(string filepath)
        {
            #region Populate Field Names

            List<string> field_names = new List<string>();

            switch(m_extension)
            {
                case ".csv":
                    //field_names = ReadCSV(filepath);
                    //string[] field_names = new string[1];

                    using(StreamReader reader = new StreamReader(filepath))
                    {
                        string first_line = reader.ReadLine();
                        field_names = first_line.Split(',').ToList<string>();
                    }
                    break;
                case ".xls":
                case ".xlsx":
                    //field_names = ReadXLS(filepath);
                    break;
                default:
                    break;
            }
            
            #endregion

            //Trim
            for(int i = 0; i < field_names.Count; i++)
            {
                field_names[i] = field_names[i].Trim();
            }

            return field_names;
        }
    }
}
