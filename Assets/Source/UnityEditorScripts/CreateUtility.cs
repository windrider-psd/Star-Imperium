#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;
namespace Assets.Source.UnityEditorScripts
{
    
    public static class CreateUtility
    {
        public static void CreatePrefab(string path)
        {
            GameObject newObject = PrefabUtility.InstantiatePrefab(Resources.Load(path)) as GameObject;
            Place(newObject);
        }

        public static void CreateObject(string name, params Type[] types)
        {
            GameObject newObject = ObjectFactory.CreateGameObject(name, types);
            Place(newObject);
        }

        public static void Place(GameObject gameObject)
        {
            var sel = Selection.activeGameObject;

            // Find location
            SceneView lastView = SceneView.lastActiveSceneView;

            gameObject.transform.position = lastView ? lastView.pivot : (sel == null) ? Vector3.zero : sel.transform.position;

            if (sel != null)
            {
                gameObject.transform.parent = sel.transform;
            }

            // Make sure we place the object in the proper scene, with a relevant name
            StageUtility.PlaceGameObjectInCurrentStage(gameObject);
            GameObjectUtility.EnsureUniqueNameForSibling(gameObject);

            // Record undo, and select
            Undo.RegisterCreatedObjectUndo(gameObject, $"Create Object: {gameObject.name}");
            Selection.activeGameObject = gameObject;

            // For prefabs, let's mark the scene as dirty for saving
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());

            

        }
    }
   
}

#endif
