﻿using GestAssoc.Modules.GestionAdhesions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionAdhesions.Views
{
	/// <summary>
	/// Logique d'interaction pour FormulaireAdherentView.xaml
	/// </summary>
	public partial class FormulaireAdherentView : UserControl, INavigationAware, IRegionMemberLifetime
	{
		public FormulaireAdherentView() {
			InitializeComponent();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) {
			return false;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) {
			
		}

		public void OnNavigatedTo(NavigationContext navigationContext) {
			var itemId = navigationContext.Parameters["Param"] ?? string.Empty;
			var parseItemId = Guid.Empty;
			Guid.TryParse(itemId.ToString(), out parseItemId);

			this.DataContext = new FormulaireAdherentViewModel(parseItemId);
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
