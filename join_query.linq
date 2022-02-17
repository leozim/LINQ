<Query Kind="Program">
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

public static void Main()
{
	var categories = new List<Category>
	{
		new Category { Id = 1, Name = "Rock" },
		new Category { Id = 2, Name = "Reggae" },
		new Category { Id = 3, Name = "Rock progressivo" },
		new Category { Id = 4, Name = "Jazz" },
		new Category { Id = 5, Name = "Punk Rock" },
		new Category { Id = 6, Name = "Classica" },
	};
	
	var songs = new List<Song>
	{
		new Song { Id = 1, Name = "Numb", CategoryId = 1 },
		new Song { Id = 2, Name = "My Mind", CategoryId = 2 },
		new Song { Id = 3, Name = "Shine on Your Crazy Diamond", CategoryId = 3 },
	};
	
	var categoriesQueries = from c in categories 
						where c.Name.Contains("Rock") 
						select c;
	Console.WriteLine("-----------------------------------");
	Console.WriteLine("Rock Category");
	Console.WriteLine("-----------------------------------");
	foreach (var c in categoriesQueries)
	{
		Console.WriteLine($"Id: {c.Id}\tName: {c.Name}");
	}
	Console.WriteLine();
	
	var categoriesById = from c in categories
							where c.Id == 1
							select c;
	
	Console.WriteLine("-----------------------------------");
	Console.WriteLine("Category By Id 1");
	Console.WriteLine("-----------------------------------");
	foreach (var c in categoriesById)
	{
		Console.WriteLine($"Id: {c.Id}\tName: {c.Name}");
	}
	Console.WriteLine();
	
	var songsWithCategories = from s in songs
				join c in categories on s.CategoryId equals c.Id
				select new { s, c };
	
	Console.WriteLine("-----------------------------------");
	Console.WriteLine("Songs with Category");
	Console.WriteLine("-----------------------------------");
	foreach (var song in songsWithCategories)
	{
		Console.WriteLine("Id: {0}\tName: {1}\tCategory: {2}", song.s.Id, song.s.Name, song.c.Name);
	}
	
	var songsWithCategoriesByName = from s in songs
				join c in categories on s.CategoryId equals c.Id
				where c.Name.Contains("Reggae")
				select new { s, c };
	
	Console.WriteLine("-----------------------------------");
	Console.WriteLine("Songs with Category By Name");
	Console.WriteLine("-----------------------------------");
	foreach (var song in songsWithCategoriesByName)
	{
		Console.WriteLine("Id: {0}\tName: {1}\tCategory: {2}", song.s.Id, song.s.Name, song.c.Name);
	}
}

public class Category
{
	public int Id { get; set; }
	public string Name { get; set; }
}

public class Song
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int CategoryId { get; set; }
}