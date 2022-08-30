using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spotiflixx
{
    internal class Gui
    {
        Data data = new Data();
        //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string path = @"C:\Users\celyn\source\repos\Spotiflixx\SaveData.txt";


        public Gui()
        {
            //data.MovieList = new();
            data.MovieList.Add(new Movie() { WWW = @"https.\\netflix.com/rambo3.mp4", Title = "Rambo III", Genre = "Action", ReleaseDate = new DateTime(1988 - 5 - 25), Length = new DateTime(1, 1, 1, 1, 42, 0) });
            while (true)
            {
                Menu();
            }
        
        
        }

        //MAIN MENU
        public void Menu()
        {
            Console.WriteLine("MENU\n1-Movies\n2-Series\n3-Music\n4-Save\n5-Load");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Console.Clear();
                    MovieMenu();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    SeriesMenu();
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    Music();
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Console.Clear();
                    SaveData();
                    break;


                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    Console.Clear();
                    LoadData();
                    break;

                default:
                    break;

            }


        }

    
        #region SAVE AND LOAD

        private void SaveData()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);
            Console.WriteLine("File saved successfully at "+ path);

        }
        private void LoadData()
        {
            string json= File.ReadAllText(path);
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
            Console.WriteLine("File loaded succesfully from " + path);
        }
        #endregion

        #region MOVIE
        private void MovieMenu()
        {
            Console.WriteLine("MENU\n1-Show movie list\n2-Search Movie\n3-Add Movie");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowMovieList();
                    break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Console.Clear();
                    SearchMovie();
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.Clear();
                    AddMovie();
                    break;
                default:
                    break;



            }

        }

        private void AddMovie()
        {
            Movie movie= new Movie();
            movie.Title = GetString("Title: ");
            movie.Length = GetLength();
            movie.Genre = GetString("Genre: ");
            movie.ReleaseDate = GetReleaseDate();
            movie.WWW = GetString("WWW: ");


            ShowMovie(movie);
            Console.WriteLine("Confirm adding to list (N/Y)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.MovieList.Add(movie);
            
        }
        private void SearchMovie()
        {
            Console.WriteLine("Search: ");
            string? search = Console.ReadLine();
            foreach (Movie movie in data.MovieList)
            {
                if (search!=null)
                {
                    if (movie.Title.Contains(search) || movie.Genre.Contains(search))
                        ShowMovie(movie);
                }
            }
        }
        private void ShowMovie(Movie m)
        {
            Console.WriteLine($"{m.Title} {m.GetLength} {m.Genre} {m.ReleaseDate} {m.WWW}");
        }
        private void ShowMovieList()
        {
            foreach (Movie m in data.MovieList)
            {
                ShowMovie(m);
            }
        }

        #endregion

        #region DateTime
        private DateTime GetLength()
        {
            DateTime to;
            do
            {
                Console.WriteLine("Length(hh:mm:ss): ");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out to));
            return to;
        }

        private DateTime GetReleaseDate()
        {
            DateTime dateOnly;
            do
            {
                Console.WriteLine("Release Date (dd/mm/yyyy): ");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out dateOnly));
            return dateOnly;
        }
        #endregion

        #region STRING OG INT
        private string GetString(string type)
        {
            string? input;
            do
            {
                Console.WriteLine(type);
                input = Console.ReadLine();
                
            }
            while (input == null || input == "");
            return input;
        }

        private int GetInt (string request)
        {
            int result;
            do
            {
                Console.WriteLine(request);


            }
            while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }
        #endregion

        #region SERIES
        private void SeriesMenu()
        {
            Console.WriteLine("MENU\n1-Show series list\n2-Search Series\n3-Add Series");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowSeries();
                    break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchSeries();
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddSeries();
                    break;
                default:
                    break;

            }

          
    }
        private void AddSeries()
        {
            Series series = new Series();
            series.Title = GetString("Title: ");
            series.Title = Console.ReadLine();
            series.Genre = GetString("Genre: ");
            series.ReleaseDate = GetReleaseDate();
            series.WWW = GetString("WWW: ");


            ShowSeries(series);
            Console.WriteLine("Confirm adding to list (N/Y)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.SeriesList.Add(series);

            Console.WriteLine("Do you want to add episode to the series?");

        }

        private void AddEpisode(Series series)
        {
            Episode episode = new Episode();
            episode.Title = GetString("Title: ");
            episode.Title = Console.ReadLine();
            episode.RelaseDate = GetReleaseDate();
            episode.Season = GetInt("Season: ");
            episode.Season =int.Parse(Console.ReadLine());
            episode.EpisodeNum = GetInt("Episode number: ");
            episode.EpisodeNum = int.Parse(Console.ReadLine());
            episode.Length = GetLength();

           
            Console.WriteLine("Add episode? (N/Y)");
            if (Console.ReadKey().Key == ConsoleKey.Y) series.EpisodesList.Add(episode);
        }


        private void SearchSeries()
        {
            Console.WriteLine("Search: ");
            string? search = Console.ReadLine();
            foreach (Series series in data.SeriesList)
            {
                if (search != null)
                {
                    if (series.Title.Contains(search) || series.Genre.Contains(search))
                        ShowSeries(series);
                }
            }
        }

        private void ShowSeries(Series s)
        {
            Console.WriteLine($"{s.Title} {s.Genre} {s.ReleaseDate} {s.WWW}");
        }
        private void ShowSeries()
        {
            foreach (Series s in data.SeriesList)
            {
                ShowSeries(s);
            }
        }
        #endregion



        private void Music()
        {
            Console.WriteLine("MENU\n1-Add Album \n2-Search Album \n3-Show Album list");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    AddAlbum();
                    break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchAlbum();
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    ShowMusic();
                    break;
                default:
                    break;

            }
        }

        private void AddAlbum()
            {
                Console.Clear();
                Music music = new Music();
                music.Album = GetString("Album: ");
                Console.WriteLine();
                music.Title = GetString("Title: ");
                Console.WriteLine();
                music.ReleaseDate = GetReleaseDate();
               

            ShowMusic(music);
          
            Console.WriteLine("Confirm adding to list (N/Y)");

            if (Console.ReadKey().Key == ConsoleKey.Y) data.AlbumList.Add(music);


        }


        private void SearchAlbum()
        {
            Console.Clear();
            Console.WriteLine("Search: ");
            string? search = Console.ReadLine();
            foreach (Music music in data.AlbumList)
            {
                if (search != null)
                {
                    if (music.Title.Contains(search) || music.Album.Contains(search))
                        ShowMusic(music);
                }

            }

        }

        private void ShowMusic(Music music)
        {
            
            Console.WriteLine($"{music.Album}{music.Title} {music.ReleaseDate}");
        }
        private void ShowMusic()
        {
            foreach (Music music in data.AlbumList)
            {
                ShowMusic(music);
            }
        }



    }
}




