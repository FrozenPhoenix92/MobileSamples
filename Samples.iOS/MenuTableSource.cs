using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace Samples.iOS
{
    public class MenuTableSource : UITableViewSource
    {
        private readonly IList<MainMenuRow> _items;
        private readonly UIViewController _owner;

        public static string CellIdentifier = "TableCell";

        public MenuTableSource(IList<MainMenuRow> items, UIViewController owner)
        {
            _items = items;
            _owner = owner;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier);
            var item = _items[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            cell.TextLabel.Text = item.Text;
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIViewController nextController = null;
            switch (_items[indexPath.Row].Id)
            {
                case "ListDemonstration":
                    nextController =
                        _owner.Storyboard.InstantiateViewController("ListTableViewController") as
                            ListTableViewController;
                    break;
                case "ScratchTicketView":
                    nextController =
                        _owner.Storyboard.InstantiateViewController("ScratchTicketViewController") as
                            ScratchTicketViewController;
                    break;
                case "Controls":
                    nextController =
                        _owner.Storyboard.InstantiateViewController("ControlsViewController") as
                            ControlsViewController;
                    break;
            }
            if (nextController != null)
                _owner.NavigationController.PushViewController(nextController, true);

            tableView.DeselectRow(indexPath, true);
        }
    }
}
