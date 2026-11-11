using System;

namespace SolidRefactoringLab
{
    // 1. OCP: Interface and Concrete Formatters
    public interface IReportFormatter
    {
        void FormatReport();
    }

    public class PdfFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as PDF...");
        }
    }

    public class WordFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a Word Document...");
        }
    }

    public class PlainTextFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as plain text...");
        }
    }
    // 2. SRP: Separate ReportSaver Class
    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }
    // 3. ReportManager using Dependency Injection
    public class ReportManager
    {
        private readonly IReportFormatter _formatter;
        public string ReportData { get; set; } = string.Empty;

        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }
         public void GenerateReport()
        {
            _formatter.FormatReport();
        }
    }

    // 4. Program with Updated Main Method
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Choose the formatter (OCP)
            IReportFormatter formatter = new PdfFormatter();

            // 2. Pass it to the manager
            ReportManager manager = new ReportManager(formatter);
            manager.GenerateReport();

            // 3. Use the dedicated saver (SRP)
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}