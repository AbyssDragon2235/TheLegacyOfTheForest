using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Quest quest;
    public PlayerController player;
    public GameObject currentInterObject = null;

    void Update()
    {
        if (Input.GetButtonDown ("Interact1") && currentInterObject)
        {
            Debug.Log("left click");
            //do something with the input Interact1
        }
        if (Input.GetButtonDown("Interact2") && currentInterObject)
        {
            Debug.Log("right click");
            //do something with the input Interact2
        }
        if (Input.GetButtonDown("Inventory") && currentInterObject)
        {
            Debug.Log("button e");
            //do something with the input Inventory
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InteractableObject")|| other.CompareTag("PickableItem"))
        {
            Debug.Log("interactable item");
            currentInterObject = other.gameObject;
        }
        if (other.CompareTag("PickableItem"))
        {
            Debug.Log("pickable item");
            //pick it up
            currentInterObject.SendMessage("DoInteraction");
            
            if (quest.isActive)
            {
                quest.goal.ItemCollected();
                if (quest.goal.IsReached())
                {
                    player.experience += quest.experienceReward;
                    player.gold += quest.goldReward;
                    quest.Complete();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InteractableObject") || other.CompareTag("PickableItem"))
        {
            if(other.gameObject == currentInterObject)
            {
                currentInterObject = null;
            }
        }
    }
}
