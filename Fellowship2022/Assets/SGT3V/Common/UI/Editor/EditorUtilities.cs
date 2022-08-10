/* 
    Copyright (C) 2021 SGT3V, Sercan Altundas
    
    Visit for details: https://app.gitbook.com/@sercan-altundas/s/asset-store
*/

using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SGT3V.UI
{
    public class EditorUtilities : MonoBehaviour
    {
        private const string PrefabFolderName = "Prefabs";

        private const string CanvasFileName = "Canvas";
        private const string EventSystemFileName = "Event System";

        /// <summary>
        ///     Secure loading of a UI item. Checks if a <see cref="Canvas"/> and an <see cref="EventSystem"/> component exists in the scene and creates if necessary.
        /// </summary>
        /// <typeparam name="T">Type of component to be loaded.</typeparam>
        /// <param name="name">Name of the object to be created.</param>
        /// <param name="callback">Actions to take once component is created in the canvas.</param>
        public static void CreateInCanvas<T>(string name, Action<Canvas, T> callback) where T: UIBehaviour
        {
            Canvas canvas = FindObjectOfType<Canvas>();
            if (Selection.activeTransform == null)
            {
                if (canvas == null)
                {
                    canvas = LoadAndInstantiate<Canvas>(CanvasFileName);
                }
                Selection.activeObject = canvas;
            }
            else
            {
                RectTransform rect = Selection.activeTransform.GetComponentInParent<RectTransform>();

                if (rect == null)
                {
                    canvas = LoadAndInstantiate<Canvas>(CanvasFileName, Selection.activeTransform);
                    Selection.activeObject = canvas;
                }
                else
                {
                    Selection.activeObject = rect;
                }
            }

            EventSystem eventSystem = FindObjectOfType<EventSystem>();
            if (eventSystem == null)
            {
                eventSystem = LoadAndInstantiate<EventSystem>(EventSystemFileName);
            }

            T target = LoadAndInstantiate<T>(name, Selection.activeTransform);

            Selection.activeObject = target;

            int undoGroup = Undo.GetCurrentGroup();
            string undoGroupName = Guid.NewGuid().ToString();
            Undo.RegisterCreatedObjectUndo(canvas.gameObject, undoGroupName);
            Undo.RegisterCreatedObjectUndo(target.gameObject, undoGroupName);
            Undo.RegisterCreatedObjectUndo(eventSystem.gameObject, undoGroupName);
            Undo.CollapseUndoOperations(undoGroup);

            callback?.Invoke(canvas, target);
        }

        public static T LoadAndInstantiate<T>(string fileName, Transform parent = null) where T : Behaviour
        {
            T prefab = Resources.Load<T>($"{PrefabFolderName}/{fileName}");
            T instance = Instantiate(prefab);
            instance.name = fileName;
            instance.transform.SetParent(parent);
            instance.transform.SetAsLastSibling();
            EditorUtility.SetDirty(instance);
            return instance;
        }
    }
}