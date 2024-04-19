using UnityEngine;

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
        Debug.Log(other);

        if (other.CompareTag("Player"))

        {
            if (gameManager != null)
            {
                gameManager.AddScore(treasureType);
            }
            Destroy(gameObject);
        }

    }
}
