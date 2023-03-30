using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Contract.Dtos.Album
{
    public class SimpleAlbumDto
    {
        public string Id { get; set; }
        public string ReleaseDate { get; set; }
        public string Name { get; set; }
        public string Type {  get; set; }
        public string Url { get; set; }
    }
}
