using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public bool inPlay = false;
    [SerializeField] Texture[] textures;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 startPosition;

	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        startPosition = transform.position;
        RandomizeTexture();
    }

    public void Lounch(Vector3 velocity)
    {
        inPlay = true;

        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Reset()
    {
        inPlay = false;
        transform.rotation = Quaternion.identity;
        transform.position = startPosition;
        rigidBody.velocity = new Vector3(0, 0, 0);
        rigidBody.angularVelocity = new Vector3(0, 0, 0);
        rigidBody.useGravity = false;
    }

    void RandomizeTexture()
    {
        GetComponent<MeshRenderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
    }
}
