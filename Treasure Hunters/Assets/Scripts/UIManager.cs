using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Import the TextMeshPro namespace

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            // Check if PlayerPrefs has WhichPlayerWon key
            if (PlayerPrefs.HasKey("WhichPlayerWon"))
            {
                // Get the value of WhichPlayerWon key
                string winningPlayer = PlayerPrefs.GetString("WhichPlayerWon");
                // Set the winning player text
                SetWinningPlayerText(winningPlayer);
            }
            else
            {
                Debug.LogError("No WhichPlayerWon key found in PlayerPrefs");
            }
        }
    }

    public void Load(int sceneIndex) 
    {
        // switch(sceneIndex)
        // {
        //     case 1:
        //         StartCoroutine(LoadSceneAfterDelay(sceneIndex, 2.5f));
        //         break;
        //     default:
                SceneManager.LoadScene(sceneIndex);
        //         break;
        // }
    }

    // private IEnumerator LoadSceneAfterDelay(int sceneIndex, float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     SceneManager.LoadScene(sceneIndex);
    // }
    private int numberOfPlayers; // This will store the number of players selected

    public void SetNumberOfPlayers(int playerCount)
        {
            numberOfPlayers = playerCount;
            PlayerPrefs.SetInt("NumberOfPlayers", numberOfPlayers);
            Debug.Log("Number of players set to " + numberOfPlayers);
        }
    public void SetWinningPlayerText(string winningPlayer)
    {
        // Find the TextMeshPro object
        GameObject textObject = GameObject.Find("WhichPlayerWon");
        if (textObject != null)
        {
            // Get the TextMeshProUGUI component and set the text
            TextMeshProUGUI textMesh = textObject.GetComponent<TextMeshProUGUI>();
            if (textMesh != null)
            {
                textMesh.SetText(winningPlayer + " won!");
            }
            else
            {
                Debug.LogError("No TextMeshProUGUI component found on " + textObject.name);
            }
        }
    }
}