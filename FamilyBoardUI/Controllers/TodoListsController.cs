using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyBoard;

namespace FamilyBoardUI.Controllers
{
    public class TodoListsController : Controller
    {
        private FamilyBoardModel db = new FamilyBoardModel();

        // GET: TodoLists
        public ActionResult Index()
        {
            var todoLists = db.TodoLists.Include(t => t.User);
            return View(todoLists.ToList());
        }

        ////GET: Mark todo list as done
        public ActionResult Done(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = db.TodoLists.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", todoList.UserId);
            return View(todoList);
        }

        //// POST: TodoLists/Done/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Done([Bind(Include = "Id,Done,Content,DateCreated,DateCompleted,UserId")] TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", todoList.UserId);
            return View(todoList);
        }


        //GET: TodoLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = db.TodoLists.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            return View(todoList);
        }

        // GET: TodoLists/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: TodoLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Done,Content,DateCreated,DateCompleted,UserId")] TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                db.TodoLists.Add(todoList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", todoList.UserId);
            return View(todoList);
        }

        // GET: TodoLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = db.TodoLists.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", todoList.UserId);
            return View(todoList);
        }

        // POST: TodoLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Done,Content,DateCreated,DateCompleted,UserId")] TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", todoList.UserId);
            return View(todoList);
        }

        
        // GET: TodoLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoList todoList = db.TodoLists.Find(id);
            if (todoList == null)
            {
                return HttpNotFound();
            }
            return View(todoList);
        }

        // POST: TodoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoList todoList = db.TodoLists.Find(id);
            db.TodoLists.Remove(todoList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
