using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace projectx {
    class Controller {
        public void RegisterNewPerson(string CprNr, string Name) {
            Person person = new Person(CprNr, Name);

            SqlConnection conn = new SqlConnection(DBConnectionString.Conn);

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SetPerson", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@CPRNR", person.CprNr));
                cmd.Parameters.Add(new SqlParameter("@Name", person.Name));
                cmd.ExecuteScalar();

            }
            catch (Exception e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }
        public void RegisterNewSensor(string model, string cprnr, string sensorid, DateTime batterylastchanged) {
            Sensor sensor = new Sensor(model, cprnr, sensorid, batterylastchanged);

            SqlConnection conn = new SqlConnection(DBConnectionString.Conn);

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SetSensor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@Model", sensor.Model));
                cmd.Parameters.Add(new SqlParameter("@CPRNR", sensor.CprNr));
                cmd.Parameters.Add(new SqlParameter("@SensorID", sensor.Id));
                cmd.Parameters.Add(new SqlParameter("@BatteryLastChanged", sensor.BatteryLastChanged));
                cmd.ExecuteScalar();

            }
            catch (Exception e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }
        public List<Sensor> GetSensors() {
            SqlConnection conn = new SqlConnection(DBConnectionString.Conn);
            List<Sensor> sensors = new List<Sensor>();

            try {
                conn.Open();

                SqlCommand cmd = new SqlCommand("GetSensorFromModel", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@Model", ""));
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read()) {
                    sensors.Add(new Sensor(reader["S_SensorID"].ToString(), reader["S_P_CPRNR"].ToString(), reader["S_Model"].ToString(), Convert.ToDateTime(reader["S_BatteryLastChanged"].ToString())));
                }
                reader.Close();
            }
            catch (SqlException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return sensors;
        }        
    }
}
