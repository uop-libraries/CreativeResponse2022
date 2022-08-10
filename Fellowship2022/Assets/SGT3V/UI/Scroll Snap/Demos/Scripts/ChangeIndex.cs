using UnityEngine;

namespace SGT3V.UI.Demo
{
    public class ChangeIndex : MonoBehaviour
    {
        private ScrollSnap scrollSnap;

        private void Start()
        {
            scrollSnap = FindObjectOfType<ScrollSnap>();
        }

        public void GoToNextPage()
        {
            scrollSnap.CurrentPageIndex++;
        }

        public void GoToPreviousPage()
        {
            scrollSnap.CurrentPageIndex--;
        }
    }
}