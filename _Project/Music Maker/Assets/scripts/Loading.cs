using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public float bpm;
    public GameObject[] note_prefab;
    public GameObject[] staffs;
    public GameObject Cursor;
    public Component[] notes;
    public string loaded_note;


    void Load_file()
    {

        note_prefab = Cursor.GetComponent<Cursor>().notes;
        int count = 0;
        
        notes = GetComponentsInChildren<Note>();
        foreach (string line in File.ReadLines(PlayerPrefs.GetString("LoadPath")))
        {
            if (count == 0)
            {
                bpm = float.Parse(line);
            }
            else
            {
                if (line.IndexOf("(", 0) != -1)
                {
                    loaded_note = line.Substring(0, line.IndexOf("(", 0));

                    foreach(GameObject prefab in note_prefab){
                        if(prefab.name == loaded_note)
                        {
                            notes[count - 1].GetComponent<Note>().InstatiateNote(prefab);
                        }
                    }         
                }
            }
            count++;
        }
    }

    void Awake()
    {
        Load_file();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
