/* 
    Copyright (C) 2021 SGT3V, Sercan Altundas
    
    Visit for details: https://app.gitbook.com/@sercan-altundas/s/asset-store
*/

using System;
using UnityEngine;
using SGT3V.Common;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SGT3V.UI
{
    [HelpURL("https://app.gitbook.com/@sercan-altundas/s/asset-store/ui-components/scroll-snap")]
    [SelectionBase]
    [ExecuteInEditMode]
    [AddComponentMenu("UI/Scroll Snap Infinite")]
    [RequireComponent(typeof(RectTransform))]
    public sealed class ScrollSnapInfinite : UIBehaviour, IDragHandler, IEndDragHandler
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
                return (currentPageIndex * AlignmentDirection).Mod(Content.childCount);
            }  
            set 
            {
                currentPageIndex = value;
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

        private int AlignmentDirection => IsHorizontal ? (IsLeftAligned ? 1 : -1) : (IsBottomAligned ? 1 : -1);

        private float AnchoredPosition => IsHorizontal ? Content.anchoredPosition.x : Content.anchoredPosition.y;

        // if infinite scroll send another index
        private int infiniteScrollPivotStart, infiniteScrollPivotEnd;

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

            infiniteScrollPivotStart = AlignmentDirection > 0 ? 0 : 1;
            infiniteScrollPivotEnd = AlignmentDirection > 0 ? (Content.childCount - 1) : (2 - Content.childCount);

            for (int i = 0; i < Content.childCount; i++)
            {
                (Content.GetChild(i) as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PageWidth);
                (Content.GetChild(i) as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, PageHeight);
            }
        }

        private void SetPagePositions()
        {
            for (int i = 0; i < Content.childCount; i++)
            {
                if (IsHorizontal)
                {
                    float x = Mathf.Abs((i + currentPageIndex) * PageWidth * AlignmentDirection) * AlignmentDirection;
                    (Content.GetChild(i) as RectTransform).anchoredPosition = new Vector2(x, 0);
                }
                else
                {
                    (Content.GetChild(i) as RectTransform).anchoredPosition = new Vector2(0, (i + currentPageIndex) * PageHeight * AlignmentDirection);
                }
            }
        }

        private void SetContentPosition()
        {
            float value = currentPageIndex * PageSize * -AlignmentDirection;
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
                float value = Mathf.Lerp(AnchoredPosition, -currentPageIndex * PageSize, 0.1f * SnapSpeed);
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
            ProcessInfiniteDrag(eventData.delta);
        }

        private void ProcessDrag(Vector2 delta)
        {
            float x = IsHorizontal ? delta.x : 0;
            float y = IsHorizontal ? 0 : delta.y;
            Content.anchoredPosition += new Vector2(x, y);
        }

        private void ProcessInfiniteDrag(Vector2 delta)
        {
            // Set drag direction for SetCurrentPageIndex
            dragDirection = IsHorizontal ? (delta.x > 0 ? 1 : -1) : (delta.y > 0 ? 1 : -1);

            if (AlignmentDirection > 0)
            {
                MovePage((-AnchoredPosition > infiniteScrollPivotEnd * PageSize), true, ref infiniteScrollPivotEnd);
                MovePage((-AnchoredPosition < infiniteScrollPivotStart * PageSize), false, ref infiniteScrollPivotStart);
            }
            else
            {
                MovePage((-AnchoredPosition > (infiniteScrollPivotStart - 1) * PageSize), false, ref infiniteScrollPivotStart);
                MovePage((-AnchoredPosition < (infiniteScrollPivotEnd - 1) * PageSize), true, ref infiniteScrollPivotEnd);
            }

            void MovePage(bool moveCondition, bool moveFirstChild, ref int pivot)
            {
                if (moveCondition)
                {
                    infiniteScrollPivotEnd -= dragDirection;
                    infiniteScrollPivotStart -= dragDirection;

                    Transform child;

                    if (moveFirstChild)
                    {
                        child = Content.GetChild(0);
                        child.SetAsLastSibling();
                    }
                    else
                    {
                        child = Content.GetChild(Content.childCount - 1);
                        child.SetAsFirstSibling();
                    }

                    float x = IsHorizontal ? (pivot - 1 * (AlignmentDirection > 0 ? 0 : 1)) * PageSize : 0;
                    float y = IsHorizontal ? 0 : (pivot - 1 * (AlignmentDirection > 0 ? 0 : 1)) * PageSize;
                    (child as RectTransform).anchoredPosition = new Vector2(x, y);
                }
            }
        }

        private void SetCurrentPageIndex()
        {
            int newIndex = -Mathf.RoundToInt((AnchoredPosition + SnapAreaSize / 2 * dragDirection) / PageSize);

            if (currentPageIndex != newIndex)
            {
                currentPageIndex = newIndex;

                int value = (newIndex * AlignmentDirection).Mod(Content.childCount);

                OnPageChanged?.Invoke(value);
            }
        }

        private void OnDrawGizmosSelected()
        {
            RectTransform rect = (transform as RectTransform);
            Gizmos.matrix = rect.localToWorldMatrix;

            Gizmos.color = SnapAreaSizeGizmoColor;
            Vector2 center = new Vector2((rect.pivot.x - 0.5f) * -PageWidth, (rect.pivot.y - 0.5f) * -PageHeight);
            Vector2 areaSize = new Vector2(IsHorizontal ? SnapAreaSize : PageWidth - 2, IsHorizontal ? PageHeight : SnapAreaSize - 2);
            Gizmos.DrawWireCube(center, areaSize);
        }
    }
}
