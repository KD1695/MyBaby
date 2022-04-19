using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float maxSpeed = 100f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.localRotation = Quaternion.Euler(0, 0, transform.localRotation.z);

        float velX = (rigidbody.velocity.x > maxSpeed) ? maxSpeed : rigidbody.velocity.x;
        velX = (rigidbody.velocity.x < -maxSpeed) ? -maxSpeed : rigidbody.velocity.x;
        float velY = (rigidbody.velocity.y > maxSpeed) ? maxSpeed : rigidbody.velocity.y;
        velY = (rigidbody.velocity.y < -maxSpeed) ? -maxSpeed : rigidbody.velocity.y;

        rigidbody.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.Play();
        if(collision.collider.gameObject.tag == "Wall" && !GameManager.Instance.isGrabbed)
        {
            rigidbody.AddForce(new Vector2((transform.position.x > 0) ? -300 : 300, 300));
        }
    }
}
