using Cysharp.Threading.Tasks;
using ProjectWItch.Scripts.Interfaces;
using System.Threading;
using UnityEngine;

namespace ProjectWItch.Scripts.Environments
{
    /// <summary>
    /// Implementation of IBurnable for thorn.
    /// </summary>
    public class Thorn : MonoBehaviour, IBurnable
    {
        #region Variable

        /// <summary>
        /// Collection of rays to detect the surrounding of thorn.
        /// </summary>
        private Ray[] rays = null;

        /// <summary>
        /// Prefab that spawn when thorn is on fire.
        /// </summary>
        [SerializeField]
        private GameObject fireEffect = null;

        /// <summary>
        /// Prefab that spawn smoke when thorn fully burned.
        /// </summary>
        [SerializeField]
        private GameObject smokeEndEffect = null;

        /// <summary>
        /// Token that use to cancel the task when the object is disabled.
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource = null;

        #endregion

        #region IBurnable

        public bool HasBurned { get; set; } = default;

        public async UniTask GetBurn()
        {
            HasBurned = true;

            fireEffect.SetActive(true);

            await UniTask.Delay(2000, cancellationToken: _cancellationTokenSource.Token);

            foreach (var r in rays)
            {
                RaycastHit hit;

                if (Physics.Raycast(r, out hit, 1.5f))
                {
                    if (hit.transform.GetComponent<IBurnable>() != null)
                    {
                        if (!hit.transform.GetComponent<IBurnable>().HasBurned)
                        {
                            await hit.transform.GetComponent<IBurnable>().GetBurn();
                        }
                    }
                }
            }

            await UniTask.Delay(4000, cancellationToken: _cancellationTokenSource.Token);

            Instantiate(smokeEndEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        #endregion

        #region Mono

        private void Awake()
        {
            rays = new Ray[4];

            fireEffect.SetActive(false);

            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }

        private void Start()
        {
            InitRays();
        }

        #endregion

        #region Main

        /// <summary>
        /// Make initialization rays to detect surrounding.
        /// </summary>
        private void InitRays()
        {
            var frontRay = new Ray(transform.position, transform.forward);
            var backRay = new Ray(transform.position, -transform.forward);
            var rightRay = new Ray(transform.position, transform.right);
            var leftRay = new Ray(transform.position, -transform.right);

            rays[0] = frontRay;
            rays[1] = backRay;
            rays[2] = rightRay;
            rays[3] = leftRay;
        }

        #endregion
    }
}