using System.Collections.Generic;
using UnityEngine;

public class PostController : MonoBehaviour
{
    [SerializeField] private PostGenerator _postGenerator;
    private LevelLoader _levelLoader;

    [SerializeField] private GameObject[] _posts;

    private Utilits _utilits;

    public void Initialize()
    {
        _levelLoader = new LevelLoader();
        _utilits = new Utilits();
    }

    public void start()
    {
        for (int i = 0; i < _posts.Length; i++)
        {
            _posts[i].SetActive(true);
        }
    }

    public void reset()
    {
        for (int i = 0; i < _posts.Length; i++)
        {
            _posts[i].SetActive(false);
            _posts[i].GetComponent<ObjectsGroup>().Enable();
        }
    }

    public void GeneratePost(GameObject Post)
    {
        Queue<GameObject> PostCubes = _utilits.GetChildrenQueue(Post.transform);
        Queue<bool> CubesCondition = _postGenerator.GenerateCubesCondition(PostCubes.Count);

        UpdatePost(PostCubes, CubesCondition);
    }

    public void LoadLevel()
    {

    }

    private void UpdatePost(Queue<GameObject> PostCubes, Queue<bool> CubesCondition)
    {
        int PostCubesCount = PostCubes.Count;

        for (int i = 0; i < PostCubesCount; i++)
        {
            PostCubes.Dequeue().SetActive(CubesCondition.Dequeue());
        }
    }
}
