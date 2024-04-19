using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int numberOfPlayers = PlayerPrefs.GetInt("numberOfPlayers");
    private Dictionary<GameObject, int> playerScores = new Dictionary<GameObject, int>();

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
        // instantiate the players based on the number of players
        for (int i = 0; i < numberOfPlayers; i++)
        {
            // instantiate the player
            GameObject player = Instantiate(Resources.Load("Player"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }

        foreach (GameObject player in numberOfPlayers )
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
    /// Adds the score to the player based on the treasure type
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void AddScore(Enum treasureType)
    {
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
