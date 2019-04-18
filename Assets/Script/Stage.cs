using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        this.gameControl = gameControllerObject.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            Destroy(collision.gameObject);

            gameControl.missAction();
        }
    }
}
