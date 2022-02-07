using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1.0f;

    private Vector3 targetPos;

    private void Start()
    {
        if (target == null) return;
    }

    private void Update()
    {
        if (target == null || GameManager.Instance.isGrabbed) return;

        targetPos = target.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetPos.y, -10), lerpSpeed * Time.deltaTime);
    }

}
