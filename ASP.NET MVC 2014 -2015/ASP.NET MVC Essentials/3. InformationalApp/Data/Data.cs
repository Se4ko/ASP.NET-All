using System;
using System.Collections.Generic;

namespace _3.InformationalApp.Data
{
    public static class Data
    {
        public static List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>
            {
                new Book()
                {
                    Id = 1,
                    Title = "Don Quixote",
                    Author = "Miguel De Cervantes",
                    Description = "The story of the gentle knight and his servant Sancho Panza has entranced readers for centuries."
                },
                new Book()
                {
                    Id = 2,
                    Title = "Pilgrim's Progress",
                    Author = "John Bunyan",
                    Description = "The one with the Slough of Despond and Vanity Fair."
                },
                new Book()
                {
                    Id = 3,
                    Title = "Robinson Crusoe",
                    Author = "Daniel Defoe",
                    Description = "The first English novel."
                },
                new Book()
                {
                    Id = 4,
                    Title = "Gulliver's Travels",
                    Author = "Jonathan Swift",
                    Description = "A wonderful satire that still works for all ages, despite the savagery of Swift's vision."
                },
                new Book()
                {
                    Id = 5,
                    Title = "Frankenstein",
                    Author = "Mary Shelley",
                    Description = "Inspired by spending too much time with Shelley and Byron."
                }
            };

            return books;
        }

        public static List<Album> GetAllAlbums()
        {
            List<Album> albums = new List<Album>
            {
                new Album()
                {
                    Id = 1,
                    Title = "Rocks",
                    Artist = "Aerosmith",
                    Year = 1976
                },
                new Album()
                {
                    Id = 2,
                    Title = "Revolver",
                    Artist = "The Beatles",
                    Year = 1966
                },
                new Album()
                {
                    Id = 3,
                    Title = "Pink Floyd",
                    Artist = "The Dark Side of the Moon",
                    Year = 1973
                },
                new Album()
                {
                    Id = 4,
                    Title = "Guns n' Roses",
                    Artist = "Appetite for Destruction",
                    Year = 1987
                },
                 new Album()
                {
                    Id = 5,
                    Title = "The Rolling Stones",
                    Artist = "Let It Bleed",
                    Year = 1969
                }

            };

            return albums;
        }

        public static List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie  
                {
                    Id = 1,
                    Title = "Avatar",
                    Director = "Jon Landau",
                    Description = "Jake Sully (Sam Worthington), a paraplegic Marine, is offered the opportunity to travel to Pandora, a distant planet that Humans are mining for precious minerals."
                                + "Once on Pandora Jake is told that the marine objective on the planet is to relocate the local indigenous population, the Na'vi, tall blue cat-like creatures, as their"
                                +  "villiage rests on the richest source of minerals. Jake learns that he is to inflitrate the Na'vi by having his conscious projected into an Avatar - a Na'vi/Human hybrid "
                                + "grown in a lab using his DNA. If he completes his mission, the scientists will give him back his legs.",
                    Year = 2009
                },
                new Movie  
                {
                    Id = 2,
                    Title = "Pretty Woman",
                    Director = "Garry Marshall",
                    Description = "A man in a legal but hurtful business needs an escort for some social events, and hires a beautiful prostitute he meets... only to fall in love.",
                    Year = 1990
                },
                new Movie  
                {
                    Id = 3,
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    Year = 1972
                },
                new Movie  
                {
                    Id = 4,
                    Title = "The Matrix",
                    Director = "Andy Wachowski, Lana Wachowski",
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    Year = 1999
                },
                new Movie  
                {
                    Id = 5,
                    Title = "Psycho",
                    Director = "Alfred Hitchcock",
                    Description = "A Phoenix secretary steals $40,000 from her employer's client, goes on the run and checks into a remote motel run by a young man under the domination of his mother.",
                    Year = 1960
                },
            };

            return movies;
        }
    }
}