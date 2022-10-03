using UnityEngine;

namespace Assets.Logic.Other.Movement {

    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class MovementBehaviour : MonoBehaviour, IMovement {

        #region Data

        [SerializeField]
        private protected float p_speed;
        public float Speed {
            get {
                return p_speed;
            }
        }

        private protected Rigidbody2D p_rigidbody2d;

        #endregion

        public abstract void Move();
    }
}
