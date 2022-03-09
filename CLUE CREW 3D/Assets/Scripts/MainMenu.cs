using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject scarlett, mustard, white, green, peacock, plum, guessVis, guessVisObjs, players;
    public background bg;
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

        players = SceneManager.GetSceneByName("3D Clue").GetRootGameObjects()[1];
        guessVis = SceneManager.GetSceneByName("3D Clue").GetRootGameObjects()[3];
        guessVisObjs = guessVis.transform.Find("GuessObjects").gameObject;
        bg = SceneManager.GetSceneByName("3D Clue").GetRootGameObjects()[0].GetComponent<background>();

        if (character == "Scarlett")
        {
            scarlett = players.transform.Find("Ms. Scarlett").gameObject;
            scarlett.GetComponent<CharacterController>().enabled = true;
            scarlett.GetComponent<PlayerControl>().enabled = true;
            scarlett.transform.Find("Cam").gameObject.SetActive(true);
            guessVis.transform.localPosition = scarlett.transform.position;
            bg.player = scarlett;
        }
        else if (character == "Mustard")
        {
            mustard = players.transform.Find("Colonel Mustard").gameObject;
            mustard.GetComponent<CharacterController>().enabled = true;
            mustard.GetComponent<PlayerControl>().enabled = true;
            mustard.transform.Find("Cam").gameObject.SetActive(true);
            guessVis.transform.localPosition = mustard.transform.position;
            bg.player = mustard;
        }
        else if (character == "White")
        {
            white = players.transform.Find("Mrs. White").gameObject;
            white.GetComponent<CharacterController>().enabled = true;
            white.GetComponent<PlayerControl>().enabled = true;
            white.transform.Find("Cam").gameObject.SetActive(true);
            guessVis.transform.localPosition = white.transform.position;
            bg.player = white;
        }
        else if (character == "Green")
        {
            green = players.transform.Find("Mr. Green").gameObject;
            green.GetComponent<CharacterController>().enabled = true;
            green.GetComponent<PlayerControl>().enabled = true;
            green.transform.Find("Cam").gameObject.SetActive(true);
            guessVis.transform.localPosition = green.transform.position;
            bg.player = green;
        }
        else if (character == "Peacock")
        {
            peacock = players.transform.Find("Mrs. Peacock").gameObject;
            peacock.GetComponent<CharacterController>().enabled = true;
            peacock.GetComponent<PlayerControl>().enabled = true;
            peacock.transform.Find("Cam").gameObject.SetActive(true);
            guessVis.transform.localPosition = peacock.transform.position;
            bg.player = peacock;
        }
        else if (character == "Plum")
        {
            plum = players.transform.Find("Professor Plum").gameObject;
            plum.GetComponent<CharacterController>().enabled = true;
            plum.GetComponent<PlayerControl>().enabled = true;
            plum.transform.Find("Cam").gameObject.SetActive(true);
            guessVis.transform.localPosition = plum.transform.position;
            bg.player = plum;
        }    
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
