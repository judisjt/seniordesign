using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;

public class loadButton : MonoBehaviour
{
    public void Press()
    {
     
		// Open file with filter
		var extensions = new [] {
		    new ExtensionFilter("Text Files", "txt"),
		    new ExtensionFilter("All Files", "*" ),
		};
		var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true);
             Debug.Log("File Path: " + paths[0]);
        PlayerPrefs.SetString("LoadPath", paths[0]);   
    }

}
