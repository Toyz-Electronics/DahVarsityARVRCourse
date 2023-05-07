/*
    Load
        Player Profile
        levels complete
        courses complete
            assignments complete
        points
        Avatar
*/
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;
#if UNITY_ANDROID
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
#endif
#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
//using GKNativeExtensions;
//using HovelHouse.CloudKit;
using Prime31;
#endif
public class script_player_profile : MonoBehaviour
{
#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
    //iCloudBinding iCloudBinding;
#endif

    public const int MAX_LEVEL = 38;
    public const int AUTO_LEADER_COUNT = 8;
    private const int ENTREPRENEUR_COUNT = 14;


    [System.Serializable]
    public class LessonType
    {
        public string name;
        public string[] lessonInfo;
        public bool completed;
    }

    [System.Serializable]
    public class QuizType
    {
        public string name;
        public string[] questions;
        public string[] answers;
        public bool completed;
    }

    [System.Serializable]
    public class EssayType
    {
        public string name;
        public string question;
        public string answer;
        public bool completed;
    }

    [System.Serializable]
    public class TopicType
    {
        public string name;
        public LessonType[] lessonList;
        public QuizType[] quizList;
        public EssayType[] essayList;
        public bool completed;
    }

    [System.Serializable]
    public class CourseType
    {
        public string name;
        public TopicType[] topicList;
        public bool completed;
    }

    [System.Serializable]
    public class AssignmentType
    {
        public string name;
        public string answers;

        public AssignmentType()
        {
            name = "";
            answers = "";
        }
    }

    //public class LevelTrackerType : IComparable<LevelTrackerType>
    [System.Serializable]
    public class LevelTrackerType
    {
        public int index;
        public string name;
        public bool unlocked;
        public bool visited;
        public bool completed;
        
        public LevelTrackerType()
        {
            index = 0;
            name = "";
            unlocked = false;
            visited = false;
            completed = false;
        }

        public LevelTrackerType(int inIndex, string inName)
        {
            index = inIndex;
            name = inName;
            unlocked = false;
            visited = false;
            completed = false;
        }

        public LevelTrackerType(LevelTrackerType other)
        {
            this.index = other.index;
            this.name = other.name;
            this.unlocked = other.unlocked;
            this.visited = other.visited;
            this.completed = other.completed;
        }

        // Give the implementation for the default comparer used for List<LevelTrackerType()>.Sort()
        public int CompareTo(LevelTrackerType other)
        {
            // (this.index < other.index)  returns -1
            // (this.index == other.index)  returns 0
            // (this.index > other.index)  returns 1
            return this.index.CompareTo(other.index);// Use the built in int comparer in IComparable<>
        }

        public void SetLevelAchievements(LevelTrackerType other)
        {
            this.unlocked = other.unlocked;
            this.visited = other.visited;
            this.completed = other.completed;
        }
    }
    
    [System.Serializable]
    public class PointsType
    {
        public int sciencePoints;
        public int techPoints;
        public int engineeringPoints;
        public int artPoints;
        public int mathPoints;
        public int deiPoints;
        public int entrepreneurPoints;
        public int globalPoints;
        public int autoIndustryPoints;
        public int manufacturingPoints;
        public int superheroPoints;
        public int dahvarsityPoints;

        public PointsType()
        {
            sciencePoints = 0;
            techPoints = 0;
            engineeringPoints = 0;
            artPoints = 0;
            mathPoints = 0;
            deiPoints = 0;
            entrepreneurPoints = 0;
            globalPoints = 0;
            autoIndustryPoints = 0;
            manufacturingPoints = 0;
            superheroPoints = 0;
            dahvarsityPoints = 0;
        }

        public void SetPoints(PointsType inPointsCard)
        {
            sciencePoints = inPointsCard.sciencePoints;
            techPoints = inPointsCard.techPoints;
            engineeringPoints = inPointsCard.engineeringPoints;
            artPoints = inPointsCard.artPoints;
            mathPoints = inPointsCard.mathPoints;
            deiPoints = inPointsCard.deiPoints;
            entrepreneurPoints = inPointsCard.entrepreneurPoints;
            globalPoints = inPointsCard.globalPoints;
            autoIndustryPoints = inPointsCard.autoIndustryPoints;
            manufacturingPoints = inPointsCard.manufacturingPoints;
            superheroPoints = inPointsCard.superheroPoints;
            dahvarsityPoints = inPointsCard.dahvarsityPoints;
        }
    }

