USE [TransferBaseDB]
GO
/****** Object:  Table [dbo].[2122Saves]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[2122Saves](
	[Div] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[HomeTeam] [varchar](50) NULL,
	[AwayTeam] [varchar](50) NULL,
	[FTHG] [varchar](50) NULL,
	[FTAG] [varchar](50) NULL,
	[HST] [varchar](50) NULL,
	[AST] [varchar](50) NULL,
	[Hsaves] [varchar](50) NULL,
	[Asaves] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[appearances]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[appearances](
	[id] [nvarchar](450) NOT NULL,
	[game_id] [nvarchar](450) NULL,
	[player_id] [int] NOT NULL,
	[club_id] [int] NULL,
	[player_current_club_id] [int] NULL,
	[date] [datetime] NULL,
	[player_name] [nvarchar](max) NULL,
	[competition_id] [nvarchar](450) NULL,
	[yellow_cards] [int] NULL,
	[red_cards] [int] NULL,
	[goals] [int] NULL,
	[assists] [int] NULL,
	[minutes_played] [int] NULL,
	[created_at] [datetime2](7) NULL,
	[updated_at] [datetime2](7) NULL,
	[season] [int] NULL,
	[formatted_date] [varchar](20) NULL,
	[last_appearance] [date] NULL,
 CONSTRAINT [pk_appearances] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[club_games]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[club_games](
	[game_id] [nvarchar](450) NOT NULL,
	[club_id] [int] NOT NULL,
	[own_goals] [int] NULL,
	[own_position] [nvarchar](max) NULL,
	[own_manager_name] [nvarchar](max) NULL,
	[opponent_id] [nvarchar](max) NULL,
	[opponent_goals] [int] NULL,
	[opponent_position] [nvarchar](max) NULL,
	[opponent_manager_name] [nvarchar](max) NULL,
	[hosting] [nvarchar](max) NULL,
	[is_win] [nvarchar](max) NULL,
 CONSTRAINT [pk_club_games] PRIMARY KEY CLUSTERED 
(
	[game_id] ASC,
	[club_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clubs]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clubs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[club_code] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[domestic_competition_id] [nvarchar](450) NULL,
	[total_market_value] [nvarchar](max) NULL,
	[squat_size] [int] NULL,
	[average_age] [nvarchar](max) NULL,
	[foreigners_number] [int] NULL,
	[foreigners_percentage] [nvarchar](max) NULL,
	[national_team_players] [nvarchar](max) NULL,
	[stadium_name] [nvarchar](max) NULL,
	[stadium_seats] [nvarchar](max) NULL,
	[net_transfer_record] [nvarchar](max) NULL,
	[last_season] [nvarchar](max) NULL,
	[created_at] [datetime2](7) NOT NULL,
	[updated_at] [datetime2](7) NULL,
	[coach_id] [int] NULL,
	[is_european] [bit] NULL,
 CONSTRAINT [pk_clubs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[coaches]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coaches](
	[id] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
	[club] [nvarchar](max) NULL,
	[citizenship] [nvarchar](max) NULL,
	[avg_term_as_coach] [float] NULL,
	[preffered_formation] [nvarchar](max) NULL,
	[created_at] [datetime2](7) NULL,
	[updated_at] [datetime2](7) NULL,
 CONSTRAINT [PK_coaches] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[competitions]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[competitions](
	[id] [nvarchar](450) NOT NULL,
	[competition_code] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[type] [nvarchar](max) NULL,
	[country_id] [nvarchar](max) NULL,
	[country_name] [nvarchar](max) NULL,
	[domestic_league_code] [nvarchar](max) NULL,
	[confederations] [nvarchar](max) NULL,
	[created_at] [datetime2](7) NULL,
	[updated_at] [datetime2](7) NULL,
	[sub_type] [nvarchar](max) NULL,
	[competition_ranking] [int] NULL,
 CONSTRAINT [PK_competitions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[game_events]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[game_events](
	[game_id] [nvarchar](450) NOT NULL,
	[club_id] [int] NOT NULL,
	[player_id] [int] NOT NULL,
	[minute] [nvarchar](max) NULL,
	[type] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[player_in_id] [nvarchar](max) NULL,
 CONSTRAINT [pk_game_events] PRIMARY KEY CLUSTERED 
(
	[game_id] ASC,
	[club_id] ASC,
	[player_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[games]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[games](
	[id] [nvarchar](450) NOT NULL,
	[competition_id] [nvarchar](450) NULL,
	[season] [int] NULL,
	[round] [nvarchar](max) NULL,
	[date] [datetime] NULL,
	[home_club_id] [int] NULL,
	[away_club_id] [int] NULL,
	[home_club_goals] [nvarchar](max) NULL,
	[away_club_goals] [nvarchar](max) NULL,
	[home_club_position] [nvarchar](max) NULL,
	[away_club_position] [nvarchar](max) NULL,
	[home_club_manager_name] [nvarchar](max) NULL,
	[away_club_manager_name] [nvarchar](max) NULL,
	[stadium] [nvarchar](max) NULL,
	[attendance] [int] NULL,
	[referre] [nvarchar](max) NULL,
	[url] [nvarchar](max) NULL,
	[home_club_name] [nvarchar](max) NULL,
	[away_club_name] [nvarchar](max) NULL,
	[aggregate] [nvarchar](max) NULL,
	[competition_type] [nvarchar](max) NULL,
	[created_at] [datetime2](7) NOT NULL,
	[updated_at] [datetime2](7) NULL,
	[new_formatted_date] [varchar](20) NULL,
	[gk_home_saves] [int] NULL,
	[gk_away_saves] [int] NULL,
 CONSTRAINT [pk_games] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[national_teams]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[national_teams](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[ranking] [int] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_national_teams] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[player_skills]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[player_skills](
	[id] [int] NOT NULL,
	[information] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[date_of_birth] [nvarchar](max) NULL,
	[nationality] [nvarchar](max) NULL,
	[division] [nvarchar](max) NULL,
	[club] [nvarchar](max) NULL,
	[based] [nvarchar](max) NULL,
	[preferred_foot] [nvarchar](max) NULL,
	[right_foot] [nvarchar](max) NULL,
	[left_foot] [nvarchar](max) NULL,
	[position] [nvarchar](max) NULL,
	[height] [nvarchar](max) NULL,
	[weight] [nvarchar](max) NULL,
	[age] [int] NULL,
	[transfer_value] [nvarchar](max) NULL,
	[wage] [nvarchar](max) NULL,
	[at_apps] [nvarchar](max) NULL,
	[atg_is] [nvarchar](max) NULL,
	[team] [nvarchar](max) NULL,
	[caps] [int] NULL,
	[yth_apps] [nvarchar](max) NULL,
	[style] [nvarchar](max) NULL,
	[rc_injury] [int] NULL,
	[best_role] [nvarchar](max) NULL,
	[best_duty] [nvarchar](max) NULL,
	[best_position] [nvarchar](max) NULL,
	[acceleration] [int] NOT NULL,
	[aerial_ability] [int] NOT NULL,
	[aggression] [int] NOT NULL,
	[agility] [int] NOT NULL,
	[anticipation] [int] NOT NULL,
	[balance] [int] NOT NULL,
	[bravery] [int] NOT NULL,
	[command_of_area] [int] NOT NULL,
	[communication] [int] NOT NULL,
	[composure] [int] NOT NULL,
	[concentration] [int] NOT NULL,
	[corners] [int] NOT NULL,
	[crossing] [int] NOT NULL,
	[decisions] [int] NOT NULL,
	[determination] [int] NOT NULL,
	[dribbling] [int] NOT NULL,
	[eccentricity] [int] NOT NULL,
	[finishing] [int] NOT NULL,
	[first_touch] [int] NOT NULL,
	[flair] [int] NOT NULL,
	[free_kick_taking] [int] NOT NULL,
	[handling] [int] NOT NULL,
	[heading] [int] NOT NULL,
	[jumping_reach] [int] NOT NULL,
	[kicking] [int] NOT NULL,
	[leadership] [int] NOT NULL,
	[long_shots] [int] NOT NULL,
	[long_throws] [int] NOT NULL,
	[marking] [int] NOT NULL,
	[natural_fitness] [int] NOT NULL,
	[off_the_ball] [int] NOT NULL,
	[one_on_ones] [int] NOT NULL,
	[pace] [int] NOT NULL,
	[passing] [int] NOT NULL,
	[penalty_taking] [int] NOT NULL,
	[positioning] [int] NOT NULL,
	[punching] [int] NOT NULL,
	[reflexes] [int] NOT NULL,
	[ruching_out] [int] NOT NULL,
	[stamina] [int] NOT NULL,
	[strength] [int] NOT NULL,
	[tackling] [int] NOT NULL,
	[teamwork] [int] NOT NULL,
	[technique] [int] NOT NULL,
	[throwing] [int] NOT NULL,
	[vision] [int] NOT NULL,
	[work_rate] [int] NOT NULL,
	[created_at] [datetime2](7) NULL,
	[updated_at] [datetime2](7) NULL,
	[adaptation] [int] NULL,
	[ambition] [int] NULL,
	[consistency] [int] NULL,
	[resistant_to_stress] [int] NULL,
	[professional] [int] NULL,
	[season] [int] NOT NULL,
	[average_skills] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[season] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[player_values]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[player_values](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[player_id] [int] NULL,
	[last_season] [int] NULL,
	[datetime] [nvarchar](max) NULL,
	[date] [nvarchar](max) NULL,
	[date_week] [date] NULL,
	[market_value_in_eur] [int] NULL,
	[n] [nvarchar](max) NULL,
	[club_id] [int] NULL,
	[player_club_domestic_competition_id] [nvarchar](450) NULL,
	[created_at] [datetime2](7) NULL,
	[updated_at] [datetime2](7) NULL,
	[season] [int] NULL,
 CONSTRAINT [PK_player_value] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[players]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NULL,
	[first_name] [nvarchar](max) NULL,
	[last_name] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[last_season] [nvarchar](max) NULL,
	[current_club_id] [int] NOT NULL,
	[country_of_birth] [nvarchar](max) NULL,
	[country_of_citizenship] [nvarchar](max) NULL,
	[date_of_birth] [nvarchar](max) NULL,
	[sub_position] [nvarchar](max) NULL,
	[foot] [nvarchar](max) NULL,
	[height_in_cm] [nvarchar](max) NULL,
	[market_value_in_eur] [int] NULL,
	[highest_market_value_in_eur] [int] NULL,
	[contract_expiration_date] [nvarchar](max) NULL,
	[agent_name] [nvarchar](max) NULL,
	[current_club_domestic_competition_id] [nvarchar](max) NULL,
	[current_club_name] [nvarchar](max) NULL,
	[created_at] [datetime2](7) NOT NULL,
	[updated_at] [datetime2](7) NULL,
	[position] [nvarchar](max) NULL,
 CONSTRAINT [pk_players] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[prediction_results]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prediction_results](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[player_name] [nvarchar](max) NULL,
	[player_position] [nvarchar](max) NULL,
	[club_to] [nvarchar](max) NULL,
	[club_to_competition] [nvarchar](max) NULL,
	[club_to_player_valuations] [int] NULL,
	[club_to_average_player_valuations] [int] NULL,
	[club_from_average_player_valuations] [int] NULL,
	[is_played_in_bigger_competitions] [bit] NULL,
	[is_played_in_similar_competitions] [bit] NULL,
	[age] [int] NULL,
	[player_nationality] [nvarchar](max) NULL,
	[appearances_with_national_team] [int] NULL,
	[nationa_team_world_ranking] [int] NULL,
	[injury_rate] [int] NULL,
	[highest_market_value] [int] NULL,
	[current_market_value] [int] NULL,
	[teams_changed_during_career] [int] NULL,
	[number_of_locals_in_new_team] [int] NULL,
	[number_of_players_in_new_team_same_position] [int] NULL,
	[average_market_value_of_player_new_team_same_position] [int] NULL,
	[maximum_market_value_of_player_new_team_same_position] [int] NULL,
	[number_of_players_in_new_team_same_country] [int] NULL,
	[average_attendance_of_new_team] [int] NULL,
	[adaptation] [int] NULL,
	[ambition] [int] NULL,
	[consistency] [int] NULL,
	[resistant_to_stress] [int] NULL,
	[professional] [int] NULL,
	[previous_season_goals] [int] NULL,
	[previous_season_assists] [int] NULL,
	[previous_season_total_minutes_played] [int] NULL,
	[previous_season_clean_sheets] [int] NULL,
	[previous_season_goals_conceded] [int] NULL,
	[previous_season_keeper_saves] [int] NULL,
	[transfer_success] [float] NULL,
	[average_skills] [float] NULL,
 CONSTRAINT [PK_PredictionResults] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[roles]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](450) NOT NULL,
	[created_at] [datetime2](7) NOT NULL,
	[updated_at] [datetime2](7) NULL,
 CONSTRAINT [pk_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[transfer_prices]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transfer_prices](
	[player_name] [varchar](250) NULL,
	[Age] [int] NULL,
	[club_involved] [varchar](250) NULL,
	[club_name] [varchar](250) NULL,
	[transfer_movement] [varchar](50) NULL,
	[year] [int] NULL,
	[fee] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[transfers]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transfers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[player_name] [nvarchar](max) NULL,
	[club_from] [nvarchar](max) NULL,
	[club_to] [nvarchar](max) NULL,
	[club_to_competition] [nvarchar](max) NULL,
	[club_to_player_valuations] [int] NULL,
	[club_to_average_player_valuations] [int] NULL,
	[is_played_in_bigger_competitions] [bit] NULL,
	[is_played_in_similar_competitions] [bit] NULL,
	[age] [int] NULL,
	[season] [int] NULL,
	[player_nationality] [nvarchar](max) NULL,
	[is_played_in_europe] [bit] NULL,
	[appearances_with_national_team] [int] NULL,
	[national_team_world_ranking] [int] NULL,
	[injury_rate] [int] NULL,
	[highest_market_value] [int] NULL,
	[current_market_value] [int] NULL,
	[teams_changed_during_career] [int] NULL,
	[last_year_appearances] [int] NULL,
	[number_of_locals_in_new_team] [int] NULL,
	[number_of_players_in_new_team_same_position] [int] NULL,
	[average_market_value_of_player_new_team_same_position] [int] NULL,
	[maximum_market_value_of_player_new_team_same_position] [int] NULL,
	[number_of_players_in_new_team_same_country] [int] NULL,
	[average_attendance_of_new_team] [int] NULL,
	[coach_nationality] [nvarchar](max) NULL,
	[is_coach_met_the_player_in_another_team_before] [bit] NULL,
	[coach_average_time_in_team] [float] NULL,
	[acceleration] [int] NULL,
	[aerial_ability] [int] NULL,
	[aggression] [int] NULL,
	[agility] [int] NULL,
	[anticipation] [int] NULL,
	[balance] [int] NULL,
	[bravery] [int] NULL,
	[command_of_area] [int] NULL,
	[communication] [int] NULL,
	[composure] [int] NULL,
	[concentration] [int] NULL,
	[corners] [int] NULL,
	[crossing] [int] NULL,
	[decisions] [int] NULL,
	[determination] [int] NULL,
	[dribbling] [int] NULL,
	[eccentricity] [int] NULL,
	[finishing] [int] NULL,
	[first_touch] [int] NULL,
	[flair] [int] NULL,
	[free_kick_taking] [int] NULL,
	[handling] [int] NULL,
	[heading] [int] NULL,
	[jumping_reach] [int] NULL,
	[kicking] [int] NULL,
	[leadership] [int] NULL,
	[long_shots] [int] NULL,
	[long_throws] [int] NULL,
	[marking] [int] NULL,
	[natural_fitness] [int] NULL,
	[off_the_ball] [int] NULL,
	[one_on_ones] [int] NULL,
	[pace] [int] NULL,
	[passing] [int] NULL,
	[penalty_taking] [int] NULL,
	[positioning] [int] NULL,
	[reflexes] [int] NULL,
	[ruching_out] [int] NULL,
	[stamina] [int] NULL,
	[strength] [int] NULL,
	[tackling] [int] NULL,
	[teamwork] [int] NULL,
	[technique] [int] NULL,
	[throwing] [int] NULL,
	[vision] [int] NULL,
	[work_rate] [int] NULL,
	[adaptation] [int] NULL,
	[ambition] [int] NULL,
	[consistency] [int] NULL,
	[resistant_to_stress] [int] NULL,
	[professional] [int] NULL,
	[goals] [int] NULL,
	[assists] [int] NULL,
	[total_minutes_played] [int] NULL,
	[previous_season_goals] [int] NULL,
	[previous_season_assists] [int] NULL,
	[previous_season_total_minutes_played] [int] NULL,
	[previous_season_clean_sheets] [int] NULL,
	[transfer_price_future] [int] NULL,
	[club_from_average_player_valuations] [int] NULL,
	[created_at] [datetime2](7) NULL,
	[updated_at] [datetime2](7) NULL,
	[player_position] [nvarchar](max) NULL,
	[clean_sheets] [int] NULL,
	[punching] [int] NULL,
	[average_skills] [float] NULL,
	[transfer_success] [float] NULL,
	[goals_conceded] [int] NULL,
	[previous_season_goals_conceded] [int] NULL,
	[keeper_saves] [int] NULL,
	[previous_season_keeper_saves] [int] NULL,
	[shots_on_target] [float] NULL,
	[clearances] [float] NULL,
	[completed_tacklings] [float] NULL,
	[completed_passes] [float] NULL,
	[aerials_won] [float] NULL,
	[is_update] [bit] NULL,
	[average_stats_defender] [float] NULL,
	[average_defender_skills] [float] NULL,
	[average_midfielder_skills] [float] NULL,
	[average_attacker_skills] [float] NULL,
 CONSTRAINT [PK_transfers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user_roles]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_roles](
	[user_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [pk_user_roles] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 1/19/2024 9:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[email] [nvarchar](450) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[remember_token] [nvarchar](max) NULL,
	[email_verified_at] [datetime2](7) NULL,
	[created_at] [datetime2](7) NOT NULL,
	[updated_at] [datetime2](7) NULL,
 CONSTRAINT [pk_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[appearances]  WITH CHECK ADD  CONSTRAINT [FK_appearances_clubs] FOREIGN KEY([club_id])
REFERENCES [dbo].[clubs] ([id])
GO
ALTER TABLE [dbo].[appearances] CHECK CONSTRAINT [FK_appearances_clubs]
GO
ALTER TABLE [dbo].[appearances]  WITH CHECK ADD  CONSTRAINT [FK_appearances_clubs1] FOREIGN KEY([player_current_club_id])
REFERENCES [dbo].[clubs] ([id])
GO
ALTER TABLE [dbo].[appearances] CHECK CONSTRAINT [FK_appearances_clubs1]
GO
ALTER TABLE [dbo].[appearances]  WITH CHECK ADD  CONSTRAINT [FK_appearances_competitions] FOREIGN KEY([competition_id])
REFERENCES [dbo].[competitions] ([id])
GO
ALTER TABLE [dbo].[appearances] CHECK CONSTRAINT [FK_appearances_competitions]
GO
ALTER TABLE [dbo].[appearances]  WITH CHECK ADD  CONSTRAINT [FK_appearances_games] FOREIGN KEY([game_id])
REFERENCES [dbo].[games] ([id])
GO
ALTER TABLE [dbo].[appearances] CHECK CONSTRAINT [FK_appearances_games]
GO
ALTER TABLE [dbo].[appearances]  WITH CHECK ADD  CONSTRAINT [FK_appearances_players] FOREIGN KEY([player_id])
REFERENCES [dbo].[players] ([id])
GO
ALTER TABLE [dbo].[appearances] CHECK CONSTRAINT [FK_appearances_players]
GO
ALTER TABLE [dbo].[club_games]  WITH CHECK ADD  CONSTRAINT [fk_club_games_clubs_club_id] FOREIGN KEY([club_id])
REFERENCES [dbo].[clubs] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[club_games] CHECK CONSTRAINT [fk_club_games_clubs_club_id]
GO
ALTER TABLE [dbo].[club_games]  WITH CHECK ADD  CONSTRAINT [fk_club_games_games_game_id] FOREIGN KEY([game_id])
REFERENCES [dbo].[games] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[club_games] CHECK CONSTRAINT [fk_club_games_games_game_id]
GO
ALTER TABLE [dbo].[clubs]  WITH CHECK ADD  CONSTRAINT [FK_clubs_competitions] FOREIGN KEY([domestic_competition_id])
REFERENCES [dbo].[competitions] ([id])
GO
ALTER TABLE [dbo].[clubs] CHECK CONSTRAINT [FK_clubs_competitions]
GO
ALTER TABLE [dbo].[game_events]  WITH CHECK ADD  CONSTRAINT [fk_game_events_clubs_club_id] FOREIGN KEY([club_id])
REFERENCES [dbo].[clubs] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[game_events] CHECK CONSTRAINT [fk_game_events_clubs_club_id]
GO
ALTER TABLE [dbo].[game_events]  WITH CHECK ADD  CONSTRAINT [fk_game_events_games_game_id] FOREIGN KEY([game_id])
REFERENCES [dbo].[games] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[game_events] CHECK CONSTRAINT [fk_game_events_games_game_id]
GO
ALTER TABLE [dbo].[game_events]  WITH CHECK ADD  CONSTRAINT [fk_game_events_players_player_id] FOREIGN KEY([player_id])
REFERENCES [dbo].[players] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[game_events] CHECK CONSTRAINT [fk_game_events_players_player_id]
GO
ALTER TABLE [dbo].[games]  WITH CHECK ADD  CONSTRAINT [FK_games_clubs] FOREIGN KEY([home_club_id])
REFERENCES [dbo].[clubs] ([id])
GO
ALTER TABLE [dbo].[games] CHECK CONSTRAINT [FK_games_clubs]
GO
ALTER TABLE [dbo].[games]  WITH CHECK ADD  CONSTRAINT [FK_games_clubs1] FOREIGN KEY([away_club_id])
REFERENCES [dbo].[clubs] ([id])
GO
ALTER TABLE [dbo].[games] CHECK CONSTRAINT [FK_games_clubs1]
GO
ALTER TABLE [dbo].[games]  WITH CHECK ADD  CONSTRAINT [FK_games_competitions] FOREIGN KEY([competition_id])
REFERENCES [dbo].[competitions] ([id])
GO
ALTER TABLE [dbo].[games] CHECK CONSTRAINT [FK_games_competitions]
GO
ALTER TABLE [dbo].[player_values]  WITH CHECK ADD  CONSTRAINT [FK_player_values_clubs] FOREIGN KEY([club_id])
REFERENCES [dbo].[clubs] ([id])
GO
ALTER TABLE [dbo].[player_values] CHECK CONSTRAINT [FK_player_values_clubs]
GO
ALTER TABLE [dbo].[player_values]  WITH CHECK ADD  CONSTRAINT [FK_player_values_competitions] FOREIGN KEY([player_club_domestic_competition_id])
REFERENCES [dbo].[competitions] ([id])
GO
ALTER TABLE [dbo].[player_values] CHECK CONSTRAINT [FK_player_values_competitions]
GO
ALTER TABLE [dbo].[player_values]  WITH CHECK ADD  CONSTRAINT [FK_player_values_players] FOREIGN KEY([player_id])
REFERENCES [dbo].[players] ([id])
GO
ALTER TABLE [dbo].[player_values] CHECK CONSTRAINT [FK_player_values_players]
GO
ALTER TABLE [dbo].[players]  WITH CHECK ADD  CONSTRAINT [FK_players_clubs] FOREIGN KEY([current_club_id])
REFERENCES [dbo].[clubs] ([id])
GO
ALTER TABLE [dbo].[players] CHECK CONSTRAINT [FK_players_clubs]
GO
ALTER TABLE [dbo].[user_roles]  WITH CHECK ADD  CONSTRAINT [fk_user_roles_roles_role_id] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[user_roles] CHECK CONSTRAINT [fk_user_roles_roles_role_id]
GO
ALTER TABLE [dbo].[user_roles]  WITH CHECK ADD  CONSTRAINT [fk_user_roles_users_user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[user_roles] CHECK CONSTRAINT [fk_user_roles_users_user_id]
GO
