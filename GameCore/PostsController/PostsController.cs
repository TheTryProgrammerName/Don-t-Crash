using System.Collections.Generic;
using UnityEngine;

public class PostsController : MonoBehaviour
{
    [SerializeField] private ObjectsPool _postsPool;

    private PostGenerator _postGenerator;
    private LevelLoader _levelLoader;

    private float _addDifficultCoefForGeneration = 0.025f;

    public float AddDifficultCoefForGeneration 
    {
        get 
        { 
            return _addDifficultCoefForGeneration; 
        }
        set 
        { 
            _addDifficultCoefForGeneration = value;
            _postGenerator.AddDifficultCoefForGeneration = value;
        } 
    }

    public void Initialize()
    {
        _postGenerator = new PostGenerator(AddDifficultCoefForGeneration);
        _levelLoader = new LevelLoader();
    }

    public void start()
    {
        _postsPool.Enable();
    }

    public void reset()
    {
        _postsPool.Disable();

        _postGenerator.reset();
    }

    public void GeneratePost(GameObject[] postCubes)
    {
        int PostCubesCount = postCubes.Length;

        Queue<bool> CubesCondition = _postGenerator.GenerateCubesCondition(PostCubesCount);

        for (int i = 0; i < PostCubesCount; i++)
        {
            GameObject postCube = postCubes[i];
            bool cubeCondition = CubesCondition.Dequeue();
            postCube.SetActive(cubeCondition);
        }
    }

    public void LoadLevel()
    {

    }
}
