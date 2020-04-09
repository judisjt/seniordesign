using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RUN : MonoBehaviour
{
    private float speed;
    public float bpm;
    public Transform sheet;
    public Transform cursor;
    public Transform beat1;
    public Transform beat2;
    private float distance;
    public Slider slider;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        bpm = slider.value;
        distance = beat2.transform.position.x - beat1.transform.position.x;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!isPaused)
            {
                isPaused = true;
            }
            else
            {
                isPaused = false;
            }
        }
        if (!isPaused)
        {
            sheet.transform.Translate(Vector2.left * speed * Time.deltaTime);
            cursor.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public void StartScrolling()
    {
        speed = (distance * bpm / 60) * 2;
    }
}
