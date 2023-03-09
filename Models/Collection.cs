using System.Collections.Generic;

namespace Inventory.Models
{
  public class Collection
  {
    public int CollectionId { get; set; }
    public string Name { get; set; }
    public List<Plant> Plants { get; set; }
  }
}