using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{
   // private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
      //  gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
          //  GameManager gameManager = FindObjectOfType<GameManager>();


            // if (gameManager != null)   // call destoy method
            // {
            //     gameManager.RemovePlayer(other.gameObject);
            // }

        }

    }
}
