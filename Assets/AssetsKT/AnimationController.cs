using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
 public void Walking()
    {
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsJump", false);
    }

    public void Idle()
    {
        anim.SetBool("IsRunning", false);
        //anim.SetBool("IsTeleport", false);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsJump", false);
        anim.SetBool("IsDodge", false);
       // anim.SetBool("IsJumping", false);


    }

    public void Teleport()
    {
        anim.SetBool("IsRolling", false);
        anim.SetBool("IsTeleport", false);
        anim.SetBool("IsJumping", true);
        StartCoroutine(JumpTime());
       

    }

    public void Aim()
    {
        
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsPunching", false);
        anim.SetBool("IsTeleport", true);
    }
    public void Run()
    {
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsRunning", true);
        anim.SetBool("IsJump", false);
    }
    public void RunJump()
    {
        anim.SetBool("IsJump", true);
        anim.SetBool("IsRunning", true);
    }
    public void Jump()
    {
        anim.SetBool("IsJump", true);
        anim.SetBool("IsRunning", false);
    }
    public void Fight()
    {

    }

    public void Roll()
    {
        anim.SetBool("IsRolling", true);
    }

    public void Dodge()
    {
        anim.SetBool("IsDodge", true);
    }
    IEnumerator JumpTime()
    {
        yield return new WaitForSeconds(4f);
        anim.SetBool("IsJumping", false);
    }
    
}
