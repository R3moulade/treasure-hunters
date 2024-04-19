using System;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int score = 0;
    public GameObject[] playersInScene;
    private Dictionary<GameObject, int> playerScores = new Dictionary<GameObject, int>();
    public int playerCount = 0;

    private void Awake()
    {
        if ( gameManager == null )
        {
            gameManager = this;
        }
        else if ( gameManager != this )
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // set the score to 0
        score = 0;

        //get all players in the scene
        playersInScene = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in playersInScene)
        {
            playerScores[player] = 0;
            Debug.Log(player);
        }

    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }


    /// <summary>
    /// Returns the current score
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// Adds the scoreToAdd to the current score
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void AddScore(Enum treasureType)
    {   
        Debug.Log(treasureType);
        switch(treasureType)
        {
            case TreasureEnum.Treasure.Coin:
            score += 1;
            break;
            case TreasureEnum.Treasure.Diamond:
            score += 3;
            break;
            default:
            break;
        }
    }

    /// <summary>
    /// Removes the player from the game by destroying it
    /// </summary>
    public void RemovePlayer(GameObject player)
    {
        // remove the player from the game
        Destroy(player);
        Debug.Log($"{player} has died");
    }

    /// <summary>
    /// Checks if all players are dead
    /// </summary>
    public void GameOver()
    {
        // show game over screen
        if (playersInScene.Length == 0)
        {
            Debug.Log("Game Over");
        }

    }
}
