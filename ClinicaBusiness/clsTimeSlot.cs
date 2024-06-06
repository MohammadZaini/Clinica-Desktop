using Clinica_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaBusiness
{
    public class clsTimeSlot
    {

        public int TimeSlotID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        private clsTimeSlot(int timeSlotID, TimeSpan startTime, TimeSpan endTime) { 
        
            TimeSlotID = timeSlotID;
            StartTime = startTime;
            EndTime = endTime;
        }

        public static DataTable GetTimeSlotsPerDoctor(int doctorID, DateTime selectedDate) {
            return clsTimeSlotData.GetAllTimeSlotsPerDoctor(doctorID, selectedDate);
        }

        public static clsTimeSlot Find(int timeSlotID) {

            TimeSpan startTime = default, endTime = default;

            if (clsTimeSlotData.GetAppointmentTimeBySlotID(timeSlotID, ref startTime, ref endTime))
                return new clsTimeSlot(timeSlotID, startTime, endTime);
            else
                return null;

        }
    }
}