    [System.Serializable]
    public class AccountType
    {
        public string email;// The player's E-mail
        //public string password;// The player's password
        public string name;// The player's name
        public string characterName;// The player's username
        public int age;// The player's Birth Date
        public string organization;// The player's Organization
        public string grade;// The player's Grade
        public int language;// The player's language
        public string superheroWorld;// The player's superhero world
        public string superheroTrait;// The player's superhero trait
        public bool speechPermission;// The player's speech permission
        public bool cameraPermission;// The player's camera permission
        public int levelRank;// The player's level progress
        public int currentLevelNumber;
        public string appleID;
        public string playfabID;
        public bool deleteRequest;
        public string googleID;
        public string authCodeGoogle;
        public string avatarURL;// The player's avatar URL
        public string playerGender;
        public string playerEthnicity;
        public string playerInterest;
        public string playerUserType;
        public string playerOrganization;
        public string playerParentFirstName;
        public string playerParentLastName;
        public string playerParentEmail;
        public string playerChildFirstName;
        public string playerChildLastName;
        public string playerChildEmail;
        public string playerUsername;
        public bool isAuthenticatedGoogle;
        public bool isCompleteProfile;

        public AccountType()
        {
            
            email = "";
            //password = "";
            name = "";
            characterName = "";
            age = 0;
            organization = "";
            grade = "";
            language = 0;
            superheroWorld = "";
            superheroTrait = "";
            speechPermission = false;
            cameraPermission = false;
            levelRank = 0;
            currentLevelNumber = 0;
            appleID = "";
            playfabID = "";
            deleteRequest = false;
            googleID = "";
            avatarURL = "default";
            playerGender = "";
            playerEthnicity = "";
            playerInterest = "";
            playerUserType = "";
            authCodeGoogle = "";
            playerOrganization = "";
            playerParentFirstName = "";
            playerParentLastName = "";
            playerParentEmail = "";
            playerChildFirstName = "";
            playerChildLastName = "";
            playerChildEmail = "";
            playerUsername = "";
            isAuthenticatedGoogle = false;
            isCompleteProfile = false;
        }
    }

    [System.Serializable]
    public class PlayerType
    {
        public AccountType account;
        public bool loggedIn;
        public bool newValue;
        public List<LevelTrackerType> levelList;
        public CourseType[] courseList;
        public List<AssignmentType> assignmentList;
        public List<string> badgeList;
        public string[] playerBackstory;
        public PointsType pointsCard;
        public Vector3 playerPosition;
        public bool preSurveyComplete;
        public bool chinaUNComplete;
        public bool colombiaUNComplete;
        public bool germanyUNComplete;
        public bool japanUNComplete;
        public bool[] autoLeadersViewed;
        public bool autoMuseumComplete;
        public bool alfaRomeoComplete;
        public bool audiComplete;
        public bool stellantisComplete;
        public bool ferrariComplete;
        public bool fordComplete;
        public bool gmComplete;
        public bool hyundaiComplete;
        public bool kiaComplete;
        public bool lincolnComplete;
        public bool mazdaComplete;
        public bool mercedesComplete;
        public bool nissanComplete;
        public bool porscheComplete;
        public bool[] entrepreneursViewed;
        public bool entrepreneursComplete;
        public bool backstoryComplete;
        public bool stopTheBullyingComplete;
        public bool marsComplete;
        public bool saturnComplete;
        public bool nasaComplete;
        public bool penetrateTheSoulComplete;
        public bool highCityComplete;
        public bool puzzle1Complete;
        public bool rhythmGameComplete;
        public bool glassesComplete;
        public bool[] channelsViewed;
        public bool apartmentComplete;
        public bool multiplayerEnabled;
        public TimeSpan totalPlaytime;

