using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public event System.Action<Player> OnLocalPlayerJoined;
    private GameObject gameObject;

    //We Only create this once
    private static GameManager m_Instance; //static means execute without creating an instance

    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("_gameManager");
                m_Instance.gameObject.AddComponent<InputController>();
            }
            return m_Instance;
        }
    }

    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
                m_InputController = gameObject.GetComponent<InputController>();
            return m_InputController;
        }
    }

    //Creating a Player (Local Player means our player which we wanna play with it)
    private Player m_LocalPlayer;
    public Player LocalPlayer {
        get {
            return m_LocalPlayer;
        }
        set {
            m_LocalPlayer = value;
            if (OnLocalPlayerJoined != null)
                OnLocalPlayerJoined(m_LocalPlayer);
        }
    }
}
