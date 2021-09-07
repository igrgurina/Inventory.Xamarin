using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Inventory.Enumerations;

namespace Inventory.Models
{
    public class Machine : INotifyPropertyChanged
    {

        #region Fields
        private string _machineName, _machineCpu, _machineGpu, _machineHdd, _machineRam;
        private MachineType _machineType;
        #endregion

        #region Properties
        public int MachineId { get; set; }

        public string MachineName
        {
            get { return _machineName; }
            set
            {
                _machineName = value;
                RaisePropertyChanged(nameof(MachineName));
            }
        }

        public MachineType MachineType
        {
            get { return _machineType; }
            set
            {
                _machineType = value;
                RaisePropertyChanged(nameof(MachineType));
            }
        }

        public string MachineCPU
        {
            get { return _machineCpu; }
            set
            {
                _machineCpu = value;
                RaisePropertyChanged(nameof(MachineCPU));
            }
        }

        public string MachineGPU
        {
            get { return _machineGpu; }
            set
            {
                _machineGpu = value;
                RaisePropertyChanged(nameof(MachineGPU));
            }
        }

        public string MachineHDD
        {
            get { return _machineHdd; }
            set
            {
                _machineHdd = value;
                RaisePropertyChanged(nameof(MachineHDD));
            }
        }

        public string MachineRAM
        {
            get { return _machineRam; }
            set
            {
                _machineRam = value;
                RaisePropertyChanged(nameof(MachineRAM));
            }
        }

        #endregion

        #region Constructor
        public Machine()
        {

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