        public PlayerType()
        {
            account = new AccountType();
            loggedIn = false;
            levelList = new List<LevelTrackerType>();
            pointsCard = new PointsType();
            assignmentList = new List<AssignmentType>();
            badgeList = new List<string>();
            autoLeadersViewed = new bool[AUTO_LEADER_COUNT];
            entrepreneursViewed = new bool[ENTREPRENEUR_COUNT];
            channelsViewed = new bool[7];
            playerBackstory = new string[10];
            preSurveyComplete = false;
            chinaUNComplete = false;
            colombiaUNComplete = false;
            germanyUNComplete = false;
            japanUNComplete = false;
            alfaRomeoComplete = false;
            audiComplete = false;
            newValue = true;
            stellantisComplete = false;
            ferrariComplete = false;
            fordComplete = false;
            gmComplete = false;
            hyundaiComplete = false;
            kiaComplete = false;
            lincolnComplete = false;
            mazdaComplete = false;
            mercedesComplete = false;
            nissanComplete = false;
            porscheComplete = false;
            entrepreneursComplete = false;
            backstoryComplete = false;
            stopTheBullyingComplete = false;
            marsComplete = false;
            saturnComplete = false;
            nasaComplete = false;
            penetrateTheSoulComplete = false;
            highCityComplete = false;
            puzzle1Complete = false;
            rhythmGameComplete = false;
            glassesComplete = false;
            multiplayerEnabled = false;
            
            entrepreneursViewed = new bool[14];

            for  (int i = 0; i < AUTO_LEADER_COUNT; i++)
            {
                autoLeadersViewed[i] = false;
            }

            for  (int i = 0; i < ENTREPRENEUR_COUNT; i++)
            {
                entrepreneursViewed[i] = false;
            }

            channelsViewed = new bool[7];
            for (int i = 0; i < channelsViewed.Length; i++)
            {
                channelsViewed[i] = false;
                Debug.Log("channels viewed: " + i + channelsViewed[i]);
            }

            apartmentComplete = false;
            
            totalPlaytime = TimeSpan.Zero;

            InitializeLevelList();// Initialize levels
        }

        public void InitializeLevelList()
        {
            //player.levelList = new LevelTrackerType[MAX_LEVEL];
            //Debug.Log("script_player_profile::InitializeLevelList() - levelList[0].name = " + levelList[0].name);
            
            LevelTrackerType level;
            TextAsset filePath;// Path of the text data file to use
            string[] lines;// Each line from the file

            filePath = Resources.Load<TextAsset>("txt_level_names");// The file where selectable level names are stored
            lines = filePath.text.Split("\r\n");// Let lines[] = each line from text file
            
            // For each lines[], levelNum =  0 to MAX_LEVEL
            for (int levelNum = 0; levelNum < lines.Length; levelNum++)
            {
                level = new LevelTrackerType(levelNum, lines[levelNum]);
                levelList.Add(level);
            }
        }
    }

    public static PlayerType player;
    public static string appleAuthCode;
    public static bool isAuthenticated = false;

    public static bool autoSaveStarted;
    private DateTime startPlaytime;// Used to track the start of the current play time

    private void Awake()
    {
#if UNITY_ANDROID
        if (SceneManager.GetActiveScene().name == "ToyzLogo") //for autologin for player
        //bc it's reinitializing this at the avatar importer scenes
        //and then no level names are being called bc it's only called in sign up
        {
            player = new PlayerType();
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                string player_data = File.ReadAllText(Application.persistentDataPath + "/player_sign_up.json");
                player = JsonUtility.FromJson<PlayerType>(player_data);
            }
        }
#endif
#if !UNITY_ANDROID
        if (SceneManager.GetActiveScene().name == "startscreentest5.1") //for starters
        //bc it's reinitializing this at the avatar importer scenes
        //and then no level names are being called bc it's only called in sign up
        {
            player = new PlayerType();
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                #if !UNITY_TVOS
                string player_data = File.ReadAllText(Application.persistentDataPath + "/player_sign_up.json");
                player = JsonUtility.FromJson<PlayerType>(player_data);
                #endif
            }
        }
#endif
    }

    // Used to add OnSceneLoaded (), which is not a Unity provided method.
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;// The SceneManager.sceneLoaded delegate can have any method hooked into it and it is OnSceneLoaded () here.
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If Scene is after the player's data has first been loaded from Sign Up/Log In
        if (SceneManager.GetActiveScene().name == "StandardAvatarImporter")
        {        
            //UpdateLevelTrackingList();// Make sure level list is up to date
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = new PlayerType();
        DontDestroyOnLoad(gameObject); //will have to destroy if this is on something like a sign in page or loading page
#if !UNITY_ANDROID
        if (SceneManager.GetActiveScene().name == "startscreentest5.1") 
            //bc it's reinitializing this at the avatar importer scenes
            //and then no level names are being called bc it's only called in sign up
        {
            player = new PlayerType();
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                #if !UNITY_TVOS
                string player_data = File.ReadAllText(Application.persistentDataPath + "/player_sign_up.json");
                player = JsonUtility.FromJson<PlayerType>(player_data);
                #endif
            }
        }
