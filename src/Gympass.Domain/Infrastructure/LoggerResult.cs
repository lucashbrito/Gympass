﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Gympass.Domain.Interfaces;

namespace Gympass.Domain.Infrastructure
{
    public class LoggerResult : ILoggerResult
    {
        private string _path = $@"{Directory.GetCurrentDirectory()}\\Assets\\Documents\\LoggerResult.txt";
        private string[] _lines;

        public string[] ReadResult(string path)
        {
            var list = ReadFile(path);
            _lines = list.ToArray();

            return _lines;
        }

        public string[] ReadResult()
        {
            var list = ReadFile(_path);
            _lines = list.ToArray();

            return _lines;
        }

        private static List<string> ReadFile(string path)
        {
            var list = new List<string>();

            try
            {
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return list;
        }
    }
}
