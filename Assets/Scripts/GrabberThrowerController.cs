using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CircusMember
{
    Grabber,
    Kicker
}

public class GrabberThrowerController : MonoBehaviour
{
    public CircusMember memberType;
    float counter = 0.0f;
    public RectTransform body;
    public Transform anchor;
    public Transform babyHoldAnchor = null;
    public int isReversed = 1;
    private bool isBabyGrabbed = false;
    private GameObject baby = null;
    public Image directionButton;

    void Start()
    {
        
    }

    void Update()
    {
        counter += Time.deltaTime;
        int direction = 0;
        
        if (GameManager.Instance.isRotating)
        {
            direction = GameManager.Instance.direction * isReversed;
        }

        if (counter >= 1 / 6)
        {
            counter = 0;
            body.transform.RotateAround(anchor.position, new Vector3(0, 0, 1), direction);
        }

        if (isBabyGrabbed)
        {
            baby.transform.position = babyHoldAnchor.position;
            if (Input.GetKey(KeyCode.Space))
            {
                isBabyGrabbed = false;
                GameManager.Instance.isGrabbed = false;
                var rigidBody = baby.GetComponent<Rigidbody2D>();
                baby = null;
                rigidBody.isKinematic = false;
                rigidBody.AddForce(new Vector2(transform.up.x * GameManager.Instance.force, GameManager.Instance.force), ForceMode2D.Force);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (memberType == CircusMember.Grabber)
        {
            if (babyHoldAnchor != null)
            {
                collider2D.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                baby = collider2D.gameObject;
                baby.transform.position = babyHoldAnchor.position;
                isBabyGrabbed = true;
                GameManager.Instance.isGrabbed = true;
            }
        }
    }

    public void ToggleRotationDirection()
    {
        isReversed *= -1;
        directionButton.color = isReversed == -1 ? Color.red : Color.green;
    }
}
