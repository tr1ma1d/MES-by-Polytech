using MES_by_Polytech.DateBase;
using MES_by_Polytech.Model;
using Npgsql;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MES_by_Polytech.ViewModel
{
    internal class HistoryViewModel : BindableBase
    {
        private Conncet conncet;
        private History _history;
        private ObservableCollection<History> _histories;
        public ObservableCollection<History> Histories { 
            get { return _histories; }
            set { SetProperty(ref _histories, value); }
        }
        public HistoryViewModel()
        {
            List<History> historyList = GetHistoryList();
          

            Histories = new ObservableCollection<History>(historyList);
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
                
                historLists.Add(history);
            }
            conncet.ConncetToDateBaseClosePublic();
            return historLists;
        }

    }
}
