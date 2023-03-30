using SpotifyAPI.Web;

namespace SpefyTests
{
    public class MappingTest
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
        }
    }
}