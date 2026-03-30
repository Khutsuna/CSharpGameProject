using GameProject.GameplaySystems;
using GameProject.Models.Characters;
using GameProject.Models.Enums;

namespace GameProject.Map
{
    public interface ILocation
    {
        string Name { get; set; }
        string Description { get; set; }
        bool IsLocked { get; set; }
        LocationType Type { get; }
        List<IInteractible> Interactibles { get; set; }
        void ShowMap();
        void ShowOptions();
        ILocation? HandleInput(string input, Player player);
    }
}
