using EphemeralEnvironments.API.Interfaces;

namespace EphemeralEnvironments.API.Repositories
{
    public class VibesRepository : IVibesRepository
    {
        public List<string> GetVibes()
        {
            return new List<string>() {
                "Chill AF Vibes",
                "Positive Vibes Only (No Negativity Allowed)",
                "Vibing on a Whole New Level",
                "Upbeat and Groovy",
                "Laid-back Like a Sloth in a Hammock",
                "Cozy Blanket Fort Vibes",
                "Good Vibes and Good Times",
                "Mellow Yellow, Dude",
                "Excitement Level: Over 9000",
                "Peace, Love, and Pizza Rolls",
                "Joyful Jamboree",
                "Vibing Harder Than a Dancing Cat",
                "Calm as a Cucumber (With Extra Coolness)",
                "Lively AF and Living Large",
                "Elegance Level: Classy Cat Wearing a Tuxedo",
                "Nostalgia Trip: 90s Kids Edition",
                "Adventures in Flavor Town",
                "Romance Level: Cheesy Rom-Com Marathon",
                "Deep Thoughts, Shallow Pockets",
                "Diverse AF Vibes: Like a Playlist on Shuffle"
            };
        }

    }
}
