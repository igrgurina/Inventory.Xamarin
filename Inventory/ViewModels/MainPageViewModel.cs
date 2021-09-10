using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory.Enumerations;
using Inventory.Models;
using Inventory.Services;
using Prism.Navigation;
using Syncfusion.DataSource.Extensions;
using Xamarin.Forms;

namespace Inventory.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Fields
        private bool _displayPopup;
        private Machine _machine;
        #endregion

        #region Properties
        public Machine Machine
        {
            get => _machine;
            set => _machine = value;
        }

        // used for listview horizontal
        public ObservableCollection<Machine> MachinesInfo { get; set; }

        public ICommand AddMachineCommand { get; set; }

        protected IMainPageViewModelService InventoryService { get; private set; }

        #region SfPopupLayout
        public ICommand OpenPopupCommand { get; set; }

        public ICommand RemoveAllMachinesCommand { get; set; }

        public bool DisplayPopup
        {
            get => _displayPopup;
            set => SetProperty(ref _displayPopup, value);
        }
        #endregion

        #endregion

        #region Constructor
        public MainPageViewModel(INavigationService navigationService, IMainPageViewModelService inventoryService)
            : base(navigationService)
        {
            Title = "Inventory";
            this.InventoryService = inventoryService;

            Machine = new Machine(); // add new
            MachinesInfo = new ObservableCollection<Machine>(); // view all existing

            Refresh();

            OpenPopupCommand = new Command(OpenPopup);
            AddMachineCommand = new Command(AddMachinePopup);
            RemoveAllMachinesCommand = new Command(RemoveAll);
        }
        #endregion

        #region Commands

        #region SfPopupLayout
        private void OpenPopup()
        {
            Machine = new Machine(); // clear
            DisplayPopup = true;
        }
        #endregion

        private void AddMachinePopup()
        {
            var machine = new Machine()
            {
                MachineName = Machine.MachineName,
                MachineCPU = Machine.MachineCPU,
                MachineGPU = Machine.MachineGPU,
                MachineHDD = Machine.MachineHDD,
                MachineRAM = Machine.MachineRAM,
                MachineType = Machine.MachineType
            };

            _ = InventoryService.Create(machine);

            this.MachinesInfo.Add(machine);
        }

        private void RemoveAll()
        {
            _ = InventoryService.DeleteAll();

            MachinesInfo.Clear();
        }

        private async void Refresh()
        {
            var t = await InventoryService.GetAll();

            MachinesInfo = t.ToObservableCollection();
        }

        #endregion
    }
}
