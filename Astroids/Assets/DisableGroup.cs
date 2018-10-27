using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGroup : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] components;
    [SerializeField] GameObject[] gameObjects;
    private void OnEnable()
    {
        foreach (var comp in components) {
            comp.enabled = true;
        }
        foreach (var ob in gameObjects) {
            ob.SetActive(true);
        }
    }
    private void OnDisable()
    {
        foreach (var comp in components) {
            comp.enabled = false;
        }
        foreach (var ob in gameObjects) {
            ob.SetActive(false);
        }
    }
}
