using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRotateState : IPlayerRotationStates
{
    PlayerRotation player;

    public void EnterState(PlayerRotation player)
    {
        this.player = player;
    }

    public void UpdatePerState()
    {
        NormalRotation();

        // V 상태 변환 조건
        if (player.PlayerAttack.IsShoot == true || player.PlayerAttack.IsZoom == true) // 타겟팅 중일 때
        {
            player.ChangeStateTo(new TargetingRotateState());
        }
    }

    public void ExitState()
    {

    }

    private void NormalRotation()
    {
        if (player.PlayerMovement.InputVector != Vector2.zero)
        {
            Vector3 moveVector = new Vector3(player.PlayerMovement.InputVector.x, 0, player.PlayerMovement.InputVector.y);

            Quaternion targetRotation = Quaternion.LookRotation(moveVector);

            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, Time.fixedDeltaTime * player.RotateSpeed);
        }
    }
}
