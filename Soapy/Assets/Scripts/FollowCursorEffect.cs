using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCursorEffect : MonoBehaviour
{
    public string targetSceneName = "Main_Menu"; // The scene name to check
    public ParticleSystem particleSystem;       // Drag your particle system here
    private bool isFollowingCursor = true;

    void Start()
    {
        // Assign particle system if not set in the Inspector
        if (particleSystem == null)
            particleSystem = GetComponent<ParticleSystem>();

        if (particleSystem == null)
        {
            Debug.LogError("ParticleSystem is not assigned and cannot be found on this GameObject.");
            return;
        }

        if (!particleSystem.isPlaying)
            particleSystem.Play(); // Ensure the particle system starts
    }

    void Update()
    {
        // Ensure Update is running
        Debug.Log("Update is running.");

        // Check if we're in the correct scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != targetSceneName)
        {
            Debug.LogWarning($"Scene mismatch. Current scene: {currentSceneName}, Target scene: {targetSceneName}");
            return;
        }

        // Ensure Camera.main is available
        if (Camera.main == null)
        {
            Debug.LogError("No Main Camera found. Ensure the camera is tagged as 'MainCamera'.");
            return;
        }

        // Get cursor position in world space
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = 10f; // Set to the distance of the particle system from the camera
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);

        // Debug the cursor position
        Debug.Log("Cursor Position (World): " + worldPosition);

        // Update particle system position if following the cursor
        if (isFollowingCursor)
        {
            transform.position = worldPosition;
        }
    }

    void OnParticleSystemStopped()
    {
        // Stop the particle system from following the cursor once it stops emitting
        isFollowingCursor = false;
        Debug.Log("Particle system stopped. Stopped following the cursor.");
    }
}
