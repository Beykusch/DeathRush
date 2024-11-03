using UnityEngine;

public class DedeKayma : MonoBehaviour
{
    public Vector2 destination = new Vector2(-8f, -4.2f);
    private Vector2 startPosition;
    private float elapsedTime = 0f;
    public float duration = 20f; // Duration in seconds

    public GameObject progressBar; // Assign a thin, small GameObject to act as the bar
    public float rechargeAmount = 2;// Amount of time to "recharge" when button is pressed
    public float dechargeAmount = 2;

    public GameObject youDiedMessage;

    public static DedeKayma instance;


    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        // Store the initial position at the start
        startPosition = transform.position;

        // Position and scale the progress bar initially from startPosition to destination
        if (progressBar != null)
        {
            progressBar.transform.position = (startPosition + destination) / 2; // Position bar in the center
            float totalDistance = Vector2.Distance(startPosition, destination);
            progressBar.transform.localScale = new Vector3(totalDistance, progressBar.transform.localScale.y, progressBar.transform.localScale.z); // Full length at the start
        }

        if (youDiedMessage != null)
        {
            youDiedMessage.SetActive(false); // Hide "You Died" message initially
        }
    }

    public void DedeArttır()
    {
        elapsedTime = Mathf.Max(0, elapsedTime - rechargeAmount);
    }

    public void DedeAzalt()
    {
        elapsedTime = Mathf.Max(0, elapsedTime + dechargeAmount);
    }

    void Update()
    {
        // Update movement and progress bar as usual
        if (elapsedTime < duration)
        {
            // Increase the elapsed time
            elapsedTime += Time.deltaTime;
            
            // Calculate the interpolation factor as a percentage of the duration
            float t = elapsedTime / duration;

            // Move the GameObject from startPosition to destination based on 't'
            transform.position = Vector2.Lerp(startPosition, destination, t);

            // Update the progress bar to reflect the remaining distance
            if (progressBar != null)
            {
                // Calculate the current position of the bar based on elapsed time
                Vector2 currentBarPosition = Vector2.Lerp(startPosition, destination, t);

                // Set the progress bar position to the midpoint between current position and destination
                progressBar.transform.position = (currentBarPosition + destination) / 2;

                // Update the scale to represent the remaining progress (only scaling on the x-axis)
                float remainingDistance = Vector2.Distance(currentBarPosition, destination);
                progressBar.transform.localScale = new Vector3(remainingDistance, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

            }
        }
        else
        {
            // Display "You Died" message if the duration has been reached
            if (youDiedMessage != null && !youDiedMessage.activeSelf)
            {
                youDiedMessage.SetActive(true);
                Debug.Log("You Died!");
            }
        }

    }

}