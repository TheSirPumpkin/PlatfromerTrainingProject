using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMover : MonoBehaviour
{
    public SpriteRenderer ParentRenderer;
    private SpriteRenderer cloudSprite;
    private Vector3 initialPos;
    private float flySpeed = 1;
    private float limit;
    private float maximumDistance = 3;
    private void Start()
    {
        initialPos = transform.parent.position;
        cloudSprite = GetComponent<SpriteRenderer>();
        limit = Mathf.Abs(initialPos.x * maximumDistance);
    }
    private void Update()
    {
        if (Mathf.Abs(transform.position.x) >= limit && !cloudSprite.isVisible && !ParentRenderer.isVisible)
        {
            transform.position = initialPos;
        }
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * flySpeed);
    }
}
