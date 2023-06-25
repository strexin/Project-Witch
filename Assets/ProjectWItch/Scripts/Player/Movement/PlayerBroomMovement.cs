using ProjectWItch.Scripts.Interfaces;
using System;
using UnityEngine;

namespace ProjectWitch.Scripts.Player.Movement
{
    public class PlayerBroomMovement : MonoBehaviour, IMoveData, IPlayerEvent
    {
        #region IMoveData

        public float MoveSpeed { get; set; } = default;
        public float MaxVelocity { get; set; } = default;
        public float RotationSpeed { get; set; } = default;

        #endregion

        #region IPlayerEvent

        public event Action<float> OnPlayerMove = null;

        public event Action<bool> OnPlayerChangeBroom = null;

        #endregion
    }
}