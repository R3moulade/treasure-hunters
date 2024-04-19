using UnityEngine;

// NOT used
public class TreasurePoint : MonoBehaviour
{

    public TreasureEnum.Treasure treasureType = TreasureEnum.Treasure.Diamond;


    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.AddScore(treasureType);
        Destroy(gameObject);
        Debug.Log("triggered");
    }
}
