using UnityEngine;

public class ColliisionWithPlayer : MonoBehaviour
{
   // private GameManager gameManager;


    public Collider2D coll;

    // Use this for initialization
    void Start()
    {
        // gameManager = FindObjectOfType<GameManager>();

        //Check if the isTrigger option on the Collider2D is set to true or false
        if (coll.isTrigger)
        {
            Debug.Log("This Collider2D can be triggered");
        }
        else if (!coll.isTrigger)
        {
            Debug.Log("This Collider2D cannot be triggered");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
          //  GameManager gameManager = FindObjectOfType<GameManager>();
        }

    }
}
