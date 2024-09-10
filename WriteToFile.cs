using System.IO;
using UnityEngine;

namespace PureFunctions
{
    public abstract class WriteToFile
    {
        private string filePath = $"{Application.persistentDataPath}/SetYourCustomFilePathWithThe'{nameof(SetDataPath)}'Method.csv";

        protected void SetDataPath(string path)
        {
            filePath = path;
        }
    
        protected void Write(string content, bool append = true)
        {
            TextWriter tw = new StreamWriter(filePath, append);
            tw.WriteLine(content);
            tw.Close();
        }
    }
}