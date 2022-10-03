using Assets.Logic.Pooling;
using UnityEngine;

namespace Assets.Logic.Obstacle {
    public sealed class ObstacleGenerator : MonoBehaviour {

        #region Data

        [SerializeField]
        private SObstacleInfo[] p_obstaclesInfo;
        public string[] ObstacleStyles {
            get {
                string[] res = new string[p_obstaclesInfo.Length];
                for (int index = 0; index < res.Length; index++) {
                    res[index] = p_obstaclesInfo[index].name;
                }
                return res;
            }
        }


        [SerializeField]
        private GameObject p_obstaclePrefab;

        [SerializeField]
        private string p_curObstacleStyle;

        [SerializeField]
        private int p_spawnOffset;

        [SerializeField]
        private float P_INCREMENT_STEP;

        [SerializeField]
        private float P_DISTANCE;

        [SerializeField]
        private float P_MIN_GAP;

        [SerializeField]
        private float P_MAX_GAP;

        [SerializeField]
        private int P_MIN_HEIGHT;

        [SerializeField]
        private int P_MAX_HEIGHT;

        private GameObject p_lastObstacle;

        private float p_spawnX;

        private System.Random p_randomizer;

        #endregion

        private void Start() {
            if (p_obstaclesInfo is null
                || p_obstaclesInfo.Length == 0)
                Debug.LogError($"Obstacles info isn't defined ({name})");
            if (P_MAX_HEIGHT < P_MIN_HEIGHT)
                Debug.LogError($"Max height of gap should be bigger then min distance");
            if (P_MAX_GAP < P_MIN_GAP)
                Debug.LogError($"Max length of gap should be bigger then min gap");
            p_randomizer = new System.Random();
            Initialize();
        }

        private void FixedUpdate() {
            if (p_lastObstacle is null) {
                p_lastObstacle = SpawnObstacle();
                p_spawnX = GameInfo.CameraTarget.transform.position.x;
            }
            if (Mathf.Abs(p_spawnX - GameInfo.CameraTarget.transform.position.x) >= P_DISTANCE) {
                p_lastObstacle = SpawnObstacle();
                p_spawnX = GameInfo.CameraTarget.transform.position.x;
            }
        }

        private void Initialize() {
            for (int i = 0; i < p_obstaclesInfo.Length; i++) {
                if (p_obstaclesInfo[i].topColumns is null
                    || p_obstaclesInfo[i].topColumns.Length == 0)
                    Debug.LogError($"Top column prefabs in {p_obstaclesInfo[i].name} are not defined");
                if (p_obstaclesInfo[i].bottomColumns is null
                    || p_obstaclesInfo[i].bottomColumns.Length == 0)
                    Debug.LogError($"Bottom column prefabs in {p_obstaclesInfo[i].name} are not defined");
                var parent = new GameObject();
                parent.transform.parent = this.transform;
                parent.name = $"Obstacles({p_obstaclesInfo[i].name})";
                p_obstaclesInfo[i].pool = new ObjectPooling<ObstacleBehaviour>();
                p_obstaclesInfo[i].pool.Initialize(
                        parent.transform, 5, p_obstaclePrefab.GetComponent<ObstacleBehaviour>()
                    );
            }
        }

        public void SetStyle(string style) {
            p_curObstacleStyle = style;
        }

        private GameObject SpawnObstacle() {
            GameObject result = null;
            for (int i = 0; i < p_obstaclesInfo.Length; i++) {
                if (string.Compare(p_obstaclesInfo[i].name, p_curObstacleStyle) == 0) {
                    var obstacle = p_obstaclesInfo[i].pool.GetObject();
                    result = obstacle.gameObject;
                    SetObstacleConfig(obstacle, i);
                    result.transform.position = GameInfo.CameraTarget.transform.position + Vector3.right * p_spawnOffset;
                    result.SetActive(true);
                    return result;
                }
            }
            return result;
        }

        private void SetObstacleConfig(ObstacleBehaviour sample, int type) {
            sample.SetColumns(p_obstaclesInfo[type]);
            sample.SetGaps(GenerateExpGap());
            sample.SetHeights(GenerateRndHeight());
        }

        private float GenerateExpGap() {
            float result = (float)(P_MAX_GAP - GameInfo.Score * P_INCREMENT_STEP);
            return (result < P_MIN_GAP) ? P_MIN_GAP : result;
        }

        private float GenerateRndHeight() {
            float height = p_randomizer.Next(P_MIN_HEIGHT, P_MAX_HEIGHT);
            height += p_randomizer.Next(0, 50) / 100f;
            return height;
        }
    }
}
