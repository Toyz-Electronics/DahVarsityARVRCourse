using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badge_tab_manager : MonoBehaviour
{
    [System.Serializable]
    public class BadgeType
    {
        public string name;
        public GameObject badge;
    }
    [SerializeField] private GameObject[] badgeLocations;

    public List<BadgeType> badgeList;

    private GameObject[] badgeImages;
    // Start is called before the first frame update
    void Start()
    {
        badgeImages = new GameObject[script_player_profile.player.badgeList.Count];
        DisplayEarnedBadges();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        DisplayEarnedBadges();
    }

    private void DisplayEarnedBadges()
    {
        GameObject earnedBadge;
        for (int i = 0; i < script_player_profile.player.badgeList.Count; i++)
        {
            // Set the earned badge to the foundBadge.badge found in badgeList where foundBadge.name == script_player_profile.badgeList[i]
            earnedBadge = badgeList.Find(foundBadge => foundBadge.name == script_player_profile.player.badgeList[i]).badge;
            earnedBadge.transform.SetParent(badgeLocations[i].transform);// Set Parent to GameObject used to mark location
            earnedBadge.transform.localPosition = new Vector3(0, 0, 0);// Set Location according to parent location
        }
    }
}
