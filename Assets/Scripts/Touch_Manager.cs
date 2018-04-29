using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Manager : MonoBehaviour {
    public LayerMask mask;
    // Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update ()
    {
        for(var i=0;i<Input.touchCount;++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero,Mathf.Infinity,1<<8);

                if(hit)
                {
                    hit.collider.gameObject.GetComponent<Botton>().Button_Touch();
                }
            }
        }
	}


}
