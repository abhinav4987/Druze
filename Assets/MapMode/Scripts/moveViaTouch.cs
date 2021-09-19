using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveViaTouch : MonoBehaviour
{
    // Start is called before the first frame update
    Touch touch;
    Vector3 touchPosition, whereToMove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 ) {
            touch = Input.GetTouch(0);
            Camera cam = Camera.main;
            whereToMove = cam.ScreenToWorldPoint(touch.position);
            transform.position = new Vector3(whereToMove.x, whereToMove.y, transform.position.z);
        }
    }
}
