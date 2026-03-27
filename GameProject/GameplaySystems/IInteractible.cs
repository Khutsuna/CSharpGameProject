using GameProject.Models.Characters;
using GameProject.Models.Enums;

namespace GameProject.GameplaySystems
{
    public interface IInteractible
    {
        void Interact(Player player, LocationType currentLocation);
    }
}
