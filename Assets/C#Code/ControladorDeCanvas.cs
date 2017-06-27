using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeCanvas : MonoBehaviour
{
    bool active;
    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Activar()
    {
        active = true;
        canvas.enabled = active;
    }

    public void Desactivar()
    {
        active = false;
        canvas.enabled = active;
    }
}
