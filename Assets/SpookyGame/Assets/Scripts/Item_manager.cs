using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_manager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> items;
    public int itemsCollected;

    private bool isNear = false;
    private GameObject closest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int counter = 0;
        //if player is near an item, allow them to collect it
        foreach(GameObject item in items)
        {
            //player is within a certain radius of item
            if(player.transform.position.x > item.transform.position.x - 10 &&
                player.transform.position.x < item.transform.position.x + 10 &&
                player.transform.position.z > item.transform.position.z - 10 &&
                player.transform.position.z < item.transform.position.z + 10)
            {
                isNear = true;
                //set closest
                if(closest == null)
                {
                    closest = item;
                }
                else if(closest != null || closest != item)
                {
                    //if this item is closer
                    if(Vector3.Distance(player.transform.position, item.transform.position) < Vector3.Distance(player.transform.position, closest.transform.position))
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
        if(counter == items.Count)
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

    void OnGUI()
    {
        if (isNear)
        {
            GUI.Box(new Rect(750, 820, 250, 50), "Press E to pickup item");
        }
    }
}
