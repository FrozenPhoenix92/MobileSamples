using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Samples.Shared.SQLite;

using Environment = System.Environment;

namespace Samples.Droid.ListDemonstration
{
    [Activity(Label = "Демонстрация списка", ParentActivity = typeof(MainActivity))]
    public class ListDemonstrationActivity : ListActivity
    {
        private UnitOfWork _unitOfWork;
        private const string DbName = "database.db3";
        private List<ListItem> _allItems;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Init();
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var t = _allItems[position];
            Toast.MakeText(this, t.Value, ToastLength.Short).Show();
        }

        private void Init()
        {
            /*var alert = new AlertDialog.Builder(this);
            var directoryInfo = new DirectoryInfo("storage/emulated/0");
            var fileInfo = new FileInfo(GetDatabaseFullPath("test.txt"));
            fileInfo.Create();
            var files = directoryInfo.GetDirectories().Select(elem => elem.FullName).Aggregate("", (cur, next) => cur + "\n" + next)
                + directoryInfo.GetFiles().Select(elem => elem.FullName).Aggregate("", (cur, next) => cur + "\n" + next);           
            alert.SetMessage(files);
            //alert.SetMessage(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath);
            alert.SetPositiveButton("OK", (x, y) => {});
            alert.Show();*/
            //ListView.FastScrollEnabled = true;
            if (!File.Exists(GetDatabaseFullPath(DbName)))
            {
                _unitOfWork = new UnitOfWork(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(),
                    GetDatabaseFullPath(DbName));
                FillDatabase();
            }
            else
            {
                _unitOfWork = new UnitOfWork(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(),
                    GetDatabaseFullPath(DbName));
            }
            var groupedItems = Convert(_unitOfWork.Sections.GetAll(), _unitOfWork.Words.GetAll()).ToList();
            _allItems = groupedItems.Aggregate(new List<ListItem>(), (cur, next) => cur.Concat(next.Items).ToList());
            ListAdapter = new ListAdapter(groupedItems, this);
        }

        private IEnumerable<ListItemGroup> Convert(IEnumerable<Section> sections, IEnumerable<Word> words)
        {
            return (from section in sections
                let wordsOfSection = words.Where(elem => elem.SectionId == section.Id).ToList()
                select new ListItemGroup
                {
                    Id = section.Id,
                    Title = section.Name,
                    Items = wordsOfSection.Select(elem => new ListItem
                    {
                        Id = elem.Id,
                        GroupId = elem.SectionId,
                        Value = elem.Value,
                        SubHeading = elem.SubHeading,
                        ImageResourceId = GetImageResourceId(elem.ImageName)
                    }).ToList()
                }).ToList();
        }

        private int GetImageResourceId(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
                return -1;
            if (imageName.StartsWith("Bulbs"))
                return Resource.Drawable.Bulbs;
            if (imageName.StartsWith("Flower Buds"))
                return Resource.Drawable.FlowerBuds;
            if (imageName.StartsWith("Fruits"))
                return Resource.Drawable.Fruits;
            if (imageName.StartsWith("Legumes"))
                return Resource.Drawable.Legumes;
            if (imageName.StartsWith("Tubers"))
                return Resource.Drawable.Tubers;
            if (imageName.StartsWith("Vegetables"))
                return Resource.Drawable.Vegetables;
            return -1;
        }

        private string GetRandomImageName()
        {
            var random = new Random();
            switch (random.Next(1, 6))
            {
                case 1:
                    return "Bulbs";
                case 2:
                    return "Flower Buds";
                case 3:
                    return "Fruits";
                case 4:
                    return "Legumes";
                case 5:
                    return "Tubers";
                case 6:
                    return "Vegetables";
            }
            return "";
        }

        private string GetDatabaseFullPath(string databaseName)
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                databaseName);
            var result = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath,
                "Android",
                "data",
                ApplicationContext.PackageName,
                "files",
                databaseName);
            return result;
        }

        private void FillDatabase()
        {
            #region Секция 1, 2
            var sections = new List<Section>
	        {
	            new Section { Name = "Секция 1" },
                new Section { Name = "Секция 2" }
	        };
	        var words = new List<Word>
	        {
	            new Word
	            {
	                SectionId = 1,
                    Value = "Луковицы",
                    SubHeading = "Будешь плакать",
                    ImageName = "Bulbs.jpg"
	            },
                new Word
                {
                    SectionId = 1,
                    Value = "Цветочные почки",
                    SubHeading = "Ещё не распустились",
                    ImageName = "Flower Buds.jpg"
                },
                new Word
                {
                    SectionId = 1,
                    Value = "Фрукты",
                    SubHeading = "Сладкие и вкусные",
                    ImageName = "Fruits.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "Бобы",
                    SubHeading = "Ненавижу бобы",
                    ImageName = "Legumes.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "Клубни",
                    SubHeading = "Можно сделать борщ",
                    ImageName = "Tubers.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "Овощи",
                    SubHeading = "Пустим на салат",
                    ImageName = "Vegetables.jpg"
                }
            };
            #endregion

            #region Секция 3
            sections.AddRange(new List<Section>
            {
                new Section { Name = "Секция 3" }
            });
            words.AddRange(new List<Word>
            {
                new Word
                {
                    SectionId = 3,
                    Value = "Луковицы",
                    SubHeading = "Будешь плакать",
                    ImageName = "Bulbs.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Цветочные почки",
                    SubHeading = "Ещё не распустились",
                    ImageName = "Flower Buds.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Фрукты",
                    SubHeading = "Сладкие и вкусные",
                    ImageName = "Fruits.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Бобы",
                    SubHeading = "Ненавижу бобы",
                    ImageName = "Legumes.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Клубни",
                    SubHeading = "Можно сделать борщ",
                    ImageName = "Tubers.jpg"
                },
                new Word
                {
                    SectionId = 3,
                    Value = "Овощи",
                    SubHeading = "Пустим на салат",
                    ImageName = "Vegetables.jpg"
                }
            });
            #endregion

            #region Секция 4
            sections.AddRange(new List<Section>
            {
                new Section { Name = "Секция 4" }
            });
            for (var index = 1; index <= 50; index++)
            {
                var word = new Word
                {
                    SectionId = 4,
                    Value = "Слово №" + index,
                    SubHeading = "Подзаголовок №" + index,
                    ImageName = GetRandomImageName()
                };
                words.Add(word);
            }
            #endregion

            #region Секция 5
            sections.AddRange(new List<Section>
            {
                new Section { Name = "Секция 5" }
            });
            for (var index = 1; index <= 150; index++)
            {
                var word = new Word
                {
                    SectionId = 4,
                    Value = "Слово №" + index,
                    SubHeading = "Подзаголовок №" + index,
                    ImageName = GetRandomImageName()
                };
                words.Add(word);
            }
            #endregion

            foreach (var section in sections)
            {
                _unitOfWork.Sections.Create(section);
            }
            foreach (var word in words)
            {
                _unitOfWork.Words.Create(word);
            }
        }
    }
}