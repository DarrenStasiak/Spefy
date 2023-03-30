using Shouldly;
using Spefy.Core.Mappers;
using SpotifyAPI.Web;

namespace Spefy.Tests
{
    public class MappingTests
    {
        [Fact]
        public void given_follower_convert_it_to_dto_should_succeed()
        {
            Followers followers = new Followers()
            {
                Href = "href",
                Total = 100
            };

            var toDto = followers.ToDto();

            toDto.href.ShouldBe("href");
            toDto.total.ShouldBe(100);
        }
        [Fact]
        public void given_FullArtist_convert_to_dto_should_succeed()
        {
            FullArtist fullArtist = new FullArtist()
            {
                Name = "name",
                Genres = new List<string>() { "xx" },
                Popularity = 100
            };

            var toDto = fullArtist.ToDto();

            toDto.Name.ShouldBe("name");
            toDto.Popularity.ShouldBe(100);
            toDto.Generes[0].ShouldBe("xx");
        }
    }
}