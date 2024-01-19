using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Spark.Library.Logging;
using TransferBase.Application.Database;
using TransferBase.Application.Models;
using TransferBase.Application.Services.FixData;
using TransferBase.Application.Services.General;
using ILogger = Spark.Library.Logging.ILogger;

namespace TransferBase.Pages
{
    public partial class Index
    {
        [Inject]
        public ILogger Logger { get; set; } = default!;

        [Inject]
        public TransfersService TransfersService { get; set; } = default!;
        public List<PlayerSkill>? PlayerSkills = new List<PlayerSkill>();
        [Inject] public IDbContextFactory<DatabaseContext>? Factory { get; set; }

        protected override void OnInitialized()
        {
            Logger.Information($"Initialized at {DateTime.Now}");
            //using var db = Factory.CreateDbContext();
            //var developers = db.PlayerSkills.ToList();
            //PlayerSkills =  PlayerSkillsService.AllSkills();
        }

        //private void ButtonClicked()
        //{
        //    TransfersService.FetchTransfers();
        //}

    }
}