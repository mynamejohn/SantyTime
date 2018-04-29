using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCleaner : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Notes")
            Destroy(collision.gameObject);
    }
}
