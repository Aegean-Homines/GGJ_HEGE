using UnityEngine;
using System.Collections;

public class CameraSizer : MonoBehaviour {

    void Awake()
    {
        float _windowAspect = Camera.main.aspect;
        Camera.main.orthographicSize = (30.0f / _windowAspect) / 2f;
    }
}
