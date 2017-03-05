namespace SoftUniStore.Models.ViewModels
{
    using System.Collections;
    using System.Collections.Generic;

    public class GameViewModelsCollection
    {
        public GameViewModelsCollection()
        {
            this.Games = new List<GameViewModel>();
        }

        public bool IsLogged { get; set; }

        public IList<GameViewModel> Games { get; set; }
    }
}
