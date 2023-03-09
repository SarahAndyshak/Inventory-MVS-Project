using System.Collections.Generic;

namespace Inventory.Models
{
  public class Inventory
  {
    public int InventoryId { get; set; }
    public string Name { get; set; }
    public List<Plant> Plants { get; set; }
  }
}