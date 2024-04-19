using System;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int score = 0;
    private Dictionary<GameObject, int> playerScores = new Dictionary<GameObject, int>();
    public int playerCount;

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

        playerCount = PlayerPrefs.GetInt("playerCount");
    }

    // Start is called before the first frame update
    void Start()
    {
        //instansiate the players based on the player count
        List<GameObject> playersInScene = new List<GameObject>();
        for (int i = 0; i < playerCount; i++)
        {
            GameObject player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            playersInScene.Add(player);

            //add unique ID to each player
            foreach (GameObject playerInScene in playersInScene)
            {
                playerInScene.name = $"Player {i++}";
            }
        }

        foreach (GameObject player in playersInScene)
        {
            playerScores[player] = 0;
            Debug.Log(player);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //get all players in the scene
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        //check if all players are dead
        if (playerCount == 0)
        {
            AllDead();
        }

        //check if one player is left in the game
        if (playerCount == 1)
        {
            //get the player that is left in the game
            GameObject winner = players[0];
            Debug.Log($"The winner is Player {winner.name}");
        }
    }

    /// <summary>
    /// Returns the current score
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        // return the current score based on the player
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
    public void AllDead()
    {
        Debug.Log("All players are dead");
    }
}
