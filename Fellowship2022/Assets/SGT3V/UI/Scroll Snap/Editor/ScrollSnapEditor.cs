/* 
    Copyright (C) 2021 SGT3V, Sercan Altundas
    
    Visit for details: https://app.gitbook.com/@sercan-altundas/s/asset-store
*/

using UnityEditor;
using UnityEngine;

namespace SGT3V.UI
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ScrollSnap))]
    public sealed class ScrollSnapEditor : Editor
    {
        private const string ScrollSnapFileName = "Scroll Snap";

        private readonly GUIContent ContentLabel = new GUIContent("Content", "Container for snappable pages.");
        private readonly GUIContent SnapSpeedLabel = new GUIContent("Snap Speed", "Speed of snap, between 1 to 10. Value 10 snaps immediately.");
        private readonly GUIContent SnapAreaSizeLabel = new GUIContent("Snap Area Size", "Size of the center area that is necessary for activating the snap.");
        private readonly GUIContent ScrollSnapAxisLabel = new GUIContent("Scroll Snap Axis", "Axis of the ScrollSnap pages to align.");
        private readonly GUIContent ScollOutMarginLabel = new GUIContent("Scoll Out Margin", " Size of the side areas in pixels to scroll out of the first and the last pages.");
        private readonly GUIContent VerticalPageStartPositionLabel = new GUIContent("Vertical Alignment", "Align start of the pages to the top or to the bottom of the Content.");
        private readonly GUIContent HorizontalPageStartPositionLabel = new GUIContent("Horizontal Alignment", "Align start of the pages to the left side or to the right side of the Content.");

        private SerializedProperty Content;
        private SerializedProperty SnapSpeed;
        private SerializedProperty SnapAreaSize;
        private SerializedProperty OnPageChanged;
        private SerializedProperty ScrollSnapAxis;
        private SerializedProperty ScrollOutMargin;
        private SerializedProperty VerticalPageAlignment;
        private SerializedProperty HorizontalPageAlignment;

        private bool snapAreaSizeChanged;
        private bool scrollOutMarginChanged;

        private void OnEnable()
        {
            Content = serializedObject.FindProperty("Content");
            SnapSpeed = serializedObject.FindProperty("SnapSpeed");
            SnapAreaSize = serializedObject.FindProperty("SnapAreaSize");
            OnPageChanged = serializedObject.FindProperty("OnPageChanged");
            ScrollSnapAxis = serializedObject.FindProperty("ScrollSnapAxis");
            ScrollOutMargin = serializedObject.FindProperty("ScrollOutMargin");
            VerticalPageAlignment = serializedObject.FindProperty("VerticalPageAlignment");
            HorizontalPageAlignment = serializedObject.FindProperty("HorizontalPageAlignment");
        }

        [MenuItem("GameObject/UI/Scroll Snap", false)]
        private static void AddScrollSnap()
        {
            EditorUtilities.CreateInCanvas<ScrollSnap>(ScrollSnapFileName, (canvas, target) => {
                target.SnapAreaSize = 300;
                target.ScrollOutMargin = 100;

                (target.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (canvas.transform as RectTransform).rect.width);
                (target.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (canvas.transform as RectTransform).rect.height);
                (target.transform as RectTransform).anchoredPosition = new Vector2(0, 0);
            });
        }

        public override void OnInspectorGUI()
        {
            ScrollSnap scrollSnap = target as ScrollSnap;
            bool isHorizontal = ((RectTransform.Axis)ScrollSnapAxis.enumValueIndex == RectTransform.Axis.Horizontal);

            serializedObject.Update();
            
            EditorGUILayout.PropertyField(Content, ContentLabel); 
            EditorGUILayout.PropertyField(ScrollSnapAxis, ScrollSnapAxisLabel);

            if (isHorizontal)
            {
                EditorGUILayout.PropertyField(HorizontalPageAlignment, HorizontalPageStartPositionLabel);
            }
            else
            {
                EditorGUILayout.PropertyField(VerticalPageAlignment, VerticalPageStartPositionLabel);
            }

            bool layouChanged = GUI.changed;

            ValidateVariables(scrollSnap, isHorizontal);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(ScrollOutMargin, ScollOutMarginLabel);
            scrollOutMarginChanged = EditorGUI.EndChangeCheck();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(SnapAreaSize, SnapAreaSizeLabel);
            snapAreaSizeChanged = EditorGUI.EndChangeCheck();

            EditorGUILayout.PropertyField(SnapSpeed, SnapSpeedLabel);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(OnPageChanged);

            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space();

            if (GUI.changed)
            {
                if (layouChanged) 
                {
                    snapAreaSizeChanged = true;
                    scrollOutMarginChanged = true;
                    scrollSnap.ResetScrollSnapUI(); 
                }

                EditorUtility.SetDirty(scrollSnap);
            }
        }

        private void ValidateVariables(ScrollSnap scrollSnap, bool isHorizontal)
        {
            float pageSize = isHorizontal ? scrollSnap.PageWidth : scrollSnap.PageHeight;

            if (pageSize < ScrollOutMargin.floatValue * 2)
            {
                ScrollOutMargin.floatValue = pageSize / 2;
            }

            if (pageSize < ScrollOutMargin.floatValue * 2 + SnapAreaSize.floatValue)
            {
                if (scrollOutMarginChanged)
                {
                    float size = pageSize - ScrollOutMargin.floatValue * 2;
                    SnapAreaSize.floatValue = Mathf.Clamp(size, 0, pageSize);
                }

                if (snapAreaSizeChanged)
                {
                    SnapAreaSize.floatValue = Mathf.Clamp(SnapAreaSize.floatValue, 0, pageSize);

                    float size = (pageSize - SnapAreaSize.floatValue) / 2;
                    ScrollOutMargin.floatValue = Mathf.Clamp(size, 0, pageSize);
                }
            }
        }
    }
}
