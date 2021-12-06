// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		Performer performer;
		Song song;

		[SetUp]
		public void SetUo()
        {
			stage = new Stage();
			performer = new Performer("Pesho", "Petrov", 20);
			song = new Song("White Rabbit", new TimeSpan(0, 1, 34));
		}
		[Test]
	    public void AddPerformerThrowsExceptionWhenAgeIsLessThan18()
	    {
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Pesho", "Petrov", 16)));
		}

		[Test]
		public void AddPerformersWorksRight()
        {
			stage.AddPerformer(performer);

			Assert.AreEqual(1, stage.Performers.Count);
		}

		[Test]
		public void AddSOngThrowsExceptionWhenDurationIsLessThatMinute()
        {
			Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("White Rabbit", new TimeSpan(0, 0, 34))));
        }

		[TestCase(null)]
		public void AddSongToPerformerThrowsExceptionWhenNameIsNull(string name)
        {
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(name, "pesho"));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("White Rabbit", name));
		}

		[Test]
		public void AddSongToPerformerWorksRight()
        {
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("White Rabbit", "Pesho Petrov");

			Assert.AreEqual(1, performer.SongList.Count);
		}

		[Test]
		public void AddSongToPerformerReturnsCorrectString()
        {
			stage.AddPerformer(performer);
			stage.AddSong(song);

			Assert.AreEqual($"{song} will be performed by {performer}", stage.AddSongToPerformer("White Rabbit", "Pesho Petrov"));
		}

		[Test]
		public void PlayReturnsCorrectString()
        {
			var songsCount = stage.Performers.Sum(p => p.SongList.Count());

			Assert.AreEqual($"{stage.Performers.Count} performers played {songsCount} songs", stage.Play());
        }
	}
}