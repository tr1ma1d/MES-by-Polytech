using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES_by_Polytech.DateBase;
using Npgsql;
using System.Windows;
using System.Windows.Navigation;
namespace MES_by_Polytech.Model
{
    internal class CycleModel
    {
        private static int allCountDetailOnStorage = 10000;
       
        public int IdCycle { get; set; }
        public string Name{ get; set; }
        public int DetailCount{ get; set; }
        public string WheelsName {  get; set; }
        public string Frame { get; set; }
        private Conncet conncet;
        public CycleModel()
        {

        }
        public void BuildCycle(int id)
        {
            conncet = new Conncet();

            DateTime dateTime = DateTime.Now;
            DateTime dateTime2 = DateTime.Now.AddMonths(2);

            string dateFormat = dateTime.ToString("yyyy-MM-dd");
            string dateFromatEnd = dateTime2.ToString("yyyy-MM-dd");
            string query = $"history(cycle_id,date_made,date_end) VALUES('{id}','{dateFormat}','{dateFromatEnd}')";

            conncet.AddToDateBase(query);

            MessageBox.Show("Операция успешно прошла");
        }
       
        
        public void AddNewCycle()
        {
            try
            {
                string query = "cycle(name,detailcount,wheelsname,frame)" +
                $"VALUES('{Name}','{DetailCount}','{WheelsName}','{Frame}')";
                conncet = new Conncet();
                conncet.AddToDateBase(query);
                MessageBox.Show("Вы успешно добавили новый товар");

            }
            catch(Exception ex) 
            {
                MessageBox.Show("Неудачная попытка добавить товар");                
            }
            
           
        }



        
        
    }
}
