using Player.BLL;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PL
{
    public class CameraFollowView : MonoBehaviour
    {
        private ICameraMovement cameraFollowController;

        void Start()
        {
            cameraFollowController = AllServices.Container.Single<ICameraMovement>();
        }
        private void FixedUpdate()
        {
            cameraFollowController.Follow(transform);
        }
    }
}
