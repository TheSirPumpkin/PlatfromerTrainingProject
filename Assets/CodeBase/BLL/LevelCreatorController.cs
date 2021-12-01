using Infrastructure.DAL;
using Player.PL;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Infrastructure.BLL
{
    public class LevelCreatorController : ILevelCreator
    {
        private LevelsData level;

        public void CreateLevel(MonoBehaviour view)
        {
            level = AllServices.Container.Single<IGameLoaderController>().GetLoadedLevel();

            view.StartCoroutine(SpawnPlayer());

            foreach (var enemy in level.Enemies)
            {
                view.StartCoroutine(SpawnEnemy(enemy.Key, enemy.Value));
            }
        }

        public IEnumerator SpawnPlayer()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            var loadedPlayer = LoadAssetBundle(PathConstants.StandalonePlayerBundlesPath);
            var player = loadedPlayer.LoadAsset("Player");

            GameObject.Instantiate(player, level.PlayerStartPosition, Quaternion.identity);

            AllServices.Container.Single<ICameraMovement>().Player = GameObject.FindObjectOfType<PlayerMoveView>().transform; ;

            loadedPlayer.Unload(false);

#else// UNITY_WEBGL
             
        using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(PathConstants.WebGlPlayerBundlesPath, 0))
        { 
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
           
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                var player = bundle.LoadAsset("Player");

                GameObject.Instantiate(player, level.PlayerStartPosition, Quaternion.identity);

                AllServices.Container.Single<ICameraMovement>().Player = GameObject.FindObjectOfType<PlayerMoveView>().transform; ;

                bundle.Unload(false);
             
            }
        }
#endif

            yield return null;
        }

        public IEnumerator SpawnEnemy(Vector2 spawnPos, string name)
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            var loadedEnemy = LoadAssetBundle(PathConstants.StandaloneEnemyBundlesPath);
            var enemy = loadedEnemy.LoadAsset(name);

            GameObject.Instantiate(enemy, spawnPos, Quaternion.identity);
            loadedEnemy.Unload(false);

#else// UNTIY_WEBGL
            using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(PathConstants.WebGlEnemyBundlesPath, 0))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {

                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                var enemy = bundle.LoadAsset(name);

                 GameObject.Instantiate(enemy, spawnPos, Quaternion.identity);

                bundle.Unload(false);
            }
        }
#endif
            yield return null;
        }
        private AssetBundle LoadAssetBundle(string path)
        {
            AssetBundle loadedAssetBundle = AssetBundle.LoadFromFile(path);
            return loadedAssetBundle;
        }
    }
}
