using Spefy.Contract.Dtos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Contract.Dtos.Artist
{
    public class ArtistDataDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public List<string> Generes { get; set; }
        public FollowersDto followers { get; set; }
    }
}
