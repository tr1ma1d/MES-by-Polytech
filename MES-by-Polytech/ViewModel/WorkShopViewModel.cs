using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES_by_Polytech.DateBase;
using System.Windows.Controls;
using System.Xml.Linq;
using MES_by_Polytech.Model;
using Npgsql;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Media;
namespace MES_by_Polytech.ViewModel
{
    internal class WorkShopViewModel : BindableBase
    {
        private static int firstIndex = 13;
        private static int secondIndex = 14;
        private static int thirdIndex = 15;
        private ObservableCollection<CycleModel> _bicycles;
        public ObservableCollection<CycleModel> Bicycles
        {
            get { return _bicycles; }
            set { SetProperty(ref _bicycles, value); }
        }

        public DelegateCommand BuildOneButton { get; }
        public DelegateCommand BuildTwoButton { get; }
        public DelegateCommand OpenNextDoor { get; }
        public DelegateCommand OpenPastDoor { get; }
        public DelegateCommand BuildThreeButton { get; }
        private CycleModel _cycleModel;

        public WorkShopViewModel()
        {
            BuildOneButton = new DelegateCommand(MakeFirstCycle);
            BuildTwoButton = new DelegateCommand(MakeSecondCycle);
            BuildThreeButton = new DelegateCommand(MakeThirdCycle);
            OpenPastDoor = new DelegateCommand(PastList);
            OpenNextDoor = new DelegateCommand(NextList);
            LoadBicyclesFromDatabase();

        }
        public void GetDateAlgoritms(History selectedHistory)
        {
            
            
        }
        private void LoadBicyclesFromDatabase()
        {
            Conncet conncet = new Conncet();
            NpgsqlDataReader reader = conncet.LoadCycleFromDateBase(firstIndex, secondIndex, thirdIndex);

            Bicycles = new ObservableCollection<CycleModel>(); // Создаем новую коллекцию перед загрузкой данных из базы

            while (reader.Read())
            {
                // Создаем новый объект CycleModel для каждой строки из базы данных
                CycleModel cycle = new CycleModel
                {
                    IdCycle = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    DetailCount = Convert.ToInt32(reader["detailCount"]),
                    WheelsName = reader["wheelsName"].ToString(),
                    Frame = reader["frame"].ToString()
                };

                // Добавляем созданный объект в коллекцию Bicycles
                Bicycles.Add(cycle);
                
            }
            conncet.ConncetToDateBaseClosePublic();

        }
        
        private void MakeFirstCycle()
        {
            int id = _bicycles[0].IdCycle;
            _cycleModel = new CycleModel();
            _cycleModel.BuildCycle(id);
        }
        private void MakeSecondCycle()
        {
            int id = _bicycles[1].IdCycle;
            _cycleModel = new CycleModel();
            _cycleModel.BuildCycle(id);
        }
        private void MakeThirdCycle() 
        {
            int id = _bicycles[2].IdCycle;
            _cycleModel = new CycleModel();
            _cycleModel.BuildCycle(id);
        }
        private void NextList()
        {
            firstIndex += 1;
            secondIndex += 1;
            thirdIndex += 1;
            LoadBicyclesFromDatabase();
        }
        private void PastList()
        {
            firstIndex -= 1;
            secondIndex -= 1;
            thirdIndex -= 1;
            LoadBicyclesFromDatabase();
        }

        
    }
}


