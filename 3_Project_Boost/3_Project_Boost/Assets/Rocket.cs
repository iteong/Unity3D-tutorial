using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    // member global variables
    [SerializeField] float rcsThrust = 250f; // need to change in Inspector
    [SerializeField] float mainThrust = 50f;
    [SerializeField] float levelLoadDelay = 2f;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;

    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

    bool collisionsDisabled = false;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (state == State.Alive) {
            RespondToThrustInput();
            RespondToRotateInput();
        }
        if (Debug.isDebugBuild) {
            RespondToDebugKeys();
        }
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKey(KeyCode.L)) {
            LoadNextScene();
        } else if (Input.GetKey(KeyCode.C)) {
            collisionsDisabled = !collisionsDisabled; // toggle collisions
        }
    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            ApplyThrust();
        }
        else
        {
            NewMethod();
        }
    }

    private void NewMethod()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    private void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        mainEngineParticles.Play();
    }

    private void RespondToRotateInput()
    {
        rigidBody.angularVelocity = Vector3.zero; // remove rotation due to physics

        float rotationThisFrame = rcsThrust * Time.deltaTime; // Time.deltaTime is last frame time

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
   }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive || collisionsDisabled) { return; } // ignore collisions when dead or debug mode

        switch (collision.gameObject.tag) {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        Invoke("LoadNextScene", levelLoadDelay); // parameterise time
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        deathParticles.Play();
        Invoke("LoadFirstLevel", levelLoadDelay); // parameterise time
    }

    private void LoadNextScene()
    {
        // get current scene based on build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // if next scene is the last scene, return to first scene
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }
}
