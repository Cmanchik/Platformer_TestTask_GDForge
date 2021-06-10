using UnityEngine;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private RectTransform mainMenu;
        [SerializeField] private RectTransform losePanel;
        public void OpenPanel(RectTransform panel)
        {
            panel.gameObject.SetActive(true);
        }

        public void ClosePanel(RectTransform panel)
        {
            panel.gameObject.SetActive(false);
        }

        public void OpenMainMenu()
        {
            OpenPanel(mainMenu);
        }

        public void OpenLosePanel()
        {
            OpenPanel(losePanel);
        }
    }
}
