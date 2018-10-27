using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PhysicsCallRegister : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{name} -> collided with -> {collision.otherCollider.name}");
    }
}
