using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject[] characters; // Characters to switch
    public GameObject[] environmentSets; // Environment groups (one per character)
    private int currentCharacter = 0;

    void Start()
    {
        // Initialize: disable all except the first character/environment
        for (int i = 1; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
            environmentSets[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // 1. Save the current character's position
            Vector2 currentPosition = characters[currentCharacter].transform.position;

            // Disable current character/environment
            characters[currentCharacter].SetActive(false);
            environmentSets[currentCharacter].SetActive(false);

            // Switch to next character
            currentCharacter = (currentCharacter + 1) % characters.Length;

            // Enable new character/environment
            environmentSets[currentCharacter].SetActive(true);

            // 4. Set the new character's position and enable it
            characters[currentCharacter].transform.position = currentPosition; // Position sync [[1]]
            characters[currentCharacter].SetActive(true);
        }
    }
}