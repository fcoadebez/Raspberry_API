namespace Interface_Mongo_Http
{
    public interface IProduct
    {

        string MachineId { get; set; }

        string Name { get; set; }

        int CurrentStock { get; set; }

        int MaxStock { get; set; }

        string ImageUrl { get; set; }

        string Category { get; set; }

    }
}