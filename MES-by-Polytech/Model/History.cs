using MES_by_Polytech.DateBase;
using MES_by_Polytech.ViewModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MES_by_Polytech.Model
{
    internal class History
    {
        public int Id { get; set; }
        public int CycleId { get; set; }
        public DateTime DateStartMade { get; set; }
        public DateTime DateEndMade { get; set;}
        public string Name { get; set; }
        public History()
        {

        }
        public bool CheckDateForRemoveData(History selectedHistory)
        {
            DateTime dateStart = Convert.ToDateTime(selectedHistory.DateStartMade);
            DateTime dateEnd = Convert.ToDateTime(selectedHistory.DateEndMade);
            return dateStart == dateEnd;
        }
        
        public int GetColorForIcon(History selectedHistory)
        {
            try
            {
                DateTime startTime = DateStartMade;
                DateTime deadline = DateEndMade;
                DateTime mediumTime = FindMedium(startTime);
                DateTime firstDot = PaintDateTimeFirst(mediumTime);
                DateTime secondDot = PaintDateTimeSecond(mediumTime);
                DateTime dateTimeNow = DateTime.Now;

                int stage = CheckForPaint(dateTimeNow, mediumTime, firstDot, secondDot, deadline);
                return stage;
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                return 0;
            }
        }
        private DateTime FindMedium(DateTime startTime)
        {
            DateTime mediumTime = startTime.AddDays(15); // Было deadline.AddDays(15), исправил на startTime.AddDays(15)
            return mediumTime;
        }

        private DateTime PaintDateTimeFirst(DateTime medium)
        {
            DateTime dotTime = medium.AddMonths(-7);
            return dotTime;
        }

        private DateTime PaintDateTimeSecond(DateTime medium)
        {
            DateTime dotTime = medium.AddDays(7);
            return dotTime;
        }

        private int CheckForPaint(DateTime dateTimeNow, DateTime mediumTime, DateTime firstDot, DateTime secondDot, DateTime deadline)
        {
          
            ObservableCollection<IconColorInfo> list;
            if (dateTimeNow >= deadline)
            {
                return 4;
            }
            else if (dateTimeNow >= secondDot)
            {
                return 3;
            }
            else if (dateTimeNow >= mediumTime)
            {
                return 2;
            }
            else if (dateTimeNow >= firstDot)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        

    }
}
