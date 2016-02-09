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
        /// ��������� ������ � ������ � ����������� ��� ������� ���.
        /// </summary>
	    private void InitTableView()
	    {
            // ������� ���
            TableView.SeparatorColor = UIColor.Black;
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            // ������ �������� �������
            /*TableView.SeparatorEffect =
                UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);*/
            // ������ ��������� �������
            /*var effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
            TableView.SeparatorEffect = UIVibrancyEffect.FromBlurEffect(effect);
            TableView.SeparatorInset.InsetRect(new CGRect(4, 4, 150, 2));*/

            //�������� ������
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
                    Footer = wordsOfSection.Count + " ���������",
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
            #region ������ 1, 2
            /*var sections = new List<Section>
	        {
	            new Section { Name = "������ 1" },
                new Section { Name = "������ 2" }
	        };
	        var words = new List<Word>
	        {
	            new Word
	            {
	                SectionId = 1,
                    Value = "��������",
                    SubHeading = "������ �������",
                    ImageName = "Bulbs.jpg"
	            },
                new Word
                {
                    SectionId = 1,
                    Value = "��������� �����",
                    SubHeading = "��� �� ������������",
                    ImageName = "Flower Buds.jpg"
                },
                new Word
                {
                    SectionId = 1,
                    Value = "������",
                    SubHeading = "������� � �������",
                    ImageName = "Fruits.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "����",
                    SubHeading = "�������� ����",
                    ImageName = "Legumes.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "������",
                    SubHeading = "����� ������� ����",
                    ImageName = "Tubers.jpg"
                },
                new Word
                {
                    SectionId = 2,
                    Value = "�����",
                    SubHeading = "������ �� �����",
                    ImageName = "Vegetables.jpg"
                }
            };*/
            #endregion

            #region ������ 3
            /*var sections = new List<Section>
            {
                new Section { Name = "������ 3" }
            };
            var words = new List<Word>
            {
                new Word
                {
                    SectionId = 9,
                    Value = "��������",
                    SubHeading = "������ �������",
                    ImageName = "Bulbs.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "��������� �����",
                    SubHeading = "��� �� ������������",
                    ImageName = "Flower Buds.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "������",
                    SubHeading = "������� � �������",
                    ImageName = "Fruits.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "����",
                    SubHeading = "�������� ����",
                    ImageName = "Legumes.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "������",
                    SubHeading = "����� ������� ����",
                    ImageName = "Tubers.jpg"
                },
                new Word
                {
                    SectionId = 9,
                    Value = "�����",
                    SubHeading = "������ �� �����",
                    ImageName = "Vegetables.jpg"
                }
            };*/
            #endregion

            #region ������ 4
            var sections = new List<Section>
            {
                new Section { Name = "������ 4" }
            };
	        var words = new List<Word>();
	        for (var index = 1; index <= 50; index++)
	        {
	            var word = new Word
	            {
	                SectionId = 10,
	                Value = "����� �" + index,
	                SubHeading = "������������ �" + index
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
