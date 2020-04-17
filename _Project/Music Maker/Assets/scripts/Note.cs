using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    private GameObject currentNote;

    public GameObject placedNote;

    public Cursor cursor;

    public GameObject run;
    public GameObject runTutorial;

    public int audioIndex = 8;

    // Start is called before the first frame update
    void Start()
    {
        currentNote = this.gameObject;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor")
        {
            cursor.currentPlace = this.gameObject;
        }
    }

    public void InstatiateNote(GameObject note, bool replace = false)
    {
        bool run_variable;
        if(run)
            run_variable = run.GetComponent<RUN>().isPaused;
        else
            run_variable = runTutorial.GetComponent<RUN_TUTORIAL>().isPaused;
        if(!run_variable)
        {
            Debug.Log("Instantiating: " + note.name);
            if (!placedNote)
            {
                placedNote = Instantiate(note, this.gameObject.transform);
                audioIndex = placedNote.GetComponent<AudioIndex>().AudioInd;
            }
            note.transform.position = new Vector2(0, note.transform.position.y);

            if (placedNote && replace)
            {
                Destroy(placedNote);
                placedNote = Instantiate(note, this.gameObject.transform);
                note.transform.position = new Vector2(0, note.transform.position.y);
            }
        }
    }

    public void DeleteNote()
    {
        Debug.Log("Deleting note: " + this.gameObject.name);
        if (!placedNote)
        {
            Destroy(this.gameObject);
        }
    }
}
