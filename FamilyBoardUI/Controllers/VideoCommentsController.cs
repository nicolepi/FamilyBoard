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
    public class VideoCommentsController : Controller
    {
        private FamilyBoardModel db = new FamilyBoardModel();

        // GET: VideoComments



        public ActionResult Index(int id)
        {
            var videoComments = from p in db.VideoComments where p.VideoId == id select p;
            return View(videoComments.ToList());
        }



        //public ActionResult Index()
        //{
        //    var videoComments = db.VideoComments.Include(v => v.User).Include(v => v.Video);
        //    return View(videoComments.ToList());
        //}

        // GET: VideoComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoComment videoComment = db.VideoComments.Find(id);
            if (videoComment == null)
            {
                return HttpNotFound();
            }
            return View(videoComment);
        }

        // GET: VideoComments/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title");
            return View();
        }

        // POST: VideoComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,DateCreated,VideoId,UserId")] VideoComment videoComment)
        {
            if (ModelState.IsValid)
            {
                db.VideoComments.Add(videoComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", videoComment.UserId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title", videoComment.VideoId);
            return View(videoComment);
        }

        // GET: VideoComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoComment videoComment = db.VideoComments.Find(id);
            if (videoComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", videoComment.UserId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title", videoComment.VideoId);
            return View(videoComment);
        }

        // POST: VideoComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,DateCreated,VideoId,UserId")] VideoComment videoComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", videoComment.UserId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title", videoComment.VideoId);
            return View(videoComment);
        }

        // GET: VideoComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoComment videoComment = db.VideoComments.Find(id);
            if (videoComment == null)
            {
                return HttpNotFound();
            }
            return View(videoComment);
        }

        // POST: VideoComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoComment videoComment = db.VideoComments.Find(id);
            db.VideoComments.Remove(videoComment);
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
