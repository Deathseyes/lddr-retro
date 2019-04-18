using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private readonly RuntimePlatform platform = Application.platform;
    private Animator animator;
    private bool isKeyDown;
    private GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        this.gameControl = gameControllerObject.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                isKeyDown = false;
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                       isKeyDown = checkTouch(Input.GetTouch(i).position);
                    }
                }
                animator.SetBool("IsKeyDown", isKeyDown);
            }
        }
        else if ((platform == RuntimePlatform.WindowsEditor) || 
            (platform == RuntimePlatform.WindowsPlayer))
        {
            isKeyDown = false;
            if (Input.GetMouseButton(0))
            {
                isKeyDown = checkTouch(Input.mousePosition);
            }
            animator.SetBool("IsKeyDown", isKeyDown);
        }
    }

 
    bool checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        return collider.OverlapPoint(touchPos);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Note") && isKeyDown)
        {
            int score = collision.gameObject.GetComponent<Note>().score;
            this.gameControl.addScore(score);

            Destroy(collision.gameObject);

        }

        Debug.Log(collision.gameObject.name + " in key area");
    }
}
