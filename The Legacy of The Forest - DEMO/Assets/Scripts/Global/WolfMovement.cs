using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;
    
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        gameObject.SetActive(false);
    }
}
