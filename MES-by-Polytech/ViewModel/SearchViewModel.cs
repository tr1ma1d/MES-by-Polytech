using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using MES_by_Polytech.DateBase;
using MES_by_Polytech.Model;
using Npgsql;
using Prism.Commands;
using Prism.Mvvm;

namespace MES_by_Polytech.ViewModel
{
    internal class SearchViewModel : BindableBase
    {

        private Conncet conncet;
        private History _history;
        private History _selectedHistory;
        private ObservableCollection<History> _histories;
    
        
        public ObservableCollection<History> Histories
        {
            get { return _histories; }
            set { SetProperty(ref _histories, value); }
        }
        public History SelectedHistory
        {
            get { return _selectedHistory; }
            set {
                if (SetProperty(ref _selectedHistory, value))
                {
                    UpdateIconColors(); // Вызываем метод для обновления цветов иконок
                }
            }
        }
        private ObservableCollection<IconColorInfo> _iconColors;
        public ObservableCollection<IconColorInfo> IconColors
        {
            get { return _iconColors; }
            set { SetProperty(ref _iconColors, value); }
        }


        public DelegateCommand Submit { get; }
      
        public SearchViewModel()
        {
          
            UpdateDataGrid();
            Submit = new DelegateCommand(SuccessForDeleteForDateBase);
        }
        private void UpdateDataGrid()
        {
            List<History> historyList = GetHistoryList();
            Histories = new ObservableCollection<History>(historyList);
        }
        private void UpdateIconColors()
        {
            if (SelectedHistory != null)
            {
                History history = new History();
                int value = history.GetColorForIcon(_selectedHistory);
                switch (value)
                {
                    case 0:
                        IconColors = new ObservableCollection<IconColorInfo> 
                        {
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                        };
                        break;
                    case 1:
                        IconColors = new ObservableCollection<IconColorInfo>
                        {
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                        };
                        break;
                    case 2:
                        IconColors = new ObservableCollection<IconColorInfo>
                        {
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                        };
                        break;
                    case 3:
                        IconColors = new ObservableCollection<IconColorInfo>
                        {
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.Black},
                        };
                        break;
                    case 4:
                        IconColors = new ObservableCollection<IconColorInfo>
                        {
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                            new IconColorInfo{Color = Brushes.DarkBlue},
                        };
                        break;
                    default:
                        IconColors = new ObservableCollection<IconColorInfo>
                        {
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                            new IconColorInfo{Color = Brushes.Black},
                        };
                        break;
                }
            }
        }

        private void SuccessForDeleteForDateBase()
        {
            if(_selectedHistory != null)
            {
                History history = new History();
                bool value = history.CheckDateForRemoveData(_selectedHistory);
                if(value == true)
                {
                    string query = $"history WHERE id = {_selectedHistory.Id}";
                    conncet.DeletedData(query);
                    UpdateDataGrid();
                }
                else
                {
                    MessageBox.Show("Велосипеды не были доставлены");
                }
            }
            
        }
        public List<History> GetHistoryList()
        {

            conncet = new Conncet();

            List<History> historLists = new List<History>();
            string query = "FROM history INNER JOIN cycle ON history.cycle_id = cycle.id";
            NpgsqlDataReader reader = conncet.CheckInDateBase(query);
            while (reader.Read())
            {
                History history = new History();
                history.Id = Convert.ToInt32(reader["id"]);
                history.CycleId = Convert.ToInt32(reader["cycle_id"]);
                history.DateStartMade = Convert.ToDateTime(reader["date_made"]);
                history.DateEndMade = Convert.ToDateTime(reader["date_end"]);
                history.Name = reader["name"].ToString();
                historLists.Add(history);
            }
            conncet.ConncetToDateBaseClosePublic();
            return historLists;
        }
       

    }
}
