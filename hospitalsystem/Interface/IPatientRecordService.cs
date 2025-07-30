using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    public interface IPatientRecordService
    {
        void AddRecord(PatientRecord record);
        List<PatientRecord> GetAllRecords();
        PatientRecord? GetRecordById(int id);
        List<PatientRecord> GetRecordsByPatientId(int patientId);
    }
}
