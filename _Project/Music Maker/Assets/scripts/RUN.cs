using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUN : MonoBehaviour
{
    private float speed;
    public float bpm;
    public Transform sheet;
    public Transform[] notes;
    public GameObject currentStaff;

    // Start is called before the first frame update
    void Start()
    {
        float beatspersecond = bpm / 60;
        float secondsperbeat = 1 / beatspersecond;
        speed = 215 / secondsperbeat;
    }

    // Update is called once per frame
    void Update()
    {
        sheet.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
