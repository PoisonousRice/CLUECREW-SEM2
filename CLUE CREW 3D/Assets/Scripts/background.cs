using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class background : MonoBehaviour
{
    public bool inRoom;
    public GameObject guessPrompt, guessingSheet, guessVis, guessCanv, guessSus, guessWep, player;
    public string[] rooms = new string[10]{"Ballroom", "Billiard Room", "Cellar", "Conservatory", "Dining Room", "Hall", "Kitchen", "Library", "Lounge", "Study"};
    public string[] characters = new string[6]{"Ms. Scarlett", "Mrs. Peacock", "Mrs. White", "Professor Plum", "Colonel Mustard", "Mr. Green"};
    public string[] weapons = new string[5]{"Candlestick", "Wrench", "Pipe", "Revolver", "Sword"};

    // Start is called before the first frame update
    void Start()
    {
        guessingSheet.GetComponent<guessSheet>().answers = new string[3]{rooms[Random.Range(0,9)], characters[Random.Range(0,5)], weapons[Random.Range(0,4)]}; 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") != 0f)
        {
            guessPrompt.SetActive(false);
            guessingSheet.SetActive(true);

            guessVis.transform.position = player.transform.position;
            guessVis.transform.localEulerAngles += player.transform.localEulerAngles;
            
            player.GetComponent<PlayerControl>().guessing = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            guessSus.transform.GetChild(0).gameObject.SetActive(true);
            guessCanv.transform.GetChild(0).gameObject.SetActive(true);
            guessCanv.transform.GetChild(3).gameObject.SetActive(true);
            
        }
    }
    public void InRoom(string room)
    {
        guessingSheet.GetComponent<guessSheet>().guesses[1] = room;
        TextMeshPro guessPromptText = guessPrompt.GetComponent<TextMeshPro>();
        guessPromptText.text = "Welcome to the " + room + ". Press the Spacebar to make a guess.";
        guessPrompt.SetActive(true);
        
    }

}
