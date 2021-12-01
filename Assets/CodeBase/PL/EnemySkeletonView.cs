using Enemy.BLL;
using Player.PL;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.PL
{
    public class EnemySkeletonView : MonoBehaviour, IEnemy
    {
        public AudioSource hitAudio;
        public AudioSource audioAmbient;

        private PlayerMoveView player;
        private IPlayerHealth playerHealth;
        private EnemySkeletonController enemySkeletonController;
        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            audioAmbient.enabled = false;
            animator = GetComponent<Animator>();
            player = GameObject.FindObjectOfType<PlayerMoveView>();
            playerHealth = AllServices.Container.Single<IPlayerHealth>();
            enemySkeletonController = new EnemySkeletonController(this, animator, hitAudio, audioAmbient, player);

            enemySkeletonController.EnableAmbientAudio();
        }

        // Update is called once per frame
        void Update()
        {
            if (!playerHealth.Dead)
            {
                enemySkeletonController.Update();
            }
            else if (audioAmbient.enabled)
            {
                enemySkeletonController.SetIdle();
                audioAmbient.enabled = false;
            }
        }

        public void TakeDamage(float damage)
        {
            enemySkeletonController.TakeDamage(damage);
        }
    }
}
