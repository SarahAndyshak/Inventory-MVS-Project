using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Controllers
{
  public class PlantsController : Controller
  {
    private readonly InventoryContext _db;

    public PlantsController(InventoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Plant> model = _db.Plants
                            .Include(plant => plant.Collection)
                            .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CollectionId = new SelectList(_db.Collections, "CollectionId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Plant plant)
    {
      if(plant.CollectionId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Plants.Add(plant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Plant thisPlant = _db.Plants.FirstOrDefault(plant => plant.PlantId == id); 
      //"plant => etc" in the parentheses above is a lambda expression, a shortened way of writing an anonymous function
      ViewBag.CollectionId = new SelectList(_db.Collections, "CollectionId", "Name");
      return View(thisPlant);
    }

    [HttpPost]
    public ActionResult Edit (Plant plant)
    {
      _db.Plants.Update(plant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Plant thisPlant = _db.Plants
                          .Include(plant => plant.Collection)
                          .FirstOrDefault(plant => plant.PlantId == id);
      return View(thisPlant);
    }

    public ActionResult Delete(int id)
    {
      Plant thisPlant = _db.Plants.FirstOrDefault(plant => plant.PlantId == id);
      return View(thisPlant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Plant thisPlant = _db.Plants.FirstOrDefault(plant => plant.PlantId == id);
      _db.Plants.Remove(thisPlant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}