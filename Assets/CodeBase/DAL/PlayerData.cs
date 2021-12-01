using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.DAL
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "DAL/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float MoveSpeed;
        public string LightAttackInput;
        public string HeavyAttackInput;
        public string MoveAxis;
        public string JumpButton;
        public float JumpHeight;
    }
}
