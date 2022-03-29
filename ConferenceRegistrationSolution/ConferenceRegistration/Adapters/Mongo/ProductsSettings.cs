namespace ConferenceRegistration.Adapters.Mongo
{
    public class ProductsSettings
    {
        public static string SectionName = "ProductsSection";
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string CollectionName { get; set; } = "";

    }
}
