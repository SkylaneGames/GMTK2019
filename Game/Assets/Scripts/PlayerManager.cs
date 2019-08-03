﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CameraShake cameraShake;

    public ColliderMovement col;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hits = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(transform.position, new Vector2(0,-1), hits);
        //Debug.Log(hits[1]);
        float distance = Vector2.Distance(transform.position, hits[1].point);
        //Debug.Log(distance);
        if (distance < 0.7)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //Debug.Log(isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            cameraShake.Shake(ShakeIntensity.Landing);
            var contacts = new List<ContactPoint2D>();
            var n = collision.GetContacts(contacts);

            foreach(var contact in contacts)
            {
                Debug.Log(contact);
            }
        }
    }

    public void IncreaseJumpPower()
    {
        col.IncreaseJumpPower();   
    }
}
