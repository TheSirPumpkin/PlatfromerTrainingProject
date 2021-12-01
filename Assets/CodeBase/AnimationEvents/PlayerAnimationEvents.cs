using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationEvents : MonoBehaviour
{
    public GameObject AttackCollider;
    public AudioSource Audio;
    public GameObject Smoke;

    private Animator animator;
    private Vector3 smokeInitPose;
    private AudioSource smokeAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        smokeInitPose = Smoke.transform.localPosition;
        smokeAudio = Smoke.GetComponent<AudioSource>();

        AttackCollider.gameObject.SetActive(false);
    }
    public void OnAttackStart()
    {
        AttackCollider.gameObject.SetActive(true);
        Audio?.Play();
    }
    public void OnLightAttackEnd()
    {
        AttackCollider.gameObject.SetActive(false);
        animator.SetInteger("LightAttack", 0);
    }

    public void OnHeavyAttackEnd()
    {
        AttackCollider.gameObject.SetActive(false);
        animator.SetInteger("HeavyAttack", 0);
    }
    public void OnJumpStart()
    {
        Smoke.transform.parent = transform;
        Smoke.transform.localPosition = smokeInitPose;
        Smoke.SetActive(true);
        smokeAudio.Play();
        Smoke.transform.parent = null;
    }
    public void OnJumpEnd()
    {
        Smoke.SetActive(false);
        animator.SetInteger("Jump", 0);
    }
}
