using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class savePanel : MonoBehaviour
{

	public GameObject panel;
	public GameObject run;

	public void EnablePanel()
	{
		run.GetComponent<RUN>().isPaused = true;
		panel.SetActive(true);
	}
}
