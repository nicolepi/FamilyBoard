using FamilyBoard;
using FamilyBoardUI;
using System.Web.Mvc;

namespace FamilyBoardUI.Controllers
{
    public class VideoFileController : Controller
    {
        private FamilyBoardModel db = new FamilyBoardModel();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.VideoFiles.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}