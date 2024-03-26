using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES_by_Polytech.Model;
using Prism.Commands;
using Prism.Mvvm;
namespace MES_by_Polytech.ViewModel
{
    internal class StorageViewModel : BindableBase
    {
        private string nameCycle;
        private int detailCount;
        private string wheelsName;
        private string frame;

        public string NameCycle
        {
            get { return nameCycle; }
            set { SetProperty(ref nameCycle, value); }
        }
        public int DetailCount
        {
            get { return detailCount; }
            set { SetProperty(ref detailCount, value); }
        }
        public string WheelsName
        {
            get { return wheelsName; }
            set { SetProperty<string>(ref wheelsName, value); }
        }
        public string Frame
        {
            get { return frame; }
            set { SetProperty(ref frame, value);}
        }

        public DelegateCommand AddCycle { get; }
        public StorageViewModel()
        {
            AddCycle = new DelegateCommand(AddingNewCycle);
        }
        private void AddingNewCycle()
        {
            CycleModel cycleModel = new CycleModel() { 
                Name = nameCycle,
                DetailCount = detailCount,
                WheelsName = wheelsName,
                Frame = frame,
            };
            cycleModel.AddNewCycle();
            
        }
    }
}
