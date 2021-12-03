using Enemy.DAL;
using Enemy.PL;
using Player.PL;
using System.Collections;
using UnityEngine;

namespace Enemy.BLL
{
    public class EnemySkeletonController
    {
        private EnemySkeletonView enemySkeletonView;
        private Animator animator;
        private AudioSource hitAudio;
        private AudioSource audioAmbient;
        private PlayerMoveView player;
        private EnemyData enemyData;

        private bool isDead;
        private float hp;
        private float attackDistance;
        private float speed;
        private float recpveryTime;
        private float ambientEnableTimer;



        public EnemySkeletonController(EnemySkeletonView enemySkeletonView, Animator animator, AudioSource hitAudio, AudioSource audioAmbient, PlayerMoveView player)
        {
            this.enemySkeletonView = enemySkeletonView;
            this.animator = animator;
            this.hitAudio = hitAudio;
            this.audioAmbient = audioAmbient;
            this.player = player;

            enemyData = ScriptableObjectsContainer.Instance.EnenmySkeletonData;//Resources.Load<EnemyData>(PathConstants.EnenmySkeletonPath);
            ambientEnableTimer = Random.Range(enemyData.AmbientEnableMin, enemyData.AmbientEnableMax);
            hp = enemyData.Hp;
            attackDistance = enemyData.AttackDistance;
            speed = enemyData.Speed;
            recpveryTime = enemyData.RecpveryTime;
        }
        public void Update()
        {
            if (isDead)
            {
                return;
            }
            if (Vector2.Distance(enemySkeletonView.transform.position, player.transform.position) > attackDistance)
            {
                Walk();
            }
            else
            {
                Attack();
            }
            Recover();
        }
        public void SetIdle()
        {
            ResetMovement();
            animator.SetInteger("Idle", 1);
        }
        public void Attack()
        {
          
            if (isDead)
            {
                animator.SetInteger("Attack", 0);
                return;
            }
            animator.SetInteger("Idle", 0);
            //LookAtTarget(player.transform);
            animator.SetInteger("Walk", 0);
            animator.SetInteger("Attack", 1);
        }
        public void TakeDamage(float damage)
        {
            if (isDead) return;
            animator.SetInteger("Idle", 0);
            hitAudio.Play();
            animator.SetInteger("Walk", 0);
            animator.SetInteger("Hit", 1);
            animator.SetInteger("Attack", 0);
            recpveryTime = 0.2f;
            hp -= damage;

            if (hp <= 0)
            {
                Die();
            }
        }
        public void Die()
        {
            isDead = true;
            animator.SetInteger("Idle", 0);
            ResetMovement();
            animator.SetInteger("Die", 1);

            enemySkeletonView.GetComponent<Rigidbody2D>().simulated = false;
            enemySkeletonView.GetComponent<Collider2D>().isTrigger = true;
            audioAmbient.enabled = false;
        }

        public void ResetMovement()
        {
            animator.SetInteger("Walk", 0);
            animator.SetInteger("Hit", 0);
            animator.SetInteger("Attack", 0);
        }

        public void EnableAmbientAudio()
        {
            enemySkeletonView.StartCoroutine(EnableAmbientAudioCoroutine());
        }
        private IEnumerator EnableAmbientAudioCoroutine()
        {
            yield return new WaitForSeconds(ambientEnableTimer);
            audioAmbient.enabled = true;
            audioAmbient.Play();
        }

        private void Recover()
        {
            recpveryTime -= Time.deltaTime;
            if (recpveryTime <= 0)
            {
                animator.SetInteger("Hit", 0);

            }
        }
        private void Walk()
        {
            animator.SetInteger("Walk", 1);

            animator.SetInteger("Attack", 0);

            LookAtTarget(player.transform);

            enemySkeletonView.transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        private void LookAtTarget(Transform target)
        {
            if (Vector2.Distance(enemySkeletonView.transform.position, player.transform.position) < attackDistance * 2)
            {
                return;
            }
            if (enemySkeletonView.transform.position.x > target.transform.position.x)
            {
                enemySkeletonView.transform.localEulerAngles = new Vector2(0, 180);
            }

            if (enemySkeletonView.transform.position.x < target.transform.position.x)
            {
                enemySkeletonView.transform.localEulerAngles = Vector2.zero;
            }

        }
    }
}
