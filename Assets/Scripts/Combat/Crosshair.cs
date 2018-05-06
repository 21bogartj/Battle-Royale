using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField] Texture2D texture;
    [SerializeField] int size;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;

    void OnGUI()
    {
        if (GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.Aiming
            || GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AimingAndFiring)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            screenPosition.y = Screen.height - screenPosition.y;
            GUI.DrawTexture(new Rect(screenPosition.x - size / 2, screenPosition.y - size / 2, size, size), texture);
            GUI.depth = 0;
        }
    }
}
