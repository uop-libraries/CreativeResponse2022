using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SGT3V.UI
{
    public class IndexTable : UIBehaviour
    {
        public ScrollSnap ScrollSnap;
        [Min(3)] public float ToggleSize;
        [Min(0)] public float TogglePadding;

        private Toggle[] toggles;

        private new void Start()
        {
            base.Start();

            ScrollSnap = gameObject.GetComponentInParent<ScrollSnap>();
            ScrollSnap.OnPageChanged.AddListener(OnPageChanged);
            SetUpToggles();
        }

        private void SetUpToggles()
        {
            toggles = GetComponentsInChildren<Toggle>();

            for (int i = 0; i < toggles.Length; i++)
            {
                int index = i;
                toggles[index].onValueChanged.AddListener((active) => {
                    if (active)
                    {
                        SetSnapScrollIndex(index);
                    }
                });
            }
        }

        private void OnPageChanged(int index)
        {
            toggles[index].isOn = true;
        }

        private void SetSnapScrollIndex(int index)
        {
            ScrollSnap.CurrentPageIndex = index;
        }
    }
}
