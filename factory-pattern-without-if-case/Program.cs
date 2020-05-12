using factory_pattern_without_if_case.Factory;
using factory_pattern_without_if_case.Interface;
using System;

namespace factory_pattern_without_if_case
{
    class Program
    {
        static void Main(string[] args)
        {
            IDocument document = DocumentFactory.CreateDocument("PDF");
            Console.WriteLine("Created Document Type : " + document.GetDocumentType());

            document = DocumentFactory.CreateDocument("WORD");
            Console.WriteLine("Created Document Type : " + document.GetDocumentType());

            Console.ReadLine();
        }
    }
}
