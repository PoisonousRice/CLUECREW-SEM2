using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject scarlett, mustard, white, green, peacock, plum;
    public string character;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayGame(string a)
    {
        SceneManager.LoadScene("3D Clue");
        SceneManager.sceneLoaded += OnSceneLoaded;
        character = a;
    }

    public void OnSceneLoaded(Scene game, LoadSceneMode mode)
    {
        GameObject players = SceneManager.GetSceneByName("3D Clue").GetRootGameObjects()[1];
        if (character == "Scarlett")
        {
            scarlett = players.transform.Find("Ms. Scarlett").gameObject;
            scarlett.GetComponent<CharacterController>().enabled = true;
            scarlett.GetComponent<PlayerControl>().enabled = true;
            scarlett.transform.Find("Cam").gameObject.SetActive(true);
        }
        else if (character == "Mustard")
        {
            mustard = players.transform.Find("Colonel Mustard").gameObject;
            mustard.GetComponent<CharacterController>().enabled = true;
            mustard.GetComponent<PlayerControl>().enabled = true;
            mustard.transform.Find("Cam").gameObject.SetActive(true);
        }
        else if (character == "White")
        {
            white = players.transform.Find("Mrs. White").gameObject;
            white.GetComponent<CharacterController>().enabled = true;
            white.GetComponent<PlayerControl>().enabled = true;
            white.transform.Find("Cam").gameObject.SetActive(true);
        }
        else if (character == "Green")
        {
            green = players.transform.Find("Mr. Green").gameObject;
            green.GetComponent<CharacterController>().enabled = true;
            green.GetComponent<PlayerControl>().enabled = true;
            green.transform.Find("Cam").gameObject.SetActive(true);
        }
        else if (character == "Peacock")
        {
            peacock = players.transform.Find("Mrs. Peacock").gameObject;
            peacock.GetComponent<CharacterController>().enabled = true;
            peacock.GetComponent<PlayerControl>().enabled = true;
            peacock.transform.Find("Cam").gameObject.SetActive(true);
        }
        else if (character == "Plum")
        {
            plum = players.transform.Find("Professor Plum").gameObject;
            plum.GetComponent<CharacterController>().enabled = true;
            plum.GetComponent<PlayerControl>().enabled = true;
            plum.transform.Find("Cam").gameObject.SetActive(true);
        }    
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
