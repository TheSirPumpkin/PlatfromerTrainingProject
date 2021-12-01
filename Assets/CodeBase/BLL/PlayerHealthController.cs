using Player.DAL;
using Services;
using UnityEngine;

namespace Player.BLL
{
    public class PlayerHealthController : IPlayerHealth
    {
        public bool Dead { get; set; }

        private IGameStopScreen gameStopScreen;
        private PlayerHealthData playerHealthData;
        private int health;
        private AudioSource playerAudio;
        private AudioClip hitClip;
        private AudioClip deathClip;
        private Animator playerAnimator;

        public PlayerHealthController(IGameStopScreen gameStopScreen)
        {
            playerHealthData = Resources.Load<PlayerHealthData>(PathConstants.PlayerHealthDataPath);
            health = playerHealthData.Health;
            hitClip = playerHealthData.HitClip;
            deathClip = playerHealthData.DeathClip;

            this.gameStopScreen = gameStopScreen;
        }

        public void InitPlayerHealthController(Animator playerAnimator)
        {
            this.playerAnimator = playerAnimator;
        }

        public void TakeDamage(int damage, AudioSource audio)
        {
            if (Dead)
            {
                return;
            }
            if (playerAudio == null)
            {
                playerAudio = audio;
            }

            playerAudio.PlayOneShot(hitClip);

            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Dead = true;
            playerAudio.PlayOneShot(deathClip);
            playerAnimator.SetInteger("Dead", 1);
            gameStopScreen.CallEndGameScreen();
        }

        public int GetInitialHealth()
        {
            return playerHealthData.Health;
        }

        public int GetCurrentHealth()
        {
            return health;
        }

        public void Ressurect()
        {
            Dead = false;
            playerAudio.PlayOneShot(deathClip);
            playerAnimator.SetInteger("Dead", 0);
            gameStopScreen.CallEndGameScreen();
            health = GetInitialHealth(); 
        }
    }
}
