using Spefy.Contract.Dtos.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Tracks
{
    public interface ITrackService
    {
        Task<TrackDataDto> GetTrackById(string id);
        Task<List<string>> SearchForTracks(string query);
    }
}
