using Assets.Logic.Pooling;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic.Environment {

    public class EnvironmentGeneratorBehaviour : MonoBehaviour {

        #region Data

        [SerializeField]
        private protected GameObject p_prefab;

        [SerializeField]
        private protected float p_offset = 10;

        private protected ObjectPooling<EnvironmentBehaviour> p_pooling;

        private protected float p_distanceToPlayer;

        private protected List<EnvironmentBehaviour> p_curView;

        #endregion

        void Awake() {
            p_pooling = new ObjectPooling<EnvironmentBehaviour>();
            p_pooling.Initialize(transform, 5, p_prefab.GetComponent<EnvironmentBehaviour>());
            SceneBuild();
        }

        void FixedUpdate() {
            var distance = Mathf.Abs(GameInfo.CameraTarget.transform.position.x - p_curView[1].transform.position.x);
            if (distance > p_offset) {
                var obj = p_pooling.GetObject();
                obj.transform.position = p_curView[3].transform.position + Vector3.right * p_offset;
                obj.gameObject.gameObject.SetActive(true);
                p_curView.Add(obj);
                p_curView[0].gameObject.SetActive(false);
                p_curView.RemoveAt(0);
            }
        }

        void Update() {
            p_curView[0].transform.position = p_curView[1].transform.position + Vector3.left * p_offset;
            p_curView[2].transform.position = p_curView[1].transform.position + Vector3.right * p_offset;
            p_curView[3].transform.position = p_curView[2].transform.position + Vector3.right * p_offset;
        }

        private void SceneBuild() {
            p_curView = new List<EnvironmentBehaviour>();
            for (int i = 0; i < 4; i++) {
                var obj = p_pooling.GetObject();
                obj.transform.position = new Vector3(
                    GameInfo.CameraTarget.transform.position.x + (-p_offset / 2) + p_offset * i,
                    GameInfo.CameraTarget.transform.position.y,
                    p_prefab.transform.position.z
                );
                obj.gameObject.SetActive(true);
                p_curView.Add(obj);
            }
        }
    }
}
