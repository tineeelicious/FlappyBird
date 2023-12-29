using UnityEngine;

public class Parallax : MonoBehaviour
{
    //declaring MeshRenderer Object to get access to the the mesh renderer
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.05f;

    //calling the awake method to initially run/execute a function before the Start and Update method
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); //to get the MeshRenderer Component before everything starts and assign it to a variable
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }


}
