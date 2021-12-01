using Infrastructure.DAL;
using Services;
using UnityEngine;

namespace Infrastructure.PL
{
    public class LevelCreatorView : MonoBehaviour
    {
        private ILevelCreator levelCreator;
        private void Awake()
        {
            levelCreator = AllServices.Container.Single<ILevelCreator>();
            levelCreator.CreateLevel(this);
        }
    }
}
