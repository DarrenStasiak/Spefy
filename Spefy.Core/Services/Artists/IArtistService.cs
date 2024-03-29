﻿using Spefy.Contract.Dtos.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Artists
{
    public interface IArtistService
    {
        Task<ArtistDataDto> GetArtistById(string Id);
        Task<List<string>> SearchForArtists(string query);
    }
}
