using ProjectWItch.Scripts.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ProjectWitch.Scripts.Player.Spells
{
    /// <summary>
    /// Handle the logic for wind slash spell.
    /// </summary>
    public class WindSlash : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Component that use to move the object.
        /// </summary>
        private Rigidbody _rb = null;

        /// <summary>
        /// The value of speed when this object move.
        /// </summary>
        [SerializeField]
        private float moveSpeed = default;

        /// <summary>
        /// Condition where the wind spell has contacted with fire or not.
        /// </summary>
        private bool _isContactWithFire = default;

        /// <summary>
        /// Token that use to cancel the task when object disable.
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();

            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }

        private async void Start()
        {
            await MoveForward();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<IBlowable>()  != null)
            {
                other.gameObject.GetComponent<IBlowable>().GetBlow();
            }

            if (other.gameObject.GetComponent<IBurnable>() != null)
            {
                var burnObject = other.gameObject.GetComponent<IBurnable>();

                if (burnObject.HasBurned) 
                {
                    _isContactWithFire = true;
                }

                if (_isContactWithFire && !burnObject.HasBurned)
                {
                    burnObject.GetBurn();
                }
            }
        }

        #endregion

        #region Main

        /// <summary>
        /// Move the spell to forward direction of the player.
        /// </summary>
        /// <returns>
        /// return task.
        /// </returns>
        private async UniTask MoveForward()
        {
            _rb.velocity = transform.forward * moveSpeed;

            await Task.Delay(1000, _cancellationTokenSource.Token);

            Destroy(gameObject);
        }

        #endregion
    }
}