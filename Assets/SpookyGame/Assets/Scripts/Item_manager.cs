using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_manager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> items;
    public int itemsCollected;
    public List<GameObject> interactables;
    public int interactablesCollected;

    private bool isNear = false;
    private bool isItem = false;
    private GameObject closest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemCheck();
        interactableCheck();
    }

    void itemCheck()
    {
        int counter = 0;
        //if player is near an item, allow them to collect it
        foreach (GameObject item in items)
        {
            //player is within a certain radius of item
            if (player.transform.position.x > item.transform.position.x - 10 &&
                player.transform.position.x < item.transform.position.x + 10 &&
                player.transform.position.z > item.transform.position.z - 10 &&
                player.transform.position.z < item.transform.position.z + 10)
            {
                isNear = true;
                //set closest
                if (closest == null)
                {
                    closest = item;
                    isItem = true;
                }
                else if (closest != null || closest != item)
                {
                    //if this item is closer
                    if (Vector3.Distance(player.transform.position, item.transform.position) < Vector3.Distance(player.transform.position, closest.transform.position))
                    {
                        closest = item;
                        isItem = true;
                    }
                }
            }
            else
            {
                counter++;
            }
        }
        //if none of the items were near, don't bring up the option
        if (counter == items.Count)
        {
            isNear = false;
        }

        //if the player is near an item, let it pick it up
        if (isNear)
        {
            if (Input.GetKey(KeyCode.E))
            {
                items.Remove(closest);
                itemsCollected++;
            }
        }
    }

    void interactableCheck()
    {
        int counter = 0;
        //if player is near an interactable, allow them to collect it
        foreach (GameObject interactable in interactables)
        {
            //player is within a certain radius of interactable
            if (player.transform.position.x > interactable.transform.position.x - 10 &&
                player.transform.position.x < interactable.transform.position.x + 10 &&
                player.transform.position.z > interactable.transform.position.z - 10 &&
                player.transform.position.z < interactable.transform.position.z + 10)
            {
                isNear = true;
                //set closest
                if (closest == null)
                {
                    closest = interactable;
                }
                else if (closest != null || closest != interactable)
                {
                    //if this interactable is closer
                    if (Vector3.Distance(player.transform.position, interactable.transform.position) < Vector3.Distance(player.transform.position, closest.transform.position))
                    {
                        closest = interactable;
                    }
                }
            }
            else
            {
                counter++;
            }
        }
        //if none of the interactables were near, don't bring up the option
        if (counter == interactables.Count)
        {
            isNear = false;
        }

        //if the player is near an interactable, let it pick it up
        if (isNear)
        {
            if (Input.GetKey(KeyCode.F))
            {
                interactables.Remove(closest);
                interactablesCollected++;
            }
        }
    }

    void OnGUI()
    {
        if (isNear)
        {
            if (isItem)
            {
                GUI.Box(new Rect(750, 820, 250, 50), "Press E to pickup item");
            }
            else //interactable
            {
                GUI.Box(new Rect(750, 820, 250, 50), "Press F to pickup interactable");
            }
        }
    }
}
