using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
	public GameObject[] staffs;

	public Component[] notes;

	public Text fileName;

	public void SaveSheet()
	{
		//Saving(staffs[0]);

		notes = GetComponentsInChildren<Note>();

        foreach (Note note in notes)
        {
        	Debug.Log("Note: " + note.placedNote);
       		System.IO.File.AppendAllText(@"save/" + fileName.text + ".txt",
       									 note.placedNote + "\n");
       	}
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);


	}
	/*
	string path = "Path/To/Save/Location";
	
	private static bool Saving(GameObject obj)
	{
	    Debug.Log(Application.persistentDataPath);

        // Stream the file with a File Stream. (Note that File.Create() 'Creates' or 'Overwrites' a file.)
        FileStream file = File.Create(Application.persistentDataPath + "/Data.dat");


        // Close the file to prevent any corruptions
        file.Close();

	    return true;
	}*/

}
