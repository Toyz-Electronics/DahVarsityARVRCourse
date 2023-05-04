using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
using Apple.GameKit;
using Apple.GameKit.Leaderboards;
using Apple.GameKit.Multiplayer;
#endif
using UnityEngine;
using UnityEngine.UI;

public class GameKitManager : MonoBehaviour
{
    #if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
    [SerializeField]
    private RawImage _playerPhotoImage;

    [SerializeField]
    private RawImage _playerDashboardImage;

    [SerializeField]
    private RawImage _playerTravelImage;

    [SerializeField]
    private Button _realtimeMatchmakeUI;

    [SerializeField]
    private Button _leaderboardUI;

    private bool TalkToPlayers = false;

    private GKMatch match;

    // Start is called before the first frame update
    private async Task Start()
    {
        try
        {
            var player = await GKLocalPlayer.Authenticate();
            Debug.Log($"GameKit Authentication: isAuthenticated => {player.IsAuthenticated}");
            _realtimeMatchmakeUI.onClick.AddListener(OnRealtimeMatchmake);
            _leaderboardUI.onClick.AddListener(ReportScore);
            _leaderboardUI.onClick.AddListener(LoadScores);
            if (!player.IsUnderage)
            {
                // Ask for analytics permissions, etc
                TalkToPlayers = true;
            }

            // Resolves a new instance of the players photo as a Texture2D
            var photo = await player.LoadPhoto(GKPlayer.PhotoSize.Small);
            _playerPhotoImage.GetComponent<RawImage>().texture = photo;
            _playerDashboardImage.GetComponent<RawImage>().texture = photo;
            _playerTravelImage.GetComponent<RawImage>().texture = photo;

            // Loads the local player's friends list if the local player and their friends grant access
            var friends = await GKLocalPlayer.Local.LoadFriends();

            // Loads players to whom the local player can issue a challenge.
            var challengeableFriends = await GKLocalPlayer.Local.LoadChallengeableFriends();

            // Loads players from the friends list or players that recently participated in a game with the local player
            var recentPlayers = await GKLocalPlayer.Local.LoadRecentPlayers();
            GKInvite.InviteAccepted += OnInviteAccepted;
            var challenges = await GKChallenge.LoadReceivedChallenges();

        }
        catch (GameKitException exception)
        {
            Debug.LogError(exception);
        }
    }

    private async void OnRealtimeMatchmake()
    {
        var request = GKMatchRequest.Init();
        request.MinPlayers = 2;
        request.MaxPlayers = 4;

        // Wait for match to start...
        GKMatch match = await GKMatchmakerViewController.Request(request);
        match.Delegate.DidFailWithError += OnRealtimeMatchDidFailWithError;
        match.Delegate.DataReceived += OnRealtimeMatchDataReceived;
        //match.PlayerConnectionStateChanged += OnMatchPlayerConnectionStateChanged;
        // Creates the channel
        var channel = match.VoiceChat("myChannelName");
        channel.Start();
        // Enable to sample microphone
        if(TalkToPlayers) {
        channel.IsActive = true;
        }
        else 
        channel.IsActive = false;
        // Send some data...
        match.Send(new byte[1] { 0 }, GKMatch.GKSendDataMode.Reliable);
    }


    public void OnInviteAccepted(GKPlayer invitingPlayer, GKInvite invite)
    {
        match.Send(new byte[1] { 0 }, GKMatch.GKSendDataMode.Reliable);
        Debug.Log("Matchmake happening!");
    }

    private void OnRealtimeMatchDataReceived(byte[] data, GKPlayer fromPlayer)
    {
        Debug.Log($"Realtime match data received from" + fromPlayer.DisplayName);
    }

    private void OnRealtimeMatchDidFailWithError(GameKitException exception)
    {
        Debug.LogError(exception);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public async void ReportScore()
    {
        var leaderboardId = "FirstDahVarsityLeaderboard";
        var score = script_player_profile.player.pointsCard.dahvarsityPoints;
        var context = 0;

        // Filter leadboards by params string[] identifiers
        var leaderboards = await GKLeaderboard.LoadLeaderboards(leaderboardId);
        var leaderboard = leaderboards.FirstOrDefault();
        // Submit
        await leaderboard.SubmitScore(score, context, GKLocalPlayer.Local);
    }

    public async Task LoadLeaderboards()
    {
        var allLeaderboards = await GKLeaderboard.LoadLeaderboards();
        var filteredLeaderboards = await GKLeaderboard.LoadLeaderboards("lb1", "lb3");
    }

    public void sendMessage(string text){
        var data = Encoding.ASCII.GetBytes(text);
        match.Send(data, GKMatch.GKSendDataMode.Reliable);
    }

    public async void LoadScores()
    {
        var playerScope = GKLeaderboard.PlayerScope.Global;
        var timeScope = GKLeaderboard.TimeScope.AllTime;
        var rankMin = 1;
        var rankMax = 100;
        var leaderboards = await GKLeaderboard.LoadLeaderboards("FirstDahVarsityLeaderboard");
        var leaderboard = leaderboards.FirstOrDefault();
        var scores = await leaderboard.LoadEntries(playerScope, timeScope, rankMin, rankMax);
    }

    public async void LoadLeaderboardImage()
    {
        var leaderboards = await GKLeaderboard.LoadLeaderboards("FirstDahVarsityLeaderboard");
        var leaderboard = leaderboards.FirstOrDefault();
        var image = await leaderboard.LoadImage();
    }



    #endif
}
