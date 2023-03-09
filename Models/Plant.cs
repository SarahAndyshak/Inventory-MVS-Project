namespace Inventory.Models
{
  public class Plant
  {
    public int PlantId { get; set; }
    public string Description { get; set; }
    public int CollectionId { get; set; }
    public Collection Collection { get; set; }
  }
}