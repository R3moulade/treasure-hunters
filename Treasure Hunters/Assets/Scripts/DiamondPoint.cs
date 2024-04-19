using UnityEngine;

public class DiamondPoint : MonoBehaviour
{

    public TreasureEnum.Treasure treasureType = TreasureEnum.Treasure.Diamond;

    private GameManager gameManager;
    
    void Start()
    {
       // gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
