using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingRotateState : IPlayerRotationStates
{
    PlayerRotation player;

    public void EnterState(PlayerRotation player)
    {
        this.player = player;

        this.player.PlayerMovement.MoveSpeed = 2.5f; // 타겟팅 시 속도 감소
    }

    public void UpdatePerState()
    {
        TargetingRotation();

        // V 상태 변환 조건
        if (player.PlayerAttack.IsShoot == false && player.PlayerAttack.IsZoom == false) // 타겟팅 해제할 때
        {
            player.ChangeStateTo(new NormalRotateState());
        }
    }

    public void ExitState()
    {
        player.PlayerMovement.ResetMoveSpeed(); // 타겟팅 끝낼 시 속도 원상복귀
    }

    private void TargetingRotation()
    {
        // TODO: 타겟팅 시 마우스 커서 위치 바라보게 해야됨.
    }
}
