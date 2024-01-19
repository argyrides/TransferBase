using Microsoft.EntityFrameworkCore;
using MimeKit;
using MudBlazor;
using Org.BouncyCastle.Utilities;
using Sprache;
using System.Data;
using System.Security.Claims;
using System;
using TransferBase.Application.CustomModels;
using TransferBase.Application.Database;
using TransferBase.Application.Models;
using static MudBlazor.Colors;

namespace TransferBase.Application.Services.General
{
    public class PlayerSkillsService
    {
        private readonly DatabaseContext _db;


        public PlayerSkillsService(DatabaseContext db)
        {
            _db = db;
        }

        /* return all the skills of players for current season specified in parameter */
        public List<PlayerSkill> GetSkillsSeason(int season) 
        {
            return _db.PlayerSkills.Where(a => a.Season == season).ToList();
        }

        /* return all the skills of specific player for all seasons */
        public List<PlayerSkill> GetSkillsPreviousSeasons(int playerId)
        {
            return _db.PlayerSkills.Where(a => a.Season < 2021).Where( a => a.Id == playerId).ToList();
        }

        /* return all players skills for all seasons */
        public List<PlayerSkill> AllSkills()
        {
            return _db.PlayerSkills.ToList();
        }

        /* return player skill based the season and player uid */
        public PlayerSkill GetPlayerSkillByUid(int uid, int season)
        {
            if (uid <= 0 || season <= 0)
                return null;

            if (season < 2019)
                season = 2019;         

            return _db.PlayerSkills.Where(a => a.Id == uid && a.Season == season).FirstOrDefault()!;
        }

        /* return specific skills for specific player */
        public PlayerSkillMod GetPlayerSkills(int uid)
        {
            return _db.PlayerSkills!.Where(a => a.Id == uid).Select(a => new PlayerSkillMod
            {
                Acceleration = a.Acceleration,
                AerialAbility = a.AerialAbility,
                Aggression = a.Aggression,
                Agility = a.Agility,
                Anticipation = a.Anticipation,
                Balance = a.Balance,
                Bravery = a.Bravery,
                CommandOfArea = a.CommandOfArea,
                Communication = a.Communication,
                Composure = a.Composure,
                Concentration = a.Concentration,
                Corners = a.Corners,
                Crossing = a.Crossing,
                Decisions = a.Decisions,
                Determination = a.Determination,
                Dribbling = a.Dribbling,
                Eccentricity = a.Eccentricity,
                Finishing = a.Finishing,
                FirstTouch = a.FirstTouch,
                Flair = a.Flair,
                FreeKickTaking = a.FreeKickTaking,
                Handling = a.Handling,
                Heading = a.Heading,
                JumpingReach = a.JumpingReach,
                Kicking = a.Kicking,
                Leadership = a.Leadership,
                LongShots = a.LongShots,
                LongThrows = a.LongThrows,
                Marking = a.Marking,
                NaturalFitness = a.NaturalFitness,
                OffTheBall = a.OffTheBall,
                OneOnOnes = a.OneOnOnes,
                Pace = a.Pace,
                Passing = a.Passing,
                PenaltyTaking = a.PenaltyTaking,
                Positioning = a.Positioning,
                Punching = a.Punching,
                Reflexes = a.Reflexes,
                RuchingOut = a.RuchingOut,
                Stamina = a.Stamina,
                Strength = a.Strength,
                Tackling = a.Tackling,
                Teamwork = a.Teamwork,
                Technique = a.Technique,
                Throwing = a.Throwing,
                Vision = a.Vision,
                WorkRate = a.WorkRate
            })!.FirstOrDefault()!;
        }

        /* return specific skills for specific player async */
        public async Task<PlayerSkillMod> GetPlayerSkillsAsync(int uid)
        {            
            return await _db.PlayerSkills!.Where(a => a.Id == uid).Select(a => new PlayerSkillMod  {
                Acceleration = a.Acceleration,
                AerialAbility = a.AerialAbility,
                Aggression = a.Aggression,
                Agility = a.Agility,
                Anticipation = a.Anticipation,
                Balance = a.Balance,
                Bravery = a.Bravery,
                CommandOfArea = a.CommandOfArea,
                Communication = a.Communication,
                Composure = a.Composure,
                Concentration = a.Concentration,
                Corners = a.Corners,
                Crossing = a.Crossing,
                Decisions = a.Decisions,
                Determination = a.Determination,
                Dribbling = a.Dribbling,
                Eccentricity = a.Eccentricity,
                Finishing = a.Finishing,
                FirstTouch = a.FirstTouch,
                Flair = a.Flair,
                FreeKickTaking = a.FreeKickTaking,
                Handling = a.Handling,
                Heading = a.Heading,
                JumpingReach = a.JumpingReach,
                Kicking = a.Kicking,
                Leadership = a.Leadership,
                LongShots = a.LongShots,
                LongThrows = a.LongThrows,
                Marking = a.Marking,
                NaturalFitness = a.NaturalFitness,
                OffTheBall = a.OffTheBall,
                OneOnOnes = a.OneOnOnes,
                Pace = a.Pace,
                Passing = a.Passing,
                PenaltyTaking = a.PenaltyTaking,
                Positioning = a.Positioning,
                Punching = a.Punching,
                Reflexes = a.Reflexes,
                RuchingOut = a.RuchingOut,
                Stamina = a.Stamina,
                Strength = a.Strength,
                Tackling = a.Tackling,
                Teamwork = a.Teamwork,
                Technique = a.Technique,
                Throwing = a.Throwing,
                Vision = a.Vision,
                WorkRate = a.WorkRate
            })!.FirstOrDefaultAsync()!;
        }
    }
}
