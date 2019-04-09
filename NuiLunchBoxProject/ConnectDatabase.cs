using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace NuiLunchBoxProject
{
    public class ConnectDatabase
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionNuiLunchboxDB"].ConnectionString;
        SqlConnection connection;

        public Boolean AddNewGridView(string userid, string passwd, string name, string email, string mobile)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO tblCustomer_Info values('" +
                userid + "', '" +
                passwd + " ', ' " +
                name + " ', ' " +
                email + " ', ' " +
                mobile + "')";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean SaveUserInformation(string userID, string userPassword, string userName, string Email, string Mobile)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO tblCustomer_Info values('" +
                userID + "', '" +
                userPassword + " ', ' " +
                userName + " ', ' " +
                Email + " ', ' " +
                Mobile + "')";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean ModifyUserInformation(string userID, string userPassword, string userName, string Email, string Mobile)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "UPDATE tblCustomer_Info SET User_Passwd='" + userPassword + "',User_Name='" + userName + " ',User_Email='" + Email + " ',User_Mobile='" + Mobile + "' WHERE User_ID='" + userID + "'";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean ModifyMenuInformation(int groupnum, string menuname, string menuprice, string imagepath, string menudescription)
        {
            string query;
            connection = new SqlConnection(connectionString);
            connection.Open();

            switch (groupnum)
            {
                case 1:
                    query = "UPDATE tblSalad SET Menu_Name='" + menuname + "',Menu_Price='" + menuprice + " ',Image_Path='" + imagepath + " ',Menu_Description='" + menudescription + "' WHERE Menu_Name='" + menuname + "'";
                    break;
                case 2:
                    query = "UPDATE tblRiceRoll SET Menu_Name='" + menuname + "',Menu_Price='" + menuprice + " ',Image_Path='" + imagepath + " ',Menu_Description='" + menudescription + "' WHERE Menu_Name='" + menuname + "'";
                    break;
                case 3:
                    query = "UPDATE tblFullPackage SET Menu_Name='" + menuname + "',Menu_Price='" + menuprice + " ',Image_Path='" + imagepath + " ',Menu_Description='" + menudescription + "' WHERE Menu_Name='" + menuname + "'";
                    break;
                case 4:
                    query = "UPDATE tblRice SET Menu_Name='" + menuname + "',Menu_Price='" + menuprice + " ',Image_Path='" + imagepath + " ',Menu_Description='" + menudescription + "' WHERE Menu_Name='" + menuname + "'";
                    break;
                case 5:
                    query = "UPDATE tblSideDish SET Menu_Name='" + menuname + "',Menu_Price='" + menuprice + " ',Image_Path='" + imagepath + " ',Menu_Description='" + menudescription + "' WHERE Menu_Name='" + menuname + "'";
                    break;
                case 6:
                    query = "UPDATE tblSandwich SET Menu_Name='" + menuname + "',Menu_Price='" + menuprice + " ',Image_Path='" + imagepath + " ',Menu_Description='" + menudescription + "' WHERE Menu_Name='" + menuname + "'";
                    break;
                default:
                    query = "";
                    break;
            }
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean CheckUserID(string userID)
        {
            int temp = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM tblCustomer_Info WHERE User_ID='" + userID + "'";
            SqlCommand command;

            try
            {
                command = new SqlCommand(query, connection);
                var firstColumn = command.ExecuteScalar();
                if (firstColumn != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean CheckSubDisplayMenuImage(int groupno, string imagename,string path)
        {
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query;
  
            switch (groupno)
            {
                case 1:
                    query = "SELECT * FROM tblSalad WHERE Menu_Name='" + imagename + "' OR Image_Path = '" + path + "'";
                    break;
                case 2:
                    query = "SELECT * FROM tblRiceRoll WHERE Menu_Name='" + imagename + "' OR Image_Path = '" + path + "'";
                    break;
                case 3:
                    query = "SELECT * FROM tblFullPackage WHERE Menu_Name='" + imagename + "' OR Image_Path = '" + path + "'";
                    break;
                case 4:
                    query = "SELECT * FROM tblRice WHERE Menu_Name='" + imagename + "' OR Image_Path = '" + path + "'";
                    break;
                case 5:
                    query = "SELECT * FROM tblSideDish WHERE Menu_Name='" + imagename + "' OR Image_Path = '" + path + "'";
                    break;
                case 6:
                    query = "SELECT * FROM tblSandwich WHERE Menu_Name='" + imagename + "' OR Image_Path = '" + path + "'";
                    break;
                default:
                    query = "";
                    break;
            }
            try
            {
                command = new SqlCommand(query, connection);
                var firstColumn = command.ExecuteScalar();
                if(firstColumn != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean CheckMainDisplayMenuImage(string imagename, string path)
        {
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM tblDisplayMenu WHERE Menu_Name='" + imagename + "' OR Image_Path='" + path + "'";

            try
            {
                command = new SqlCommand(query, connection);
                var firstColumn = command.ExecuteScalar();
                if (firstColumn != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean CheckCartMenuImage(string imagename)
        {
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM tblCartMenu WHERE Menu_Name='" + imagename + "'";

            try
            {
                command = new SqlCommand(query, connection);
                var firstColumn = command.ExecuteScalar();
                if (firstColumn != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean CheckOrderMenuImage(string imagename)
        {
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM tblOrder WHERE Menu_Name='" + imagename + "'";

            try
            {
                command = new SqlCommand(query, connection);
                var firstColumn = command.ExecuteScalar();
                if (firstColumn != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean CheckUser_Passwd(string passwd)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM tblCustomer_Info WHERE User_Passwd='" + passwd + "'";
            SqlCommand command;
            try
            {
                command = new SqlCommand(query, connection);
                var firstColumn = command.ExecuteScalar();
                if (firstColumn != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean SaveMainDisplayMenu(string groupnum, string MenuName, string imagepath)
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "INSERT INTO tblDisplayMenu VALUES('" + MenuName + "','" + groupnum + "','" + imagepath + "')";
            try
            {
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean SaveCartMenu(string groupnum, string MenuName, string imagepath,string count,string price)
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "INSERT INTO tblCartMenu VALUES('" + MenuName + "','" + groupnum + "','" + imagepath + "','" + count + "','" + price + "')";
            try
            {
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean SaveSubDisplayMenu(string groupnum, string MenuName, string MenuPrice, string ImagePath, string description)
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            int gnum = Convert.ToInt32(groupnum);
            switch (gnum)
            {
                case 1:
                    query = "INSERT INTO tblSalad VALUES('" + MenuName + "','" + MenuPrice + "','" + ImagePath + "','" + description + "')";
                    break;
                case 2:
                    query = "INSERT INTO tblRiceRoll VALUES('" + MenuName + "','" + MenuPrice + "','" + ImagePath + "','" + description + "')";
                    break;
                case 3:
                    query = "INSERT INTO tblFullPackage VALUES('" + MenuName + "','" + MenuPrice + "','" + ImagePath + "','" + description + "')";
                    break;
                case 4:
                    query = "INSERT INTO tblRice VALUES('" + MenuName + "','" + MenuPrice + "','" + ImagePath + "','" + description + "')";
                    break;
                case 5:
                    query = "INSERT INTO tblSideDish VALUES('" + MenuName + "','" + MenuPrice + "','" + ImagePath + "','" + description + "')";
                    break;
                case 6:
                    query = "INSERT INTO tblSandwich VALUES('" + MenuName + "','" + MenuPrice + "','" + ImagePath + "','" + description + "')";
                    break;
                default:
                    query = "";
                    break;
            }
            try
            {
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public SqlDataReader GetMainDisplaytMenu()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select Menu_Name, Menu_Group,Image_Path from tblDisplayMenu";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int GetDisplayItemCount()
        {
            int count = 0;
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select count(1) from tblDisplayMenu";
            try
            {
                using (SqlCommand cmdCount = new SqlCommand(query, connection))
                {
                     count = (int)cmdCount.ExecuteScalar();
                }
                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public SqlDataReader GetUserImformation(string userid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "select User_ID, User_Passwd,User_Name, User_Email,User_Mobile from tblCustomer_Info where User_ID='"+ userid+"'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetUserImformation()
        {
            string query;
            SqlCommand cmd;

            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "select User_ID, User_Passwd,User_Name, User_Email,User_Mobile from tblCustomer_Info";
            cmd = new SqlCommand();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable GetViewMenuTableFromDB(int GroupNo)
        {
            string query;

            connection = new SqlConnection(connectionString);
            connection.Open();

            switch (GroupNo)
            {
                case 1:
                    query = "SELECT Menu_Name,Image_Path FROM tblSalad";
                    break;
                case 2:
                    query = "SELECT Menu_Name,Image_Path FROM tblRiceRoll";
                    break;
                case 3:
                    query = "SELECT Menu_Name,Image_Path FROM tblFullPackage";
                    break;
                case 4:
                    query = "SELECT Menu_Name,Image_Path FROM tblRice";
                    break;
                case 5:
                    query = "SELECT Menu_Name,Image_Path FROM tblSideDish";
                    break;
                case 6:
                    query = "SELECT Menu_Name,Image_Path FROM tblSandwich";
                    break;
                default:
                    query = "";
                    break;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable GetViewNoImageMenuTableFromDB()
        {
            string query;
            SqlCommand cmd;

            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "SELECT Menu_Name,Menu_Group,Image_Path FROM tblNoImage";
            cmd = new SqlCommand();

            cmd.CommandText = query;
            cmd.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable GetViewDisplayMenuTableFromDB()
        {
            string query;
            SqlCommand cmd;

            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "SELECT Menu_Name,Menu_Group,Image_Path FROM tblDisplayMenu";
            cmd = new SqlCommand();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable GetViewCartMenuTableFromDB()
        {
            string query;
            SqlCommand cmd;

            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "SELECT Menu_Name,Image_Path,Menu_Count,Menu_Price FROM tblCartMenu";
            cmd = new SqlCommand();

            cmd.CommandText = query;
            cmd.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable GetViewOrderMenuTableFromDB()
        {
            string query;
            SqlCommand cmd;

            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "SELECT User_ID,Menu_Name,Menu_Count,Menu_Time FROM tblOrder";
            cmd = new SqlCommand();

            cmd.CommandText = query;
            cmd.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public SqlDataReader GetMenuTableFromDB(int GroupNo)
        {
            string query;

            connection = new SqlConnection(connectionString);
            connection.Open();

            switch (GroupNo)
            {
                case 1:
                    query = "SELECT Menu_Name, Image_Path FROM tblSalad";
                    break;
                case 2:
                    query = "SELECT Menu_Name, Image_Path FROM tblRiceRoll";
                    break;
                case 3:
                    query = "SELECT Menu_Name, Image_Path FROM tblFullPackage";
                    break;
                case 4:
                    query = "SELECT Menu_Name, Image_Path FROM tblRice";
                    break;
                case 5:
                    query = "SELECT Menu_Name, Image_Path FROM tblSideDish";
                    break;
                case 6:
                    query = "SELECT Menu_Name, Image_Path FROM tblSandwich";
                    break;
                default:
                    query = "";
                    break;
            }
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataReader GetAllMenuTableFromDB(int GroupNo)
        {
            string query;
            int num = 0;

            connection = new SqlConnection(connectionString);
            connection.Open();

            switch (GroupNo)
            {
                case 1:
                    query = "SELECT Menu_Name, Menu_Price, Image_Path, Menu_Description FROM tblSalad";
                    break;
                case 2:
                    query = "SELECT Menu_Name ,Menu_Price, Image_Path ,Menu_Description FROM tblRiceRoll";
                    break;
                case 3:
                    query = "SELECT Menu_Name, Menu_Price, Image_Path, Menu_Description FROM tblFullPackage";
                    break;
                case 4:
                    query = "SELECT Menu_Name, Menu_Price, Image_Path, Menu_Description FROM tblRice";
                    break;
                case 5:
                    query = "SELECT Menu_Name, Menu_Price, Image_Path, Menu_Description FROM tblSideDish";
                    break;
                case 6:
                    query = "SELECT Menu_Name,Menu_Price, Image_Path , Menu_Description FROM tblSandwich";
                    break;
                default:
                    query = "";
                    break;
            }
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
         }
        public SqlDataReader GetAllMenuTableFromDB(int GroupNo, string MenuName)
        {
            string query;
            int num = 0;
            SqlCommand command;
            SqlDataReader reader = null;

            connection = new SqlConnection(connectionString);
            connection.Open();

            switch (GroupNo)
            {
                case 1:
                    query = "SELECT Menu_Name, Menu_Price, Image_Path, Menu_Description FROM tblSalad WHERE Menu_Name='"+MenuName+"'";
                    break;
                case 2:
                    query = "SELECT Menu_Name ,Menu_Price, Image_Path ,Menu_Description FROM tblRiceRoll WHERE Menu_Name='" + MenuName + "'";
                    break;
                case 3:
                    query = "SELECT Menu_Name, Menu_Price, Image_Path, Menu_Description FROM tblFullPackage WHERE Menu_Name='" + MenuName + "'";
                    break;
                case 4:
                    query = "SELECT Menu_Name, Menu_Price, Image_Path, Menu_Description FROM tblRice WHERE Menu_Name='" + MenuName + "'";
                    break;
                case 5:
                    query = "SELECT Menu_Name, Menu_Price, Image_Path, Menu_Description FROM tblSideDish WHERE Menu_Name='" + MenuName + "'";
                    break;
                case 6:
                    query = "SELECT Menu_Name,Menu_Price, Image_Path , Menu_Description FROM tblSandwich WHERE Menu_Name='" + MenuName + "'";
                    break;
                default:
                    query = "";
                    break;
            }

            if (query != "")
            {
                command = new SqlCommand(query, connection);
                try
                {
                    reader = command.ExecuteReader();
                    return reader;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return reader;
        }
        public Boolean SaveCartMenuToOrder(string userid,string menuname, string count, string time)
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "INSERT INTO tblOrder VALUES('"+ userid+"','" + menuname + "','" + count + "','" + time + "')";
            command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean SaveSelectedMainDisplayMenu(string num, string name)
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "INSERT INTO tblSelectMenu VALUES('" + name + "','" + num + "')";
            command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean DeleteAllSelectedTable()
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "DELETE tblSelectMenu";
            command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean DeleteSelectedMainDisplayMenu(string name)
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "DELETE FROM tblSelectMenu WHERE Menu_Name = '"+name+"'";
            command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public SqlDataReader GetSelectMenu()
        {
            string query;
            SqlCommand command;
            SqlDataReader reader = null;

            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "select Menu_Name,Menu_Group from tblSelectMenu";
            command = new SqlCommand(query, connection);
  
            try
            {
                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void DeleteMainDisplayMenu(int group,string name)
        {
            string query;
   
            query = "DELETE FROM tblDisplayMenu WHERE Menu_Name='" + name + "'";
            DeleteItemFromTable(query);

            switch (group)
            {
                case 1:
                    query = "DELETE FROM tblSalad WHERE Menu_Name ='" + name + "'";
                    break;
                case 2:
                    query = "DELETE FROM tblRiceRoll WHERE Menu_Name = '" + name + "'";
                    break;
                case 3:
                    query = "DELETE FROM tblFullPackage WHERE Menu_Name = '" + name + "'";
                    break;
                case 4:
                    query = "DELETE FROM tblRice WHERE Menu_Name = '" + name + "'";
                    break;
                case 5:
                    query = "DELETE FROM tblSideDish WHERE Menu_Name = '" + name + "'";
                    break;
                case 6:
                    query = "DELETE FROM tblSandwich WHERE Menu_Name = '" + name + "'";
                    break;
                default:
                    query = "";
                    break;
            }
            DeleteItemFromTable(query);
            
            query = "DELETE tblSelectMenu";
            DeleteItemFromTable(query);
        }
        public Boolean DeleteCartMenu(string menuname)
        {
            string query, MenuName, GroupNo;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "DELETE FROM tblCartMenu WHERE Menu_Name='" + menuname + "'";
            command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean DeleteItemFromTable(string query)
        {
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean DeleteOneItemFromTable(int groupnum,string menuname)
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            switch (groupnum)
            {
                case 1:
                    query = "DELETE FROM tblSalad WHERE Menu_Name = '"+menuname+"'";
                    break;
                case 2:
                    query = "DELETE FROM tblRiceRoll WHERE Menu_Name = '" + menuname + "'";
                    break;
                case 3:
                    query = "DELETE FROM tblFullPackage WHERE Menu_Name = '" + menuname + "'";
                    break;
                case 4:
                    query = "DELETE FROM tblRice WHERE Menu_Name = '" + menuname + "'";
                    break;
                case 5:
                    query = "DELETE FROM tblSideDish WHERE Menu_Name = '" + menuname + "'";
                    break;
                case 6:
                    query = "DELETE FROM tblSandwich WHERE Menu_Name = '" + menuname + "'";
                    break;
                default:
                    query = "";
                    break;
            }
            command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public Boolean UpdateCustomer_Info(string id, string passwd, string name, string email, string mobile)
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "UPDATE tblCustomer_Info SET User_ID = '" + id+"', User_Passwd = '"+passwd+"',User_Name='"+name+"',User_Email='"+ email + "',User_Mobile='"+ mobile + "' WHERE User_ID = '"+id+"'";
            command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
        }
        public Boolean DeleteRowGridview(string id)
        {
            string query;
            SqlCommand command;
            connection = new SqlConnection(connectionString);
            connection.Open();

            query = "DELETE FROM tblCustomer_Info WHERE User_ID = '" + id + "'";
            command = new SqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
        }
     }
}