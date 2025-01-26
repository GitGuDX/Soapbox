using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCursorEffect : MonoBehaviour
{
    public string targetSceneName = "Main_Menu"; // Name of the scene to check for
    public GameObject particlePrefab;  // Particle prefab to instantiate at the mouse position
    public float spawnInterval = 0.1f;  // Time interval between each particle spawn
    private float spawnTimer = 0f;  // Timer to control the spawn rate
    private Vector3 lastMousePosition; // To keep track of the last mouse position

    void Update()
    {
        // Ensure the script only works in the target scene
        string currentSceneName = SceneManager.GetActiveScene().name.Trim();
        if (!currentSceneName.Equals(targetSceneName.Trim()))
        {
            return;
        }

        // Only spawn particles when the mouse moves and enough time has passed
        if (Input.mousePosition != lastMousePosition)
        {
            spawnTimer += Time.deltaTime;

            // Check if enough time has passed to spawn a particle
            if (spawnTimer >= spawnInterval)
            {
                spawnTimer = 0f;  // Reset the spawn timer
                SpawnParticleAtMousePosition();
            }

            lastMousePosition = Input.mousePosition; // Update the last mouse position
        }
    }

    // Method to spawn particles at the mouse position
    private void SpawnParticleAtMousePosition()
    {
        // Check if the prefab is assigned
        if (particlePrefab == null)
        {
            Debug.LogWarning("Particle prefab is not assigned!");
            return; // Exit the method if no prefab is assigned
        }

        // Get the mouse position in screen space
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = Mathf.Abs(Camera.main.transform.position.z); // Set depth for the camera
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition); // Convert to world space

        // Instantiate the particle prefab at the mouse position
        Instantiate(particlePrefab, worldPosition, Quaternion.identity);
    }
}
