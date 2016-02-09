using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Foundation;
using Samples.Shared.SQLite;
using UIKit;

namespace Samples.iOS
{
    public class ListTableSource : UITableViewSource
    {
        private readonly List<ListTableItemGroup> _items;
        private readonly UITableViewController _owner;


        public static string CellIdentifier = "TableCell";
        public static string CustomCellIdentifier = "CustomTableCell";
        

        public ListTableSource(List<ListTableItemGroup> items, UITableViewController owner)
        {
            _items = items;
            _owner = owner;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return _items.Count;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items[(int)section].Items.Count;
        }

        public override string[] SectionIndexTitles(UITableView tableView)
        {
            return _items.Select(elem => elem.Title).ToArray();
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return _items[(int)section].Title;
        }

        public override string TitleForFooter(UITableView tableView, nint section)
        {
            return _items[(int)section].Footer;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Section == 2)
            {
                var customCell = tableView.DequeueReusableCell(CustomCellIdentifier) as ListCustomVegeCell;
                var customItem = _items[indexPath.Section].Items[indexPath.Row];
                if (customCell == null)
                    customCell = new ListCustomVegeCell((NSString)CustomCellIdentifier);
                customCell.UpdateCell(customItem.Heading
                        , customItem.SubHeading
                        , UIImage.FromFile("Images/ListDemonstration/" + customItem.ImageName));
                return customCell;
            }

            var cell = tableView.DequeueReusableCell(CellIdentifier);
            var item = _items[indexPath.Section].Items[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(item.CellStyle, CellIdentifier);
            }
            else
            {
                cell.ImageView.Image = null;
            }

            cell.TextLabel.Text = item.Heading;

            if (!string.IsNullOrEmpty(item.SubHeading)
               && (item.CellStyle == UITableViewCellStyle.Subtitle
               || item.CellStyle == UITableViewCellStyle.Value1
               || item.CellStyle == UITableViewCellStyle.Value2))
            {
                if (cell.DetailTextLabel != null)
                    cell.DetailTextLabel.Text = item.SubHeading;
            }

            if (!string.IsNullOrEmpty(item.ImageName) && item.CellStyle != UITableViewCellStyle.Value2)
            {
                if (File.Exists("Images/ListDemonstration/" + item.ImageName))
                { cell.ImageView.Image = UIImage.FromFile("Images/ListDemonstration/" + item.ImageName); }
            }

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var okAlertController = UIAlertController.Create("Выбран элемент",
                _items[indexPath.Section].Items[indexPath.Row].Heading, UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            _owner.PresentViewController(okAlertController, true, null);

            tableView.DeselectRow(indexPath, true);
        }
    }
}
