using Dapper;
using DapperRepoWinForm.ClassObjects;
using DapperRepoWinForm.Repository;
using DapperRepoWinForm.Utilities;
using System.Collections.Generic;

namespace DapperRepoWinForm.Bll
{
    partial class UsersBll
    {
        public string Insert(Users _users)
        {
            RepGen reposGen = new RepGen();
            DynamicParameters param = new DynamicParameters();

            param.Add("@id", _users.id);
            param.Add("@name", _users.name);
            param.Add("@address", _users.address);
            param.Add("@status", _users.status);

            //executa a Stored Procedure
            return reposGen.executeNonQuery("users_Insert_Update", param);
        }

        public string delete(Users _users)
        {
            RepGen reposGen = new Repository.RepGen();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", _users.id);

            //executa a Stored Procedure
            return reposGen.executeNonQuery("users_DeleteRow_By_id", param);
        }

        public List<Users> allRecords(Users _usuario)
        {
            RepList<Users> lista = new RepList<Users>();
            DynamicParameters param = new DynamicParameters();

            //executa a Stored Procedure
            return lista.returnListClass("users_SelectAll", param);
        }

        public List<Users> AllRecordsById(string id)
        {
            RepList<Users> lista = new RepList<Users>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            return lista.returnListClass("users_SelectRow_By_id", param);
        }

        public Users findById(string id)
        {
            RepList<Users> class_usu = new RepList<Users>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return class_usu.returnClass("users_SelectRow_By_id", param);
        }

        public List<dynamic> dynamicsList()
        {
            Funciones FG = new Funciones();
            DynamicParameters param = new DynamicParameters();
            RepList<dynamic> repo = new RepList<dynamic>();
            var items = repo.returnListClass("users_SelectwithDate", param);
            return items;
        }

    }
}
