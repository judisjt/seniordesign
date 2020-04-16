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

	public GameObject run;


	public void SaveSheet()
	{

   		System.IO.File.AppendAllText(@"save/" + fileName.text + ".txt",
   									 run.GetComponent<RUN>().bpm + "\n");

		notes = GetComponentsInChildren<Note>();

        foreach (Note note in notes)
        {
       		System.IO.File.AppendAllText(@"save/" + fileName.text + ".txt",
       									 note.placedNote + "\n");
       	}
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);


	}

}
