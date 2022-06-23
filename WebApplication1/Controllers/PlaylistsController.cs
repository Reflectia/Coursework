using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PlaylistsController : Controller
    {
        private readonly WebApplication1Context _context;

        public PlaylistsController(WebApplication1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _context.Playlist.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Playlist == null) return NotFound();
            var playlist = await _context.Playlist.FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null) return NotFound();

            List<Track> tracks = new List<Track>();
            var tracksById = _context.Track.Where(t => t.PlaylistId == playlist.Id);
            tracks.AddRange(tracksById);
            playlist.Tracks = tracks;

            await _context.SaveChangesAsync();
            return View(playlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Img,TracksCount")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                playlist.TracksCount = 0;
                _context.Add(playlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Playlist == null) return NotFound();
            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist == null) return NotFound();

            List<Track> tracks = new List<Track>();
            var tracksById = _context.Track.Where(t => t.PlaylistId == playlist.Id);
            tracks.AddRange(tracksById);
            playlist.Tracks = tracks;

            return View(playlist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Img,TracksCount")] Playlist playlist)
        {
            if (id != playlist.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var tracksById = _context.Track.Where(t => t.PlaylistId == playlist.Id);
                    playlist.TracksCount = tracksById.Count();
                    _context.Update(playlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.Id)) return NotFound();
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Playlist == null) return NotFound();

            var playlist = await _context.Playlist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null) return NotFound();

            return View(playlist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Playlist == null) return Problem("Entity set 'WebApplication1Context.Playlist'  is null.");

            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist != null) _context.Playlist.Remove(playlist);

            var tracksById = _context.Track.Where(t => t.PlaylistId == playlist.Id);
            foreach(var track in tracksById)
            {
                track.PlaylistId = 0;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(int id)
        {
          return _context.Playlist.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTrack(int id) 
        {
            var track = await _context.Track.FindAsync(Constants.trackId);
            var playlist = await _context.Playlist.FindAsync(id);           

            if (track.PlaylistId == 0)
            {
                track.PlaylistId = playlist.Id;
                playlist.TracksCount += 1;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteTrack(string trackId, string playlistId) 
        {
            var track = await _context.Track.FindAsync(trackId);
            track.PlaylistId = 0;
           
            var playlist = await _context.Playlist.FindAsync(int.Parse(playlistId));
            playlist.TracksCount -= 1;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
