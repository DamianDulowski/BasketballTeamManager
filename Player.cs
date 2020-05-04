using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTeamMeanger
{
    public class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Country { get; set; }
        public int Years { get; set; }
        public int Games { get; set; }
        public int MinutesPlayed { get; set; }
        public int FieldGoals { get; set; }
        public int FieldGoalsAttempts { get; set; }
        public int ThreePointGoals { get; set; }
        public int ThreePointGoalsAttempts { get; set; }
        public int FreeThrows { get; set; }
        public int FreeThrowsAttempts { get; set; }
        public int OffensiveRebounds { get; set; }
        public int TotalRebounds { get; set; }
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int Turnovers { get; set; }
        public int PersonalFauls { get; set; }
        public int Points { get; set; }
        public float MiuntesPerGame { get; set; }
        public float FieldGoalsPerGame { get; set; }
        public float FieldGoalsAttemptsPerGame { get; set; }
        public float ThreePointGoalsPerGame { get; set; }
        public float ThreePointGoalsAttemptsPerGame { get; set; }
        public float FreeThrowsPerGame { get; set; }
        public float FreeThrowsAttemptsPerGame { get; set; }
        public float OffensiveReboundsPerGame { get; set; }
        public float TotalReboundsPerGame { get; set; }
        public float AssistPerGame { get; set; }
        public float StealsPerGame { get; set; }
        public float BlocksPerGame { get; set; }
        public float TurnoversPerGame { get; set; }
        public float PersonalFaulsPerGame { get; set; }
        public float PointPerGame { get; set; }

        public Player(string name, string position, string country, int years, int games, int minutes, int fieldGoals, int fieldGoalsAttempts, int threePointFieldGoals,
            int threePointFieldGoalsAttempts, int freeThrows, int freeThrowsAttempts, int offReb, int totReb,
            int assists, int steals, int blocks, int turnovers, int personalFauls, int points)
        {
            this.Name = name;
            this.Position = position;
            this.Country = country;
            this.Years = years;
            this.Games = games;
            this.MinutesPlayed = minutes;
            this.FieldGoals = fieldGoals;
            this.FieldGoalsAttempts = fieldGoalsAttempts;
            this.ThreePointGoals = threePointFieldGoals;
            this.ThreePointGoalsAttempts = threePointFieldGoalsAttempts;
            this.FreeThrows = freeThrows;
            this.FreeThrowsAttempts = freeThrowsAttempts;
            this.OffensiveRebounds = offReb;
            this.TotalRebounds = totReb;
            this.Assists = assists;
            this.Steals = steals;
            this.Blocks = blocks;
            this.Turnovers = turnovers;
            this.PersonalFauls = personalFauls;
            this.Points = points;
            if (games == 0)
                games = 1;
            this.MiuntesPerGame = minutes / games;
            this.FieldGoalsPerGame = fieldGoals / games;
            this.FieldGoalsAttemptsPerGame = fieldGoalsAttempts / games;
            this.ThreePointGoalsPerGame = threePointFieldGoals / games;
            this.ThreePointGoalsAttemptsPerGame = threePointFieldGoalsAttempts / games;
            this.FreeThrowsPerGame = freeThrows / games;
            this.FreeThrowsAttemptsPerGame = freeThrowsAttempts / games;
            this.OffensiveReboundsPerGame = offReb / games;
            this.TotalReboundsPerGame = totReb / games;
            this.AssistPerGame = assists / games;
            this.StealsPerGame = steals / games;
            this.BlocksPerGame = blocks / games;
            this.TurnoversPerGame = turnovers / games;
            this.PersonalFaulsPerGame = personalFauls / games;
            this.PointPerGame = points / games;
        }

    }
}