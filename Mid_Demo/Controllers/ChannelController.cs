using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mid_Demo.DTO;
using Mid_Demo.EF;  
namespace Mid_Demo.Controllers
{
    public class ChannelController : Controller
    {
        private readonly TRP_TablaEntities1 db = new TRP_TablaEntities1();

        public static Channel_Table ConvertToEntity(ChannelDTO channelDTO)
        {
            return new Channel_Table()
            {
                ChannelId = channelDTO.ChannelId,
                ChannelName = channelDTO.ChannelName,
                EstablishedYear = channelDTO.EstablishedYear,
                Country = channelDTO.Country
            };
        }

        public static ChannelDTO ConvertToDTO(Channel_Table channel)
        {
            return new ChannelDTO()
            {
                ChannelId = channel.ChannelId,
                ChannelName = channel.ChannelName,
                EstablishedYear = channel.EstablishedYear,
                Country = channel.Country
            };
        }

        public static List<ChannelDTO> ConvertToDTOList(List<Channel_Table> channels)
        {
            var list = new List<ChannelDTO>();
            foreach (var c in channels)
            {
                list.Add(ConvertToDTO(c));
            }
            return list;
        }

        public ActionResult List(int page = 1, int pageSize = 10)
        {
            var totalChannels = db.Channel_Table.Count();
            var totalPages = (int)Math.Ceiling((double)totalChannels / pageSize);

            if (page > totalPages) page = totalPages;
            if (page < 1) page = 1; 

            
            var paginatedChannels = db.Channel_Table
                .OrderBy(c => c.ChannelId) 
                .Skip((page - 1) * pageSize) 
                .Take(pageSize) 
                .ToList();

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(ConvertToDTOList(paginatedChannels));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ChannelDTO channelDTO)
        {
            if (ModelState.IsValid)
            {
                if (db.Channel_Table.Any(c => c.ChannelName == channelDTO.ChannelName))
                {
                    ModelState.AddModelError("ChannelName", "Channel Name must be unique.");
                    return View(channelDTO);
                }

                var channelEntity = ConvertToEntity(channelDTO);
                db.Channel_Table.Add(channelEntity);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Channel added successfully.";
                return RedirectToAction("List");
            }

            return View(channelDTO);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var channel = db.Channel_Table.FirstOrDefault(c => c.ChannelId == id);
            if (channel == null)
            {
                TempData["ErrorMessage"] = "Channel not found.";
                return RedirectToAction("List");
            }

            return View(ConvertToDTO(channel));
        }

        [HttpPost]
        public ActionResult Edit(ChannelDTO channelDTO)
        {
            if (ModelState.IsValid)
            {
                var existingChannel = db.Channel_Table.FirstOrDefault(c => c.ChannelId == channelDTO.ChannelId);
                if (existingChannel == null)
                {
                    TempData["ErrorMessage"] = "Channel not found.";
                    return RedirectToAction("List");
                }

                if (db.Channel_Table.Any(c => c.ChannelName == channelDTO.ChannelName && c.ChannelId != channelDTO.ChannelId))
                {
                    ModelState.AddModelError("ChannelName", "Channel Name must be unique.");
                    return View(channelDTO);
                }

                existingChannel.ChannelName = channelDTO.ChannelName;
                existingChannel.EstablishedYear = channelDTO.EstablishedYear;
                existingChannel.Country = channelDTO.Country;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Channel updated successfully.";
                return RedirectToAction("List");
            }

            return View(channelDTO);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var channel = db.Channel_Table.FirstOrDefault(c => c.ChannelId == id);
            if (channel == null)
            {
                TempData["ErrorMessage"] = "Channel not found.";
                return RedirectToAction("List");
            }



            return View(ConvertToDTO(channel));
        }



        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var channel = db.Channel_Table.FirstOrDefault(c => c.ChannelId == id);
            if (channel == null)
            {
                TempData["ErrorMessage"] = "Channel not found.";
                return RedirectToAction("List");
            }

            db.Channel_Table.Remove(channel);
            db.SaveChanges();

            TempData["SuccessMessage"] = "Channel deleted successfully.";
            return RedirectToAction("List");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        var channel = db.Channel_Table.FirstOrDefault(c => c.ChannelId == id);
        //        if (channel == null)
        //        {
        //            TempData["ErrorMessage"] = "Channel not found.";
        //            return RedirectToAction("List");
        //        }

        //        db.Channel_Table.Remove(channel);
        //        db.SaveChanges();

        //        TempData["SuccessMessage"] = "Channel deleted successfully.";
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = $"Error deleting channel: {ex.Message}";
        //    }

        //    return RedirectToAction("List");
        //}




        public ActionResult Search(string searchText, int page = 1, int pageSize = 10)
        {
            var filteredChannels = db.Channel_Table
                .Where(c => string.IsNullOrEmpty(searchText) ||
                            c.ChannelName.ToLower().Contains(searchText.ToLower()) ||
                            c.Country.ToLower().Contains(searchText.ToLower()))
                .ToList();

            var totalChannels = filteredChannels.Count();
            var totalPages = (int)Math.Ceiling((double)totalChannels / pageSize);

            if (page > totalPages) page = totalPages;

            var paginatedChannels = filteredChannels
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            ViewBag.SearchQuery = searchText;

            return View("List", ConvertToDTOList(paginatedChannels));
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
