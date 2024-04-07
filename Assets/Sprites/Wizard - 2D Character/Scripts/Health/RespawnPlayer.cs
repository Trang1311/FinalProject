using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private Heart playerHealth;
    private Transform currentCheck;
    private UIManager manager;
    private void Awake()
    {
        playerHealth = GetComponent<Heart>();
        manager = FindObjectOfType<UIManager>();
    }
    public void Check()
    {
        if(currentCheck == null) 
        { 
            manager.GameOver();
            return;
        }
        playerHealth.RespawnPlayer();
        transform.position = currentCheck.position;

        Camera.main.GetComponent<CameraControl>().MoveToNewRoom(currentCheck.parent);
        
    }
}
