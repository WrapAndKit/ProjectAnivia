using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.UI.Scripts {

    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public abstract class ButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

        #region Data

        private Image p_img;

        [SerializeField]
        private Sprite p_default, p_pressed;

        private Button p_button;

        #endregion

        private void Awake() {
            p_button = GetComponent<Button>();
            p_img = GetComponent<Image>();
            p_button.onClick.AddListener(ButtonClicked);
        }

        public void OnPointerDown(PointerEventData eventData) {
            p_img.sprite = p_pressed;
            GameInfo.AudioManager.PlaySFX("UIButtonDown");
        }

        public void OnPointerUp(PointerEventData eventData) {
            p_img.sprite = p_default;
        }

        public abstract void ButtonClicked();
    }
}
