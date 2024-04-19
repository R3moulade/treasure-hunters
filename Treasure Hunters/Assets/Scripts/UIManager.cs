using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
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
    public int numberOfPlayers; // This will store the number of players selected

    public void SetNumberOfPlayers(int playerCount)
        {
            numberOfPlayers = playerCount;
            PlayerPrefs.SetInt("NumberOfPlayers", numberOfPlayers);
            Debug.Log("Number of players set to " + numberOfPlayers);
        }
}