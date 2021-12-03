using Services;
using UnityEngine;
using Player.DAL;

namespace Player.BLL
{
    public class PlayerControllerStandalone : IPlayeController
    {
        private PlayerData playerData;

        private float playerSpeed;
        private string lightAttackInput;
        private string heavyAttackInput;
        private string moveAxis;
        private string jumpButton;

        private Animator animator;
        private bool rotationPositive = true;
        private bool rotationNegative;
        private float jumpHeigt;

        private bool isGrounded;
        private BoxCollider2D mainCollider;
        private Bounds colliderBounds;
        private Transform player;
        private Rigidbody2D rBody;
        private float colliderRadius;
        private Vector3 groundCheckPos;

        private IPlayerHealth playerHealth;

        public PlayerControllerStandalone(IPlayerHealth playerHealth)
        {
            playerData = ScriptableObjectsContainer.Instance.CurrentPlayerData;//Resources.Load<PlayerData>(PathConstants.CurrentPlayerPath);
            playerSpeed = playerData.MoveSpeed;
            lightAttackInput = playerData.LightAttackInput;
            heavyAttackInput = playerData.HeavyAttackInput;
            moveAxis = playerData.MoveAxis;
            jumpButton = playerData.JumpButton;
            jumpHeigt = playerData.JumpHeight;

            this.playerHealth = playerHealth;
        }

        public void InitFromView(Transform player, Animator animator, Rigidbody2D rBody)
        {
            this.player = player;
            this.animator = animator;
            this.rBody = rBody;

            mainCollider = player.GetComponent<BoxCollider2D>();
        
        }

        public void Move()
        {
            if (playerHealth.Dead)
            {
                return;
            }

            if (Input.GetAxis(moveAxis) == 0)
            {
                animator.SetInteger("Walk", 0);
            }
            else
            {
                animator.SetInteger("Walk", 1);
            }

            if (Input.GetAxis(moveAxis) > 0 && !rotationPositive)
            {
                SetRotation(false, true, 1.5f, 0.5f);
            }
            if (Input.GetAxis(moveAxis) < 0 && !rotationNegative)
            {
                SetRotation(true, false, -1.5f, -0.5f);
            }

            if (Input.GetButton(jumpButton))
            {
                DoJump();
            }

            player.Translate(new Vector3(Input.GetAxis(moveAxis), 0, 0) * Time.deltaTime * playerSpeed);

        }

        public void Attack()
        {
            if (playerHealth.Dead)
            {
                return;
            }

            if (Input.GetButtonDown(lightAttackInput) && animator.GetInteger("LightAttack") != 1)
            {
                animator.SetInteger("LightAttack", 1);
            }
            if (Input.GetButtonDown(heavyAttackInput) && animator.GetInteger("HeavyAttack") != 1)
            {
                animator.SetInteger("HeavyAttack", 1);
            }
        }
        public void ResetAttack()
        {
            if (playerHealth.Dead)
            {
                return;
            }

            animator.SetInteger("LightAttack", 0);
            animator.SetInteger("HeavyAttack", 0);
        }
        private void SetRotation(bool negative, bool positive, float xScale, float playerXPos)
        {
            rotationPositive = positive;
            rotationNegative = negative;
            player.localScale = new Vector3(xScale, 1.5f, 1.5f);
            player.position += new Vector3(playerXPos, 0, 0);
        }

        private float GetDirection()
        {
            if (Input.GetAxis(moveAxis) > 0)
            {
                return 1;
            }
            if (Input.GetAxis(moveAxis) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private void DoJump()
        {
            Vector2 direction = Vector2.down;

            colliderBounds = mainCollider.bounds;
            colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(player.localScale.x);
            groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);

            float distance = player.localScale.y / 5f;

            RaycastHit2D hit = Physics2D.Raycast(groundCheckPos, direction, distance, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                animator.SetInteger("Jump", 1);
                rBody.velocity = new Vector2(rBody.velocity.x, jumpHeigt);
            }
        }
    }
}