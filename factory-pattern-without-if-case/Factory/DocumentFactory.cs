using factory_pattern_without_if_case.Concrete;
using factory_pattern_without_if_case.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace factory_pattern_without_if_case.Factory
{
    public class DocumentFactory
    {
        public static IDocument CreateDocument(string documentType)
        {
            if (documentType == "PDF")
                return new PdfDocument();
            else if (documentType == "WORD")
                return new WordDocument();
            else
                return null;
        }

        public static IDocument CreateDocument()
        {
            try
            {
                string a = ConfigurationManager.AppSettings["use-doc-type"];
                
                Type type = Type.GetType("factory_pattern_without_if_case.Concrete." + ConfigurationManager.AppSettings["use-doc-type"].ToString());
                var instance = (IDocument)Activator.CreateInstance(type);

                return instance;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
