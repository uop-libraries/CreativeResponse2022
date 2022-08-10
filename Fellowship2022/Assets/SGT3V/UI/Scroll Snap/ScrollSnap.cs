/* 
    Copyright (C) 2021 SGT3V, Sercan Altundas
    
    Visit for details: https://app.gitbook.com/@sercan-altundas/s/asset-store
*/

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SGT3V.UI
{
    [HelpURL("https://app.gitbook.com/@sercan-altundas/s/asset-store/ui-components/scroll-snap")]
    [SelectionBase]
    [ExecuteInEditMode]
    [AddComponentMenu("UI/Scroll Snap")]
    [RequireComponent(typeof(RectTransform))]
    public sealed class ScrollSnap : UIBehaviour, IDragHandler, IEndDragHandler
    {
        /// <summary>
        ///     Leaning side of the horizontal alignment for ScrollSnap pages.
        /// </summary>
        public enum HorizontalAlignment
        {
            Left,
            Right
        }

        /// <summary>
        ///     Leaning side of the vertical alignment for ScrollSnap pages.
        /// </summary>
        public enum VerticalAlignment
        {
            Top,
            Bottom
        }

        /// <summary>
        ///     Container for scroll snap pages.
        /// </summary>
        public RectTransform Content;

        /// <summary>
        ///     Axis of the pages.
        /// </summary>
        public RectTransform.Axis ScrollSnapAxis = RectTransform.Axis.Horizontal;

        /// <summary>
        ///     Align start of the pages to the top or to the bottom of the <see cref="Content"/>.
        /// </summary>
        public VerticalAlignment VerticalPageAlignment = VerticalAlignment.Bottom;

        /// <summary>
        ///     Align start of the pages to the left side or to the right side of the <see cref="Content"/>.
        /// </summary>
        public HorizontalAlignment HorizontalPageAlignment = HorizontalAlignment.Left;

        /// <summary>
        ///     Size of the side areas in pixels to scroll out of the first and the last pages.
        /// </summary>
        [Min(0)] public float ScrollOutMargin = 100;

        private readonly Color ScrollOutMarginGizmoColor = new Color(0.86f, 0.46f, 0.20f);

        /// <summary>
        ///     Size of the center area in pixels, that is necessary for activating the snap. If the next page enters this range page will snap.
        /// </summary>
        [Min(0)] public float SnapAreaSize = 200;

        private readonly Color SnapAreaSizeGizmoColor = new Color(0.33f, 0.60f, 0.78f);

        /// <summary>
        ///     Speed of snap between 1 to 10. Value 10 snaps immediately.
        /// </summary>
        [Range(1, 10)] public float SnapSpeed = 3;

        /// <summary>
        ///     Index of the current page in the <see cref="Content"/>.
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                return currentPageIndex;
            }
            set
            {
                currentPageIndex = Mathf.Clamp(value, 0, Content.childCount - 1);
            }
        }
        private int currentPageIndex;

        /// <summary>
        ///     Amount of the scroll from 0 to number of pages.
        /// </summary>
        public float ScrollAmount { get; private set; }

        [Serializable] public class ScrollSnapEvent : UnityEvent<int> { }

        /// <summary>
        ///     Event called on page changes. Returns the changed index.
        /// </summary>
        public ScrollSnapEvent OnPageChanged = new ScrollSnapEvent();

        private bool isDragged;
        private int dragDirection;
        private float fullWidth, fullHeight;

        /// <summary>
        ///     Width of <see cref="ScrollSnap"/> page.
        /// </summary>
        [SerializeField] public float PageWidth { get; private set; }

        /// <summary>
        ///     Height of <see cref="ScrollSnap"/> page.
        /// </summary>
        [SerializeField] public float PageHeight { get; private set; }

        private bool IsHorizontal => ScrollSnapAxis == RectTransform.Axis.Horizontal;

        private bool IsLeftAligned => HorizontalPageAlignment == HorizontalAlignment.Left;

        private bool IsBottomAligned => VerticalPageAlignment == VerticalAlignment.Bottom;

        private float PageSize => IsHorizontal ? PageWidth : PageHeight;

        private int Direction => IsHorizontal ? (IsLeftAligned ? -1 : 1) : (IsBottomAligned ? -1 : 1);

        private float AnchoredPosition => IsHorizontal ? Content.anchoredPosition.x : Content.anchoredPosition.y;

        private new void Start()
        {
            base.Start();

            ResetScrollSnapUI();
        }

        protected override void OnRectTransformDimensionsChange()
        {
            ResetScrollSnapUI();
        }

        private bool IsContentNull()
        {
            if (Content == null)
            {
                Debug.LogWarning($"ScrollSnap.ResetScrollSnapUI: Content field is null on ScrollSnap component.");
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Resets the page size and position.
        /// </summary>
        public void ResetScrollSnapUI()
        {
            if (IsContentNull()) return;

            SetPageSizes();
            SetPagePositions();
            SetContentPosition();
        }

        private void SetPageSizes()
        {
            PageWidth = (transform as RectTransform).rect.width;
            PageHeight = (transform as RectTransform).rect.height;

            for (int i = 0; i < Content.childCount; i++)
            {
                (Content.GetChild(i) as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PageWidth);
                (Content.GetChild(i) as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, PageHeight);
            }

            fullWidth = (Content.childCount - 1) * PageWidth;
            fullHeight = (Content.childCount - 1) * PageHeight;
        }

        private void SetPagePositions()
        {
            for (int i = 0; i < Content.childCount; i++)
            {
                if (IsHorizontal)
                {
                    int direction = IsLeftAligned ? 1 : -1;
                    (Content.GetChild(i) as RectTransform).anchoredPosition = new Vector2(i * PageWidth * direction, 0);
                }
                else
                {
                    int direction = IsBottomAligned ? 1 : -1;
                    (Content.GetChild(i) as RectTransform).anchoredPosition = new Vector2(0, i * PageHeight * direction);
                }
            }

            fullWidth = (Content.childCount - 1) * PageWidth;
            fullHeight = (Content.childCount - 1) * PageHeight;
        }

        private void SetContentPosition()
        {
            float value = currentPageIndex * PageSize * Direction;
            float x = IsHorizontal ? value : 0;
            float y = IsHorizontal ? 0 : value;
            Content.anchoredPosition = new Vector2(x, y);
        }

        private void LateUpdate()
        {
            if (Content != null && Application.isPlaying)
            {
                SnapToPage();
            }
        }

        private void SnapToPage()
        {
            if (!isDragged)
            {
                float value = Mathf.Lerp(AnchoredPosition, currentPageIndex * PageSize * Direction, 0.1f * SnapSpeed);
                float x = IsHorizontal ? value : 0;
                float y = IsHorizontal ? 0 : value;
                Content.anchoredPosition = new Vector2(x, y);
            }

            ScrollAmount = Math.Abs((float)Math.Round(-AnchoredPosition / PageSize, 2));
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (IsContentNull()) return;

            isDragged = false;
            SetCurrentPageIndex();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (IsContentNull()) return;

            isDragged = true;
            ProcessDrag(eventData.delta);
            StopDrag();
        }

        private void StopDrag()
        {
            float fullSize = IsHorizontal ? fullWidth : fullHeight;

            if (AnchoredPosition * -Direction >= ScrollOutMargin)
            {
                Content.anchoredPosition = IsHorizontal ? new Vector2(ScrollOutMargin * -Direction, 0) : new Vector2(0, ScrollOutMargin * -Direction);
            }

            if (Direction * AnchoredPosition >= fullSize + ScrollOutMargin)
            {
                Content.anchoredPosition = IsHorizontal ? new Vector2(Direction * (fullSize + ScrollOutMargin), 0) : new Vector2(0, Direction * (fullSize + ScrollOutMargin));
            }
        }

        private void ProcessDrag(Vector2 delta)
        {
            float x = IsHorizontal ? delta.x / Screen.width * PageSize : 0;
            float y = IsHorizontal ? 0 : delta.y / Screen.width * PageSize;
            Content.anchoredPosition += new Vector2(x, y);

            dragDirection = IsHorizontal ? (delta.x > 0 ? 1 : -1) : (delta.y > 0 ? 1 : -1);
        }

        private void SetCurrentPageIndex()
        {
            int newIndex = Mathf.Clamp(Direction * Mathf.RoundToInt((AnchoredPosition + SnapAreaSize / 2 * dragDirection) / PageSize), 0, Content.childCount - 1);

            if (currentPageIndex != newIndex)
            {
                currentPageIndex = newIndex;
                OnPageChanged?.Invoke(newIndex);
            }
        }

        private void OnDrawGizmosSelected()
        {
            RectTransform rect = (transform as RectTransform);
            Gizmos.matrix = rect.localToWorldMatrix;

            Gizmos.color = ScrollOutMarginGizmoColor;

            if (IsHorizontal)
            {
                Vector2 size = new Vector2(ScrollOutMargin - 2, PageHeight - 2);
                Vector2 centerLeft = new Vector2((ScrollOutMargin - PageWidth) / 2 - (rect.pivot.x - 0.5f) * PageWidth, (rect.pivot.y - 0.5f) * -PageHeight);
                Vector2 centerRight = new Vector2((PageWidth - ScrollOutMargin) / 2 - (rect.pivot.x - 0.5f) * PageWidth, (rect.pivot.y - 0.5f) * -PageHeight);

                Gizmos.DrawWireCube(centerLeft, size);
                Gizmos.DrawWireCube(centerRight, size);
            }
            else
            {
                Vector2 size = new Vector2(PageWidth - 2, ScrollOutMargin - 2);
                Vector2 centerTop = new Vector2((rect.pivot.x - 0.5f) * -PageWidth, (PageHeight - ScrollOutMargin) / 2 - (rect.pivot.y - 0.5f) * PageHeight);
                Vector2 centerBottom = new Vector2((rect.pivot.x - 0.5f) * -PageWidth, (ScrollOutMargin - PageHeight) / 2 - (rect.pivot.y - 0.5f) * PageHeight);

                Gizmos.DrawWireCube(centerTop, size);
                Gizmos.DrawWireCube(centerBottom, size);
            }

            Gizmos.color = SnapAreaSizeGizmoColor;

            Vector2 center = new Vector2((rect.pivot.x - 0.5f) * -PageWidth, (rect.pivot.y - 0.5f) * -PageHeight);
            Vector2 areaSize = new Vector2(IsHorizontal ? SnapAreaSize : PageWidth - 2, IsHorizontal ? PageHeight : SnapAreaSize - 2);
            Gizmos.DrawWireCube(center, areaSize);
        }
    }
}
