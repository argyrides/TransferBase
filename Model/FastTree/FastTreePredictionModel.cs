using Microsoft.ML;
using Microsoft.ML.Data;

namespace TransferBase.Model.FastTree
{
    public class FastTreePredictionModel
    {
        public class TransferData
        {
            [LoadColumn(7), ColumnName(@"highest_market_value")]
            public float Highest_market_value { get; set; }

            [LoadColumn(8), ColumnName(@"current_market_value")]
            public float Current_market_value { get; set; }

            [LoadColumn(9), ColumnName(@"teams_changed_during_career")]
            public float Teams_changed_during_career { get; set; }
            [LoadColumn(6), ColumnName(@"injury_rate")]
            public float Injury_rate { get; set; }
            [LoadColumn(3), ColumnName(@"is_played_in_bigger_competitions")]
            public bool Is_played_in_bigger_competitions { get; set; }
            [LoadColumn(4), ColumnName(@"is_played_in_similar_competitions")]
            public bool Is_played_in_similar_competitions { get; set; }
            [LoadColumn(25), ColumnName(@"player_position")]
            public string? PlayerPosition;
            [LoadColumn(0), ColumnName(@"club_from_average_player_valuations")]
            public float Club_from_average_player_valuations;
            [LoadColumn(2), ColumnName(@"club_to_player_valuations")]
            public float Club_to_player_valuations;
            [LoadColumn(1), ColumnName(@"club_to_average_player_valuations")]
            public float Club_to_average_player_valuations;
            [LoadColumn(5), ColumnName(@"age")]
            public float Age;
            [LoadColumn(10), ColumnName(@"number_of_locals_in_new_team")]
            public float Number_Of_Locals_In_New_Team;
            [LoadColumn(11), ColumnName(@"number_of_players_in_new_team_same_position")]
            public float NumberOfPlayersInNewTeamSamePosition;
            [LoadColumn(12), ColumnName(@"average_market_value_of_player_new_team_same_position")]
            public float AverageMarketValueOfPlayerNewTeamSamePosition;
            [LoadColumn(13), ColumnName(@"maximum_market_value_of_player_new_team_same_position")]
            public float MaximumMarketValueOfPlayerNewTeamSamePosition;
            [LoadColumn(14), ColumnName(@"number_of_players_in_new_team_same_country")]
            public float NumberOfPlayersInNewTeamSameCountry;
            [LoadColumn(15), ColumnName(@"average_attendance_of_new_team")]
            public float AverageAttendanceOfNewTeam;
            [LoadColumn(16), ColumnName(@"adaptation")]
            public float Adaptation;
            [LoadColumn(17), ColumnName(@"ambition")]
            public float Ambition;
            [LoadColumn(18), ColumnName(@"consistency")]
            public float Consistency;
            [LoadColumn(19), ColumnName(@"resistant_to_stress")]
            public float ResistantToStress;
            [LoadColumn(20), ColumnName(@"professional")]
            public float Professional;
            [LoadColumn(21), ColumnName(@"previous_season_goals")]
            public float PreviousSeasonGoals;
            [LoadColumn(22), ColumnName(@"previous_season_assists")]
            public float PreviousSeasonAssists;
            [LoadColumn(23), ColumnName(@"previous_season_total_minutes_played")]
            public float PreviousSeasonTotalMinutesPlayed;
            [LoadColumn(26), ColumnName(@"average_skills")]
            public float AverageSkills;
            [LoadColumn(24), ColumnName(@"previous_season_clean_sheets")]
            public float Previous_season_clean_sheets { get; set; }

            [LoadColumn(27), ColumnName(@"previous_season_goals_conceded")]
            public float Previous_season_goals_conceded { get; set; }

            [LoadColumn(28), ColumnName(@"previous_season_keeper_saves")]
            public float Previous_season_keeper_saves { get; set; }

            [LoadColumn(29), ColumnName(@"Label")]
            public float Transfer_success;


        }

        public class TransferDataM2
        {
            [LoadColumn(5), ColumnName(@"highest_market_value")]
            public float Highest_market_value { get; set; }

            [LoadColumn(6), ColumnName(@"current_market_value")]
            public float Current_market_value { get; set; }


            [LoadColumn(4), ColumnName(@"injury_rate")]
            public float Injury_rate { get; set; }

            [LoadColumn(15), ColumnName(@"player_position")]
            public string? PlayerPosition;
            [LoadColumn(0), ColumnName(@"club_from_average_player_valuations")]
            public float Club_from_average_player_valuations;
            [LoadColumn(2), ColumnName(@"club_to_player_valuations")]
            public float Club_to_player_valuations;
            [LoadColumn(1), ColumnName(@"club_to_average_player_valuations")]
            public float Club_to_average_player_valuations;
            [LoadColumn(3), ColumnName(@"age")]
            public float Age;
            [LoadColumn(7), ColumnName(@"number_of_locals_in_new_team")]
            public float Number_Of_Locals_In_New_Team;
            [LoadColumn(8), ColumnName(@"number_of_players_in_new_team_same_position")]
            public float NumberOfPlayersInNewTeamSamePosition;
            [LoadColumn(9), ColumnName(@"average_market_value_of_player_new_team_same_position")]
            public float AverageMarketValueOfPlayerNewTeamSamePosition;
            [LoadColumn(10), ColumnName(@"maximum_market_value_of_player_new_team_same_position")]
            public float MaximumMarketValueOfPlayerNewTeamSamePosition;
            [LoadColumn(11), ColumnName(@"average_attendance_of_new_team")]
            public float AverageAttendanceOfNewTeam;
            [LoadColumn(12), ColumnName(@"adaptation")]
            public float Adaptation;

            [LoadColumn(13), ColumnName(@"previous_season_total_minutes_played")]
            public float PreviousSeasonTotalMinutesPlayed;
            [LoadColumn(16), ColumnName(@"average_skills")]
            public float AverageSkills;
            [LoadColumn(14), ColumnName(@"previous_season_clean_sheets")]
            public float Previous_season_clean_sheets { get; set; }

            [LoadColumn(17), ColumnName(@"previous_season_goals_conceded")]
            public float Previous_season_goals_conceded { get; set; }

            [LoadColumn(18), ColumnName(@"previous_season_keeper_saves")]
            public float Previous_season_keeper_saves { get; set; }

            [LoadColumn(19), ColumnName(@"Label")]
            public float Transfer_success;
        }
        public class PredictedValue
        {
            [ColumnName(@"Score")]
            public float Transfer_success { get; set; }
        }

        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static string MLNetModelPath = path + @"\source\repos\TransferBase\TransferBase\Model\FastTree\M2.zip";

        public static readonly Lazy<PredictionEngine<TransferData, PredictedValue>> PredictEngine = new Lazy<PredictionEngine<TransferData, PredictedValue>>(() => CreatePredictEngine(), true);
        public static readonly Lazy<PredictionEngine<TransferDataM2, PredictedValue>> PredictEngineM2 = new Lazy<PredictionEngine<TransferDataM2, PredictedValue>>(() => CreatePredictEngineM2(), true);

        public static PredictedValue Predict(TransferData input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }
        private static PredictionEngine<TransferData, PredictedValue> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<TransferData, PredictedValue>(mlModel);
        }

        public static PredictedValue PredictM2(TransferDataM2 input)
        {
            var predEngine = PredictEngineM2.Value;
            return predEngine.Predict(input);
        }
        private static PredictionEngine<TransferDataM2, PredictedValue> CreatePredictEngineM2()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<TransferDataM2, PredictedValue>(mlModel);
        }
    }
}
