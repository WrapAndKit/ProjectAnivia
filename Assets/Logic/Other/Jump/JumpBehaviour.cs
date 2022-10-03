using UnityEngine;

namespace Assets.Logic.Other.Jump {

    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class JumpBehaviour : MonoBehaviour, IJump {

        #region Data

        [SerializeField]
        private protected float p_jumpForce;

        [SerializeField]
        private protected float p_maxSpeed;

        private protected Rigidbody2D p_rigidbody2d;

        #endregion

        public abstract void Jump();
    }
}
