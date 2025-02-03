using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    [RequireComponent(typeof(Button))]
    public class URLButton : MonoBehaviour
    {
        [SerializeField] private string URL;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Open);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Open);
        }

        private void Open()
        {
            Application.OpenURL(URL);
        }
    }
}