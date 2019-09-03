using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyJukeBox.Models;

namespace MyJukeBox.Controllers
{
    public class TracksController : Controller
    {
        private readonly JukeBoxContext _context;

        public TracksController(JukeBoxContext context)
        {
            _context = context;
        }

        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            // To DO: replce the lsit 

            var jukeBoxContext = _context.Tracks.Include(t => t.Artist);
            return View(await jukeBoxContext.ToListAsync());
        }

        // GET: Tracks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .Include(t => t.Artist)
                .FirstOrDefaultAsync(m => m.TrackID == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            // TODO: Change list of ID to Names

            var mylist = from artist in _context.Artists select artist.Name;

            ViewData["Artists"] = mylist;
            //ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistID");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create([Bind("TrackID, ArtistID, Title,Description,Duration,ImageURL")] Track track)
        public async Task<IActionResult> Create(string ArtistID, string Title, string Description, float Duration, string ImageURL)
        {
            Track track = new Track();

            var ids = from artist in _context.Artists where artist.Name == ArtistID select artist.ArtistID;

            track.ArtistID = ids.First(); // should only be the one
            //track.TrackID = TrackID;
            track.Description = Description;
            track.Duration = Duration;
            track.Title = Title;
            track.ImageURL = ImageURL;

            if (ModelState.IsValid)
            {
                _context.Add(track);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var mylist = from artist in _context.Artists select artist;
            ViewData["Artists"] = mylist;
            //ViewData["ArtistID"] = new SelectList(mylist, "Name", "Artist");

            //ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistID", track.ArtistID);
            return View(track);
        }

        // GET: Tracks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            // get list of artist names
            var mylist = from a in _context.Artists select a.Name;

            ViewData["Artists"] = mylist;

            // find the selected artist name 
            var artist = (string) (from a in _context.Artists where a.ArtistID == track.ArtistID select a.Name).First();

            // set up view data
            ViewData["Artist"] = artist;
            ViewData["ArtistID"] = mylist;

            //ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistID", track.ArtistID);
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Artist, string Title,string Description,float Duration,string ImageURL)
        //public async Task<IActionResult> Edit(int id, [Bind("TrackID,ArtistID,Title,Description,Duration,ImageURL")] Track track)
        {
            Track track = new Track();
            track.TrackID = id;
            var aid = (from ar in _context.Artists where ar.Name == Artist select ar.ArtistID).First();

            track.ArtistID = aid;
            track.Title = Title;
            track.Description = Description;
            track.Duration = Duration;
            track.ImageURL = ImageURL;
            if (id != track.TrackID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(track);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.TrackID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var mylist = from a in _context.Artists select a.Name;

            ViewData["Artists"] = mylist;

            // find the selected artist name 
            var artist = (string)(from a in _context.Artists where a.ArtistID == track.ArtistID select a.Name).First();

            // set up view data
            ViewData["Artist"] = artist;
            ViewData["ArtistID"] = mylist;

            //ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistID", track.ArtistID);
            return View(track);
        }

        // GET: Tracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks
                .Include(t => t.Artist)
                .FirstOrDefaultAsync(m => m.TrackID == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.TrackID == id);
        }
    }
}
