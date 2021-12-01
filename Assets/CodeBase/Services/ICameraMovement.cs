using UnityEngine;
namespace Services
{
    public interface ICameraMovement : IService
    {
        Transform Player { get; set; }
        void Follow(Transform camera);
    }
}