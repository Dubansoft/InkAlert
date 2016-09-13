//  Copyright 2015 Jhorman Duban Rodríguez Pulgarín
//  
//  This file is part of InkAlert.
//  
//  InkAlert is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  
//  InkAlert is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with InkAlert.  If not, see <http://www.gnu.org/licenses/>.
//  
//  Jhorman Duban Rodríguez., hereby disclaims all copyright interest in 
//  the program "InkAlert" (which makes passes at 
//  compilers) written by Jhorman Duban Rodríguez.
//  
//  Jhorman Duban Rodríguez,
//  5 January 2016
//  For more information, visit <http://www.codigoinnovador.com/projects/inkalert/>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace InkAlert
{
    public class FileManager
    {
        #region "Members"

        private static string textToAppend;
        public static string TextToAppend
        {
            get { return FileManager.textToAppend; }
            set { FileManager.textToAppend = value; }
        }

        public string Text
        {
            set { TextToAppend = value; }
        }

        public static Action WriteFileDelegate;

        private string folderPath;
        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        public string FullFilePath
        {
            get { return folderPath + "\\" + fileName; }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        #endregion

        /// <summary>
        /// FileManager initialiser with path and filename parameters
        /// Use it when creating and writing to a file different from
        /// the log file
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="newFileName"></param>
        public FileManager(string filePath, string newFileName)
        {
            this.FileName = newFileName;
            this.FolderPath = filePath;
        }

        /// <summary>
        /// Empty fileManager initialiser
        /// Use this initialiser only when writing to the log file
        /// because this will point to the log file by default.
        /// </summary>
        public FileManager(){
            this.FolderPath = GlobalSetup.LogFolderPath;
            this.FileName = GlobalSetup.LogFileName;
        }

        public bool CreateFolder()
        {
            try
            {
                if (Directory.Exists(FolderPath)) 
                {
                    Console.WriteLine("That path exists already.");
                    return true;
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(FolderPath);
                    return true;
                }

            }
            catch (Exception e)
            {
                TextToAppend = e.Message.ToString();
                this.WriteToFile();
                return false;
            }
        }

        public bool CreateFile()
        {
            CreateFolder();

            try
            {
                if (!File.Exists(FullFilePath))
                {
                    File.Create(FullFilePath).Dispose();
                }
                return true;
            }
            catch (Exception e)
            {
                FileHelper.EventLogger.LogEvent(this, e.Message.ToString(),e);
                return false;
            }
        }

        public void WriteToFile()
        {
            CreateFile();

            try
            {
                if (File.Exists(FullFilePath))
                {
                    using (StreamWriter sw = File.AppendText(FullFilePath))
                    {
                        sw.WriteLine(TextToAppend);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                FileHelper.EventLogger.LogEvent(this, e.Message.ToString(),e);
            }
        }

        public string ReadFile()
        {
            try
            {
                if (File.Exists(FullFilePath))
                {
                    string fileText = string.Empty;

                    using (TextReader tr = new StreamReader(FullFilePath))
                    {
                        fileText = tr.ReadToEnd();
                        tr.Close(); 
                        return fileText;
                    }
                }
                return string.Empty;
            }
            catch (Exception e)
            {
                FileHelper.EventLogger.LogEvent(this, e.Message.ToString(),e);
                return string.Empty;
            }
        }

        public void RemoveFile()
        {
            try
            {
                File.Delete(FullFilePath);
            }
            catch (Exception e)
            {
                FileHelper.EventLogger.LogEvent(this, e.Message.ToString(),e);
            }
        }
    }
}
