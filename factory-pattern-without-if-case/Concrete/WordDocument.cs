using factory_pattern_without_if_case.Interface;
using System;

namespace factory_pattern_without_if_case.Concrete
{
    public class WordDocument : IDocument
    {
        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public string GetDocumentType()
        {
            return "WORD";
        }
    }
}
