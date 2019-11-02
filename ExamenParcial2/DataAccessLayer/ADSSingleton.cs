using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Proxy.Models;
using DataAccessLayer;
using System.Data;
namespace DataAccessLayer
{
    public class ADSSingleton
    {
        private readonly SqlClient _client;
        private static ADSSingleton _instance;

        private ADSSingleton(string connectionString)
        {
            _client = new SqlClient(connectionString);
        }

        public static ADSSingleton GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new ADSSingleton(connectionString);
            }
            return _instance;
        }

        public List<Lista> GetCity(string nombre)
        {
            var result = new List<Lista>();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "getcity",
                        CommandType = CommandType.StoredProcedure
                    };
                    var par1 = new SqlParameter("@nombre", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = nombre
                    };
                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var ciudad = new Lista
                        {
                            id = Convert.ToInt32(dataReader["idciudad"].ToString()),
                            name = dataReader["nombre"].ToString(),
                            country = dataReader["pais"].ToString(),
                            timezone = Convert.ToInt32(dataReader["tiempohorario"].ToString()),
                            sunrise = Convert.ToInt32(dataReader["amanecer"].ToString()),
                            sunset = Convert.ToInt32(dataReader["anochecer"].ToString()),
                            temp = Convert.ToDouble(dataReader["temperatura"].ToString()),
                            temp_max = Convert.ToDouble(dataReader["temperaturamax"].ToString()),
                            temp_min = Convert.ToDouble(dataReader["temperaturamin"].ToString()),
                        };
                        result.Add(ciudad);
                    }
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool AddCity(Lista ciudad)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "addcity",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@name", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ciudad.name
                    };

                    var par2 = new SqlParameter("@pais", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ciudad.country
                    };

                    var par3 = new SqlParameter("@tiempohorario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ciudad.timezone
                    };

                    var par4 = new SqlParameter("@amancer", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ciudad.sunrise
                    };
                    var par5 = new SqlParameter("@anochecer", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ciudad.sunset
                    };
                    var par6 = new SqlParameter("@temperatura", SqlDbType.Float)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ciudad.temp
                    };

                    var par7 = new SqlParameter("@temperaturamax", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ciudad.temp_max
                    };
                    var par8 = new SqlParameter("@temperaturamin", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ciudad.temp_min
                    };

                    var par9 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par4);
                    command.Parameters.Add(par5);
                    command.Parameters.Add(par6);
                    command.Parameters.Add(par7);
                    command.Parameters.Add(par8);
                    command.Parameters.Add(par9);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());


                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool DeleteCity(string nombre)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "deletecity",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@nombre", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = nombre
                    };

                    var par5 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par5);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());


                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }
        public Lista UnaCiudad(string nombre)
        {
            var result = new Lista();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "unaciudad",
                        CommandType = CommandType.StoredProcedure
                    };
                    var par1 = new SqlParameter("@nombre", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = nombre
                    };
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var ciudad = new Lista
                        {
                            id = Convert.ToInt32(dataReader["idciudad"].ToString()),
                            name = dataReader["nombre"].ToString(),
                            country = dataReader["pais"].ToString(),
                            timezone = Convert.ToInt32(dataReader["tiempohorario"].ToString()),
                            sunrise = Convert.ToInt32(dataReader["amanecer"].ToString()),
                            sunset = Convert.ToInt32(dataReader["anochecer"].ToString()),
                            temp = Convert.ToDouble(dataReader["temperatura"].ToString()),
                            temp_max = Convert.ToDouble(dataReader["temperaturamax"].ToString()),
                            temp_min = Convert.ToDouble(dataReader["temperaturamin"].ToString()),
                        };
                        result = ciudad;
                    }
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool ValidarUsuario(string usuario, string contraseña)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "validarusuario",
                        CommandType = CommandType.StoredProcedure
                    };
                    var par1 = new SqlParameter("@usuario", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = usuario
                    };
                    var par2 = new SqlParameter("@contraseña", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = contraseña
                    };

                    var par5 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par5);

                    command.ExecuteNonQuery();
                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                _client.Close();
            }

            return result;
        }
        public bool RegistrarUsuario(Perfil perfil)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "registrarusuario",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@usuario", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = perfil.usuario
                    };

                    var par2 = new SqlParameter("@contraseña", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = perfil.contraseña
                    };

                    var par9 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par9);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());


                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }
    }
}
