using Player.DAL;
using Services;
using UnityEngine;

namespace Player.BLL
{
    public class CameraFollowController : ICameraMovement
    {
        public Transform Player { get; set; }

        private CameraFollowData cameraFollowData;
        private float followSpped;
        private float heightAdjustment;


        public CameraFollowController()
        {
            cameraFollowData = Resources.Load<CameraFollowData>(PathConstants.CameraDataPath);
            followSpped = cameraFollowData.FollowSpeed;
            heightAdjustment = cameraFollowData.HeightAdjustment;
        }

        public void Follow(Transform camera)
        {
            if (Player == null)
            {
                return;
            }

            if (Input.GetAxis("Vertical") >= 0)
            {
                camera.position = Vector3.Slerp(camera.position, new Vector3(Player.position.x, Player.position.y + heightAdjustment, -10), Time.deltaTime * followSpped);
            }

            if (Input.GetAxis("Vertical") < 0)
            {
                camera.position = Vector3.Slerp(camera.position, new Vector3(Player.position.x, Player.position.y - heightAdjustment, -10), Time.deltaTime * followSpped);
            }
        }
    }
}
