using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetBundleCreator : Editor
{
    [MenuItem("BuildAssetBundle/ Standalone")]
    static void BuildStandaloneBundle()
    {
        BuildPipeline.BuildAssetBundles(PathConstants.StandaloneBundlesPath,BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
    [MenuItem("BuildAssetBundle/ WebGl")]
    static void BuildWebGlBundle()
    {
        BuildPipeline.BuildAssetBundles(PathConstants.WebGlBundlesPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.WebGL);
    }
}
