using FamilyBoard;
using FamilyBoardUI;
using System.Web.Mvc;

namespace FamilyBoardUI.Controllers
{
    public class FileController : Controller
    {
        private FamilyBoardModel db = new FamilyBoardModel();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}
