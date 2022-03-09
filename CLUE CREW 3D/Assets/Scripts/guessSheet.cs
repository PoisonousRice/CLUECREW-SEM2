using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guessSheet : MonoBehaviour
{
    public string[] answers, guesses;
    public GameObject currentGuess, guessVis, guessCanv, guessSus, guessWep, player;
    public string[] rooms = new string[10]{"Ballroom", "Billiard Room", "Cellar", "Conservatory", "Dining Room", "Hall", "Kitchen", "Library", "Lounge", "Study"};
    public string[] characters = new string[6]{"Ms. Scarlett", "Mrs. Peacock", "Mrs. White", "Professor Plum", "Colonel Mustard", "Mr. Green"};
    public string[] weapons = new string[5]{"Candlestick", "Wrench", "Pipe", "Revolver", "Sword"};

    // Start is called before the first frame update
    void Start()
    {
        answers = new string[3]{rooms[Random.Range(0,9)], characters[Random.Range(0,5)], weapons[Random.Range(0,4)]};
        currentGuess = guessSus.transform.Find("Green").gameObject;
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void Guess(string[] guesses, string[] answers)
    {
        bool room = false, sus = false, wep = false;
        Debug.Log("Checking Guesses");

        if (guesses[0] == answers[0])
        {
            room = true;
        }
        if (guesses[1] == answers[1])
        {
            Debug.Log("Correct Suspect");
            sus = true;
        }
        if (guesses[2] == answers[2])
        {
            Debug.Log("Correct Weapon");
            wep = true;
        }

        if (room && sus && wep)
        {
            Win();
        }
        else if (!room && !sus && !wep)
        {
            Debug.Log("You suck at this.");
        }
        

        player.GetComponent<PlayerControl>().guessing = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Next()
    {
        if (currentGuess.tag == "Suspect")
        {
            NextSus();
        }
        else if (currentGuess.tag == "Weapon")
        {
            NextWep();
        }        
    }
    public void Prev()
    {
        if (currentGuess.tag == "Suspect")
        {
            PrevSus();
        }
        else if (currentGuess.tag == "Weapon")
        {
            PrevWep();
        }
    } 
    void NextSus()
    {
        int index = currentGuess.transform.GetSiblingIndex();
        if (index == 5)
        {
            index = -1;
        }
        currentGuess.SetActive(false);
        GameObject temp = currentGuess.transform.parent.GetChild(index + 1).gameObject;
        temp.SetActive(true);
        currentGuess = temp;
    }
    void PrevSus()
    {
        int index = currentGuess.transform.GetSiblingIndex();
        if (index == 0)
        {
            index = 6;
        }
        currentGuess.SetActive(false);
        GameObject temp = currentGuess.transform.parent.GetChild(index - 1).gameObject;
        temp.SetActive(true);
        currentGuess = temp;
    }
    void NextWep()
    {
        int index = currentGuess.transform.GetSiblingIndex();
        if (index == 4)
        {
            index = -1;
        }
        currentGuess.SetActive(false);
        GameObject temp = currentGuess.transform.parent.GetChild(index + 1).gameObject;
        temp.SetActive(true);
        currentGuess = temp;
    }
    void PrevWep()
    {
        int index = currentGuess.transform.GetSiblingIndex();
        if (index == 0)
        {
            index = 5;
        }
        currentGuess.SetActive(false);
        GameObject temp = currentGuess.transform.parent.GetChild(index - 1).gameObject;
        temp.SetActive(true);
        currentGuess = temp;
    }
    public void confirmGuess()
    {
        Debug.Log("confirmGuess");
        if(currentGuess.tag == "Suspect")
        {
            guesses[1] = currentGuess.name;
            currentGuess.SetActive(false);
            GameObject newGuess = currentGuess.transform.parent.parent.Find("Weapons").GetChild(0).gameObject;
            newGuess.SetActive(true);
            currentGuess = newGuess;
            guessVis.transform.GetChild(1).Find("suspectText").gameObject.SetActive(false);
            guessVis.transform.GetChild(1).Find("weaponText").gameObject.SetActive(true);
        }
        else if (currentGuess.tag == "Weapon")
        {
            guesses[2] = currentGuess.name;
            Guess(guesses, answers);
            currentGuess.SetActive(false);
            currentGuess = guessSus.transform.Find("Green").gameObject;
            guessCanv.transform.GetChild(0).gameObject.SetActive(false);
            guessCanv.transform.GetChild(3).gameObject.SetActive(false);
            guessCanv.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    void Win()
    {
        Debug.Log("You win.");
    }
}
