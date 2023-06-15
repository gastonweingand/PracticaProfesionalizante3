using DAL.Tools;
using Services.DAL.Implementations.SqlServer.Adapters;
using Services.DAL.Interfaces;
using Services.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SqlServer
{

    internal sealed class PatenteRepository : IGenericRepository<Patente>
    {
        #region Singleton
        private readonly static PatenteRepository _instance = new PatenteRepository();

        public static PatenteRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private PatenteRepository()
        {
            //Implement here the initialization code
        }


        #endregion


        #region Statements
        private string InsertStatement
        {
            get => "Patente_Insert";
        }

        private string UpdateStatement
        {
            get => "Patente_Update";
        }

        private string DeleteStatement
        {
            get => "Patente_Delete";
        }

        private string SelectOneStatement
        {
            get => "Patente_Select";
        }

        private string SelectAllStatement
        {
            get => "Patente_SelectAll";
        }
        #endregion


        public void Add(Patente obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Patente obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Patente> GetAll()
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter[] { }))
            {
                while (dr.Read())
                {
                    object[] campos = new object[dr.FieldCount];
                    dr.GetSqlValues(campos);

                    //Usamos el adaptor para HIDRATAR el objeto Patente
                    patentes.Add(PatenteAdapter.Current.Adapt(campos));
                }

            }
            return patentes;
        }

        public Patente GetById(Guid id)
        {
            Patente patente = null;

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.StoredProcedure,
              new System.Data.SqlClient.SqlParameter[] { new SqlParameter("@IdPatente", id) }))
            {
                if (dr.Read())
                {
                    object[] campos = new object[dr.FieldCount];
                    dr.GetSqlValues(campos);

                    //Usamos el adaptor para HIDRATAR el objeto Cliente
                    patente = PatenteAdapter.Current.Adapt(campos);
                }
            }
            return patente;
        }
    }

}
