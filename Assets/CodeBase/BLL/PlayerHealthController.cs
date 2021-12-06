using Player.DAL;
using Player.Inventroy.DAL;
using Services;
using UnityEngine;

namespace Player.BLL
{
    public class PlayerHealthController : IPlayerHealth
    {
        public bool Dead { get; set; }

        private IGameStopScreen gameStopScreen;
        private IHealthHud healthHud;
        private IPlayerInventory playerInventory;
        private IInventoryScreen inventoryScreen;
        private PlayerHealthData playerHealthData;
        private int health;
        private AudioSource playerAudio;
        private AudioClip hitClip;
        private AudioClip deathClip;
        private Animator playerAnimator;

        public PlayerHealthController(IGameStopScreen gameStopScreen, IPlayerInventory playerInventory)
        {
            playerHealthData = ScriptableObjectsContainer.Instance.PlayerHealthData;//Resources.Load<PlayerHealthData>(PathConstants.PlayerHealthDataPath);
            health = playerHealthData.Health;
            hitClip = playerHealthData.HitClip;
            deathClip = playerHealthData.DeathClip;

            this.gameStopScreen = gameStopScreen;
            this.playerInventory = playerInventory;
        }

        public void InitPlayerHealthControllerFromView(Animator playerAnimator, IHealthHud healthHud, IInventoryScreen inventoryScreen)
        {
            this.playerAnimator = playerAnimator;
            this.healthHud = healthHud;
            this.inventoryScreen = inventoryScreen;
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

            healthHud.SetHealth();

            if (health <= 0)
            {
                Die();
            }
        }

        public void RestoreHealth(int amount, ItemObject item)
        {
            if (Dead)
            {
                return;
            }

            if (health + amount <= GetInitialHealth())
            {
                health += amount;
            }
            else
            {
                health = GetInitialHealth();
            }

            playerInventory.RemoveItem(item);

            healthHud.SetHealth();
        }

        public void Die()
        {
            Dead = true;
            playerAudio.PlayOneShot(deathClip);
            playerAnimator.SetInteger("Dead", 1);
            gameStopScreen.CallEndGameScreen();
            inventoryScreen.UpdateInventoryState(false);
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
