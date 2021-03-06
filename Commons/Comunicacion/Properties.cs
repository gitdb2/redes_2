﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comunicacion
{

    public class Settings
    {
        static private Settings instance = new Settings();
        private Properties config = new Properties("settings.properties");
        public static Settings GetInstance()
        {
            return instance;
        }
        private Settings() {
           // Properties config = new Properties("settings.properties");
            //get value whith default value
          //  com_port.Text = config.get("com_port", "1");
        
        }

        public String GetProperty(String key)
        {
            return config.Get(key);
        }

        public String GetProperty(String key, String defval)
        {
            return config.Get(key, defval);
        }


    }

    public class Properties
    {
        private Dictionary<String, String> list;
        private String filename;

        public Properties(String file)
        {
            Reload(file);
        }

        public String Get(String field, String defValue)
        {
            return (Get(field) == null) ? (defValue) : (Get(field));
        }
        public String Get(String field)
        {
            return (list.ContainsKey(field)) ? (list[field]) : (null);
        }

        public void Set(String field, Object value)
        {
            if (!list.ContainsKey(field))
                list.Add(field, value.ToString());
            else
                list[field] = value.ToString();
        }

        public bool ContainsKey(string key)
        {
            return list.ContainsKey(key);
        }

        public void Save()
        {
            Save(this.filename);
        }

        public void Save(String filename)
        {
            this.filename = filename;

            if (!System.IO.File.Exists(filename))
                System.IO.File.Create(filename);

            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);

            foreach (String prop in list.Keys.ToArray())
              //  if (!String.IsNullOrWhiteSpace(list[prop]))
                    file.WriteLine(prop + "=" + list[prop]);

            file.Close();
        }

        public List<string> GetRegisteredUsers()
        {
            List<string> result = new List<string>();
            result.AddRange(list.Keys);
            return result;
        }

        public void Reload()
        {
            Reload(this.filename);
        }

        public void Reload(String filename)
        {
            this.filename = filename;
            list = new Dictionary<String, String>();

            if (System.IO.File.Exists(filename))
                loadFromFile(filename);
            else
                System.IO.File.Create(filename);
        }

        private void loadFromFile(String file)
        {
            foreach (String line in System.IO.File.ReadAllLines(file))
            {
                if ((!String.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(";")) &&
                    (!line.StartsWith("#")) &&
                    (!line.StartsWith("'")) &&
                    (line.Contains('=')))
                {
                    int index = line.IndexOf('=');
                    String key = line.Substring(0, index).Trim();
                    String value = line.Substring(index + 1).Trim();

                    if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                        (value.StartsWith("'") && value.EndsWith("'")))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    try
                    {
                        //ignore dublicates
                        list.Add(key, value);
                    }
                    catch { }
                }
            }
        }

        public int Count { get { return list.Count; } }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            foreach (String prop in list.Keys.ToArray())
              //  if (!String.IsNullOrWhiteSpace(list[prop]))
                    res.Append(prop + "=" + list[prop] + "\r\n");
            return res.ToString();
        }

    }
}
