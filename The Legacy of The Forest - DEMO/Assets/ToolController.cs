using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    PlayerMovement playerMovement;
    Rigidbody2D rb;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float pickupZone = 1.5f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact1"))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 pos = rb.position + playerMovement.lastPos * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, pickupZone);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
