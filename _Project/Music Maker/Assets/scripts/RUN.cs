using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RUN : MonoBehaviour
{
    public float speed;
    public float bpm;
    public Transform sheet;
    public Transform[] notes;
    public GameObject currentStaff;
    public Transform beat1;
    public Transform beat2;
    public float distance;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        bpm = slider.value;
        distance = beat2.transform.position.x - beat1.transform.position.x;
    }

    // Update is called once per frame

    void Update()
    {
        sheet.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void StartScrolling()
    {
        speed = (distance * bpm / 60) * 2;
    }
}
