using ProjectWItch.Scripts.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectWitch.Scripts.Player.Spells
{
    /// <summary>
    /// Handle the logic for fireball spell.
    /// </summary>
    public class Fireball : MonoBehaviour
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
        /// A prefab that use to spawn hit effect when fireball hit an object.
        /// </summary>
        [SerializeField]
        private GameObject hitEffect = null;

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

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                if (collision.gameObject.GetComponent<IBurnable>() != null)
                {
                    collision.gameObject.GetComponent<IBurnable>().GetBurn();

                    Instantiate(hitEffect, transform.position, Quaternion.identity);

                    Destroy(gameObject);
                }
                else
                {
                    Instantiate(hitEffect, transform.position, Quaternion.identity);

                    Destroy(gameObject);
                }
            }
        }

        #endregion

        #region Main

        /// <summary>
        /// Move the fireball forward when spawned.
        /// </summary>
        /// <returns>
        /// return task. 
        /// </returns>
        private async Task MoveForward()
        {
            _rb.velocity = transform.forward * moveSpeed;

            await Task.Delay(3000, _cancellationTokenSource.Token);

            Destroy(gameObject);
        }

        #endregion
    }
}