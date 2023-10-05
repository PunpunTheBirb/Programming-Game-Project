using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
  private static Controls _controls;

  public static void Init(Player myPlayer)
  {

    _controls = new Controls();

    //if a movement is inputed set the movement direction in direction inputed
    _controls.Game.Movement.performed += ctx =>
    {
      myPlayer.SetMovementDirection(ctx.ReadValue<Vector3>());
    };

    //if player jumps call the playerJump function in the Player class
    _controls.Game.Jump.performed += _ =>
    {
      myPlayer.playerJump();
    };
  
    _controls.Game.Attack.performed += _ =>
    {
      Debug.Log("Attack");
    };

    _controls.Game.Crouch.performed += _ =>
    {
      Debug.Log("Crouch");
    };

    _controls.Permanent.Enable();

  }

   public static void GameMode()
   {
    //controls player inputs avaiable based on gamestate
     _controls.Game.Enable();
     _controls.UI.Disable();
   }
    
   public static void UIMode()
   {
    //controls player inputs avaiable based on gamestate
     _controls.UI.Enable();
     _controls.Game.Disable();
   }


}
