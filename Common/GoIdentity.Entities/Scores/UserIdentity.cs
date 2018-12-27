using GoIdentity.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoIdentity.Entities.Scores
{
    public class UserIdentity
    {
        //profile properties
        public int UserId { get; set; }
        public string ProfilePicUrl { get; set; }
        public string UserName { get; set; }
        public int Rank { get; set; }
        public string Title { get; set; }
        public string Badge { get; set; }

        public decimal CurrentProfileScore => CategoryScores.Where(c => c.ScoreType.Contains("Current")).Sum(c => c.Score * c.CategoryWeightage);
        public decimal LastProfileScore => CategoryScores.Where(c => c.ScoreType.Contains("Last")).Sum(c => c.Score * c.CategoryWeightage);
        public List<vUserScore> CategoryScores { get; set; } = new List<vUserScore>();
        //setiment scores
        public decimal CurrentPositiveScore => CategoryScores.Where(c => c.ScoreType.Contains("Current")).Sum(c => _round(c.PositiveScore * c.CategoryWeightage));
        public decimal LastPositiveScore  => CategoryScores.Where(c => c.ScoreType.Contains("Last")).Sum(c => _round(c.PositiveScore * c.CategoryWeightage));
        public decimal CurrentNeutralScore => CategoryScores.Where(c => c.ScoreType.Contains("Current")).Sum(c => _round(c.NeutralScore * c.CategoryWeightage));
        public decimal LastNeutralScore => CategoryScores.Where(c => c.ScoreType.Contains("Last")).Sum(c => _round(c.NeutralScore * c.CategoryWeightage));
        public decimal CurrentNegativeScore => CategoryScores.Where(c => c.ScoreType.Contains("Current")).Sum(c => _round(c.NegativeScore * c.CategoryWeightage));
        public decimal LastNegativeScore => CategoryScores.Where(c => c.ScoreType.Contains("Last")).Sum(c => _round(c.NegativeScore * c.CategoryWeightage));
        private decimal _round(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
