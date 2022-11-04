using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Item item;
    public void DoInteraction()
    {
        Debug.Log("picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        //pick up and send to inventory
        if (wasPickedUp)
        Destroy(gameObject);
    }
}
