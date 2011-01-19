using System.Linq;
using System.Web.Mvc;
using Web.Models.Domain;
using Web.Models.ViewModels;
using Web.Storage;

namespace Web.Controllers
{   
    public class KanbanBoardController : Controller
    {
        private readonly IKanbanBoardRepository repository;

        public KanbanBoardController(IKanbanBoardRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /KanbanBoard/

        public ViewResult Index()
        {
            var vm = new KanbanBoardIndexViewModel
                         {
                             TopFavoritedKanbanBoards =
                                 repository.GetAllKanbanBoards()
                                    .OrderByDescending(x => x.TimesFavorited)
                                    .Take(3)
                                    .ToList()
                         };

            return View("Index", vm);
        }

        //
        // GET: /KanbanBoard/Details/5

        public ViewResult Details(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // GET: /KanbanBoard/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /KanbanBoard/Create

        [HttpPost]
        public ActionResult Create(KanbanBoard d)
        {
            if (ModelState.IsValid)
            {
              this.repository.Add(d);
              this.repository.Save();
              return RedirectToAction("Index");  
            }
            return View();
        }
        
        //
        // GET: /KanbanBoard/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(this.repository.GetById(id));
        }

        //
        // POST: /KanbanBoard/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            var d = this.repository.GetById(id);
            if (TryUpdateModel(d))
            {
                this.repository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /KanbanBoard/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(this.repository.GetById(id));
        }

        //
        // POST: /KanbanBoard/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.repository.Delete(id);
            this.repository.Save();

            return RedirectToAction("Index");
        }
    }
}