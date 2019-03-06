using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicListAni1 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool is_update = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_update == true){
            Vector3 target = new Vector3(-0f, -1.5f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, target, 3 * Time.deltaTime);
            if (Vector3.Distance(target, transform.position) < 0.01f)
                is_update = false;
        }
    }

    public void Move()
    {
        is_update = true;
    }

    public void Hide()
    {
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
}
