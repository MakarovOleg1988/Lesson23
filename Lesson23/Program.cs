using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson23
{
    class Program
    {
        static object _lock = new object();
        static void Main(string[] args)
        {
            WriteAndReadFileAsync2();
            Console.ReadLine();
        }

        static void WriteAndReadFileAsync2()
        {
            var _thread = new Thread(() => _ReaderFile(WriteFile("MyFile.txt"))); // Создание нового потока данных
            _thread.Start();

        }

        private static string WriteFile(string _fileName)
        {
            _fileName = "d://" + _fileName;

            using (var _file = File.Create(_fileName))
            {
                using (var _writer = new StreamWriter(_file))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        _writer.WriteLine("This is Async");
                        Thread.Sleep(500);
                    }
                }
            }

            return _fileName;
        }

        private static void _ReaderFile(string _fileName)
        {
            var _file = File.OpenRead(_fileName);
            var _reader = new StreamReader(_file);
            Console.WriteLine(_reader.ReadToEnd());

            _reader.Close();
            _file.Close();
        }
    }
}

