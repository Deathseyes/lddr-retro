using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicListAni2 : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    private bool is_update = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        transform.position = new Vector3(-0.88f, -1.5f, 0f);
        animator.SetBool("isPz", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (is_update == true){
            Vector3 target = new Vector3(-0f, -1.5f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, target, 3 * Time.deltaTime);
            if (Vector3.Distance(target, transform.position) < 0.1f)
                is_update = false;
        }
    }

    public void Move()
    {
        Debug.Log("Clicked2");
        animator.SetBool("isPz", true);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        is_update = true;
    }
}
