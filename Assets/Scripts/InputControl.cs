using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Command
{
    [SerializeField]
    public UnityAction action;
    [SerializeField]
    private Func<bool> shouldExecute;

    public Command(UnityAction action, Func<bool> shouldExecute)
    {
        this.action = action;
        this.shouldExecute = shouldExecute;
    }

    public bool CanExecute()
    {
        return shouldExecute();
    }

    public void Execute()
    {
        action.Invoke();
    }
}

// [CreateAssetMenu(fileName = "CommandsPreset", menuName = "Input", order = 1)]
public class InputControl : MonoBehaviour
{
    [SerializeField]
    public List<Command> commands;

    public void HandleCommands()
    {
        foreach (var command in commands)
        {
            if (command.CanExecute())
                command.Execute();
        }
    }
}

// public class PlayerControl : InputControl
// {
//     public override Vector3 GetMoveDirection()
//     {
//         if (Input.GetKey(KeyCode.UpArrow))
//             return Vector2.up;
//         return base.GetMoveDirection();
//     }

//     public override float GetRotationAngle()
//     {
//         if (Input.GetKeyDown(KeyCode.RightArrow))
//             return 1;
//         else if (Input.GetKeyDown(KeyCode.RightArrow))
//             return 1;
//         return base.GetRotationAngle();
//     }

//     public override float BulletToShot()
//     {
//         if (Input.GetKey(KeyCode.Space))
//             return 1;
//         return base.BulletToShot();
//     }
// }