using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.DAL
{
    [CreateAssetMenu(fileName = "CameraFollowData", menuName = "DAL/CameraFollowData")]
    public class CameraFollowData : ScriptableObject
    {
        public float FollowSpeed;
        public float HeightAdjustment;
    }
}
