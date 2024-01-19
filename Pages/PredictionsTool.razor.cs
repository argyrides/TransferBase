using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Runtime.ConstrainedExecution;
using TransferBase.Application.CustomModels;
using TransferBase.Application.Models;
using TransferBase.Application.Services.FixData;
using TransferBase.Application.Services.General;
using TransferBase.Components;
using TransferBase.Model.FastTree;
using TransferBase.Pages.Shared;

namespace TransferBase.Pages
{
    public partial class PredictionsTool
    {
        [Inject]
        public TransfersService TransfersService { get; set; } = default!;
        [Inject]
        public PlayersService PlayersService { get; set; } = default!;
        [Inject]
        public ClubsService ClubsService { get; set; } = default!;
        [Inject]
        public PlayerSkillsService PlayerSkillsService { get; set; } = default!;
        [Inject]
        public ValuesService ValuesService { get; set; } = default!;
        [Inject]
        public NationalTeamsService NationalTeamsService { get; set; } = default!;
        [Inject]
        public GamesService GamesService { get; set; } = default!;
        [Inject]
        public CoachesService CoachesService { get; set; } = default!;
        [Inject]
        public AppearancesService AppearancesService { get; set; } = default!;
        [Inject]
        public ISnackbar? Snackbar { get; set; }


        [CascadingParameter]
        public MainLayout? Layout { get; set; }
        private User? user => Layout!.User;

        private AlertMessage? _alertMessage;

