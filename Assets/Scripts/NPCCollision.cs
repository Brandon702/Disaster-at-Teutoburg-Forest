using UnityEngine;


public class NPCCollision : MonoBehaviour
{
    public bool interaction = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interaction = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interaction = false;
    }
}

