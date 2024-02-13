using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    private int _notesCollected = 0;
    public string labelText = "Find all the notes to win!";
    public int maxNotes = 10;
    public bool showWinScreen = false;
    public PlayerBehavior Player;
    public GameObject Note10;
    public int Notes
    {
        get { return _notesCollected; }

        set 
        { 
            _notesCollected = value;
            
            if (_notesCollected >= maxNotes)
            {
               
                showWinScreen = true;
            }
            else if (_notesCollected == 9)
            {
                labelText = "Head to the middle of the arena for the last note!";
                Note10.SetActive(true);
            }
            else
            {
                labelText = "Note found, only " + (maxNotes - _notesCollected) + " more to go.";
            }
        }
        

    }
   
    private void OnGUI()
    {
        GUI.Box(new Rect(20,50,150,25), "Notes Collected:" + _notesCollected);
        GUI.Label(new Rect(Screen.width / 2, Screen.height - 50,300,50), labelText);
        if(showWinScreen) {
            Cursor.lockState = CursorLockMode.Confined;
            if (GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 - 50,200,100),"You win!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1f;

            }
        }
    }
}
