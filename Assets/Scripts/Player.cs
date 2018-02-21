using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {
    // This was Test [E #3] InputController inputcontroller;
    [System.Serializable]
    //Add some Sensitivity
    public class MouseInput {
        public Vector2 Damping;
        public Vector2 Sensitivity;        
    }

    public  MoveController m_MoveController;
    public MoveController MoveController
    {
        get
        {
            if (m_MoveController == null)
            {
                m_MoveController = new MoveController();
                m_MoveController.GetComponent<MoveController>();
            }
            return m_MoveController;
        }
    }

    private Crosshair m_crosshair;
    public Crosshair crosshair
    {
        get
        {
            if (m_crosshair == null)
                m_crosshair = GetComponentInChildren<Crosshair>();
            return m_crosshair;
        }
    }

    [SerializeField] float speed;
    [SerializeField] MouseInput MouseControl;


    InputController playerInput;
    Vector2 mouseInput;
	// Use this for initialization
	void Awake () {
        // This was Test [E #3] inputcontroller = GameManager.Instance.InputController;
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;

	}
	
	// Update is called once per frame
	void Update () {
        /*
         * Tests [E #3]
         * print("Horizontal: " + inputcontroller.
         * print("Mouse: " + inputcontroller.MouseInput);
         */
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        m_MoveController.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);
	}
}
