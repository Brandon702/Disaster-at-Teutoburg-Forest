using UnityEngine;
using System.Collections.Generic;


public class Ambient : MonoBehaviour
{
    public int selection;
    private List<bool> interactions = new List<bool>();

    private void Start()
    {
        interactions.Add(false);
        interactions.Add(false);
        interactions.Add(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactions[selection] = true;
        if(interactions[0])
        {
            Debug.Log("Amb1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactions[selection] = false;
    }
}

