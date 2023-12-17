using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace MovieApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MovieDbContext())
            {
                db.Database.Migrate();

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. List Movies");
                    Console.WriteLine("2. Add Movie");
                    Console.WriteLine("3. Update Movie");
                    Console.WriteLine("4. Delete Movie");
                    Console.WriteLine("5. Search Movies");
                    Console.WriteLine("6. Add new User");
                    Console.WriteLine("7. Enter new movie Rating");
                    Console.WriteLine("8. List Top Rated Movie");
                    Console.WriteLine("9. Exit");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            ListMovies(db);
                            break;

                        case "2":
                            AddMovie(db);
                            break;

                        case "3":
                            UpdateMovie(db);
                            break;

                        case "4":
                            DeleteMovie(db);
                            break;

                        case "5":
                            SearchMovies(db);
                            break;

                        case "6":
                            AddUser(db);
                            break;

                        case "7":
                            EnterMovieRating(db);
                            break;

                        case "8":
                            ListTopRatedMovie(db);
                            break;

                        case "9":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
        }

        static void ListMovies(MovieDbContext db)
        {
            var movies = db.Movies.ToList();
            foreach (var movie in movies)
            {
                movie.Display();
            }
        }

        static void AddMovie(MovieDbContext db)
        {
            Console.WriteLine("Enter the title of the movie:");
            string title = Console.ReadLine();

            if (db.Movies.Any(m => m.Title.ToUpper() == title.ToUpper()))
            {
                Console.WriteLine("Movie with the same title already exists.");
                return;
            }

            Console.WriteLine("Enter the genres of the movie (comma-separated):");
            string genres = Console.ReadLine();

            var movie = new Movie
            {
                Title = title,
                Genres = genres
            };

            db.Movies.Add(movie);
            db.SaveChanges();

            Console.WriteLine("Movie added successfully.");
        }

        static void UpdateMovie(MovieDbContext db)
        {
            Console.WriteLine("Enter the title of the movie to update:");
            string title = Console.ReadLine();

            var movie = db.Movies.FirstOrDefault(m => m.Title.ToUpper() == title.ToUpper());

            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
                return;
            }

            Console.WriteLine($"Enter new title for {title}:");
            string newTitle = Console.ReadLine();

            Console.WriteLine($"Enter new genres for {title} (comma-separated):");
            string newGenres = Console.ReadLine();

            movie.Title = newTitle;
            movie.Genres = newGenres;

            db.SaveChanges();

            Console.WriteLine("Movie updated successfully.");
        }

        static void DeleteMovie(MovieDbContext db)
        {
            Console.WriteLine("Enter the title of the movie to delete:");
            string title = Console.ReadLine();

            var movie = db.Movies.FirstOrDefault(m => m.Title.ToUpper() == title.ToUpper());

            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
                return;
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            Console.WriteLine("Movie deleted successfully.");
        }

        static void SearchMovies(MovieDbContext db)
        {
            Console.WriteLine("Enter search term:");
            string searchTerm = Console.ReadLine();

            var movieResults = db.Movies.Where(m => m.Title.Contains(searchTerm)).ToList();

            Console.WriteLine("Search Results:");
            foreach (var movie in movieResults)
            {
                movie.Display();
            }
        }

        static void AddUser(MovieDbContext db)
        {
            Console.WriteLine("Enter the name of the user:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the age of the user:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the gender of the user:");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter the occupation of the user:");
            string occupationName = Console.ReadLine();

            Console.WriteLine("Enter the zip code of the user:");
            string zipCode = Console.ReadLine();

            var occupation = db.Occupations.FirstOrDefault(o => o.OccupationName == occupationName);
            if (occupation == null)
            {
                occupation = new Occupation { OccupationName = occupationName };
                db.Occupations.Add(occupation);
                db.SaveChanges();
            }

            var user = new User
            {
                Age = age,
                Gender = gender,
                OccupationName = occupationName, // Updated to use OccupationName
                ZipCode = zipCode
            };

            db.Users.Add(user);
            db.SaveChanges();

            Console.WriteLine("User added successfully.");
            Console.WriteLine($"Name: {name}, Age: {age}, Gender: {gender}, Occupation: {occupationName}, Zip Code: {zipCode}");
        }

        static void EnterMovieRating(MovieDbContext db)
        {
            Console.WriteLine("Enter the title of the movie to rate:");
            string movieTitle = Console.ReadLine();

            var movie = db.Movies.FirstOrDefault(m => m.Title.ToUpper() == movieTitle.ToUpper());

            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
                return;
            }

            Console.WriteLine("Enter the user's ID who is rating the movie:");
            int userId = int.Parse(Console.ReadLine());

            var user = db.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine("Enter the rating for the movie (1-10):");
            int rating = int.Parse(Console.ReadLine());

            var userMovie = new UserMovie
            {
                User = user,
                Movie = movie,
                Rating = rating,
                RatedAt = DateTimeOffset.Now.ToUnixTimeSeconds()
            };

            db.UserMovies.Add(userMovie);
            db.SaveChanges();

            Console.WriteLine("Rating added successfully.");
            Console.WriteLine($"Movie Title: {movie.Title}, Rated: {rating}/10 by User ID: {userId}");
        }

        static void ListTopRatedMovie(MovieDbContext db)
        {
            Console.WriteLine("Enter age bracket or occupation to list top-rated movie:");
            string criterion = Console.ReadLine();

            var topRatedMovie = db.UserMovies
                .Where(um => um.User.Age.ToString() == criterion || um.User.Occupation.OccupationName == criterion)
                .OrderByDescending(um => um.Rating)
                .ThenBy(um => um.Movie.Title)
                .FirstOrDefault();

            if (topRatedMovie != null)
            {
                Console.WriteLine("Top-Rated Movie:");
                Console.WriteLine($"Title: {topRatedMovie.Movie.Title}, Rating: {topRatedMovie.Rating}");
            }
            else
            {
                Console.WriteLine("No top-rated movie found for the specified criterion.");
            }
        }
    }
}