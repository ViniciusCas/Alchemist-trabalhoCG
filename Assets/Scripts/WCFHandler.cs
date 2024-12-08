using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using WaveFunctionCollaps;
using GridHandler;

public class WFCHandler : MonoBehaviour
{
    public Tilemap inputImage;
    public Tilemap outputImage;
    [Tooltip("For tiles usualy set to 1. If tile contain just a color can set to higher value")]
    public int patternSize;
    [Tooltip("How many times algorithm will try creating the output before quiting")]
    public int maxIterations;
    [Tooltip("Output image width")]
    public int outputWidth = 5;
    [Tooltip("Output image height")]
    public int outputHeight = 5;
    [Tooltip("Don't use tile frequency - each tile has equal weight")]
    public bool equalWeights = false;
    WaveFunctionCollapse wfc;

    public GameObject grid3D;
    private TileTo3D tileTo3D;

    // Start is called before the first frame update
    void Start()
    {
        tileTo3D = outputImage.gameObject.GetComponent<TileTo3D>();

        CreateWFC();
        CreateTilemap();
        SaveTilemap();

    }

    public void CreateWFC()
    {
        wfc = new WaveFunctionCollapse(this.inputImage, this.outputImage, patternSize, this.outputWidth, this.outputHeight, this.maxIterations, this.equalWeights);
    }
    public void CreateTilemap()
    {
        wfc.CreateNewTileMap();
        tileTo3D.Create3DTilemap(grid3D);
    }

    public void SaveTilemap()
    {
        var output = wfc.GetOutputTileMap();
        if (output != null)
        {
            outputImage = output;
            GameObject objectToSave = outputImage.gameObject;

            PrefabUtility.SaveAsPrefabAsset(objectToSave, "Assets/Resources/output.prefab");
        }
    }

}
