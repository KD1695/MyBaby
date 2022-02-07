using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickerController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.transform.position.y >= collision.GetContact(0).point.y)
        {
            collision.rigidbody.AddForce(new Vector2(0, GameManager.Instance.isRotating ? GameManager.Instance.force : GameManager.Instance.force / 3));
        }
    }
}
