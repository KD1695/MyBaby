using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] Rigidbody2D rigidbody;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.localRotation = Quaternion.Euler(0, 0, transform.localRotation.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.Play();
        if(collision.collider.gameObject.tag == "Wall" && !GameManager.Instance.isGrabbed)
        {
            rigidbody.AddForce(new Vector2((transform.position.x > 0) ? 200 : -200, 200));
        }
    }
}
