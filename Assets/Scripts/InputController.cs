﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assign the InputControll to the GameManager
public class InputController : MonoBehaviour {

    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool Fire1; //for firing

    void Update() {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Fire1 = Input.GetButton("Fire1");
    }
}