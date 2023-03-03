using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpefyClassLibrary.Models
{
    public class TrackDatasetContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }

        public string DbPath { get; }

        public TrackDatasetContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "TracksDataset.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite($"Data Source ={DbPath}");
    }

    public class Track
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Generes { get; set; }
        public float Acousticness { get; set; }
        public float Danceability { get; set; }
        public float Energy { get; set; }
        public float Instrumentalness { get; set; }
        public int Key { get; set; }
        public float Liveness { get; set; }
        public float Loudness { get; set; }
        public int Mode { get; set; }
        public float Speechiness { get; set; }
        public float Tempo { get; set; }
        public float Valence { get; set; }
        public int Time_signature { get; set; }
        public int Popularity { get; set; }

    }

}