#endif
        autoSaveStarted = false;
        SetBadgeNameList();
        startPlaytime = DateTime.UtcNow;// Track the start of the current play time
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // called at sign up
    public static void InitializePlayer()
    {
        Debug.Log("InitializingPlayer");
        Debug.Log("InitializedLevel");
        //InitializeProgress();
        //InitializeCourseList();
        //InitializePointsCard();
    }

    // called at sign up
    public static void InitializeProgress()
    {
        player.preSurveyComplete = false;
        player.chinaUNComplete = false;
        player.colombiaUNComplete = false;
        player.germanyUNComplete = false;
        player.japanUNComplete = false;
        player.alfaRomeoComplete = false;
        player.audiComplete = false;
        player.newValue = true;
        player.stellantisComplete = false;
        player.ferrariComplete = false;
        player.fordComplete = false;
        player.gmComplete = false;
        player.hyundaiComplete = false;
        player.kiaComplete = false;
        player.lincolnComplete = false;
        player.mazdaComplete = false;
        player.mercedesComplete = false;
        player.nissanComplete = false;
        player.porscheComplete = false;
        player.entrepreneursComplete = false;
        player.backstoryComplete = false;
        player.stopTheBullyingComplete = false;
        player.marsComplete = false;
        player.saturnComplete = false;
        player.nasaComplete = false;
        player.penetrateTheSoulComplete = false;
        player.highCityComplete = false;
        player.puzzle1Complete = false;
        player.rhythmGameComplete = false;
        player.glassesComplete = false;
        player.multiplayerEnabled = false;
        
        player.entrepreneursViewed = new bool[14];

        for  (int i = 0; i < AUTO_LEADER_COUNT; i++)
        {
            player.autoLeadersViewed[i] = false;
        }

        for  (int i = 0; i < ENTREPRENEUR_COUNT; i++)
        {
            player.entrepreneursViewed[i] = false;
        }

        player.channelsViewed = new bool[7];
        for (int i = 0; i < player.channelsViewed.Length; i++)
        {
            player.channelsViewed[i] = false;
            Debug.Log("channels viewed: " + i + player.channelsViewed[i]);
        }

        player.apartmentComplete = false;
        
        player.totalPlaytime = TimeSpan.Zero;

    }


    /*
    public void UpdateLevelTrackingList()
    {
        LevelTrackerType[] tempJSONLevelData;
        int index = 0;
        player.levelList.CopyTo(tempJSONLevelData);// Create temporary array for JSON levelListData

        InitializeLevelList();// Initialize levelList to current set of level

        // Copy data from temporary JSON list to current level list
        for (int i = 0; i < tempJSONLevelData.Length; i++)
        {
            // Find the index of tempJSONLevelData[i] in the levelList
            index = player.levelList.FindIndex(listElement => listElement.name == tempJSONLevelData[i].name);

            // Copy the data over
            player.levelList[index].unlocked = tempJSONLevelData[i].unlocked;
            player.levelList[index].visited = tempJSONLevelData[i].visited;
            player.levelList[index].completed = tempJSONLevelData[i].completed;
        }
    }
    */

    // called at sign up
    public static void InitializeCourseList()
    {/*
        TextAsset courseFilePath;// Path of the text data file to use
        string[] courseLines;// Each line from the file
        string[] courseLineSubStrings;// A line split by the seperator '|'
        TextAsset topicFilePath;// Path of the text data file to use
        string[] topicLines;// Each line from the file
        string[] topicLineSubStrings;// A line split by the seperator '|'
        TextAsset lessonFilePath;// Path of the text data file to use
        string[] lessonLines;// Each line from the file
        string[] lessonLineSubStrings;// A line split by the seperator '|'
        TextAsset quizFilePath;// Path of the text data file to use
        string[] quizLines;// Each line from the file
        string[] quizLineSubStrings;// A line split by the seperator '|'
        TextAsset essayFilePath;// Path of the text data file to use
        string[] essayLines;// Each line from the file
        string[] essayLineSubStrings;// A line split by the seperator '|'

        courseFilePath = Resources.Load<TextAsset>("course_list");// The file where selectable level names are stored
        courseLines = courseFilePath.text.Split("\r\n");// Let lines[] = each line from text file        

        player.courseList = new CourseType[courseLines.Length];

        for (int courseNum = 0; courseNum < courseLines.Length; courseNum++)
        {
            player.courseList[courseNum].name = courseLines[courseNum];
            player.courseList[courseNum].completed = false;
            // Get Topic info
            topicFilePath = Resources.Load<TextAsset>(player.courseList[courseNum].name + "_topics");// The file where selectable level names are stored
            topicLines = topicFilePath.text.Split("\r\n");// Let lines[] = each line from text file        
            player.courseList[courseNum].topicList = new TopicType[topicLines.Length];

            for (int topicNum = 0; topicNum < topicLines.Length; topicNum++)
            {
                player.courseList[courseNum].topicList[topicNum].name = topicLines[topicNum];
                player.courseList[courseNum].topicList[topicNum].completed = false;
                
                // Get lesson info
                lessonFilePath = Resources.Load<TextAsset>(player.courseList[courseNum].topicList[topicNum].name + "_lessons");// The file where selectable level names are stored
                lessonLines = lessonFilePath.text.Split("\r\n");// Let lines[] = each line from text file        
                player.courseList[courseNum].topicList[topicNum].lessonList = new LessonType[lessonLines.Length];

                for (int lessonNum = 0; lessonNum < lessonLines.Length; lessonNum++)
                {
                    lessonLineSubStrings = lessonLines[lessonNum].Split('|');// Split line[levelNum] at '|' into substrings
                    player.courseList[courseNum].topicList[topicNum].lessonList[lessonNum].name = lessonLineSubStrings[0];
                    player.courseList[courseNum].topicList[topicNum].lessonList[lessonNum].lessonInfo = lessonLineSubStrings[1].Split('#');
                    player.courseList[courseNum].topicList[topicNum].lessonList[lessonNum].completed = false;
                }

                // Get Quiz info
                quizFilePath = Resources.Load<TextAsset>(player.courseList[courseNum].topicList[topicNum].name + "_quizes");// The file where selectable level names are stored
                quizLines = quizFilePath.text.Split("\r\n");// Let lines[] = each line from text file        
                player.courseList[courseNum].topicList[topicNum].quizList = new QuizType[quizLines.Length];

                for (int quizNum = 0; quizNum < quizLines.Length; quizNum++)
                {
                    quizLineSubStrings = quizLines[quizNum].Split('|');// Split line[levelNum] at '|' into substrings
                    player.courseList[courseNum].topicList[topicNum].quizList[quizNum].name = quizLineSubStrings[0];
                    player.courseList[courseNum].topicList[topicNum].quizList[quizNum].questions = quizLineSubStrings[1].Split('#');
                    player.courseList[courseNum].topicList[topicNum].quizList[quizNum].completed = false;
                }

                // Get Essay info
                essayFilePath = Resources.Load<TextAsset>(player.courseList[courseNum].topicList[topicNum].name + "_essays");// The file where selectable level names are stored
                essayLines = essayFilePath.text.Split("\r\n");// Let lines[] = each line from text file        
                player.courseList[courseNum].topicList[topicNum].essayList = new EssayType[essayLines.Length];

                for (int essayNum = 0; essayNum < essayLines.Length; essayNum++)
                {
                    essayLineSubStrings = essayLines[essayNum].Split('|');// Split line[levelNum] at '|' into substrings
                    player.courseList[courseNum].topicList[topicNum].essayList[essayNum].name = essayLineSubStrings[0];
                    player.courseList[courseNum].topicList[topicNum].essayList[essayNum].question = essayLineSubStrings[1];
                    player.courseList[courseNum].topicList[topicNum].essayList[essayNum].completed = false;
                }
            }
        }*/
    }


    public string GetPlayerName()
    {
        return player.account.name;
    }

    public string GetPlayerEmail()
    {
        return player.account.email;
    }

    public int GetPlayerAge()
    {
        return player.account.age;
    }

    public string GetPlayerWorld()
    {
        return player.account.superheroWorld;
    }

    public string GetPlayerTrait()
    {
        return player.account.superheroTrait;
    }

    public int GetMaxLevel()
    {
        return MAX_LEVEL;
    }

