using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonAnimationEvents : MonoBehaviour
{
    public GameObject AttackCollider;
    private void Start()
    {
        AttackCollider.gameObject.SetActive(false);
    }
    public void OnAttackStart()
    {
        AttackCollider.SetActive(true);
    }

    public void OnAttackEnd()
    {
        AttackCollider.SetActive(false);
    }
}
