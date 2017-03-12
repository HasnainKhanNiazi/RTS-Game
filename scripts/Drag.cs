using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
    Vector3 distance;
    float posX;
    float posY;

    void OnMouseDown()
    {
        distance = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - distance.x;
        posY = Input.mousePosition.y - distance.y;
    }

    void OnMouseDrag()
    {
        Vector3 currentpoint = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, distance.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(currentpoint);
        transform.position = worldPos;
    }
}