using System;

namespace Task1
{
    class CsvLineException : Exception
    {
        private string csvString;
        public string CsvString
        {
            get => csvString;
            set => csvString = value;
        }
        public CsvLineException(string csvString, string message) : base(message)
        {
            this.csvString = csvString;
        }
    }
}
