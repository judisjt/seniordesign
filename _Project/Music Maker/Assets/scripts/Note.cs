using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    private GameObject currentNote;

    public GameObject placedNote;

    public Cursor cursor;

    public GameObject run;


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
        if(!run.GetComponent<RUN>().isPaused)
        {
            Debug.Log("Instantiating: " + note.name);
            if (!placedNote)
            {
                placedNote = Instantiate(note, this.gameObject.transform);
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
