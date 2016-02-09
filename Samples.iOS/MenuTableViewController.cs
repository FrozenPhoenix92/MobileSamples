using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using UIKit;

namespace Samples.iOS
{
	partial class MenuTableViewController : UITableViewController
	{
        private readonly List<MainMenuRow> _items = new List<MainMenuRow> 
	    {
            new MainMenuRow { Id = "ListDemonstration", Text = "Демонстрация списка" },
            new MainMenuRow { Id = "ScratchTicketView", Text = "Демонстрация пользовательского компонента" },
            new MainMenuRow { Id = "Controls", Text = "Демонстрация стандартных компонентов" }
        };


	    public MenuTableViewController (IntPtr handle) : base (handle)
		{
		}


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.Source = new MenuTableSource(_items, this);
        }
	}
}
