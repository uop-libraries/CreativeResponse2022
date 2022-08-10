using UnityEngine;
using UnityEngine.UI;

namespace SGT3V.UI.Demo
{
    public class ResizeAndBlend : MonoBehaviour
    {
        private ScrollSnap scrollSnap;
        private int pageCount;
        private Transform[] cards;
        private Image[] pageBackgrounds;

        private void Start()
        {
            scrollSnap = FindObjectOfType<ScrollSnap>();

            pageCount = scrollSnap.Content.childCount;

            cards = new Transform[pageCount];
            pageBackgrounds = new Image[pageCount];
            for (int i = 0; i < cards.Length; i++)
            {
                Transform page = scrollSnap.Content.GetChild(i);
                pageBackgrounds[i] = page.GetComponent<Image>();
                cards[i] = page.GetChild(0);
            }
        }

        private void Update()
        {
            int index = Mathf.RoundToInt(scrollSnap.ScrollAmount);

            float blend = Mathf.Abs(Mathf.Cos(scrollSnap.ScrollAmount * Mathf.PI)) + 0.2f;

            cards[index].localScale = Vector3.one * blend;

            Color color = pageBackgrounds[index].color;
            color.a = blend;
            pageBackgrounds[index].color = color;
        }
    }
}