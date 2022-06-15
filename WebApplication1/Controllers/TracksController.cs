using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TracksController : Controller
    {
        private readonly WebApplication1Context _context;

        public TracksController(WebApplication1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {            
            var tracks = from t in _context.Track
                 select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                tracks = tracks.Where(s => s.Title!.Contains(searchString) || s.Subtitle!.Contains(searchString));
            }
            return View(await tracks.ToListAsync());             
        }

        public IActionResult Add(string Key, string Title, string Subtitle, string Background, string Coverart, string Genres, string Text, string Footer, string Caption, string Uri) {
            Track track = new
                (
                    Key,
                    Title,
                    Subtitle,
                    Background,
                    Coverart,
                    Genres,
                    Text,
                    Footer,
                    Caption,
                    Uri
                );
            return View(track);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Key,Title,Subtitle,Background,Coverart,Genres,Text,Footer,Caption,Uri")] Track track) {
            if (ModelState.IsValid)
            {
                _context.Add(track);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(track);            
        }

        // GET: Tracks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Track == null)
            {
                return NotFound();
            }

            var track = await _context.Track
                .FirstOrDefaultAsync(m => m.Key == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        public async Task<IActionResult> GetLink(string id) {
            HttpClient client = new HttpClient();           
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.baseurlDownload}/dl?id={id}"),
                Headers =
                {
                    { "X-RapidAPI-Host", Constants.hostDownload },
                    { "X-RapidAPI-Key", Constants.apikey },
                },
            };
            DownloadLink result;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<DownloadLink>(content);
            }
            Process.Start(new ProcessStartInfo
            {
                FileName = result.Link,
                UseShellExecute = true
            });
            return RedirectToAction("Index");
        }





        // GET: Tracks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Key,Title,Subtitle,Background,Coverart,Genres,Text,Footer,Caption,Uri")] Track track)
        {
            if (ModelState.IsValid)
            {
                _context.Add(track);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // GET: Tracks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Track == null)
            {
                return NotFound();
            }

            var track = await _context.Track.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Key,Title,Subtitle,Background,Coverart,Genres,Text,Footer,Caption,Uri")] Track track)
        {
            if (id != track.Key)
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
                    if (!TrackExists(track.Key))
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
            return View(track);
        }

        // GET: Tracks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Track == null)
            {
                return NotFound();
            }

            var track = await _context.Track
                .FirstOrDefaultAsync(m => m.Key == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Track == null)
            {
                return Problem("Entity set 'WebApplication1Context.Track'  is null.");
            }
            var track = await _context.Track.FindAsync(id);
            if (track != null)
            {
                _context.Track.Remove(track);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(string id)
        {
          return _context.Track.Any(e => e.Key == id);
        }
    }
}
