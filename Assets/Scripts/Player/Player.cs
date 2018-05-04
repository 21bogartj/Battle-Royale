using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(PlayerState))]
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

    private PlayerState playerState;
    public PlayerState PlayerState
    {
        get
        {
            if (playerState == null)
                playerState = GetComponentInChildren<PlayerState>();
            return playerState;
        }
    }

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float crouchSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] MouseInput MouseControl;
    [SerializeField] AudioController footSteps;
    [SerializeField] float minimumMovementToPlayFootstep;
    [SerializeField] float walkingDelayBetweenClips;
    [SerializeField] float RunningDelayBetweenClips;

	public PlayerAim playerAim;

    InputController playerInput;
    Vector2 mouseInput;
    Vector3 prevPosition; //to implement movement sound
	// Use this for initialization
	void Awake () {
        // This was Test [E #3] inputcontroller = GameManager.Instance.InputController;
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
        prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        /*
         * Tests [E #3]
         * print("Horizontal: " + inputcontroller.
         * print("Mouse: " + inputcontroller.MouseInput);
         */
        move();

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

		//crosshair.LookHeight (mouseInput.y * MouseControl.Sensitivity.y);
		playerAim.SetRotation (mouseInput.y * MouseControl.Sensitivity.y);
    }

    void move()
    {
        float moveSpeed = walkSpeed;
        float DelayBetweenClips = walkingDelayBetweenClips;
        if (GameManager.Instance.InputController.Run)
        {
            moveSpeed = runSpeed;
            DelayBetweenClips = RunningDelayBetweenClips;
        }
        Vector2 direction = new Vector2(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed);
        m_MoveController.Move(direction);
        if (Vector3.Distance(transform.position, prevPosition) > minimumMovementToPlayFootstep)
            footSteps.Play(DelayBetweenClips);
        prevPosition = transform.position;
    }
}