        private string? value1;
        private string? value2;
        private bool showValuesChart;
        private bool showStatistics;
        private bool showPositiveSkills;
        private bool showNegativeSkills;
        private bool showInformation;
        private float predictionValue = 0f;
        private int playerId = -1;
        public Color SelectedColor { get; set; } = Color.Default;
        private IEnumerable<string>? players { get; set; }
        private IEnumerable<string>? clubs { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                List<Player> playersList = await PlayersService.GetAllPlayersAsync(2021);
                players = playersList.Select(a => string.Concat(a.Name, " | ", a.Id))!;

                List<Club> clubsList = await ClubsService.GetAllClubs();
                clubs = clubsList.Select(a => a.Name)!;
            }
            catch (Exception ex)
            {
                _alertMessage!.ShowAlert(ex.Message, Severity.Error);
            }
        }
        private async Task<IEnumerable<string>> Search1(string value)
        {
            await Task.Delay(1000);
            //Player selectedPlayer = await PlayersService.GetPlayerById(value);
            //string realValue = (selectedPlayer != null) ? selectedPlayer.Name! : "";
            if (string.IsNullOrEmpty(value))
                return players!;
            return players!.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        private async Task<IEnumerable<string>> Search2(string value)
        {
            await Task.Delay(1000);

            if (string.IsNullOrEmpty(value))
                return clubs!;
            return clubs!.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        private void TestChange(string newValue1)
        {
            if (value1 == null)
            {
                value1 = newValue1;
            }
            else
            {
                if (value1 != newValue1)
                {
                    showValuesChart = false;
                    showStatistics = false;
                    showPositiveSkills = false;
                    showNegativeSkills = false;
                    showInformation = false;
                    value1 = newValue1;
                    predictionValue = 0;
                    StateHasChanged();
                }
            }
            
        }

        private void PredictTransferSuccess(int playerId, string clubName)
        {
            if (playerId <= 0 || clubName == null)
                return;

            Player selectedPlayer = PlayersService.GetPlayerById(playerId);
            Club selectedClub = ClubsService.GetClubByClubName(clubName);

            if (selectedPlayer != null && selectedClub != null)
            {
                PlayerSkill playerSkill = PlayerSkillsService.GetPlayerSkillByUid(selectedPlayer.UID, 2021);
                PlayerStatisticsMod playerStatisticsMod = PlayersService.GetPlayerStatistics(playerId, 2020);
                if (playerSkill != null && playerStatisticsMod != null) 
                {
                    PredictionResult predictionResult = new()
                    {
                        PlayerName = selectedPlayer.Name,
                        PlayerPosition = selectedPlayer.SubPosition,
                        ClubFrom = playerStatisticsMod.ClubName,
                        ClubTo = selectedClub.Name,
                        ClubToCompetition = selectedClub.DomesticCompetitionId,
                        ClubToPlayerValuations = ClubsService.GetClubPlayerValuation(selectedClub.Id, 2021),
                        ClubToAveragePlayerValuations = ClubsService.GetClubAveragePlayerValuation(selectedClub.Id, 2021),
                        ClubFromAveragePlayerValuations = ClubsService.GetClubAveragePlayerValuation(selectedPlayer.CurrentClubId, 2020),
                        IsPlayedInBiggerCompetitions = TransfersService.ComparePlayerCompetitions(selectedPlayer.Id, selectedClub.Id, 2021),
                        IsPlayedInSimilarCompetitions = TransfersService.ComparePlayerSimilarCompetitions(selectedPlayer.Id, selectedClub.Id, 2021),
                        Age = playerSkill.Age,
                        PlayerNationality = selectedPlayer.CountryOfBirth,
                        AppearancesWithNationalTeam = playerSkill.Caps,
                        NationalTeamWorldRanking = NationalTeamsService.GetNationalTeamRanking(selectedPlayer.CountryOfBirth!),
                        InjuryRate = playerSkill.RcInjury,
                        HighestMarketValue = ValuesService.GetHighestMarketValueOfPlayer(selectedPlayer.Id, 2021),
                        CurrentMarketValue = ValuesService.GetMarketValueOfPlayer(selectedPlayer.Id, 2021),
                        TeamsChangedDuringCareer = AppearancesService.GetTeamsChangedDuringCareer(selectedPlayer.Id),
                        NumberOfLocalsInNewTeam = (selectedClub != null) ? selectedClub.SquatSize - selectedClub.ForeignersNumber : -1,
                        NumberOfPlayersInNewTeamSamePosition = ClubsService.GetClubPlayersInSamePosition(selectedClub!.Id, 2021, selectedPlayer.SubPosition!),
                        AverageMarketValueOfPlayerNewTeamSamePosition = ClubsService.GetTeamBestPlayerInSpecificPosition(selectedClub!.Id, 2021, selectedPlayer.SubPosition!),
                        MaximumMarketValueOfPlayerNewTeamSamePosition = ClubsService.GetClubAveragePlayerValuationByPosition(selectedClub!.Id, 2021, selectedPlayer.SubPosition!),
                        NumberOfPlayersInNewTeamSameCountry = ClubsService.GetClubPlayersSameNationality(selectedClub!.Id, 2021, selectedPlayer.SubPosition!),
                        AverageAttendanceOfNewTeam = GamesService.GetAverageAttendance(selectedClub!.Id, 2021),
                        Adaptation = playerSkill.Adaptation,
                        Ambition = playerSkill.Ambition,
                        Consistency = playerSkill.Consistency,
                        ResistantToStress = playerSkill.ResistantToStress,
                        Professional = playerSkill.Professional,
                        PreviousSeasonGoals = playerStatisticsMod.Goals,
                        PreviousSeasonAssists = playerStatisticsMod.Assists,
                        PreviousSeasonTotalMinutesPlayed = playerStatisticsMod.MinutesPlayed,
                        PreviousSeasonCleanSheets = AppearancesService.GetCleanSheets(selectedPlayer.Id, selectedPlayer.CurrentClubId, 2020),
                        PreviousSeasonGoalsConceded = AppearancesService.GetGoalsConceded(selectedPlayer.Id, 2020),
                        AverageSkills = (float)playerSkill.AverageSkills,
                        TransferSuccess = 0
                    };

                    var sampleData = new FastTreePredictionModel.TransferDataM2()
                    {
                        Club_from_average_player_valuations = predictionResult.ClubFromAveragePlayerValuations,
                        Club_to_average_player_valuations = predictionResult.ClubToAveragePlayerValuations,
                        Club_to_player_valuations = predictionResult.ClubToPlayerValuations,
                        //Is_played_in_bigger_competitions = predictionResult.IsPlayedInBiggerCompetitions,
                        //Is_played_in_similar_competitions = predictionResult.IsPlayedInSimilarCompetitions,
                        Age = predictionResult.Age,
                        Injury_rate = predictionResult.InjuryRate,
                        Highest_market_value = predictionResult.HighestMarketValue,
                        Current_market_value = predictionResult.CurrentMarketValue,
                        Number_Of_Locals_In_New_Team = predictionResult.NumberOfLocalsInNewTeam, 
                        NumberOfPlayersInNewTeamSamePosition = predictionResult.NumberOfPlayersInNewTeamSamePosition,
                        AverageMarketValueOfPlayerNewTeamSamePosition = predictionResult.AverageMarketValueOfPlayerNewTeamSamePosition,
                        MaximumMarketValueOfPlayerNewTeamSamePosition = predictionResult.MaximumMarketValueOfPlayerNewTeamSamePosition,
                        //Teams_changed_during_career = predictionResult.TeamsChangedDuringCareer,
                        AverageAttendanceOfNewTeam = predictionResult.AverageAttendanceOfNewTeam,
                        Adaptation = predictionResult.Adaptation,
                        //Ambition = predictionResult.Ambition,
                        //Consistency = predictionResult.Consistency,
                        //ResistantToStress = predictionResult.ResistantToStress,
                        //Professional = predictionResult.Professional,
                       // PreviousSeasonAssists = predictionResult.PreviousSeasonAssists,
                        //PreviousSeasonGoals = predictionResult.PreviousSeasonGoals,
                        PreviousSeasonTotalMinutesPlayed = predictionResult.PreviousSeasonTotalMinutesPlayed,
                        PlayerPosition = predictionResult.PlayerPosition!,
                        Previous_season_clean_sheets = predictionResult.PreviousSeasonCleanSheets,
                        AverageSkills = predictionResult.AverageSkills,
                        Previous_season_goals_conceded = predictionResult.PreviousSeasonGoalsConceded,
                        Previous_season_keeper_saves = predictionResult.PreviousSeasonKeeperSaves
                    };

                    var output = FastTreePredictionModel.PredictM2(sampleData);
                    var score = output.Transfer_success;

                    predictionValue = float.Round(score,2);
                    predictionResult.TransferSuccess = predictionValue;
                }
                else
                {
                    _alertMessage!.ShowAlert("Statistics are not available for specific player. Please choose another.", Severity.Error);
                }
            }
        }

        private void PredictTransfer()
        {
            try
            {
                if (value1 == null || value2 == null)
                {
                    _alertMessage!.ShowAlert("Player and Club must be filled", Severity.Error);
                    return;
                }
                if (value1 != null)
                {
                    string[] splitValues = value1.Split('|');
                    
                    if (splitValues.Length == 2)
                    {
                        playerId = Convert.ToInt32(splitValues[1].Trim());
                        // prediction for playerId
                        PredictTransferSuccess(playerId, value2);
                    }
                }

                showValuesChart = true;
                showStatistics = true;
                showPositiveSkills = true;
                showNegativeSkills = true;
                showInformation = true;
                StateHasChanged();

            }
            catch (Exception ex)
            {
                _alertMessage!.ShowAlert(ex.Message, Severity.Error);
            }
        }
    }
}