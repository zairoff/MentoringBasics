namespace OOP.Contract
{
    public interface IMagazine : IDocument
    {
        public string Publisher { get; set; }

        public int ReleaseNumber { get; set; }
    }
}
