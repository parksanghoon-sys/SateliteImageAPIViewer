using System;
using Microsoft.EntityFrameworkCore;
using Musician.MVVM.Models;

namespace Musician.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        DbSet<Music> Musics { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Playlist> Playlists { get; set; }
    }
}
