using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleArrowMove : MonoBehaviour
{
    [SerializeField] Vector2 speed = Vector2.one;

    private void Update()
    {
        var pos = transform.position;
        float deltaTime = Time.deltaTime;

        if (Input.GetKey(KeyCode.I)) {
            pos.y += speed.y * deltaTime;
        } else if (Input.GetKey(KeyCode.K)) {
            pos.y -= speed.y * deltaTime;
        }

        if (Input.GetKey(KeyCode.L)) {
            pos.x += speed.x * deltaTime;
        } else if (Input.GetKey(KeyCode.J)) {
            pos.x -= speed.x * deltaTime;
        }

        transform.position = pos;
    }
}
