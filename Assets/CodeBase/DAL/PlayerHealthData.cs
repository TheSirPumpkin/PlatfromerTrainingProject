using UnityEngine;

namespace Player.DAL
{
    [CreateAssetMenu(fileName = "PlayerHealthData", menuName = "DAL/PlayerHealthData")]
    public class PlayerHealthData : ScriptableObject
    {
        [Range(1, 5)]
        public int Health = 1;
        public AudioClip HitClip;
        public AudioClip DeathClip;
    }
}