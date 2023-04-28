using DAL.Implementations.SqlServer.Adapters;
using DAL.Interfaces;
using DAL.Tools;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations.SqlServer
{
    public class ClienteSqlServerRepository : IGenericRepository<Cliente>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Cliente] (Nombre, FechaNac) VALUES (@Nombre, @FechaNac)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Cliente] SET (Nombre = @Nombre, FechaNac = @FechaNac) WHERE  IdUsuario = @IdUsuario";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Cliente] WHERE IdUsuario = @IdUsuario";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdUsuario , Nombre, FechaNac FROM [dbo].[Cliente] WHERE IdUsuario = @IdUsuario";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdUsuario , Nombre, FechaNac FROM [dbo].[Cliente]";
        }
        #endregion

        public void Add(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text,
                new System.Data.SqlClient.SqlParameter[] { }))
            {
                while (dr.Read())
                {
                    object[] campos = new object[dr.FieldCount];
                    dr.GetSqlValues(campos);

                    //Usamos el adaptor para HIDRATAR el objeto Cliente
                    clientes.Add(ClienteAdapter.Current.Adapt(campos));
                }

            }
            return clientes;
        }

        public Cliente GetById(Guid id)
        {
            Cliente cliente = null;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
              new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@IdUsuario", id) }))
            {
                if (dr.Read())
                {
                    object[] campos = new object[dr.FieldCount];
                    dr.GetSqlValues(campos);

                    //Usamos el adaptor para HIDRATAR el objeto Cliente
                    cliente = ClienteAdapter.Current.Adapt(campos);
                }
            }
            return cliente;
        }

        public void Update(Cliente obj)
        {
            throw new NotImplementedException();
        }
    }

}
