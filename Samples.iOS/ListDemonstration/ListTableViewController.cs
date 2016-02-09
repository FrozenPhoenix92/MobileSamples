using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CoreGraphics;
using Foundation;
using Samples.Shared.SQLite;
using UIKit;

namespace Samples.iOS
{
	partial class ListTableViewController : UITableViewController
	{
	    private UnitOfWork _unitOfWork;

	    private const string DbName = "database.db3";


        public ListTableViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            InitList();
        }


	    private void InitList()
	    {
	        _unitOfWork = new UnitOfWork(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), GetDatabasePath(DbName));
            //FillDatabase();
	        InitTableView();
	    }

        /// <summary>
        /// Загружает данные в список и настраивает его внешний вид.
        /// </summary>
	    private void InitTableView()
	    {
            // Внешний вид
            TableView.SeparatorColor = UIColor.Black;
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            // Эффект размытия границы
            /*TableView.SeparatorEffect =
                UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);*/
            // Эффект резонанса границы
            /*var effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
            TableView.SeparatorEffect = UIVibrancyEffect.FromBlurEffect(effect);
            TableView.SeparatorInset.InsetRect(new CGRect(4, 4, 150, 2));*/

            //Загрузка данных
            var sections = _unitOfWork.Sections.GetAll();
            var words = _unitOfWork.Words.GetAll();
            TableView.Source = new ListTableSource(ConvertData(sections, words), this);
        }

	    private string GetDatabasePath(string databaseName)
	    {
	        var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
	        return Path.Combine(folder, databaseName);
	    }

	    private List<ListTableItemGroup> ConvertData(IEnumerable<Section> sections,
	        IEnumerable<Word> words)
	    {
	        var result = new List<ListTableItemGroup>();
            foreach (var section in sections)
            {
                var wordsOfSection = words.Where(elem => elem.SectionId == section.Id).ToList();
                var listTableItemGroup = new ListTableItemGroup
                {
                    Id = Convert.ToInt32(section.Id),
                    Title = Convert.ToString(section.Name),
                    Footer = wordsOfSection.Count + " элементов",
                    Items = wordsOfSection.Select(elem => new ListTableItem
                    {
                        Id = Convert.ToInt32(elem.Id),
                        GroupId = Convert.ToInt32(elem.SectionId),
                        Heading = Convert.ToString(elem.Value),
                        CellStyle = UITableViewCellStyle.Subtitle,
                        SubHeading = Convert.ToString(elem.SubHeading),
                        ImageName = Convert.ToString(elem.ImageName)
                    }).ToList()
                };
                result.Add(listTableItemGroup);
            }
	        return result;
	    }

	    private void FillDatabase()
	    {
            #region Секция 1, 2
            /*var sections = new List<Section>
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
            };*/
            #endregion

            #region Секция 3
            /*var sections = new List<Section>
            {
                new Section { Name = "Секция 3" }
            };
            var words = new List<Word>
            {
                new Word
                {
                    SectionId = 9,
                    Value = "Луковицы",
                    SubHeading = "Будешь плакать",
                    ImageName = "Bulbs.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "Цветочные почки",
                    SubHeading = "Ещё не распустились",
                    ImageName = "Flower Buds.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "Фрукты",
                    SubHeading = "Сладкие и вкусные",
                    ImageName = "Fruits.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "Бобы",
                    SubHeading = "Ненавижу бобы",
                    ImageName = "Legumes.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "Клубни",
                    SubHeading = "Можно сделать борщ",
                    ImageName = "Tubers.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "Овощи",
                    SubHeading = "Пустим на салат",
                    ImageName = "Vegetables.jpg"
                }
            };*/
            #endregion

            #region Секция 4
            var sections = new List<Section>
            {
                new Section { Name = "Секция 4" }
            };
	        var words = new List<Word>();
	        for (var index = 1; index <= 50; index++)
	        {
	            var word = new Word
	            {
	                SectionId = 10,
	                Value = "Слово №" + index,
	                SubHeading = "Подзаголовок №" + index
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
