using UnityEngine;


namespace Dungeons.UI
{
    public class BaseWindow : MonoBehaviour
    {
        public virtual void ShowWindow()
        {
            gameObject.SetActive(true);
        }

        public virtual void HideWindow()
        {
            gameObject.SetActive(false);
        }
    }
}

