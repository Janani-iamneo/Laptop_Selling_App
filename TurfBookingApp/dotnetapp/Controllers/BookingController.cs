using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Exceptions;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Book(int tableId)
        {
            var table = _dbContext.DiningTables
                .Include(t => t.Bookings)
                .FirstOrDefault(t => t.DiningTableID == tableId);           

            if (table == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Book(int tableId, Booking booking)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(booking);
                }
                var table = _dbContext.DiningTables
                    .Include(t => t.Bookings)
                    .FirstOrDefault(t => t.DiningTableID == tableId);

                if (table == null)
                {
                    return NotFound();
                }

                DateTime targetDate = new DateTime(2024, 4, 25);

                if (booking.ReservationDate < targetDate)
                {

                    Console.WriteLine("Came");
                    throw new TurfBookingException("Booking Starts from 25/4/2024");
                }
                booking.DiningTableID = tableId;

                
                if (ModelState.IsValid)
                {
                    _dbContext.Bookings.Add(booking);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Details", new { bookingId = booking.BookingID });
                }
                return View(booking);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public IActionResult Details(int bookingId)
        {
            var booking = _dbContext.Bookings
                .Include(b => b.DiningTable)
                .FirstOrDefault(b => b.BookingID == bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
    }
}
