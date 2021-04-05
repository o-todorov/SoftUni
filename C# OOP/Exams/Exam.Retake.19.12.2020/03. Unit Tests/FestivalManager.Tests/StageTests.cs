// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {

		private List<Song> songs;
		private List<Performer> performers;
		private Stage stage;
		private Performer	performer;
		private Song		song;
		[SetUp]
		public void SetUp()
		{
			stage = new Stage();
			performer = new Performer("Test", "Testov", 45);
			song = new Song("Hello", new TimeSpan(0, 10, 55));
		}

	[Test]
	    public void AddPerformer_Throws_WhenArgIsNull()
	    {
			Assert.That(() => stage.AddPerformer(null), Throws.ArgumentNullException);
		}

		[Test]
	    public void AddPerformer_Throws_WhenYoungerThan18()
	    {
			var performer = new Performer("Ivan", "Ivanov", 16);
			Assert.That(() => stage.AddPerformer(performer), Throws.ArgumentException);
		}

		[Test]
	    public void AddPerformer_PerformerShoultExist()
	    {
			//var performer = new Performer("Ivan", "Ivanov", 23);
			stage.AddPerformer(performer);
			var found = stage.Performers.FirstOrDefault(p => p == performer);
			Assert.That(found, Is.EqualTo(performer));
		}

		[Test]
	    public void AddSong_Throws_WhenArgIsNull()
	    {
			Assert.That(() => stage.AddSong(null), Throws.ArgumentNullException);
		}

		[Test]
	    public void AddSong_Throws_WhenDurationIsLess()
	    {
            var song = new Song("Hello", new TimeSpan(0, 0, 55));

            Assert.That(() => stage.AddSong(song), Throws.ArgumentException);
		}

		[Test]
		public void AddSong_SongShoultExist()
		{
			//var performer = new Performer("Ivan", "Ivanov", 23);
			//var song = new Song("Hello", new TimeSpan(0, 10, 55));
			stage.AddSong(song);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer(song.Name, performer.FullName);
			var found = performer.SongList.FirstOrDefault(s => s.Equals(song));

			Assert.That(found, Is.EqualTo(song));
		}

		[Test]
		[TestCase("MySong", null)]
		[TestCase(null, "Ivan")]
		public void AddSongToPerformer_Throws_IfNullArg(string songname, string perfname)
		{
			var ex = Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(songname, perfname));
		}

		[Test]
		public void AddSongToPerformer_ReturnsRightMessageWhenSuccessfull()
		{
			//var performer = new Performer("Ivan", "Ivanov", 23);
			//var song = new Song("Hello", new TimeSpan(0, 10, 55));
			stage.AddSong(song);
			stage.AddPerformer(performer);
			
			var ret = stage.AddSongToPerformer(song.Name, performer.FullName);
			var expected = $"{song} will be performed by {performer}";

			Assert.That(ret, Is.EqualTo(expected));
		}

		[Test]
		public void Play_ReturnsRightMessageWhenSuccessfull()
		{
			//var performer = new Performer("Ivan", "Ivanov", 23);
			//var song = new Song("Hello", new TimeSpan(0, 10, 55));
			stage.AddSong(song);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer(song.Name, performer.FullName);

			var ret = stage.Play();
			var expected = $"{1} performers played {1} songs";

			Assert.That(ret, Is.EqualTo(expected));
		}

		[Test]
		[TestCase("Petyr", "Hello", "There is no performer with this name.")]
		[TestCase("Ivan Ivanov", "UnknownSong", "There is no song with this name.")]
		public void GetPerformer_Throws_IfArgDoesNotExist(string perfName, string songName, string expected)
		{
			var performer	= new Performer("Ivan", "Ivanov", 23);
			var song		= new Song("Hello", new TimeSpan(0, 10, 55));
			stage.AddSong(song);
			stage.AddPerformer(performer);

			var ex = Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(songName, perfName));
			Assert.That(ex.Message, Is.EqualTo(expected));
		}





	}
}