/*
    public string GetCompletedLevelNames()
    {
        string collectedNames = "";
        for (int i = 0; i < MAX_LEVEL; i++)
        {
            if (levelList[i].levelCompleted)
            {
                collectedNames += levelList[i].levelName;// Add answers to collection
            }
            // Add seperator character, unless at the end
            if (i < (MAX_LEVEL - 1))
            {
                collectedNames += "#";                
            }
        }
        
        return collectedNames;
    }
*/

    public void SetRPMAvatarURL()
    {
        // Get RPM Avatar URL
        string rpmShortCode = "https://api.readyplayer.me/v1/avatars/";
        string avatarURL = GameObject.FindWithTag("RPMPlayer").name;// Get the name of the player's avatar game object
        //avatarURL.Replace("Avatar-", "https://d1a370nemizbjq.cloudfront.net/");// Recreate the player's avatar URL for storage
        player.account.avatarURL = rpmShortCode + avatarURL + ".glb";// Set the player's avater URL to the resulting URL
        Debug.Log("you saved the avatar URL! it's this: " + player.account.avatarURL);
    }

    private void SetCompletedLevelNames()
    {/*
        string collectedNames = "";// Get Completed Level Names from back end
        string[] nameSubStrings = collectedNames.Split('#');// Split collectedNames at '#' into substrings

        for (int i = 0; i < nameSubStrings.Length; i++)
        {
            for (int j = 0; j < MAX_LEVEL; j++)
            {
                if (nameSubStrings[i] == levelList[j].levelName)
                {
                    levelList[j].levelCompleted = true;
                }
            }
        }
    */}

    private void SetBadgeNameList()
    {/*
        TextAsset filePath;// Path of the text data file to use
        string[] lines;// Each line from the file
        filePath = Resources.Load<TextAsset>("txt_badge_names");
        lines = filePath.text.Split("\r\n");

        badgeNamesList = new string[lines.Length];

        // store the record of badge names
        for (int i = 0; i < lines.Length; i++)
        {
            badgeNamesList[i] = lines[i];
        }
    */}

    public void HasAppleKey()
    {

    }


    public void DeleteAppleKey()
    {
        
    }

    public void AddBadge(string inBadgeName)
    {
        if (!player.badgeList.Contains(inBadgeName))
        {
            player.badgeList.Add(inBadgeName);
            //SaveProgress();// Update back end
        }
    }

    public void AddAssignment(string inAssignmentName, string inAssignmentAnswers)
    {
        bool hasAssignment = false;
        AssignmentType newAssignment = new AssignmentType();
        // Check if they already have the assignment
        for (int i = 0; i < player.assignmentList.Count; i++)
        {
            // If so, update answers
            if (player.assignmentList[i].name == inAssignmentName)
            {
                hasAssignment = true;
                player.assignmentList[i].answers = inAssignmentAnswers;
                //SaveProgress();// Update back end
            }
        }

        // Otherwise, add assignment
        if (hasAssignment == false)
        {
            newAssignment.name = inAssignmentName;
            newAssignment.answers = inAssignmentAnswers;
            player.assignmentList.Add(newAssignment);
            //SaveProgress();// Update back end
        }
    }

    public static script_player_profile.PlayerType load_data() //Should only be called in login or start of game,      turns json string to class playerType
    { 
        //this will check if a local file is there (if for any reason cloud save isnt called, this should be called
        //then after called, use load JSON player data to take this data to the CURRENT player type)
#if !UNITY_TVOS
        if (File.Exists(Application.persistentDataPath + "/player_sign_up.json"))
        {
            string loaded_data = File.ReadAllText(Application.persistentDataPath + "/player_sign_up.json");
            script_player_profile.PlayerType lod = JsonUtility.FromJson<script_player_profile.PlayerType>(loaded_data);
            Debug.Log("lod");//just to just if the data is correct
            return lod;
        }
        else
        {
            Debug.Log("File doesn't exist");
            return null;
        }
        #endif
        #if UNITY_TVOS
            return new script_player_profile.PlayerType();
        #endif
    }

    // Updates record of player's position, called in player progress
    private void UpdatePosition()
    {
        player.playerPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }

    // Updates record of player's position, called in player progress
    private void UpdatePlaytime()
    {
        DateTime currentPlaytime = DateTime.UtcNow;// Get the current play time
        player.totalPlaytime += currentPlaytime - startPlaytime;
        startPlaytime = DateTime.UtcNow;
    }

    public void SaveProgress() //self explanatory, saves to backend and JSON to read
    {
        UpdatePosition();// Ensure the player's position it updated
        UpdatePlaytime();// Update the player's total playtime
        string strOutput = JsonUtility.ToJson(player);
        // Create or update JSON
        #if !UNITY_TVOS
        File.WriteAllText(Application.persistentDataPath + "/player_sign_up.json", strOutput);
        #endif
        //Debug.Log("JSON Updated to this" + strOutput);
        //const string URL = "https://8u4v59vyvb.execute-api.us-east-1.amazonaws.com/test/update_level";
        //var webRequest  = System.Net.WebRequest.Create(URL);
        //webRequest.Method = "GET";
        //webRequest.Timeout = 12000;
        //webRequest.ContentType = "application/json";
        //webRequest.Headers.Add("email", player.account.email);
        //webRequest.Headers.Add("level", player.account.levelRank.ToString());
        //webRequest.Headers.Add("playerProgress", strOutput);
        //using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
        //{
        //        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
        //        {
        //            var jsonResponse = sr.ReadToEnd();
        //            Debug.Log("script_player_profile::SaveProgress() - jsonResponse" + jsonResponse);
        //            Debug.Log("script_player_profile::SaveProgress() - level_progress" + player.account.levelRank.ToString());
        //            if (jsonResponse == "Success")
        //            {
        //                Debug.Log("script_player_profile::SaveProgress() - Success: Saved Progress");
        //            }
        //            else if (jsonResponse == "Error: User does not exist")
        //            {
        //                Debug.Log("script_player_profile::SaveProgress() - Error: User does not exist");
        //            }
        //            else if (jsonResponse == "Error: Multiple users have same email. This is not allowed")
        //            {
        //                Debug.Log("script_player_profile::SaveProgress() - Error: Multiple users have same email. This is not allowed");
        //            }
        //    }
        //}
#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
        //var database = CKContainer.DefaultContainer().PrivateCloudDatabase;
        //var record = new CKRecord("userInfo", new CKRecordID(PlayerPrefs.GetString("AppleUserId")));
        GameObject.Find("player_data").GetComponent<PlayfabManager>().LoginAndSaveToApple(); //re login and save to backend
        //database.FetchRecordWithID(new CKRecordID(PlayerPrefs.GetString("AppleUserId")), (record2, error) =>
        //{
        //    Debug.Log("we fetch the record!");
        //    if (error != null) {
        //        //set this record to the record fetched
        //        record = record2;
        //        record.SetAsset(new CKAsset(NSURL.FileURLWithPath(Application.persistentDataPath + "/player_sign_up.json")), "player_sign_up");
        //        database.SaveRecord(record, (r, error) =>
        //        {
        //            //wasCalled = true;
        //            Debug.Log("we saved the record!");
        //        });
        //    }
        //}
        //);
        //iCloudBinding.selectDatabase(false);
        //iCloudBinding.fetchRecord("userinfo", script_player_profile.player.account.appleID);
        //fetches the record we saved to the backend
        //iCloudBinding.updateRecord("userInfo", script_player_profile.player.account.appleID, script_player_profile.player.account.name, Application.persistentDataPath + "/player_sign_up.json");
        //updates it
        //GKSaveGame(,"saveFile",)
        updateScore();
#endif

        // ********************************GPG_CloudSaveSystem***********************************
#if UNITY_ANDROID
        GameObject.Find("player_data").GetComponent<PlayfabManager>().LoginGoogle(); //re login and save to backend
        gameObject.GetComponent<GPG_CloudSaveSystem>().SaveToCloud();//script is attached to player_data
        Social.ReportScore(player.pointsCard.dahvarsityPoints, "CgkI0cy7pbIaEAIQCw", (bool success) => {
            // handle success or failure
        });
#endif

    }

