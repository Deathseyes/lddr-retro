using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{
    public Note note;
    public float noteRate = 1;

    private float nextNote = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextNote)
        {
            nextNote += noteRate;

            Note clone = Instantiate(note);
            clone.xSpeed = 0.85f * (int)(Random.Range(-1, 2));
        } 
    }
}
