using System;
using System.Linq;
using System.Web.Mvc;
using Mid_Demo.DTOs;
using Mid_Demo.EF;
using System.Data.Entity;

namespace Mid_Demo.Controllers
{
    public class ProgramController : Controller
    {
        private readonly TRP_TablaEntities1 db = new TRP_TablaEntities1(); // Make sure to replace with your actual DbContext name

        public ActionResult List()
        {
            var programs = db.Program_Table.Include(p => p.Channel_Table).ToList();
            return View(programs);
        }

        public ActionResult Create()
        {
            ViewBag.ChannelList = new SelectList(db.Channel_Table, "ChannelId", "ChannelName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgramDTO model)
        {
            if (ModelState.IsValid)
            {
                bool isProgramNameExists = db.Program_Table.Any(p => p.ProgramName == model.ProgramName && p.CId == model.ChannelId);
                if (isProgramNameExists)
                {
                    ModelState.AddModelError("ProgramName", "Program Name must be unique within the channel.");
                    ViewBag.ChannelList = new SelectList(db.Channel_Table, "ChannelId", "ChannelName", model.ChannelId);
                    return View(model);
                }

                var program = new Program_Table
                {
                    ProgramName = model.ProgramName,
                    TRPScore = model.TRPScore,
                    CId = model.ChannelId,
                    AirTime = model.AirTime
                };

                db.Program_Table.Add(program);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.ChannelList = new SelectList(db.Channel_Table, "ChannelId", "ChannelName", model.ChannelId);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var program = db.Program_Table.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }

            var model = new ProgramDTO
            {
                ProgramId = program.ProgramId,
                ProgramName = program.ProgramName,
                TRPScore = program.TRPScore,
                ChannelId = program.CId,
                AirTime = program.AirTime
            };

            ViewBag.ChannelList = new SelectList(db.Channel_Table, "ChannelId", "ChannelName", program.CId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProgramDTO model)
        {
            if (ModelState.IsValid)
            {
                bool isProgramNameExists = db.Program_Table
                    .Any(p => p.ProgramName == model.ProgramName && p.CId == model.ChannelId && p.ProgramId != model.ProgramId);

                if (isProgramNameExists)
                {
                    ModelState.AddModelError("ProgramName", "Program Name must be unique within the channel.");
                    ViewBag.ChannelList = new SelectList(db.Channel_Table, "ChannelId", "ChannelName", model.ChannelId);
                    return View(model);
                }

                var program = db.Program_Table.Find(model.ProgramId);
                if (program == null)
                {
                    return HttpNotFound();
                }

                program.ProgramName = model.ProgramName;
                program.TRPScore = model.TRPScore;
                program.CId = model.ChannelId;
                program.AirTime = model.AirTime;

                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.ChannelList = new SelectList(db.Channel_Table, "ChannelId", "ChannelName", model.ChannelId);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var program = db.Program_Table.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }

            return View(program);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var program = db.Program_Table.Find(id);
            if (program != null)
            {
                db.Program_Table.Remove(program);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
