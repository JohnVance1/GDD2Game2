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

    private bool itemNear = false;
    private bool interactableNear = false;
    private GameObject closest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemCheck();
        //uncomment when interactables are implemented
        //interactableCheck();
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
                itemNear = true;
                //set closest
                if (closest == null)
                {
                    closest = item;
                }
                else if (closest != null || closest != item)
                {
                    //if this item is closer
                    if (Vector3.Distance(player.transform.position, item.transform.position) < Vector3.Distance(player.transform.position, closest.transform.position))
                    {
                        closest = item;
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
            itemNear = false;
        }

        //if the player is near an item, let it pick it up
        if (itemNear)
        {
            if (Input.GetKey(KeyCode.E))
            {
                items.Remove(closest);
                Destroy(closest);
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
                interactableNear = true;
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

                if (Input.GetKey(KeyCode.F))
                {
                    interactable.transform.position += new Vector3(1, 0, 0);
                    interactablesCollected++; //probably remove this later
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
            interactableNear = false;
        }
    }

    void OnGUI()
    {
        if (itemNear) //if the player is near an item, tell them they can pick it up
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 60, 250, 50), "Press E to pickup item");
        }

        if (interactableNear) //if the player is near an interactable, tell them they can pick it up
        {
            GUI.Box(new Rect(720, 800, 250, 50), "Press F to pickup interactable");
        }
    }
}
