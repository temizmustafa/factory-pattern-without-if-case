namespace factory_pattern_without_if_case.Interface
{
    public interface IDocument
    {
        void Open();
        void Close();
        string GetDocumentType();
    }
}