#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
    public void updateScore()
    {
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Avatar");
        currentPlayer.GetComponent<GameKitManager>().ReportScore();
    }
#endif

    public void StartAutosave()
    {
        autoSaveStarted = true;

        InvokeRepeating("SaveProgress", 0f, 60.0f);
    }

    public void DeleteAccount()
    {
        /*
        const string URL = "https://8u4v59vyvb.execute-api.us-east-1.amazonaws.com/test/update_level";
        var webRequest  = System.Net.WebRequest.Create(URL);
            webRequest.Method = "GET";
            webRequest.Timeout = 12000;
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("email", playerEmail);
            webRequest.Headers.Add("level", levelProgress.ToString());
            webRequest.Headers.Add("isDeleteRequest", "True");
            using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                {
                    var jsonResponse = sr.ReadToEnd();
                    if (jsonResponse == "Success")
                    {
                        
                    }
                    else if (jsonResponse == "Error: User does not exist")
                    {
                    }
                    else if (jsonResponse == "Error: Multiple users have same email. This is not allowed")
                    {
                    }
                }
            }
        */
#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
        //var database = CKContainer.DefaultContainer().PrivateCloudDatabase;
        //var wasCalled = false;
        //database.DeleteRecordWithID(new CKRecordID(player.account.appleID), (r2, error2) => {
        //    wasCalled = true;
        //    Debug.Log("we deleted the record!");
        //});
        ////iCloudBinding.deleteRecord(player.account.appleID);
        //PlayerPrefs.DeleteKey("AppleUserId");
        CallDeletePlayerBackend();
#endif

#if UNITY_ANDROID
        gameObject.GetComponent<GPG_CloudSaveSystem>().DeleteGameData("player_sign_up");//script is attached to player_data
#endif
#if !UNITY_TVOS
        File.Delete(Application.persistentDataPath + "/player_sign_up.json");
        Debug.Log("file Deleted!");
        script_player_profile.player.account.deleteRequest = true;
#endif
#if UNITY_ANDROID
        GameObject.Find("player_data").GetComponent<PlayfabManager>().SavePlayerData();
        GameObject.Find("player_data").GetComponent<GPG_CloudSaveSystem>().SaveToCloud();
#endif
        //SceneManager.LoadScene("startscreentest5.1");// Go to Sign up
    }

    public void SaveBadge(string inBadgeName)
    {/*
        Debug.Log("script_player_profile::SaveBadge() - inBadgeName = " + inBadgeName);
        const string URL = "https://i3st5lhdq1.execute-api.us-east-1.amazonaws.com/test/add";
        var webRequest  = System.Net.WebRequest.Create(URL);
            webRequest.Method = "GET";
            webRequest.Timeout = 12000;
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("email", playerEmail);
            webRequest.Headers.Add("assetname", inBadgeName);
            webRequest.Headers.Add("assettype", "Badge");
            using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                {
                    var jsonResponse = sr.ReadToEnd();
                    Debug.Log(jsonResponse);
                    if (jsonResponse == "Success")
                    {
                        Debug.Log("script_player_profile::SaveBadge() - Success: Saved Player's Badge");
                    }
                }
            }
    */}

    public void CallDeletePlayerBackend()
    {
        
    }

    public void LoadBadges()
    {/*

        // Get Badge data
        BadgeData badgeWebResult;

        // Check each available badge, and if they have it, then add it to their badgelist
        for (int i = 0; i < badgeNamesList.Length; i++)
        {
            Debug.Log("script_player_profile::LoadBadges() - email:" + playerEmail + "|" + "assetName:" + badgeNamesList[i] +"|END");
            const string URL = "https://i3st5lhdq1.execute-api.us-east-1.amazonaws.com/test/get";
            var webRequest = System.Net.WebRequest.Create(URL);
            webRequest.Method = "GET";
            webRequest.Timeout = 12000;
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("email", playerEmail);
            webRequest.Headers.Add("assetName", badgeNamesList[i]);
            webRequest.Headers.Add("assetType", "Badge");

            using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                {
                    var jsonResponse = sr.ReadToEnd();
                    Debug.Log("script_player_profile::LoadBadges() - json for badges: " + jsonResponse);
                    Debug.Log("script_player_profile::LoadBadges() - inBadgeName: " + badgeNamesList[i]);
                    if (jsonResponse == "Success")
                    {
                        badgeWebResult = JsonUtility.FromJson<BadgeData>(jsonResponse);
                        Debug.Log("script_player_profile::LoadBadges() - badgeWebResult.badgeName: " + badgeWebResult.badgeName);
                        badgeList.Add(badgeWebResult.badgeName);
                    }
                    else if (jsonResponse == "Error: Asset not found for user")
                    {
                        Debug.Log("script_player_profile::LoadBadges() - Error: Asset not found for user");
                    }
                }
            }
        }
    */}

    public void SaveProfile()
    {
        
    }
}
