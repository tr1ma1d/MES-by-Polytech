using MES_by_Polytech.DateBase;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES_by_Polytech.Model
{
    internal class History
    {
        public int Id { get; set; }
        public int CycleId { get; set; }
        public DateTime DateStartMade { get; set; }
        public DateTime DateEndMade { get; set;}

       
    }
}
