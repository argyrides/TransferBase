using Microsoft.ML;
using Microsoft.ML.Trainers.LightGbm;
using Microsoft.ML.Transforms;

namespace TransferBase.Model.CustomModelTransferSuccess
{
    public class MLModel
    {
        string _trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "TransfersTrainData.csv");
        string _testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "TransfersTestData.csv");
        string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");
        
        
        public void InitializeModel()
        {
            MLContext mlContext = new MLContext(seed: 0);
            var model = Train(mlContext, _trainDataPath);

            Evaluate(mlContext, model);


        }


        ITransformer Train(MLContext mlContext, string dataPath)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(dataPath, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new[] { new InputOutputColumnPair(@"is_played_in_bigger_competitions", @"is_played_in_bigger_competitions"),
                          new InputOutputColumnPair(@"is_played_in_similar_competitions", @"is_played_in_similar_competitions"),
                          new InputOutputColumnPair(@"player_position", @"player_position") }, outputKind: OneHotEncodingEstimator.OutputKind.Indicator)
                          .Append(mlContext.Transforms.ReplaceMissingValues(new[] { new InputOutputColumnPair(@"club_from_average_player_valuations", @"club_from_average_player_valuations"), new InputOutputColumnPair(@"club_to_player_valuations", @"club_to_player_valuations"), new InputOutputColumnPair(@"club_to_average_player_valuations", @"club_to_average_player_valuations"), new InputOutputColumnPair(@"age", @"age"),
                              new InputOutputColumnPair(@"injury_rate", @"injury_rate"), new InputOutputColumnPair(@"highest_market_value", @"highest_market_value"), new InputOutputColumnPair(@"current_market_value", @"current_market_value"), new InputOutputColumnPair(@"teams_changed_during_career", @"teams_changed_during_career"), new InputOutputColumnPair(@"number_of_locals_in_new_team", @"number_of_locals_in_new_team"), new InputOutputColumnPair(@"number_of_players_in_new_team_same_position", @"number_of_players_in_new_team_same_position"), new InputOutputColumnPair(@"average_market_value_of_player_new_team_same_position", @"average_market_value_of_player_new_team_same_position"), new InputOutputColumnPair(@"maximum_market_value_of_player_new_team_same_position", @"maximum_market_value_of_player_new_team_same_position"), new InputOutputColumnPair(@"number_of_players_in_new_team_same_country", @"number_of_players_in_new_team_same_country"), new InputOutputColumnPair(@"average_attendance_of_new_team", @"average_attendance_of_new_team"), new InputOutputColumnPair(@"adaptation", @"adaptation"), new InputOutputColumnPair(@"ambition", @"ambition"), new InputOutputColumnPair(@"consistency", @"consistency"), new InputOutputColumnPair(@"resistant_to_stress", @"resistant_to_stress"), new InputOutputColumnPair(@"professional", @"professional"), new InputOutputColumnPair(@"previous_season_goals", @"previous_season_goals"), new InputOutputColumnPair(@"previous_season_assists", @"previous_season_assists"), new InputOutputColumnPair(@"previous_season_total_minutes_played", @"previous_season_total_minutes_played"), new InputOutputColumnPair(@"previous_season_clean_sheets", @"previous_season_clean_sheets"), new InputOutputColumnPair(@"previous_season_goals_conceded", @"previous_season_goals_conceded"), new InputOutputColumnPair(@"previous_season_keeper_saves", @"previous_season_keeper_saves"), new InputOutputColumnPair(@"average_skills", @"average_skills") }))
                          .Append(mlContext.Transforms.Concatenate(@"Features", new[] { @"is_played_in_bigger_competitions", @"is_played_in_similar_competitions", @"player_position",
                          @"club_from_average_player_valuations", @"club_to_player_valuations", @"club_to_average_player_valuations", @"age",
                          @"injury_rate", @"highest_market_value", @"current_market_value", @"teams_changed_during_career",
                          @"number_of_locals_in_new_team", @"number_of_players_in_new_team_same_position", @"average_market_value_of_player_new_team_same_position", @"maximum_market_value_of_player_new_team_same_position",
                          @"number_of_players_in_new_team_same_country", @"average_attendance_of_new_team", @"adaptation", @"ambition", @"consistency", @"resistant_to_stress", @"professional", @"previous_season_goals", @"previous_season_assists", @"previous_season_total_minutes_played", @"previous_season_clean_sheets", @"previous_season_goals_conceded", @"previous_season_keeper_saves", @"average_skills" }))
                          //.Append(mlContext.Regression.Trainers.LightGbm(new LightGbmRegressionTrainer.Options() { NumberOfLeaves = 6, NumberOfIterations = 53, MinimumExampleCountPerLeaf = 20, LearningRate = 0.183527165889228, LabelColumnName = @"transfer_success", FeatureColumnName = @"Features", ExampleWeightColumnName = null, Booster = new GradientBooster.Options() { SubsampleFraction = 0.00247056580604279, FeatureFraction = 0.99999999, L1Regularization = 4.79390020253533E-10, L2Regularization = 0.247767803890592 }, MaximumBinCountPerFeature = 978 }));
                          .Append(mlContext.Regression.Trainers.FastTree());

            var model = pipeline.Fit(dataView);

            return model;
        }

        void Evaluate(MLContext mlContext, ITransformer model)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(_testDataPath, hasHeader: true, separatorChar: ',');
            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");

        }

    }

   

}
