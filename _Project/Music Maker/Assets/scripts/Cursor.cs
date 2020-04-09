using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    public GameObject[] notes;

    private bool holding;

    private GameObject note;
    private int noteIdx;
    private int noteCount = 1;

    public GameObject currentPlace;
    public Note currentNote;
    private AudioSource currentNoteAudio;
    private Note replaceNote;
    private List<GameObject> allPlaces;

    public AudioClip[] audioClips;
    private AudioSource audioSource;

    void Update()
    {
        // Get first note that was pressed, onkeyup will get last note pressed
        if (Input.GetButtonDown("C_L"))
        {
            Debug.Log("C_L Press");
            noteIdx = 0;
            PlaceNote(0);
            holding = true;
            noteCount = 0;
        }
        else if (Input.GetButtonDown("D"))
        {
            Debug.Log("D Press");
            noteIdx = 4;
            PlaceNote(1);
            holding = true;
            noteCount = 0;
        }
        else if (Input.GetButtonDown("E"))
        {
            Debug.Log("E Press");
            noteIdx = 8;
            PlaceNote(2);
            holding = true;
            noteCount = 0;
        }
        else if (Input.GetButtonDown("F"))
        {
            Debug.Log("F Press");
            noteIdx = 12;
            PlaceNote(3);
            holding = true;
            noteCount = 0;
        }
        else if (Input.GetButtonDown("G"))
        {
            Debug.Log("G Press");
            noteIdx = 16;
            PlaceNote(4);
            holding = true;
            noteCount = 0;
        }
        else if (Input.GetButtonDown("A"))
        {
            Debug.Log("A Press");
            noteIdx = 20;
            PlaceNote(5);
            holding = true;
            noteCount = 0;
        }
        else if (Input.GetButtonDown("B"))
        {
            Debug.Log("B Press");
            noteIdx = 24;
            PlaceNote(6);
            holding = true;
            noteCount = 0;
        }
        else if (Input.GetButtonDown("C_H"))
        {
            Debug.Log("C Press");
            noteIdx = 28;
            PlaceNote(7);
            holding = true;
            noteCount = 0;
        }


        // Get last note pressed
        if (Input.GetButtonUp("C_L"))
        {
            Debug.Log("C_L Release");
            holding = false;
            StopAudio();
        }
        else if (Input.GetButtonUp("D"))
        {
            Debug.Log("D Release");
            holding = false;
            StopAudio();
        }
        else if (Input.GetButtonUp("E"))
        {
            Debug.Log("E Release");
            holding = false;
            StopAudio();
        }
        else if (Input.GetButtonUp("F"))
        {
            Debug.Log("F Release");
            holding = false;
            StopAudio();
        }
        else if (Input.GetButtonUp("G"))
        {
            Debug.Log("G Release");
            holding = false;
            StopAudio();
        }
        else if (Input.GetButtonUp("A"))
        {
            Debug.Log("A Release");
            holding = false;
            StopAudio();

        }
        else if (Input.GetButtonUp("B"))
        {
            Debug.Log("B Release");
            holding = false;
            StopAudio();
        }
        else if (Input.GetButtonUp("C_H"))
        {
            Debug.Log("C Release");
            holding = false;
            StopAudio();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            if (holding == true)
            {
                noteCount++;
                if (noteCount == 0)
                {
                    note = notes[noteIdx];
                }
                else if (noteCount == 2)
                {
                    note = notes[noteIdx + 1];
                }
                else if (noteCount == 4)
                {
                    note = notes[noteIdx + 2];
                }
                else if (noteCount == 8)
                {
                    note = notes[noteIdx + 3];
                }
                else if (noteCount > 8)
                {
                    holding = false;
                }
                ReplaceNote();
                currentNote = currentPlace.GetComponent<Note>();
                currentNote.DeleteNote();
            }
            else
            {
                noteCount = 0;
            }
        }
        Debug.Log(noteCount);
    }

    void PlaceNote(int noteID)
    {
        Debug.Log(currentPlace);
        Debug.Log(allPlaces);
        note = notes[noteIdx];
        currentNote = currentPlace.GetComponent<Note>();
        currentNoteAudio = currentPlace.GetComponent<AudioSource>();
        currentNoteAudio.clip = audioClips[noteID];
        replaceNote = currentNote;
        currentNote.InstatiateNote(note);
        PlayAudio();
    }

    void ReplaceNote()
    {
        replaceNote.InstatiateNote(note, true);
    }

    public void PlayAudio()
    {
        currentNoteAudio.Play();
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.Stop();
    }

    public void StopAudio()
    {
        StartCoroutine(FadeOut(currentNoteAudio, 1f));
    }


}
