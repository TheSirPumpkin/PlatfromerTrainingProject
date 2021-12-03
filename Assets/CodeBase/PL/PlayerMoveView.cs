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
            playeMovementController = AllServices.Container.Single<IPlayeController>();
            playeMovementController.InitFromView(transform, GetComponent<Animator>(), GetComponent<Rigidbody2D>());
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
