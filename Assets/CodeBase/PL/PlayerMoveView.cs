using Player.BLL;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PL
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public class PlayerMoveView : MonoBehaviour
    {
        private IPlayeController playeMovementController;
        private void Start()
        {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
            playeMovementController = new PlayerControllerStandalone(transform, GetComponent<Animator>(), GetComponent<Rigidbody2D>());
#endif
        }
        private void Update()
        {
            playeMovementController.Attack();
        }
        private void FixedUpdate()
        {
            playeMovementController.Move();
        }
        private void LateUpdate()
        {
            playeMovementController.ResetAttack();
        }
    }
}
