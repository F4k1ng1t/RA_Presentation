using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;


public class NotecardBehavior : MonoBehaviour
{
    public GameObject Text;
    public GameBehavior gameManager;
    public PlayerBehavior PlayerBehavior;
    public GameObject Paper;
    public GameObject NoteText1;
    public GameObject NoteText2;
    public GameObject NoteText3;
    public GameObject NoteText4;
    public GameObject NoteText5;
    public GameObject NoteText6;
    public GameObject NoteText7;
    public GameObject NoteText8;
    public GameObject NoteText9;
    public GameObject NoteText10;
    private bool noteIsOut = false;
    public bool noteFound = false;


    public int noteID = 0;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Text.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            
            if (Input.GetKey(KeyCode.E) && !noteIsOut && !noteFound)
            {
                Text.SetActive(false);
                noteIsOut = true;
                
                
                displayNote();
            }
            else if(Input.GetKey(KeyCode.E) && !noteIsOut && noteFound)
            {
                Text.SetActive(false);
                noteIsOut = true;
                displayNote();
            }
        }
    }
    private void displayNote()
    {
        Paper.SetActive(true);

        switch (noteID)
        {
            case 0:
                NoteText1.SetActive(true);
                break;
            case 1:
                NoteText2.SetActive(true);
                break;
            case 2:
                NoteText3.SetActive(true);
                break;
            case 3:
                NoteText4.SetActive(true); 
                break;
            case 4:
                NoteText5.SetActive(true); 
                break;
            case 5:
                NoteText6.SetActive(true); 
                break;
            case 6:
                NoteText7.SetActive(true); 
                break;
            case 7:
                NoteText8.SetActive(true); 
                break;
            case 8:
                NoteText9.SetActive(true); 
                break;
            case 9:
                NoteText10.SetActive(true); 
                break;
            default:
                Debug.Log("Default case ran");
                break;
        }
    }
    private void stopDisplayingNote()
    {
        Paper.SetActive(false);
        noteIsOut = false;
        switch (noteID)
        {
            case 0:
                NoteText1.SetActive(false); 
                break;
            case 1:
                NoteText2.SetActive(false); 
                break;
            case 2:
                NoteText3.SetActive(false);
                break;
            case 3:
                NoteText4.SetActive(false); 
                break;
            case 4:
                NoteText5.SetActive(false); 
                break;
            case 5:
                NoteText6.SetActive(false); 
                break;
            case 6:
                NoteText7.SetActive(false); 
                break;
            case 7:
                NoteText8.SetActive(false); 
                break;
            case 8:
                NoteText9.SetActive(false); 
                break;
            case 9:
                NoteText10.SetActive(false); 
                break;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            stopDisplayingNote();
            if (!noteFound)
            {
                gameManager.Notes += 1;
                noteFound = true;
            }
        }
        Text.SetActive(false);
    }
}