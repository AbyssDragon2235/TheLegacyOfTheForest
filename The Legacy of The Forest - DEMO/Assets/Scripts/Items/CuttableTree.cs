using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableTree : ToolHit
{
    [SerializeField] GameObject drop;
    [SerializeField] int dropCount = 10;
    [SerializeField] float spread = 2f;
    [SerializeField] int healthToDeal;

    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;
            Vector3 pos = transform.position;
            pos.x += spread * UnityEngine.Random.value - spread / 2;
            pos.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(drop);
            go.transform.position = pos;
        }

        player.health = player.health + healthToDeal;

        Destroy(gameObject);
    }
}