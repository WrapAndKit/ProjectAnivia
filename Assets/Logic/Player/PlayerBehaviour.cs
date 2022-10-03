using Assets.Logic.Other.Jump;
using Assets.Logic.Other.Movement;
using UnityEngine;

namespace Assets.Logic.Player {
    /// <summary>
    /// Script with Player behaviour
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerBehaviour : MonoBehaviour {

        #region Data

        [SerializeReference]
        private MovementBehaviour p_movementBehaviour;

        public MovementBehaviour MovementBehaviour {
            get {
                return p_movementBehaviour;
            }
            set {
                p_movementBehaviour = value;
            }
        }

        [SerializeField]
        private JumpBehaviour p_jumpBehaviour;
        public JumpBehaviour JumpBehaviour {
            get {
                return p_jumpBehaviour;
            }
            set {
                p_jumpBehaviour = value;
            }
        }

        [SerializeField]
        private float p_scoreIncrement;
        public float ScoreIncrement {
            get {
                return p_scoreIncrement;
            }
        }

        private Rigidbody2D p_rigidbody2d;

        private float p_startX;

        private EPlayerState p_state;

        public bool IsFlying => p_state == EPlayerState.Fly;

        public bool IsSleeping => p_state == EPlayerState.Sleep;

        public bool IsAlive => p_state != EPlayerState.Dead;

        #endregion

        private void Start() {
            p_rigidbody2d = GetComponent<Rigidbody2D>();
            p_movementBehaviour = GetComponent<MovementBehaviour>();
            p_jumpBehaviour = GetComponent<JumpBehaviour>();
            p_startX = transform.position.x;
            if (GameInfo.IsViewMode)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }

        private void FixedUpdate() {
            if (GameInfo.IsPlaying && IsFlying)
                GameInfo.SetScore((int)(Mathf.Abs(p_startX - transform.position.x) * p_scoreIncrement));
        }

        private void Update() {
            if (!GameInfo.IsPlaying) {
                return;
            }

            if (Input.GetMouseButtonDown(0)) {
                if (IsSleeping) {
                    WakeUp();
                }
                p_jumpBehaviour.Jump();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (IsFlying) {
                Die();
                GameInfo.IsPlaying = false;
                GameInfo.PauseMenu.SetActive(true);
                GameInfo.GameUI.SetActive(false);
            }
        }

        public void FallAsleep() {
            p_state = EPlayerState.Sleep;
        }

        private void WakeUp() {
            if (IsSleeping) {
                p_state = EPlayerState.Fly;
                p_movementBehaviour.Move();
            }
        }

        private void Die() {
            p_state = EPlayerState.Dead;
            var highestScore = PlayerPrefs.GetInt("HighestScore", 0);
            if (GameInfo.Score > highestScore) {
                PlayerPrefs.SetInt("HighestScore", GameInfo.Score);
                PlayerPrefs.Save();
            }
        }

#if UNITY_EDITOR

        private void OnValidate() {
            if (gameObject.activeInHierarchy == false)
                return;
            p_movementBehaviour = GetComponent<MovementBehaviour>();
            p_jumpBehaviour = GetComponent<JumpBehaviour>();
        }

        private void OnDrawGizmos() {
            if (Application.isPlaying) {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(p_rigidbody2d.position, p_rigidbody2d.position + p_rigidbody2d.velocity.normalized / 2);
            }
        }

#endif

    }
}