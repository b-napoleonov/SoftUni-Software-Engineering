using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (racerOne.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (racerTwo.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double racingOneBehaviorMultiplier = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            double chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingOneBehaviorMultiplier;
            double racingTwoBehaviorMultiplier = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            double chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingTwoBehaviorMultiplier;

            racerOne.Race();
            racerTwo.Race();

            string winner = chanceOfWinningRacerOne > chanceOfWinningRacerTwo ? racerOne.Username : racerTwo.Username;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);
        }
    }
}
