using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the minimap icons for the whole game
/// Currently creates and tracks icons for each enemy and target, as well as tracks the icon and sonar effect for the player
/// 
/// TODO:
///     Adjust the camera based off of the position of the player
///         Needed to be done when merged because the old movement and map make testing this feature almost impossible
///     Make higher fidelity effects for the different icons
///     Test the target system more granularly
/// </summary>
public class MinimapManager : MonoBehaviour
{
    #region Camera Members
    // Camera members
    // Relevant information for camera adjustment based off of player movement
    // Currently work in progress
    [SerializeField]
    Camera minimapCamera;

    [SerializeField]
    private Vector3 tLeftCorner;
    [SerializeField]
    private Vector3 bLeftCorner;
    [SerializeField]
    private Vector3 tRightCorner;
    [SerializeField]
    private Vector3 bRightCorner;
    #endregion

    #region Prefabs
    // Prefabs needed in order to create each minimap object during runtime
    [SerializeField]
    private GameObject enemyIconPrefab;
    [SerializeField]
    private GameObject targetIconPrefab;
    [SerializeField]
    private GameObject offScreenIconPrefab;
    [SerializeField]
    private GameObject playerIconPrefab;
    [SerializeField]
    private GameObject sonarPrefab;
    #endregion
    
    // The actual player object on the scene
    [SerializeField]
    private GameObject player;

    #region Minimap Elements
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();
    // Use the same index for the icons as the enemies
    private List<GameObject> enemyIcons = new List<GameObject>();
    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();
    // Use the same index for the icons as the targets
    private List<GameObject> targetIcons = new List<GameObject>();
    [SerializeField]
    private List<GameObject> targetOffScreenIcons = new List<GameObject>();
    [SerializeField]
    private GameObject playerIcon;
    [SerializeField]
    private GameObject sonarPulse;
    #endregion

    #region Main Code
    private void Start()
    {
        // Instantiate the minimap objects needed for the start of the game
        playerIcon = Instantiate(playerIconPrefab, Vector3.zero, Quaternion.identity);
        sonarPulse = Instantiate(sonarPrefab, Vector3.zero, Quaternion.identity);

        // Code for testing purposes
        AddTarget(GameObject.Find("Khnumian"));
    }

    private void Update()
    {
        // Track the player's objects to the player, including rotating the icon to show the player's orientation
        playerIcon.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        // Lock the rptation to just the rotations on the y axis
        playerIcon.transform.rotation = new Quaternion(0, player.transform.rotation.y, 0, player.transform.rotation.w);

        // Lock the sonar effect to the player
        sonarPulse.transform.position = player.transform.position;

        // Track the target icons 
        for(int i = 0; i < targets.Count; i++)
        {
            if(targets[i] == null)
            {
                Destroy(targetIcons[i]);
                targetIcons.RemoveAt(i);
                Destroy(targetOffScreenIcons[i]);
                targetOffScreenIcons.RemoveAt(i);
                targets.RemoveAt(i);
                i--;
            }
            else
            {
                // If the target isn't currently visible, indicate a direction in which the target is towards
                if (!targetIcons[i].GetComponent<Renderer>().isVisible)
                {
                    targetOffScreenIcons[i].SetActive(true);
                    targetOffScreenIcons[i].transform.LookAt(new Vector3(targets[i].transform.position.x, targets[i].transform.position.y, targets[i].transform.position.z));
                }
                // If the targets are visible, make sure to disable the arrows pointing to them
                else
                {
                    targetOffScreenIcons[i].SetActive(false);
                }
                // Track the icons to the targets
                targetIcons[i].transform.position = new Vector3(targets[i].transform.position.x, targets[i].transform.position.y, targets[i].transform.position.z);
            }
        }    

        // Track the enemy icons
        for(int i = 0; i < enemies.Count; i++)
        {
            // If this enemy is no longer in the list, make sure to clean up the objects
            if(enemies[i] == null)
            {
                Destroy(enemyIcons[i]);
                enemyIcons.RemoveAt(i);
                enemies.RemoveAt(i);
                i--;
            }
            // If there is an enemy, track the icon to it's position
            else
            {
                enemyIcons[i].transform.position = new Vector3(enemies[i].transform.position.x, enemies[i].transform.position.x, enemies[i].transform.position.z);
            }
        }

    }
    #endregion

    #region Add Methods
    // Used in order to allow other managers/scripts to add their objects into the minimap
    /// <summary>
    /// Creates an enemy icon on the minimap for a given game object
    /// </summary>
    /// <param name="enemy">The enemy game object</param>
    public void AddEnemy(GameObject enemy)
    {
        // Add the new enemy to the list tracking them
        enemies.Add(enemy);
        // Make a new icon that is at the enemy's location
        enemyIcons.Add(Instantiate(enemyIconPrefab, new Vector3(enemy.transform.position.x, 100, enemy.transform.position.z), Quaternion.identity));
        // Set the icon to the minimap layer so that the player doesn't see it
        enemyIcons[enemyIcons.Count - 1].layer = 10;
    }

    /// <summary>
    /// Creates a target icon on the minimap for a given game object
    /// </summary>
    /// <param name="target">The target game object</param>
    public void AddTarget(GameObject target)
    {
        // Add the new target to the list tracking them
        targets.Add(target);
        // Make a new icon that is at the target's location
        targetIcons.Add(Instantiate(targetIconPrefab, new Vector3(target.transform.position.x, 100, target.transform.position.z), Quaternion.identity));
        // Set the icon to the minimap layer so that the player doesn't see it
        targetIcons[targetIcons.Count - 1].layer = 10;
        // Make the offscreen icon that is at the player's location
        targetOffScreenIcons.Add(Instantiate(targetIconPrefab, new Vector3(player.transform.position.x, 100, player.transform.position.z), Quaternion.identity));
        // Set the offscreen icon to the minimap layer so that the player doesn't see it
        targetIcons[targetIcons.Count - 1].layer = 10;
    }
    #endregion
}
