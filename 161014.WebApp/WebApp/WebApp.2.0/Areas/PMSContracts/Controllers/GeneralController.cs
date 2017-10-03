using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.PMSContracts.Models;
using excel = Microsoft.Office.Interop.Excel;
namespace WebApp.Areas.PMSContracts.Controllers
{
    public class GeneralController : Controller
    {
        //
        // GET: /PMSContracts/General/
        PMSDataContext objContext = new PMSDataContext();
        public ActionResult Index()
        {
            var tbGeneral = objContext.CONTRACTS_CONDITIONS_GENERAL.OrderByDescending(s => s.ContractID).Take(10).ToList();
            return View(tbGeneral);
        }
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            if (excelfile==null||excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please select a excel file";
                return View("Index", "General");
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Areas/PMSContracts/" + excelfile.FileName);
                    //string fileName = Path.GetFileName(excelfile.FileName);
                    //string path = Path.Combine(Server.MapPath("~/Areas/PMSContracts/"), fileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelfile.SaveAs(path);
                    // Read dataz from excel file
                    excel.Application application = new excel.Application();
                    excel.Workbook workbook = application.Workbooks.Open(path);
                    excel.Worksheet worksheet = workbook.ActiveSheet;
                    excel.Range range = worksheet.UsedRange;
                    List<GeneralModel> genct = new List<GeneralModel>();
                   
                    for (int row=3; row <= range.Rows.Count; row++)
                    {
                        GeneralModel g = new GeneralModel();
                        g.ContractID = int.Parse(((excel.Range)range.Cells[row, 1]).Text);
                        g.ClauseCode = ((excel.Range)range.Cells[row, 2]).Text;
                        g.ClauseContent = ((excel.Range)range.Cells[row, 3]).Text;
                        g.OriginalLanguage = ((excel.Range)range.Cells[row, 4]).Text;
                        g.ClauseCode = ((excel.Range)range.Cells[row, 5]).Text;
                        g.ParentId = int.Parse(((excel.Range)range.Cells[row,6]).Text);
                        g.BookType = ((excel.Range)range.Cells[row,7]).Text;
                        g.CreationDate = ((excel.Range)range.Cells[row, 8]).Text;
                        g.Type = ((excel.Range)range.Cells[row, 9]).Text;
                        genct.Add(g);
                     
                    }
                    ViewBag.genct = genct;
                    return View("Index", "General");
                }
                else
                {
                    ViewBag.Error = "File type is incorrect<br>";
                    return View("Index", "General");
                }
            }
        }
        public ActionResult Create() // For view layer
        {
            return View(new GeneralModel());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tbGeneral = objContext.CONTRACTS_CONDITIONS_GENERAL.Find(id);
            if (tbGeneral == null)
            {
                return HttpNotFound();
            }
            return View(tbGeneral);
        }
        //


        //
        // POST: /PMSContracts/General/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PMSContracts/General/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PMSContracts/General/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PMSContracts/General/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PMSContracts/General/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
