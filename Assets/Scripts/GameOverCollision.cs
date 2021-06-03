using UnityEngine;

public class GameOverCollision : MonoBehaviour
{
    public bool interaction = false;
    private MenuController menuController;
    private SceneController sceneController;

    private void Awake()
    {
        menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interaction = true;
        menuController.Disable();
        sceneController.Next();
        menuController.gameOverTrackPlayer();
        menuController.ScenePanel.SetActive(true);
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("Game Over");

    }
}

