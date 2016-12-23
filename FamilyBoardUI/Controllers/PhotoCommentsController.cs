using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyBoard;

//Controller

namespace FamilyBoardUI.Controllers
{
    public class PhotoCommentsController : Controller
    {
        private FamilyBoardModel db = new FamilyBoardModel();

        //original code
        public ActionResult Index()
        {
            var photoComments = db.PhotoComments.Include(p => p.Photo).Include(p => p.User);
            return View(photoComments.ToList());
        }


        // GET: PhotoComments


        public ActionResult ViewComment(int? id)
        {
           
            var photoComments = from p in db.PhotoComments where p.PhotoId == id select p;
            var photo = from p in db.Photos where p.Id == id select p;
            return View(new FamilyBoardUI.Models.CommentWithPhotoModel(photoComments.ToList(), photo.First()));
        }




        // GET: PhotoComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoComment photoComment = db.PhotoComments.Find(id);
            if (photoComment == null)
            {
                return HttpNotFound();
            }
            return View(photoComment);
        }

        // GET: PhotoComments/Create
        public ActionResult Create(int? photoId, String user)
        {
            ViewBag.PhotoId = new SelectList(db.Photos.Where(p => p.Id == photoId.Value), "Id", "Title");
            ViewBag.UserId = new SelectList(db.Users.Where(p => p.EmailAddress == user), "Id", "UserName");
            return View();
        }

        // POST: PhotoComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,DateCreated,PhotoId,UserId")] PhotoComment photoComment)
        {
            if (ModelState.IsValid)
            {
                db.PhotoComments.Add(photoComment);
                db.SaveChanges();
                return RedirectToAction("Index", "Photos");
            }

            ViewBag.PhotoId = new SelectList(db.Photos, "Id", "Title", photoComment.PhotoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", photoComment.UserId);
            return RedirectToAction("Index", "Photos");
        }

        // GET: PhotoComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoComment photoComment = db.PhotoComments.Find(id);
            if (photoComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhotoId = new SelectList(db.Photos, "Id", "Title", photoComment.PhotoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", photoComment.UserId);
            return View(photoComment);
        }

        // POST: PhotoComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,DateCreated,PhotoId,UserId")] PhotoComment photoComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photoComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhotoId = new SelectList(db.Photos, "Id", "Title", photoComment.PhotoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", photoComment.UserId);
            return View(photoComment);
        }

        // GET: PhotoComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoComment photoComment = db.PhotoComments.Find(id);
            if (photoComment == null)
            {
                return HttpNotFound();
            }
            return View(photoComment);
        }

        // POST: PhotoComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhotoComment photoComment = db.PhotoComments.Find(id);
            db.PhotoComments.Remove(photoComment);
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
