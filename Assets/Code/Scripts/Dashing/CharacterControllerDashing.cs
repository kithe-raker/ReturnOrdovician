using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class CharacterControllerDashing : MonoBehaviour
{
    PlayerCharacterControllerDoubleJump moveScript;

    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;

    public bool isDashing = false;
    public bool isCooldown = false;

    void Start()
    {
        moveScript = GetComponent<PlayerCharacterControllerDoubleJump>();
    }

    void Update()
    {
        // check if dash button is pressed and dash is not on cooldown
        if (Input.GetKeyDown(KeyCode.F) && !isDashing && !isCooldown)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        // remember current velocity before dashing
        Vector3 oldVelocity = moveScript.CharacterVelocity;
        // set new velocity to dash speed in the current move direction
        Vector3 targetVelocity = transform.forward * dashSpeed;
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            // use Vector3.Lerp() to smoothly interpolate the player's velocity
            moveScript.CharacterVelocity = Vector3.Lerp(
                oldVelocity, targetVelocity,
                moveScript.MovementSharpnessOnGround * dashTime
            ) ;
            yield return null;
        }
        // reset velocity back to the old velocity after dash
        moveScript.CharacterVelocity = oldVelocity;
        isDashing = false;
        isCooldown = true;
        yield return new WaitForSeconds(dashCooldown);
        isCooldown = false;
    }
}
