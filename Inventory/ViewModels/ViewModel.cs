using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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
            get { return _machine; }
            set
            {
                _machine = value;
            }
        }

        // listview horizontal
        public ObservableCollection<Machine> MachinesInfo { get; set; }

        public ICommand AddMachineCommand { get; set; }

        #region SfPopupLayout
        public ICommand OpenPopupCommand { get; set; }

        public ICommand RemoveAllMachinesCommand { get; set; }

        public bool DisplayPopup
        {
            get { return _displayPopup; }
            set
            {
                _displayPopup = value;
                RaisePropertyChanged(nameof(DisplayPopup));
            }
        }
        #endregion

        #endregion

        #region Constructor
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Inventory";

            Machine = new Machine(); // add new
            MachinesInfo = new ObservableCollection<Machine>(); // view all existing

            using (var dbContext = new InventoryContext())
            {
                MachinesInfo = dbContext.Machines.ToObservableCollection();
            }

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
            // TODO: add to database
            var _machine = new Machine()
            {
                MachineName = Machine.MachineName,
                MachineCPU = Machine.MachineCPU,
                MachineGPU = Machine.MachineGPU,
                MachineHDD = Machine.MachineHDD,
                MachineRAM = Machine.MachineRAM,
                MachineType = MachineType.PC
            };


            this.MachinesInfo.Add(_machine);

            using (var dbContext = new InventoryContext())
            {
                dbContext.Add(_machine);

                dbContext.SaveChanges();
            }
        }

        private void RemoveAll()
        {
            using (var dbContext = new InventoryContext())
            {
                dbContext.RemoveRange(dbContext.Machines);

                dbContext.SaveChanges();

                //MachinesInfo = dbContext.Machines.ToObservableCollection();
                MachinesInfo.Clear();
            }
        }

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
