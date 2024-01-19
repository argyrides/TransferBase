using Microsoft.ML.Data;
using Microsoft.ML;

namespace TransferBase.Model.CustomModelTransferSuccess
{
    public class ModelInput
    {
        [ColumnName(@"club_from_average_player_valuations")]
        public float Club_from_average_player_valuations { get; set; }

        [ColumnName(@"club_to_player_valuations")]
        public float Club_to_player_valuations { get; set; }

        [ColumnName(@"club_to_average_player_valuations")]
        public float Club_to_average_player_valuations { get; set; }

        [ColumnName(@"is_played_in_bigger_competitions")]
        public bool Is_played_in_bigger_competitions { get; set; }

        [ColumnName(@"is_played_in_similar_competitions")]
        public bool Is_played_in_similar_competitions { get; set; }

        [ColumnName(@"age")]
        public float Age { get; set; }

        [ColumnName(@"injury_rate")]
        public float Injury_rate { get; set; }

        [ColumnName(@"highest_market_value")]
        public float Highest_market_value { get; set; }

        [ColumnName(@"current_market_value")]
        public float Current_market_value { get; set; }

        [ColumnName(@"teams_changed_during_career")]
        public float Teams_changed_during_career { get; set; }

        [ColumnName(@"number_of_locals_in_new_team")]
        public float Number_of_locals_in_new_team { get; set; }

        [ColumnName(@"number_of_players_in_new_team_same_position")]
        public float Number_of_players_in_new_team_same_position { get; set; }

        [ColumnName(@"average_market_value_of_player_new_team_same_position")]
        public float Average_market_value_of_player_new_team_same_position { get; set; }

        [ColumnName(@"maximum_market_value_of_player_new_team_same_position")]
        public float Maximum_market_value_of_player_new_team_same_position { get; set; }

        [ColumnName(@"number_of_players_in_new_team_same_country")]
        public float Number_of_players_in_new_team_same_country { get; set; }

        [ColumnName(@"average_attendance_of_new_team")]
        public float Average_attendance_of_new_team { get; set; }

        [ColumnName(@"adaptation")]
        public float Adaptation { get; set; }

        [ColumnName(@"ambition")]
        public float Ambition { get; set; }

        [ColumnName(@"consistency")]
        public float Consistency { get; set; }

        [ColumnName(@"resistant_to_stress")]
        public float Resistant_to_stress { get; set; }

        [ColumnName(@"professional")]
        public float Professional { get; set; }

        [ColumnName(@"previous_season_goals")]
        public float Previous_season_goals { get; set; }

        [ColumnName(@"previous_season_assists")]
        public float Previous_season_assists { get; set; }

        [ColumnName(@"previous_season_total_minutes_played")]
        public float Previous_season_total_minutes_played { get; set; }

        [ColumnName(@"previous_season_clean_sheets")]
        public float Previous_season_clean_sheets { get; set; }

        [ColumnName(@"previous_season_goals_conceded")]
        public float Previous_season_goals_conceded { get; set; }

        [ColumnName(@"previous_season_keeper_saves")]
        public float Previous_season_keeper_saves { get; set; }

        [ColumnName(@"player_position")]
        public string Player_position { get; set; }

        [ColumnName(@"average_skills")]
        public float Average_skills { get; set; }

        [ColumnName(@"transfer_success")]
        public float Transfer_success { get; set; }
    }

   
}
